namespace AppPapelaria1.DAO;
using AppPapelaria1.Config;
using AppPapelaria1.Model;

public class CaixaDAO { 

    private readonly Conexao _conexao;

    public CaixaDAO(Conexao conexao) { }

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
}

            