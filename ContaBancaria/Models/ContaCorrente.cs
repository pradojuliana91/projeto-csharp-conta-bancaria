namespace ContaBancaria.Models
{
    class ContaCorrente : Conta
    {
        public float Limite { get; protected set; }

        public ContaCorrente(int numero, int agencia, string titular, float limite)
            : base(numero, agencia, 2, titular)
        {
            Limite = limite;
        }

        public override bool Sacar(float valor)
        {
            if (Saldo + Limite < valor)
            {
                return false;
            }

            if (valor <= 0)
            {
                return false;
            }

            Saldo -= valor;
            return true;

        }
        public void Visualizar()
        {
            Console.WriteLine("----- Dados da Conta Corrente -----");
            Console.WriteLine("Número: " + Numero);
            Console.WriteLine("Agência: " + Agencia);
            Console.WriteLine("Titular: " + Titular);
            Console.WriteLine("Saldo: " + Saldo);
            Console.WriteLine("Limite: " + Limite);
        }
    }
}
