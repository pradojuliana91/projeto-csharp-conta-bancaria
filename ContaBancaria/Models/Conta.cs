using ContaBancaria.Models.Enums;

namespace ContaBancaria.Models
{
    abstract class Conta
    {
        public long? Id { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }        
        public TipoConta Tipo { get; set; }
        public string Titular { get; set; }
        public float Saldo { get; set; }

        public Conta(long? id, int agencia, int numero, TipoConta tipo, string titular, float saldo)
        {
            Id = id;
            Agencia = agencia;
            Numero = numero;
            Tipo = tipo;
            Titular = titular;
            Saldo = saldo;
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
