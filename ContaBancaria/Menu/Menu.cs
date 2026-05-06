using ContaBancaria.Controllers;
using ContaBancaria.Models;
using ContaBancaria.Utils;

namespace ContaBancaria.Menu
{
    class Menu
    {
        private ContaController contaController = new ContaController();
        public void Executar()
        {
            int opcao;
            do
            {
                Cores.Linha();
                Cores.Titulo("     SISTEMA CONTA BANCÁRIA      ");
                Cores.Linha();
                Cores.Menu("1. Criar Conta");
                Cores.Menu("2. Listar Contas");
                Cores.Menu("3. Buscar Conta");
                Cores.Menu("4. Atualizar Conta");
                Cores.Menu("5. Deletar Conta");
                Cores.Menu("6. Sacar");
                Cores.Menu("7. Depositar");
                Cores.Menu("8. Transferir");
                Cores.Menu("0. Sair");

                Cores.Linha();
                Cores.Opcao("\nEscolha uma opção: ");
                Console.ForegroundColor = ConsoleColor.White;
                opcao = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (opcao)
                {
                    case 1:
                        CriarConta();
                        break;
                    case 2:
                        ListarContas();
                        break;
                    case 3:
                        BuscarPorNumero();
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

        private void CriarConta()
        {
            Cores.Opcao("\nEscolha o tipo de conta\n");
            Cores.Menu("\n1 - Conta Corrente");
            Cores.Menu("2 - Conta Poupança");
            Cores.Opcao("\nDigite a opção desejada: ");
            int tipo = int.Parse(Console.ReadLine());

            while (tipo != 1 && tipo != 2)
            {
                Cores.Erro("\nTipo de conta inválido! Tente novamente.");

                Cores.Opcao("\nEscolha o tipo de conta\n");
                Cores.Menu("\n1 - Conta Corrente");
                Cores.Menu("2 - Conta Poupança");
                Cores.Opcao("\nDigite a opção desejada: ");
                tipo = int.Parse(Console.ReadLine());
            }

            int numero = contaController.GerarNumero();

            Cores.Sucesso($"\nNúmero da conta gerado: {numero}\n");

            while (true)
            {
                Cores.Input("Agência: ");
                string agencia = Console.ReadLine();

                if (string.IsNullOrEmpty(agencia))
                {
                    Cores.Input("\nCampo agência não pode ser vazio.\n\n");
                    continue;
                }

                if (!agencia.All(char.IsDigit))
                {
                    Cores.Input("\nDigite apenas números! Tente novamente.\n\n");
                    continue;
                }

                int numAgencia = int.Parse(agencia);

                if(numAgencia < 4)
                {
                    Cores.Input("\nNúmero de agência inválido! Deve conter pelo menos 4 dígitos. Tente novamente.\n\n");
                    continue;
                }

                Cores.Input("Titular: ");
                string titular = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(titular))
                {
                    Cores.Input("Titular inválido! Tente novamente.\n");
                    continue;
                }

                if (tipo == 1)
                {
                    Cores.Input("Limite da Conta Corrente: ");
                    float limite = float.Parse(Console.ReadLine());

                    contaController.cadastrar(
                        new ContaCorrente(numero, numAgencia, titular, limite));

                    break;
                }
                else
                {
                    int aniversario = DateTime.Now.Day;
                    Cores.Aviso($"Dia de aniversário da conta: {aniversario}");

                    contaController.cadastrar(
                        new ContaPoupanca(numero, numAgencia, titular, aniversario));

                    break;
                }
            }
        }
        private void ListarContas()
        {
            contaController.listarTodas();
        }
        private void BuscarPorNumero()
        {
            int auxNumero;

            while (true)
            {
                Cores.Input("\nDigite o número da conta (4 digitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Cores.Erro("Número de conta inválido! Deve conter exatamente 4 dígitos. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números!\n");
                    continue;
                }

                auxNumero = int.Parse(numeroConta);

                break;
            }

            contaController.procurarPorNumero(auxNumero);

            
        }
        private void AtualizarConta()
        {
            int auxNumero;

            while (true)
            {
                Cores.Input("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Cores.Erro("Número de conta inválido! Deve conter exatamente 4 dígitos. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números!\n");
                    continue;
                }

                auxNumero = int.Parse(numeroConta);
                break;
            }

            int auxAgencia;
            while (true)
            {
                Cores.Input("Nova agência: ");
                string agenciaInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(agenciaInput))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (!agenciaInput.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números!\n");
                    continue;
                }


                auxAgencia = int.Parse(agenciaInput);
                break;
            }

            string auxTitular;
            while (true)
            {
                Cores.Input("Novo titular: ");
                auxTitular = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(auxTitular))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }
                break;
            }

            Conta conta = new ContaCorrente(auxNumero, auxAgencia, auxTitular, 0);

            contaController.atualizar(conta);
        }
        private void DeletarConta()
        {
            int auxNumero;

            while (true)
            {
                Cores.Input("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Cores.Erro("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números. Tente novamente.\n");
                    continue;
                }
                auxNumero = int.Parse(numeroConta);
                break;
            }

            contaController.deletar(auxNumero);
        }
        private void Sacar()
        {
            int auxNumero;
            while (true)
            {
                Cores.Input("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Cores.Erro("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números. Tente novamente.\n");
                    continue;
                }

                auxNumero = int.Parse(numeroConta);
                break;
            }

            float auxValor;
            while (true)
            {
                Cores.Input("Valor do saque: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                auxValor = float.Parse(valor);

                if (auxValor <= 0)
                {
                    Cores.Erro("O valor deve ser maior que zero. Tente novamente.\n");
                    continue;
                }
                break;
            }

            contaController.sacar(auxNumero, auxValor);

        }
        private void Depositar()
        {
            int auxNumero;

            while (true)
            {
                Cores.Input("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Cores.Erro("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números. Tente novamente.\n");
                    continue;
                }
                auxNumero = int.Parse(numeroConta);
                break;
            }

            float auxValor;
            while (true)
            {
                Cores.Input("Digite o valor do depósito: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                auxValor = float.Parse(valor);

                if (auxValor <= 0)
                {
                    Cores.Erro("O valor deve ser maior que zero. Tente novamente.\n");
                    continue;
                }
                break;
            }

            contaController.depositar(auxNumero, auxValor);
        }
        private void Transferir()
        {
            int auxNumeroOrigem, auxNumeroDestino;

            while (true)
            {
                Cores.Input("Digite o número da conta de origem (4 dígitos): ");
                string numeroOrigem = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroOrigem))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroOrigem.Length != 4)
                {
                    Cores.Erro("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroOrigem.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números. Tente novamente.\n");
                    continue;
                }
                auxNumeroOrigem = int.Parse(numeroOrigem);
                break;
            }

            while (true)
            {
                Cores.Input("Digite o número da conta de destino (4 dígitos): ");
                string numeroDestino = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroDestino))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroDestino.Length != 4)
                {
                    Cores.Erro("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroDestino.All(char.IsDigit))
                {
                    Cores.Erro("Digite apenas números. Tente novamente.\n");
                    continue;
                }

                auxNumeroDestino = int.Parse(numeroDestino);
                break;
            }

            float auxValor;
            while (true)
            {
                Cores.Input("Digite o valor da transferência: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }
                auxValor = float.Parse(valor);
                if (auxValor <= 0)
                {
                    Cores.Erro("O valor deve ser maior que zero. Tente novamente.\n");
                    continue;
                }
                break;
            }

            contaController.transferir(auxNumeroOrigem, auxNumeroDestino, auxValor);
        }
    }
}
