using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO;

public class CategoriaDAO
{
    private readonly Conexao _conexao;

    public CategoriaDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Categoria> Listar()
    {
        try
        {
            var lista = new List<Categoria>();

            // Buscando a Conexão com o banco de dados
            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM categoria";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var categoria = new Categoria();

                categoria.Id = leitor.GetInt32("id");
                categoria.Nome = leitor.GetString("nome");

                lista.Add(categoria);
            }

            return
                
                lista;
        }
        catch
        {
            throw;
        }
    }
}