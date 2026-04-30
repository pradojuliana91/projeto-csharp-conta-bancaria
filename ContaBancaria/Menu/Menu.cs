using ContaBancaria.Controllers;

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
                        //listar contas
                        break;
                    case 3:
                        //buscar conta
                        break;
                    case 4:
                        //atualizar conta
                        break;
                    case 5:
                        //deletar conta
                        break;
                    case 6:
                        //sacar
                        break;
                    case 7:
                        //depositar
                        break;
                    case 8:
                        //transferir
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

            Console.Write("Número: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Agência: ");
            int agencia = int.Parse(Console.ReadLine());

            Console.Write("Titular: ");
            string titular = Console.ReadLine();

            if (tipo == 1)
            {
                Console.Write("Limite da Conta Corrente: ");
                float limite = float.Parse(Console.ReadLine());

                //criar conta corrente
            }
            else if (tipo == 2)
            {
                int aniversario = DateTime.Now.Day;
                Console.WriteLine($"Aniversário definido automaticamente: {aniversario}");
            }
            else
            {
                Console.WriteLine("Tipo de conta inválido.");
            }
        }
    }
}
