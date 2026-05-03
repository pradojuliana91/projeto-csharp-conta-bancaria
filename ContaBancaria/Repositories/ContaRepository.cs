using ContaBancaria.Models;
using ContaBancaria.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using ContaBancaria.Utils;

namespace ContaBancaria.Repositories;
class ContaRepository : IContaRepository
{
    // TODO Criar banco de dados em docker local com os create table tudo guardado os arquivos de criacao.
    // Vir aqui e implementar toda logica desses metodos com conexao a banco de daods
    // lembrando que quando se trabalha com banco de dados vc deve configurar coisas como string de conexao, criar as tabelas, criar os scripts de criacao, etc.
    public void atualizar(Conta conta)
    {
        throw new NotImplementedException();
    }

    public void cadastrar(Conta conta)
    {
        throw new NotImplementedException();
    }

    public void deletar(int numero)
    {
        using (var conexao = new Conexao().Connection())
        {
            conexao.Open();

            string sql = "DELETE FROM contas WHERE numero = @numero";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@numero", numero);

                int auxDeletar = comando.ExecuteNonQuery();

                if (auxDeletar > 0)
                {
                    Console.WriteLine($"Conta excluída com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Nenhuma conta encontrada com número {numero}.");
                }
            }
        }
    }

    public void depositar(int numero, float valor)
    {
        throw new NotImplementedException();
    }

    public void listarTodas()
    {
        using (var conexao = new Conexao().Connection())
        {
            conexao.Open();

            string sql = "SELECT * FROM contas";

            using (var comando = new MySqlCommand(sql, conexao))
            using (var reader = comando.ExecuteReader())
            {

                while (reader.Read())
                {
                    int numero = reader.GetInt32("numero");
                    int agencia = reader.GetInt32("agencia");
                    string titular = reader.GetString("titular");
                    decimal saldo = reader.GetDecimal("saldo");

                    Console.WriteLine($"Número: {numero}, Agência: {agencia}, Titular: {titular}, Saldo: {saldo}");
                }
            }
        }
    }

    public void procurarPorNumero(int numero)
    {
        using (var conexao = new Conexao().Connection())
        {
            conexao.Open();

            string sql = "SELECT * FROM contas WHERE numero = @numero";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@numero", numero);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int agencia = reader.GetInt32("agencia");
                        string titular = reader.GetString("titular");
                        decimal saldo = reader.GetDecimal("saldo");

                        Console.WriteLine($"Número: {numero}, Agência: {agencia}, Titular: {titular}, Saldo: {saldo}");
                    }
                    else
                    {
                        Console.WriteLine($"Nenhuma conta encontrada com número {numero}.");
                    }
                }
            }
        }
    }

    public void sacar(int numero, float valor)
    {
        throw new NotImplementedException();
    }

    public void transferir(int numeroOrigem, int numeroDestino, float valor)
    {
        throw new NotImplementedException();
    }
}
