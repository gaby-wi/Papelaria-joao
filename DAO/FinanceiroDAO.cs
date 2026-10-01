namespace AppPapelaria1.DAO
{
    using AppPapelaria1.Config;
    using AppPapelaria1.Model;

    public class FinanceiroDAO
    {
        private readonly Conexao _conexao;

        public FinanceiroDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Financeiro> Listar()
        {
            try
            {
                var lista = new List<Financeiro>();

                // Buscando e abrindo a conexão com o banco de dados
                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Financeiro";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var financeiro = new Financeiro();
                    financeiro.Id = leitor.GetInt32("id_fin");
                    financeiro.Tipo = leitor.GetString("tipo_fin");
                    financeiro.Valor = leitor.GetFloat("valor_fin");
                    financeiro.Data = leitor.GetDateTime("data_fin");
                    financeiro.IdFuncionario = leitor.GetInt32("id_fun_fk");
                    financeiro.IdVenda = leitor.GetInt32("id_vend_fk");

                    lista.Add(financeiro);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}