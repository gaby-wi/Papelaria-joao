using MySql.Data.MySqlClient;

namespace AppPapelaria1.Config
{
    public class Conexao
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public Conexao(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MySqlConnection") ?? "";
        }

        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public MySqlConnection GetConnectionFornecedor()
        {
            string connectionStringFornecedor = _configuration.GetConnectionString("MySqlConnectionFornecedor") ?? "";
            var conn = new MySqlConnection(connectionStringFornecedor);
            conn.Open();
            return conn;
        }

        public MySqlCommand CreateCommand(string query, MySqlConnection? conn = null)
        {
            conn ??= GetConnection();
            return new MySqlCommand(query, conn);
        }
    }
}
