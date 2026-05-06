using ContaBancaria.Models.Enums;

namespace ContaBancaria.Models
{
    class ContaCorrente : Conta
    {
        public float Limite { get; set; }

        public ContaCorrente(long? id, int agencia, int numero, string titular, float saldo, float limite)
            : base(id, agencia, numero, TipoConta.Corrente, titular, saldo)
        {
            Limite = limite;
        }

        public override bool Sacar(float valor)
        {
            if ((Saldo + Limite) < valor)
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

        public override string ExibirDadosConta()
        {
            return base.ExibirDadosConta() + $", Limite: {Limite}"; 
        }
    }
}
