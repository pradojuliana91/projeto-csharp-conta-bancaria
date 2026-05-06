namespace ContaBancaria.Utils
{
    class Cores
    {
        public static void Sucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Erro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Aviso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Titulo(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Destaque(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Menu(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Opcao(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        public static void Input(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        public static void Linha()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("=================================");
            Console.ResetColor();
        }

        public static void Saida(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void PressioneEnter()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}

