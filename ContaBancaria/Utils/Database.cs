using ContaBancaria.Utils;
using MySql.Data.MySqlClient;

namespace ContaBancaria.Utils
{
    sealed class Database
    {
        private const string connectionString = "server=localhost;port=3306;database=contabancaria;user=root;password=123456;AllowPublicKeyRetrieval=True;";

        public static MySqlConnection Conexao()
        {
            return new MySqlConnection(connectionString);
        }
    }
}



