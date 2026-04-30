using ContaBancaria.Interfaces;
using ContaBancaria.Models;

namespace ContaBancaria.Controllers
{
    class ContaController : IContaRepository
    {
        private List<Conta> listaContas = new List<Conta>();
        public void procurarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }
        public void listarTodas()
        {
            throw new NotImplementedException();
        }
        public void cadastrar(Conta conta)
        {
            throw new NotImplementedException();
        }
        public void atualizar(Conta conta)
        {
            throw new NotImplementedException();
        }
        public void deletar(int numero)
        {
            throw new NotImplementedException();
        }
        public void sacar(int numero, float valor)
        {
            throw new NotImplementedException();
        }
        public void depositar(int numero, float valor)
        {
            throw new NotImplementedException();
        }
        public void transferir(int numeroOrigem, int numeroDestino, float valor)
        {
            throw new NotImplementedException();
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
