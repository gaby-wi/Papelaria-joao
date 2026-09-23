using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO;

public class MovCaixaDAO
{
    private readonly Conexao _conexao;

    public MovCaixaDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<MovCaixa> Listar()
    {
        try
        {
            var lista = new List<MovCaixa>();

            // Buscando a Conexão com o banco de dados
            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM Movimentacao_Caixa";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var movimentacao = new MovCaixa();

                movimentacao.Id = leitor.GetInt32("id_movi");
                movimentacao.IdCaixa = leitor.GetInt32("id_cai_fk");
                movimentacao.Tipo = leitor.GetString("tipo_movi");
                movimentacao.Valor = leitor.GetFloat("valor_movi");
                movimentacao.Data = leitor.GetDateTime("dataMovi");
                movimentacao.Descricao = leitor.GetString("descricao_movi");
                movimentacao.FormaPagamento = leitor.GetString("formaPagamento_movi");

                lista.Add(movimentacao);
            }

            return lista;
        }
        catch
        {
            throw;
        }
    }
}