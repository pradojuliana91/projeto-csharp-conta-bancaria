namespace ContaBancaria.Models
{
    class Conta
    {
        public int Numero { get; protected set; }
        public int Agencia { get; protected set; }
        public int Tipo { get; protected set; }
        public string? Titular { get; protected set; }
        public float Saldo { get; protected set; }

        public Conta(int numero, int agencia, int tipo, string titular)
        {
            Numero = numero;
            Agencia = agencia;
            Tipo = tipo;
            Titular = titular;
            Saldo = 0.0f;
        }

        public virtual bool Sacar(float valor)
        {
            if (Saldo < valor || valor <= 0)
            {
                return false;
            }
            else
            {
                Saldo -= valor;
                return true;
            }
        }
        public virtual void Depositar(float valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }
    }
}
