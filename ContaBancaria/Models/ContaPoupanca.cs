using ContaBancaria.Enums;

namespace ContaBancaria.Models
{
    class ContaPoupanca : Conta
    {
        public int Aniversario { get; protected set; }

        public ContaPoupanca(int numero, int agencia, string titular, int aniversario)
            : base(numero, agencia, TipoConta.Poupanca, titular)
        {
            Aniversario = aniversario;
        }

        public void Visualizar()
        {
            Console.WriteLine("----- Dados da Conta Poupança -----");
            Console.WriteLine("Número: " + Numero);
            Console.WriteLine("Agência: " + Agencia);
            Console.WriteLine("Titular: " + Titular);
            Console.WriteLine("Saldo: " + Saldo);
            Console.WriteLine("Aniversário: " + Aniversario);
        }
    }
}
