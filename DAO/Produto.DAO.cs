namespace AppPapelaria1.DAO;

using AppPapelaria1.Config;
using AppPapelaria1.Model;

public class ProdutoDAO { }

public class produtoDAO
{
    private readonly Conexao _conexao;

    public produtoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Produto> Listar()
    {
        try
        {
            var lista = new List<Produto>();

            // Buscando e abrindo a conexão com o banco de dados
            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM Produto";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = leitor.GetString("nome_pro");
                produto.Preco = leitor.GetFloat("preco_pro");
                produto.IdCategoria = leitor.GetInt32("id_cate_fk");

                lista.Add(produto);
            }

            return lista;

        }
        catch
        {
            throw;
        }
    }
}