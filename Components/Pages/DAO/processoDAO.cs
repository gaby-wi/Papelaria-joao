namespace AppPapelaria1.DAO;
using AppPapelaria1.Config;
using AppPapelaria1.Model;

    public class processoDAO
    {
        private readonly Conexao _conexao;
        public processoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Processo> Listar()
        {
            try
            {
                var lista = new List<Processo>();

                // Buscando e abrindo a conexão com o banco de dados
                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM processos";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var processo = new Processo();
                    processo.Id = leitor.GetInt32("id_pro");
                    processo.Numero = leitor.GetString("numero_pro");
                    processo.Interresado = leitor.GetString("interresado_pro");
                    processo.Assunto = leitor.GetString("assunto_pro");
                    processo.Descricao = leitor.GetString("descricao_pro");
                    processo.Situacao = leitor.GetString("sintuacao_pro");

                    //processo.Data = leitor["data_pro"];

                    lista.Add(processo);
                }

                return lista;

            }
            catch
            {
                throw;
            }
        }
    }

