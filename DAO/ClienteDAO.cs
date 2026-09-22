using MySql.Data.MySqlClient;
using AppPapelaria1.Model;
using AppPapelaria1.Config;

namespace AppPapelaria1.DAO
{
    public class ClienteDAO
    {
        private Conexao conexao;

        public ClienteDAO(Conexao conexao)
        {
            this.conexao = conexao;
        }

        public void Cadastrar(Cliente cliente)
        {
            string sql = @"INSERT INTO cliente
                           (nome_cli, cpf_cli, telefone_cli, email_cli, endereco_cli)
                           VALUES
                           (@nome, @cpf, @telefone, @email, @endereco)";

            using (MySqlConnection conexaoBanco = conexao.GetConnection())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, conexaoBanco))
                {
                    comando.Parameters.AddWithValue("@nome", cliente.NomeCli);
                    comando.Parameters.AddWithValue("@cpf", cliente.CpfCli);
                    comando.Parameters.AddWithValue("@telefone", cliente.TelefoneCli);
                    comando.Parameters.AddWithValue("@email", cliente.EmailCli);
                    comando.Parameters.AddWithValue("@endereco", cliente.EnderecoCli);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}