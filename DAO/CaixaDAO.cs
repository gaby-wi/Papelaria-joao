using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO;

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

            // Buscando a Conexão com o banco de dados
            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM Caixa";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var caixa = new Caixa();

                caixa.Id = leitor.GetInt32("id_cai");
                caixa.DataAbertura = leitor.GetDateTime("Data_abertura_cai");
                caixa.ValorInicial = leitor.GetFloat("Valor_inicial_cai");
                caixa.ValorFinal = leitor.GetFloat("valor_final_cai");

                if (!leitor.IsDBNull(leitor.GetOrdinal("DataDfechamento_cai")))
                {
                    caixa.DataFechamento = leitor.GetDateTime("DataDfechamento_cai");
                }

                if (!leitor.IsDBNull(leitor.GetOrdinal("ValorFinal_cai")))
                {
                    caixa.ValorFinal = leitor.GetFloat("ValorFinal_cai");
                }

                lista.Add(caixa);
            }

            return lista;
        }
        catch
        {
            throw;
        }
    }
}