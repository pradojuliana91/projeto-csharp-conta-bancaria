using ContaBancaria.Models;

namespace ContaBancaria.Repositories.Interfaces
{
    interface IContaRepository
    {
        Conta? ProcurarPorAgenciaENumero(int agencia, int numero);
        List<Conta> ListarTodas();
        int MaiorNumerContaPorAgencia(int agencia);
        long? Cadastrar(Conta conta);
        void Atualizar(Conta conta);
       
        void Deletar(int agencia, int numero);
        void Sacar(int agencia, int numero, float valor);
        void Depositar(int agencia, int numero, float valor);
        void Transferir(int agenciaOrigem, int numeroOrigem, int agenciaDestino, int numeroDestino, float valor);
    }
}
