using ContaBancaria.Controllers;
using ContaBancaria.Models;
using System.ComponentModel;

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
                Console.WriteLine("=================================");
                Console.WriteLine("     SISTEMA CONTA BANCÁRIA      ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Criar Conta");
                Console.WriteLine("2. Listar Contas");
                Console.WriteLine("3. Buscar Conta");
                Console.WriteLine("4. Atualizar Conta");
                Console.WriteLine("5. Deletar Conta");
                Console.WriteLine("6. Sacar");
                Console.WriteLine("7. Depositar");
                Console.WriteLine("8. Transferir");
                Console.WriteLine("0. Sair");
                Console.WriteLine("=================================");
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

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
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        private void CriarConta()
        {
            Console.WriteLine("Escolha o tipo de conta: ");
            Console.WriteLine("1 - Corrente | 2 - Poupança");
            int tipo = int.Parse(Console.ReadLine());

            if (tipo != 1 && tipo != 2)
            {
                Console.WriteLine("Tipo de conta inválido! Tente novamente.\n");
                return;
            }

            int numero = contaController.GerarNumero();
            Console.WriteLine($"Número da conta gerado: {numero}");

            while (true)
            {
                Console.Write("Agência: ");
                int agencia = int.Parse(Console.ReadLine());

                if (agencia <= 0)
                {
                    Console.WriteLine("Agência inválida! Tente novamente.\n");
                    continue;
                }

                Console.Write("Titular: ");
                string titular = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(titular))
                {
                    Console.WriteLine("Titular inválido! Tente novamente.\n");
                    continue;
                }

                if (tipo == 1)
                {
                    Console.Write("Limite da Conta Corrente: ");
                    float limite = float.Parse(Console.ReadLine());

                    contaController.cadastrar(
                        new ContaCorrente(numero, agencia, titular, limite));

                    break;
                }
                else
                {
                    int aniversario = DateTime.Now.Day;
                    Console.WriteLine($"Aniversário definido automaticamente: {aniversario}");

                    contaController.cadastrar(
                        new ContaPoupanca(numero, agencia, titular, aniversario));

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
                Console.Write("Digite o número da conta (4 digitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido! Deve conter exatamente 4 dígitos. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números!\n");
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
                Console.Write("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido! Deve conter exatamente 4 dígitos. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números!\n");
                    continue;
                }

                auxNumero = int.Parse(numeroConta);
                break;
            }

            int auxAgencia;
            while (true)
            {
                Console.Write("Nova agência: ");
                string agenciaInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(agenciaInput))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (!agenciaInput.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números!\n");
                    continue;
                }

                auxAgencia = int.Parse(agenciaInput);
                break;
            }

            string auxTitular;
            while (true)
            {
                Console.Write("Novo titular: ");
                auxTitular = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(auxTitular))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }
                break;
            }

            //contaController.atualizar((auxNumero, auxAgencia, auxTitular));


        }
        private void DeletarConta()
        {
            int auxNumero;

            while (true)
            {
                Console.Write("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números. Tente novamente.\n");
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
                Console.Write("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números. Tente novamente.\n");
                    continue;
                }

                auxNumero = int.Parse(numeroConta);
                break;
            }

            float auxValor;
            while (true)
            {
                Console.Write("Valor do saque: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                auxValor = float.Parse(valor);

                if (auxValor <= 0)
                {
                    Console.WriteLine("O valor deve ser maior que zero. Tente novamente.\n");
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
                Console.Write("Digite o número da conta (4 dígitos): ");
                string numeroConta = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroConta))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroConta.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroConta.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números. Tente novamente.\n");
                    continue;
                }
                auxNumero = int.Parse(numeroConta);
                break;
            }

            float auxValor;
            while (true)
            {
                Console.Write("Digite o valor do depósito: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                auxValor = float.Parse(valor);

                if (auxValor <= 0)
                {
                    Console.WriteLine("O valor deve ser maior que zero. Tente novamente.\n");
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
                Console.Write("Digite o número da conta de origem (4 dígitos): ");
                string numeroOrigem = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroOrigem))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroOrigem.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroOrigem.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números. Tente novamente.\n");
                    continue;
                }
                auxNumeroOrigem = int.Parse(numeroOrigem);
                break;
            }

            while (true)
            {
                Console.Write("Digite o número da conta de destino (4 dígitos): ");
                string numeroDestino = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(numeroDestino))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }

                if (numeroDestino.Length != 4)
                {
                    Console.WriteLine("Número de conta inválido. Tente novamente.\n");
                    continue;
                }

                if (!numeroDestino.All(char.IsDigit))
                {
                    Console.WriteLine("Digite apenas números. Tente novamente.\n");
                    continue;
                }

                auxNumeroDestino = int.Parse(numeroDestino);
                break;
            }

            float auxValor;
            while (true)
            {
                Console.Write("Digite o valor da transferência: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("O campo não pode ser vazio. Tente novamente.\n");
                    continue;
                }
                auxValor = float.Parse(valor);
                if (auxValor <= 0)
                {
                    Console.WriteLine("O valor deve ser maior que zero. Tente novamente.\n");
                    continue;
                }
                break;
            }

            contaController.transferir(auxNumeroOrigem, auxNumeroDestino, auxValor);
        }
    }
}
