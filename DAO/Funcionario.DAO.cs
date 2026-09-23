using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO
{
 
    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;

        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Funcionario> Listar()
        {
            try
            {
                var lista = new List<Funcionario>();
                //Buscando e abrindo a Conexão com o banco de dados
                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Funcionario";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var funcionario = new Funcionario();
                    funcionario.Id = leitor.GetInt32("id_fun");
                    funcionario.Nome = leitor.GetString("nome_fun");
                    funcionario.Cpf = leitor.GetString("cpf_fun");
                    funcionario.Senha = leitor.GetString("senha_fun");
                    funcionario.Telefone = leitor.GetString("telefone_fun");
                    funcionario.Sexo = leitor.GetString("sexo_fun");
                    funcionario.Endereco = leitor.GetString("endereco_fun");
                    funcionario.Email = leitor.GetString("email_fun");

                    lista.Add(funcionario);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}

