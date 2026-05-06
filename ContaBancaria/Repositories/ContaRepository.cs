using ContaBancaria.Models;
using ContaBancaria.Models.Enums;
using ContaBancaria.Repositories.Interfaces;
using ContaBancaria.Utils;
using MySql.Data.MySqlClient;

namespace ContaBancaria.Repositories;
class ContaRepository : IContaRepository
{
    public Conta? ProcurarPorAgenciaENumero(int agencia, int numero)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string sql = @"SELECT 
                                id,
                                agencia, 
                                numero, 
                                tipo, 
                                titular, 
                                saldo, 
                                limite, 
                                aniversario
                           FROM 
                                contas 
                           WHERE 
                                agencia = @agencia 
                                AND numero = @numero";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@agencia", agencia);
                comando.Parameters.AddWithValue("@numero", numero);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TipoConta tipoConta = (TipoConta)reader.GetInt32("tipo");
                        switch (tipoConta)
                        {
                            case TipoConta.Corrente:
                                return new ContaCorrente(
                                    id: reader.GetInt64("id"),
                                    agencia,
                                    numero,
                                    titular: reader.GetString("titular"),
                                    saldo: reader.GetFloat("saldo"),
                                    limite: reader.GetFloat("limite"));
                            case TipoConta.Poupanca:
                                return new ContaPoupanca(
                                    id: reader.GetInt64("id"),
                                    agencia,
                                    numero,
                                    titular: reader.GetString("titular"),
                                    saldo: reader.GetFloat("saldo"),
                                    aniversario: reader.GetInt32("aniversario"));
                        }
                    }
                }
            }
            return null;
        }
    }

    public List<Conta> ListarTodas()
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string sql = @"SELECT 
                                id,
                                agencia, 
                                numero, 
                                tipo, 
                                titular, 
                                saldo, 
                                limite, 
                                aniversario
                           FROM 
                                contas";

            List<Conta> contas = new List<Conta>();
            using (var comando = new MySqlCommand(sql, conexao))
            using (var reader = comando.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TipoConta tipoConta = (TipoConta)reader.GetInt32("tipo");
                        switch (tipoConta)
                        {
                            case TipoConta.Corrente:
                                contas.Add(new ContaCorrente(
                                    id: reader.GetInt64("id"),
                                    agencia: reader.GetInt32("agencia"),
                                    numero: reader.GetInt32("numero"),
                                    titular: reader.GetString("titular"),
                                    saldo: reader.GetFloat("saldo"),
                                    limite: reader.GetFloat("limite")));
                                break;
                            case TipoConta.Poupanca:
                                contas.Add(new ContaPoupanca(
                                    id: reader.GetInt64("id"),
                                    agencia: reader.GetInt32("agencia"),
                                    numero: reader.GetInt32("numero"),
                                    titular: reader.GetString("titular"),
                                    saldo: reader.GetFloat("saldo"),
                                    aniversario: reader.GetInt32("aniversario")));
                                break;
                        }
                    }

                }
                return contas;
            }
        }
    }

    public long? Cadastrar(Conta conta)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();
            string sql = """
                    INSERT INTO contas (agencia, numero, tipo, titular, saldo, limite, aniversario)                 
                           VALUES (@agencia, @numero, @tipo, @titular, @saldo, @limite, @aniversario);
                    SELECT LAST_INSERT_ID();
                """;

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@agencia", conta.Agencia);
                comando.Parameters.AddWithValue("@numero", conta.Numero);
                comando.Parameters.AddWithValue("@tipo", (int)conta.Tipo);
                comando.Parameters.AddWithValue("@titular", conta.Titular);
                comando.Parameters.AddWithValue("@saldo", conta.Saldo);

                if (conta.Tipo == TipoConta.Corrente && conta is ContaCorrente contaCorrente)
                {
                    comando.Parameters.AddWithValue("@limite", contaCorrente.Limite);
                    comando.Parameters.AddWithValue("@aniversario", DBNull.Value);
                }
                else if (conta.Tipo == TipoConta.Poupanca && conta is ContaPoupanca contaPoupanca)
                {
                    comando.Parameters.AddWithValue("@limite", DBNull.Value);
                    comando.Parameters.AddWithValue("@aniversario", contaPoupanca.Aniversario);
                }
                else
                {
                    comando.Parameters.AddWithValue("@limite", DBNull.Value);
                    comando.Parameters.AddWithValue("@aniversario", DBNull.Value);
                }

                long? id = null;
                object result = comando.ExecuteScalar();
                if (result != null)
                {
                    id = Convert.ToInt64(result);
                }
                return id;
            }
        }
    }


    public void Atualizar(int agenciaAtual, int numeroAtual, Conta conta)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string sql = @"UPDATE contas SET 
                                agencia = @agencia, 
                                numero = @numero,
                                titular = @titular, 
                                saldo = @saldo, 
                                limite = @limite, 
                                aniversario = @aniversario 
                          WHERE 
                                agencia = @agenciaAtual 
                                AND numero = @numeroAtual";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@agencia", conta.Agencia);
                comando.Parameters.AddWithValue("@numero", conta.Numero);
                comando.Parameters.AddWithValue("@titular", conta.Titular);
                comando.Parameters.AddWithValue("@saldo", conta.Saldo);
                comando.Parameters.AddWithValue("@agenciaAtual", agenciaAtual);
                comando.Parameters.AddWithValue("@numeroAtual", numeroAtual);

                if (conta.Tipo == TipoConta.Corrente && conta is ContaCorrente contaCorrente)
                {
                    comando.Parameters.AddWithValue("@limite", contaCorrente.Limite);
                    comando.Parameters.AddWithValue("@aniversario", DBNull.Value);
                }
                else if (conta.Tipo == TipoConta.Poupanca && conta is ContaPoupanca contaPoupanca)
                {
                    comando.Parameters.AddWithValue("@limite", DBNull.Value);
                    comando.Parameters.AddWithValue("@aniversario", contaPoupanca.Aniversario);
                }
                else
                {
                    comando.Parameters.AddWithValue("@limite", DBNull.Value);
                    comando.Parameters.AddWithValue("@aniversario", DBNull.Value);
                }

                comando.ExecuteNonQuery();
            }
        }
    }


    public void Deletar(int agencia, int numero)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string sql = @"DELETE FROM 
                                contas 
                           WHERE 
                                agencia == @agencia 
                                AND numero = @numero";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@agencia", agencia);
                comando.Parameters.AddWithValue("@numero", numero);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void Sacar(int agencia, int numero, float valor)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string sql = @"UPDATE contas SET 
                                saldo = saldo - @valor 
                           WHERE 
                                agencia = @agencia 
                                AND numero = @numero 
                                AND saldo >= @valor";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@agencia", agencia);
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@valor", valor);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void Depositar(int agencia, int numero, float valor)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string sql = @"UPDATE contas SET 
                                saldo = saldo + @valor 
                           WHERE 
                                agencia = @agencia
                                AND numero = @numero";

            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@agencia", agencia);
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@valor", valor);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void Transferir(int agenciaOrigem, int numeroOrigem, int agenciaDestino, int numeroDestino, float valor)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();
            using (var transaction = conexao.BeginTransaction())
            {
                try
                {
                    string sqlSacar = @"UPDATE contas SET 
                                            saldo = saldo - @valor 
                                        WHERE 
                                            agencia = @agenciaOrigem 
                                            AND numero = @numeroOrigem 
                                            AND saldo >= @valor";

                    using (var comandoSacar = new MySqlCommand(sqlSacar, conexao, transaction))
                    {
                        comandoSacar.Parameters.AddWithValue("@agenciaOrigem", agenciaOrigem);
                        comandoSacar.Parameters.AddWithValue("@numeroOrigem", numeroOrigem);
                        comandoSacar.Parameters.AddWithValue("@valor", valor);


                        int auxSacar = comandoSacar.ExecuteNonQuery();

                        if (auxSacar <= 0)
                        {
                            transaction.Rollback();
                            throw new Exception($"Nenhuma conta de origem foi encontrada com agência {agenciaOrigem} e número {numeroOrigem} ou saldo insuficiente.");
                        }
                    }

                    string sqlDepositar = @"UPDATE contas SET 
                                                saldo = saldo + @valor 
                                            WHERE 
                                                agencia = @agenciaDestino       
                                                AND numero = @numeroDestino";

                    using (var comandoDepositar = new MySqlCommand(sqlDepositar, conexao, transaction))
                    {
                        comandoDepositar.Parameters.AddWithValue("@agenciaDestino", agenciaDestino);
                        comandoDepositar.Parameters.AddWithValue("@numeroDestino", numeroDestino);
                        comandoDepositar.Parameters.AddWithValue("@valor", valor);

                        int auxDepositar = comandoDepositar.ExecuteNonQuery();

                        if (auxDepositar <= 0)
                        {
                            transaction.Rollback();
                            throw new Exception($"Nenhuma conta de destino foi encontrada com agência {agenciaDestino} e número {numeroDestino}.");
                        }
                    }

                    transaction.Commit();
                }

                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
