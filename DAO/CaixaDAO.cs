namespace AppPapelaria1.DAO;

using AppPapelaria1.Config;
using AppPapelaria1.Model;

public class CaixaDAO
{
    private readonly Conexao _conexao;

    public CaixaDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Caixa> Listar()
    {
        try
        {
            var lista = new List<Caixa>();

            // Buscando e abrindo a conexão com o banco de dados
            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM Caixa";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var caixa = new Caixa();
                caixa.Id = leitor.GetInt32("id_cai");
                caixa.DataAbertura = leitor.GetDateTime("data_abertura_cai");
                caixa.DataFechamento = leitor.GetDateTime("data_fechamento_cai");
                caixa.ValorInicial = leitor.GetFloat("valor_inicial_cai");
                caixa.ValorFinal = leitor.GetFloat("valor_final_cai");
                caixa.IdFuncionario = leitor.GetInt32("id_fun_fk");

                lista.Add(caixa);
            }

            return lista;
        }
        catch
        {
            throw;
        }
    }

    public void Inserir(Caixa caixa)
    {
        try
        {
            using var con = _conexao.GetConnection();

            string sql = @"INSERT INTO Caixa 
                (data_abertura_cai, data_fechamento_cai, valor_inicial_cai, valor_final_cai, id_fun_fk) 
                VALUES 
                (@dataAbertura, @dataFechamento, @valorInicial, @valorFinal, @idFuncionario)";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            comando.Parameters.AddWithValue("@dataAbertura", caixa.DataAbertura);
            comando.Parameters.AddWithValue("@dataFechamento", caixa.DataFechamento);
            comando.Parameters.AddWithValue("@valorInicial", caixa.ValorInicial);
            comando.Parameters.AddWithValue("@valorFinal", caixa.ValorFinal);
            comando.Parameters.AddWithValue("@idFuncionario", caixa.IdFuncionario);

            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }
}