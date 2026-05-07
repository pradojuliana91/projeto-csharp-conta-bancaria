using ContaBancaria.Models.Enums;

namespace ContaBancaria.Models
{
    public class ContaPoupanca : Conta
    {
        public int Aniversario { get; set; }

        public ContaPoupanca(long? id, int agencia, int numero, string titular, float saldo, int aniversario)
            : base(id, agencia, numero, TipoConta.Poupanca, titular, saldo)
        {
            Aniversario = aniversario;
        }

        public override string ExibirDadosConta()
        {
            return base.ExibirDadosConta() + $", Aniversario: {Aniversario}";
        }

        public override bool Sacar(float valor)
        {
            if (Saldo < valor)
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
    }
}
