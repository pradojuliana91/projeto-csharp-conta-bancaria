using ContaBancaria.Controllers.Inerfaces;
using ContaBancaria.Models;
using ContaBancaria.Repositories;
using ContaBancaria.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ContaBancaria.Controllers
{
    public class ContaController : IContaController
    {
        private readonly IContaRepository contaRepository;

        public ContaController(IContaRepository contaRepository)
        {
            this.contaRepository = contaRepository;
        }

        public ContaController()
        {
            contaRepository = new ContaRepository();
        }        

        public Conta ProcurarPorAgenciaENumero(int agencia, int numero)
        {
            Conta? conta = contaRepository.ProcurarPorAgenciaENumero(agencia, numero);
            if (conta == null)
            {
                throw new ValidationException($"Nenhuma conta encontrada com agência {agencia} e número {numero}.");
            }
            return conta;
        }

        public List<Conta> ListarTodas()
        {
            List<Conta> contas = contaRepository.ListarTodas();
            if (contas == null || contas.Count == 0)
            {
                throw new ValidationException("Nenhuma conta encontrada.");
            }
            return contas;
        }

        public int GerarNumero(int agencia)
        {
            return contaRepository.MaiorNumerContaPorAgencia(agencia);
        }

        public void Cadastrar(Conta? conta)
        {
            if (conta == null)
            {
                throw new ValidationException("A conta não pode ser nula.");
            }

            contaRepository.Cadastrar(conta);
        }

        public void Atualizar(Conta? conta)
        {
            if(conta == null)
            {
                throw new ValidationException("A conta não pode ser nula.");
            }
            Conta? contaAtualizar = ProcurarPorAgenciaENumero(conta.Agencia, conta.Numero);
            if (contaAtualizar == null)
            {
                throw new ValidationException($"Não existe conta para está agência {conta.Agencia} e número {conta.Numero}.");
            }
            contaRepository.Atualizar(conta);
        }

        public void Deletar(int agencia, int numero)
        {
            Conta? contaAtualizar = ProcurarPorAgenciaENumero(agencia, numero);
            if (contaAtualizar == null)
            {
                throw new ValidationException($"Não existe conta para está agência {agencia} e número {numero}.");
            }
            contaRepository.Deletar(agencia, numero);
        }

        public void Sacar(int agencia, int numero, float valor)
        {
            Conta? contaSacar = ProcurarPorAgenciaENumero(agencia, numero);
            if (contaSacar == null)
            {
                throw new ValidationException($"Não existe conta para está agência {agencia} e número {numero}.");
            }
            if (!contaSacar.Sacar(valor))
            {
                throw new ValidationException($"Saldo insuficiente para sacar o valor de {valor}.");
            }
            contaRepository.Sacar(agencia, numero, contaSacar.Saldo);
        }

        public void Depositar(int agencia, int numero, float valor)
        {
            Conta? contaDepositar = ProcurarPorAgenciaENumero(agencia, numero);
            if (contaDepositar == null)
            {
                throw new ValidationException($"Não existe conta para está agência {agencia} e número {numero}.");
            }
            contaRepository.Depositar(agencia, numero, valor);
        }

        public void Transferir(int agenciaOrigem, int numeroOrigem, int agenciaDestino, int numeroDestino, float valor)
        {
            Conta? contaOrigem = ProcurarPorAgenciaENumero(agenciaOrigem, numeroOrigem);
            if (contaOrigem == null)
            {
                throw new ValidationException($"Não existe conta origem para está agência {agenciaOrigem} e número {numeroOrigem}.");
            }
            if (!contaOrigem.Sacar(valor))
            {
                throw new ValidationException($"Saldo insuficiente para transferir na conta de origem o valor de {valor}.");
            }

            Conta? contaDestino = ProcurarPorAgenciaENumero(agenciaDestino, numeroDestino);
            if (contaDestino == null)
            {
                throw new ValidationException($"Não existe conta destino para está agência {agenciaOrigem} e número {numeroOrigem}.");
            }

            contaRepository.Transferir(agenciaOrigem, numeroOrigem, agenciaDestino, numeroDestino, valor);
        }
    }
}
