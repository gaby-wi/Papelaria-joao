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

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @" INSERT INTO Funcionario(nome_fun,
                  cpf_fun,senha_fun, telefone_fun, sexo_fun,endereco_fun, email_fun)

                   VALUES(@nome,@cpf,@senha,@telefone,@sexo,@endereco,@email)";

                using var comando = con.CreateCommand();

                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);

                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);

                comando.Parameters.AddWithValue("@senha", funcionario.Senha);

                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);

                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);

                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);

                comando.Parameters.AddWithValue("@email", funcionario.Email);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}

