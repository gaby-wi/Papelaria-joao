using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;

        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Produto> Listar()
        {
            try
            {
                var lista = new List<Produto>();

                using var con = _conexao.GetConnection();
                string sql = "SELECT * FROM Produto";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var produto = new Produto
                    {
                        Id = leitor.GetInt32("id_pro"),
                        Nome = leitor.GetString("nome_pro"),
                        Preco = leitor.GetFloat("preco_pro"),
                        IdCategoria = leitor.GetInt32("id_cate_fk")
                    };

                    lista.Add(produto);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        // Método que estava faltando:
        public bool Inserir(Produto produto)
        {
            try
            {
                using var con = _conexao.GetConnection();
                string sql = @"INSERT INTO Produto (nome_pro, preco_pro, id_cate_fk) 
                              VALUES (@nome, @preco, @idCategoria)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@preco", produto.Preco);
                comando.Parameters.AddWithValue("@idCategoria", produto.IdCategoria);

                int linhasAfetadas = comando.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}