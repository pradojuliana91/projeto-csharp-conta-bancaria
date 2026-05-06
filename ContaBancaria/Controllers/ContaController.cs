using ContaBancaria.Controllers.Inerfaces;
using ContaBancaria.Models;
using ContaBancaria.Models.Enums;
using ContaBancaria.Utils;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContaBancaria.Controllers
{
    class ContaController : IContaController
    {
        private List<Conta> listaContas = new List<Conta>();
        public void procurarPorNumero(int numero)
        {

            if (reader.Read())
            {
                Cores.Sucesso($"Conta encontrada:\nTipo: {Enum.GetName(tipoConta)}, Agência: {agencia}, Número: {numero}, Titular: {reader.GetString("titular")}, Saldo: {reader.GetDecimal("saldo")}");
            }
            else
            {
                Cores.Aviso($"Nenhuma conta encontrada com agência {agencia} e número {numero}.");
            }


            if (listaContas.Count == 0)
            {
                Cores.Aviso("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                Cores.Titulo("\nCONTA ENCONTRADA:");
                Cores.Linha();
                Cores.Sucesso($"Número: {conta.Numero} | Titular: {conta.Titular} | Saldo: {conta.Saldo}");
            }
            else
            {
                Cores.Aviso("\nConta não encontrada.");
            }
        }
        public void listarTodas()
        {


            if (!reader.HasRows)
            {
                Cores.Aviso("Nenhuma conta encontrada.");
                return;
            }

            Cores.Sucesso("Contas encontradas:");
            while (reader.Read())
            {
                int agencia = reader.GetInt32("agencia");
                int numero = reader.GetInt32("numero");
                string titular = reader.GetString("titular");
                decimal saldo = reader.GetDecimal("saldo");
                TipoConta tipoConta = (TipoConta)reader.GetInt32("tipo");
                Cores.Sucesso($"Tipo: {Enum.GetName(tipoConta)}, Agência: {agencia}, Número: {numero}, Titular: {titular}, Saldo: {saldo}");
            }

            if (listaContas.Count == 0)
            {
                Cores.Aviso("\nNenhuma conta cadastrada.");
                Cores.PressioneEnter();
                return;
            }
            else
            {
                Cores.Titulo("\nCONTAS CADASTRADAS:");
                Cores.Linha();
                foreach (var conta in listaContas)
                {
                    Cores.Destaque($"\nNúmero: {conta.Numero} | Titular: {conta.Titular} | Saldo: {conta.Saldo:F2}");
                    Cores.PressioneEnter();
                }
            }
        }
        public void cadastrar(Conta conta)
        {

            if (auxCadastrar > 0)
            {
                Cores.Sucesso($"Conta cadastrada com sucesso.");
            }
            else
            {
                Cores.Erro($"Erro ao cadastrar conta.");
                Console.WriteLine($"Erro ao cadastrar conta.");
            }

            if (conta == null)
            {
                Cores.Erro("\nConta inválida.");
                return;
            }

            if (buscarNaCollection(conta.Numero) != null)
            {
                Cores.Aviso("\nNúmero de conta já existe. Tente novamente com um número diferente.");
                return;
            }

            listaContas.Add(conta);
            Cores.Sucesso($"\nConta {conta.Numero} cadastrada com sucesso!\n");
        }
        public void atualizar(Conta conta)
        {

            if (auxAtualizar > 0)
            {
                Cores.Sucesso($"Conta atualizada com sucesso.");
            }
            else
            {
                Cores.Aviso($"Nenhuma conta encontrada com agência {agenciaAtual} e número {numeroAtual}.");
            }

            var existeConta = buscarNaCollection(conta.Numero);            

            if (existeConta != null)
            {
                listaContas.Remove(existeConta);
                listaContas.Add(conta);

                Cores.Sucesso($"\nConta {conta.Numero} atualizada com sucesso!");
            }
            else
            {
                Cores.Aviso("\nConta não encontrada.");
            }
        }
        public void deletar(int numero)
        {

            if (auxDeletar > 0)
            {
                Cores.Sucesso($"Conta excluída com sucesso.");
            }
            else
            {
                Cores.Aviso($"Nenhuma conta encontrada com agência {agencia} e número {numero}.");
            }

            if (listaContas.Count == 0)
            {
                Cores.Aviso("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                listaContas.Remove(conta);
                Cores.Sucesso($"\nConta excluída com sucesso!");
            }
            else
            {
                Cores.Aviso("\nConta não encontrada.");
            }
        }
        public void sacar(int numero, float valor)
        {

            if (valor <= 0)
            {
                Console.WriteLine("Valor de saque inválido.");
                return;
            }

            if (auxSacar > 0)
            {
                Console.WriteLine($"Valor R$ {valor} sacado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Nenhuma conta encontrada com número {numero}.");
            }

            if (listaContas.Count == 0)
            {
                Cores.Aviso("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                if (conta.Sacar(valor))
                {
                    Cores.Sucesso($"\nSaque de {valor} realizado com sucesso! Saldo atual: {conta.Saldo}");
                }
                else
                {
                    Cores.Erro("\nSaldo insuficiente para realizar o saque.");
                }
            }
            else
            {
                Cores.Aviso("\nConta não encontrada.");
            }
        }
        public void depositar(int numero, float valor)
        {


            if (valor <= 0)
            {
                Console.WriteLine("Valor de depósito deve ser maior que zero.");
                return;
            }

            if (auxDepositar > 0)
            {
                Console.WriteLine($"Valor R$ {valor} depositado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Nenhuma conta encontrada com número {numero}.");
            }

            if (listaContas.Count == 0)
            {
                Cores.Aviso("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                conta.Depositar(valor);
                Cores.Sucesso($"\nDepósito de {valor} realizado com sucesso! Saldo atual: {conta.Saldo}");
            }
            else
            {
                Cores.Aviso("\nConta não encontrada.");
            }
        }
        public void transferir(int numeroOrigem, int numeroDestino, float valor)
        {
                    public void Visualizar()
        {
            Console.WriteLine("----- Dados da Conta Corrente -----");
            Console.WriteLine("Número: " + Numero);
            Console.WriteLine("Agência: " + Agencia);
            Console.WriteLine("Titular: " + Titular);
            Console.WriteLine("Saldo: " + Saldo);
            Console.WriteLine("Limite: " + Limite);
        }
        Console.WriteLine($"Valor R$ {valor} transferido com sucesso de conta {numeroOrigem} para conta {numeroDestino}.");

            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            if (listaContas.Count == 0)
            {
                Cores.Aviso("\nNenhuma conta cadastrada.");
                return;
            }

            var contaOrigem = buscarNaCollection(numeroOrigem);
            var contaDestino = buscarNaCollection(numeroDestino);

            if (contaOrigem == null || contaDestino == null)
            {
                Cores.Aviso("\nConta de origem ou destino não encontrada.");
                return;
            }

            if (contaOrigem.Sacar(valor))
            {
                contaDestino.Depositar(valor);
                Cores.Sucesso($"\nTransferência de {valor} realizada com sucesso!");
            }
            else
            {
                Cores.Erro("\nSaldo insuficiente para realizar a transferência.");
            }
        }
        public int GerarNumero()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        Conta buscarNaCollection(int numero)
        {
            return listaContas.FirstOrDefault(c => c.Numero == numero);
        }
    }
}
