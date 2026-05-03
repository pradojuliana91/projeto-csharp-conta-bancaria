using ContaBancaria.Models.Enums;

namespace ContaBancaria.Models
{
    abstract class Conta
    {
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public TipoConta Tipo { get; set; }
        public string Titular { get; set; }
        public float Saldo { get; set; }

        public Conta(int numero, int agencia, TipoConta tipo, string titular)
        {
            Numero = numero;
            Agencia = agencia;
            Tipo = tipo;
            Titular = titular;
            Saldo = 0.0f;
        }

        public abstract bool Sacar(float valor);

        public virtual void Depositar(float valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }
    }
}
