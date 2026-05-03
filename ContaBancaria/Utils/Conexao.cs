using MySql.Data.MySqlClient;

namespace ContaBancaria.Utils
{
    class Conexao
    {
        private string connectionString =
            "server=localhost;port=3306;database=contabancaria;user=root;password=123456;AllowPublicKeyRetrieval=True;";

        public MySqlConnection Connection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
