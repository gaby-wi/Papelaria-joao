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

            using var con = _conexao.GetConnection();

            string sql = @"SELECT 
                id_cli,
                nome_cli,
                cpf_cli,
                telefone_cli,
                email_cli,
                sexo_cli,
                endereco_cli
                FROM cliente";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente();

                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = leitor.GetString("nome_cli");
                cliente.CPF = leitor.GetString("cpf_cli");
                cliente.Telefone = leitor.GetString("telefone_cli");
                cliente.Email = leitor.GetString("email_cli");
                cliente.Sexo = leitor.GetString("sexo_cli");
                cliente.Endereco = leitor.GetString("endereco_cli");

                lista.Add(cliente);
            }

            return lista;
        }
        catch
        {
            throw;
        }
    }

    public void Cadastrar(Cliente cliente)
    {
        try
        {
            using var con = _conexao.GetConnection();

            string sql = @"INSERT INTO cliente
                (nome_cli, cpf_cli, telefone_cli, sexo_cli, endereco_cli, email_cli)
                VALUES
                (@nome, @cpf, @telefone, @sexo, @endereco, @email)";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            comando.Parameters.AddWithValue("@nome", cliente.Nome);
            comando.Parameters.AddWithValue("@cpf", cliente.CPF);
            comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
            comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
            comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
            comando.Parameters.AddWithValue("@email", cliente.Email);

            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }
}