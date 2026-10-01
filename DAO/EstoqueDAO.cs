using AppPapelaria1.Config;
using AppPapelaria1.Model;
namespace AppPapelaria1.DAO
{
    public class EstoqueDAO
    {
        private readonly Conexao _conexao;

        public EstoqueDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Estoque> Listar()
        {
            try
            {
                var lista = new List<Estoque>();
                // Buscando a Conexão com o banco de dados
                using var con = _conexao.GetConnection();
                string sql = "SELECT * FROM estoque";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;
                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var estoque = new Estoque();
                    estoque.Id = leitor.GetInt32("id_est");
                    estoque.QuantidadeInicial= leitor.GetString("quantidade_inicial_est");
                    estoque.QuantidadeFinal = leitor.GetInt32("quantidade_final_est");
                    estoque.IdProduto = leitor.GetDecimal("id_pro_fk");
                    lista.Add(estoque);
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
