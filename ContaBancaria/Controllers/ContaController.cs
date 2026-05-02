using ContaBancaria.Interfaces;
using ContaBancaria.Models;

namespace ContaBancaria.Controllers
{
    class ContaController : IContaRepository
    {
        private List<Conta> listaContas = new List<Conta>();
        public void procurarPorNumero(int numero)
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                Console.WriteLine($"\nConta encontrada\n: Número: {conta.Numero} | Titular: {conta.Titular} | Saldo: {conta.Saldo}");
            }
            else
            {
                Console.WriteLine("\nConta não encontrada.");
            }
        }
        public void listarTodas()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                return;
            }
            else
            {
                Console.WriteLine("\nContas cadastradas:");
                foreach (var conta in listaContas)
                {
                    Console.WriteLine($"Número: {conta.Numero}, Titular: {conta.Titular}, Saldo: {conta.Saldo}");
                }
            }
        }
        public void cadastrar(Conta conta)
        {
            if (conta == null)
            {
                Console.WriteLine("\nConta inválida.");
                return;
            }

            if (buscarNaCollection(conta.Numero) != null)
            {
                Console.WriteLine("\nNúmero de conta já existe. Tente novamente com um número diferente.");
                return;
            }

            listaContas.Add(conta);
            Console.WriteLine($"\nConta {conta.Numero} cadastrada com sucesso!");
        }
        public void atualizar(Conta conta)
        {
            var existeConta = buscarNaCollection(conta.Numero);

            if (existeConta != null)
            {
                listaContas.Remove(existeConta);
                listaContas.Add(conta);

                Console.WriteLine($"\nConta {conta.Numero} atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nConta não encontrada.");
            }
        }
        public void deletar(int numero)
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                listaContas.Remove(conta);
                Console.WriteLine($"\nConta excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("\nConta não encontrada.");
            }
        }
        public void sacar(int numero, float valor)
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                if (conta.Sacar(valor))
                {
                    Console.WriteLine($"\nSaque de {valor} realizado com sucesso! Saldo atual: {conta.Saldo}");
                }
                else
                {
                    Console.WriteLine("\nSaldo insuficiente para realizar o saque.");
                }
            }
            else
            {
                Console.WriteLine("\nConta não encontrada.");
            }
        }
        public void depositar(int numero, float valor)
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                return;
            }

            var conta = buscarNaCollection(numero);

            if (conta != null)
            {
                conta.Depositar(valor);
                Console.WriteLine($"\nDepósito de {valor} realizado com sucesso! Saldo atual: {conta.Saldo}");
            }
            else
            {
                Console.WriteLine("\nConta não encontrada.");
            }
        }
        public void transferir(int numeroOrigem, int numeroDestino, float valor)
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada.");
                return;
            }

            var contaOrigem = buscarNaCollection(numeroOrigem);
            var contaDestino = buscarNaCollection(numeroDestino);

            if (contaOrigem == null || contaDestino == null)
            {
                Console.WriteLine("\nConta de origem ou destino não encontrada.");
                return;
            }

            if (contaOrigem.Sacar(valor))
            {
                contaDestino.Depositar(valor);
                Console.WriteLine($"\nTransferência de {valor} realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nSaldo insuficiente para realizar a transferência.");
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
