using ContaBancaria.Controllers;
using ContaBancaria.Models;
using ContaBancaria.Models.Enums;
using ContaBancaria.Utils;
using System.ComponentModel.DataAnnotations;

namespace ContaBancaria.Menu
{
    class Menu
    {
        private readonly ContaController contaController = new ContaController();
        public void Executar()
        {
            int opcao = -1;
            do
            {
                Cores.Linha();
                Cores.Titulo("     SISTEMA CONTA BANCÁRIA      ");
                Cores.Linha();
                Cores.Menu("1. Buscar Conta");
                Cores.Menu("2. Listar Contas");
                Cores.Menu("3. Criar Conta");
                Cores.Menu("4. Atualizar Conta");
                Cores.Menu("5. Deletar Conta");
                Cores.Menu("6. Sacar");
                Cores.Menu("7. Depositar");
                Cores.Menu("8. Transferir");
                Cores.Menu("0. Sair");

                Cores.Linha();
                Cores.Opcao("\nEscolha uma opção: ");
                Console.ForegroundColor = ConsoleColor.White;
                string? op = Console.ReadLine();
                if (op == null || !int.TryParse(op, out opcao))
                {
                    Cores.Erro("\nOpção inválida, tente novamente\n");
                    Console.WriteLine();
                    Cores.Input("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.ResetColor();

                switch (opcao)
                {
                    case 1:
                        BuscarPorAgenciaENumero();
                        break;
                    case 2:
                        ListarContas();
                        break;
                    case 3:
                        CriarConta();
                        break;
                    case 4:
                        AtualizarConta();
                        break;
                    case 5:
                        DeletarConta();
                        break;
                    case 6:
                        Sacar();
                        break;
                    case 7:
                        Depositar();
                        break;
                    case 8:
                        Transferir();
                        break;
                    case 0:
                        Cores.Saida("\nSaindo do sistema...");
                        break;
                    default:
                        Cores.Input("\nOpção inválida, tente novamente\n");
                        Console.WriteLine();
                        Cores.Input("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcao != 0);
        }

        private void BuscarPorAgenciaENumero()
        {
            int inputAgencia = InputUtil.InputAgencia();
            int inputNumeroConta = InputUtil.InputNumeroConta();
            try
            {
                Conta conta = contaController.ProcurarPorAgenciaENumero(inputAgencia, inputNumeroConta);
                Cores.Sucesso("Conta encontrada:\n" + conta.ExibirDadosConta());
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao buscar com agência {inputAgencia} e número {inputNumeroConta}, msg:{ex.Message}.");
            }
        }

        private void ListarContas()
        {
            try
            {
                List<Conta> listaContas = contaController.ListarTodas();

                Cores.Sucesso("Conta(s) encontrada(s):");
                foreach (var conta in listaContas)
                {
                    Cores.Sucesso(conta.ExibirDadosConta());
                }
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao buscar contas, msg:{ex.Message}.");
            }
        }

        private void CriarConta()
        {
            TipoConta inputTipoConta = InputUtil.InputTipoConta();
            int inputAgencia = InputUtil.InputAgencia();
            string inputTitular = InputUtil.InputTitular();

            int numeroConta = contaController.GerarNumero(inputAgencia);

            Conta? contaCadastro = null;
            try
            {
                switch (inputTipoConta)
                {
                    case TipoConta.Corrente:
                        float inputLimie = InputUtil.InputLimite();
                        contaCadastro = new ContaCorrente(null, inputAgencia, numeroConta, inputTitular, 0f, inputLimie);
                        break;
                    case TipoConta.Poupanca:
                        int inputAniversario = InputUtil.InputAniversario();
                        contaCadastro = new ContaPoupanca(null, inputAgencia, numeroConta, inputTitular, 0f, inputAniversario);
                        break;
                }
                contaController.Cadastrar(contaCadastro);

                Cores.Sucesso("Conta cadastrada:\n" + contaCadastro!.ExibirDadosConta());
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao criar conta, msg:{ex.Message}.");
            }
        }

        private void AtualizarConta()
        {
            int inputAgencia = InputUtil.InputAgencia();
            int inputNumeroConta = InputUtil.InputNumeroConta();
            string inputTitular = InputUtil.InputTitular();

            try
            {
                Conta? contaAtualizar = contaController.ProcurarPorAgenciaENumero(inputAgencia, inputNumeroConta);
                if (contaAtualizar == null)
                {
                    Cores.Aviso($"Não existe conta para está agência {inputAgencia} e número {inputNumeroConta}.");
                    return;
                }

                contaAtualizar.Titular = inputTitular;

                switch (contaAtualizar.Tipo)
                {
                    case TipoConta.Corrente:
                        float inputLimie = InputUtil.InputLimite();
                        ((ContaCorrente)contaAtualizar).Limite = inputLimie;
                        break;
                    case TipoConta.Poupanca:
                        int inputAniversario = InputUtil.InputAniversario();
                        contaAtualizar.Titular = inputTitular;
                        ((ContaPoupanca)contaAtualizar).Aniversario = inputAniversario;
                        break;
                }

                contaController.Atualizar(contaAtualizar);
                Cores.Sucesso($"Conta atualizada com sucesso:\n" + contaAtualizar.ExibirDadosConta());

            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao atualizar conta, msg:{ex.Message}.");
                return;
            }
        }

        private void DeletarConta()
        {
            int inputAgencia = InputUtil.InputAgencia();
            int inputNumeroConta = InputUtil.InputNumeroConta();

            try
            {
                contaController.Deletar(inputAgencia, inputNumeroConta);
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao deletar conta, msg:{ex.Message}.");
                return;
            }
        }

        private void Sacar()
        {
            int inputAgencia = InputUtil.InputAgencia();
            int inputNumeroConta = InputUtil.InputNumeroConta();
            float inputValorSacar = InputUtil.InputValorSacar();

            try
            {
                contaController.Sacar(inputAgencia, inputNumeroConta, inputValorSacar);
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao sacar, msg:{ex.Message}.");
                return;
            }
        }

        private void Depositar()
        {
            int inputAgencia = InputUtil.InputAgencia();
            int inputNumeroConta = InputUtil.InputNumeroConta();
            float inputValorDepositar = InputUtil.InputValorDepositar();

            try
            {
                contaController.Depositar(inputAgencia, inputNumeroConta, inputValorDepositar);
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao depositar, msg:{ex.Message}.");
                return;
            }
        }

        private void Transferir()
        {
            int inputAgenciaOrigem = InputUtil.InputAgenciaOriem();
            int inputNumeroContaOrigem = InputUtil.InputNumeroContaOrigem();
            int inputAgenciaDestino = InputUtil.InputAgenciaDestino();
            int inputNumeroContaDestino = InputUtil.InputNumeroContaDestino();
            float inputValorTransferencia = InputUtil.InputValorTransferir();

            try
            {
                contaController.Transferir(inputAgenciaOrigem, inputNumeroContaOrigem, inputAgenciaDestino, inputNumeroContaDestino, inputValorTransferencia);
            }
            catch (ValidationException vex)
            {
                Cores.Aviso(vex.Message);
            }
            catch (Exception ex)
            {
                Cores.Erro($"Erro ao transferir, msg:{ex.Message}.");
                return;
            }
        }
    }
}
