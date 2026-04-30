using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Models
{
    class ContaPoupanca : Conta
    {
        public int Aniversario { get; protected set; }

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
