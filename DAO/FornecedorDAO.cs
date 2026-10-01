
using AppPapelaria1.Config;
using AppPapelaria1.Model;
namespace AppPapelaria1.DAO;
    public class FornecedorDAO
    {
        private readonly Conexao _conexao;

        public FornecedorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Fornecedor> Listar()
        {
            try
            {
                var lista = new List<Fornecedor>();

                // Buscando a Conexão com o banco de dados
                using var con = _conexao.GetConnection();


                string sql = "SELECT * FROM fornecedor";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();



                while (leitor.Read())
                {
                    var fornecedor = new Fornecedor();
                    fornecedor.Id = leitor.GetInt32("id_for");
                    fornecedor.Nome = leitor.GetString("nome_fantasia_for");
                    fornecedor.Telefone = leitor.GetString("telefone_for");
                    fornecedor.Email = leitor.GetString("email_for");
                    fornecedor.Cnpj = leitor.GetString("cnpj_for");
                    fornecedor.Endereco = leitor.GetString("endereco_for");

                    //processo.Data = leitor["data_pro];

                    lista.Add(fornecedor);
                }


                return lista;
            }
            catch
            {
                throw;
            }
        }
    }

