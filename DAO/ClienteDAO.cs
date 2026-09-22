using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO;

public class ClienteDAO
{
    private readonly Conexao _conexao;

    public ClienteDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Cliente> Listar()
    {
        try
        {
            var lista = new List<Cliente>();

            // Buscando a Conexão com o banco de dados
            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM clientes";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente();

                cliente.Id = leitor.GetInt32("id");
                cliente.Nome = leitor.GetString("nome");
                cliente.CPF = leitor.GetString("cpf");
                cliente.Telefone = leitor.GetString("telefone");
                cliente.Email = leitor.GetString("email");
                cliente.Endereco = leitor.GetString("endereco");

                lista.Add(cliente);
            }

            return lista;
        }
        catch
        {
            throw;
        }
    }
}
