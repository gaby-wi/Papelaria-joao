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

        // Método para cadastrar uma nova movimentação financeira no banco
        public void Inserir(Financeiro fin)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"INSERT INTO Financeiro (tipo_fin, valor_fin, data_fin, id_fun_fk, id_vend_fk) 
                               VALUES (@tipo, @valor, @data, @idFun, @idVend)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                var pTipo = comando.CreateParameter();
                pTipo.ParameterName = "@tipo";
                pTipo.Value = fin.Tipo ?? (object)DBNull.Value;
                comando.Parameters.Add(pTipo);

                var pValor = comando.CreateParameter();
                pValor.ParameterName = "@valor";
                pValor.Value = fin.Valor;
                comando.Parameters.Add(pValor);

                var pData = comando.CreateParameter();
                pData.ParameterName = "@data";
                pData.Value = fin.Data;
                comando.Parameters.Add(pData);

                var pIdFun = comando.CreateParameter();
                pIdFun.ParameterName = "@idFun";
                pIdFun.Value = fin.IdFuncionario;
                comando.Parameters.Add(pIdFun);

                var pIdVend = comando.CreateParameter();
                pIdVend.ParameterName = "@idVend";
                pIdVend.Value = fin.IdVenda;
                comando.Parameters.Add(pIdVend);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        // Método para listar todas as movimentações já cadastradas
        public List<Financeiro> Listar()
        {
            try
            {
                var lista = new List<Financeiro>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT id_fin, tipo_fin, valor_fin, data_fin, id_fun_fk, id_vend_fk FROM Financeiro ORDER BY id_fin DESC";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var financeiro = new Financeiro
                    {
                        Id = leitor.GetInt32("id_fin"),
                        Tipo = leitor.IsDBNull(leitor.GetOrdinal("tipo_fin")) ? "" : leitor.GetString("tipo_fin"),
                        Valor = leitor.GetFloat("valor_fin"),
                        Data = leitor.GetDateTime("data_fin"),
                        IdFuncionario = leitor.GetInt32("id_fun_fk"),
                        IdVenda = leitor.GetInt32("id_vend_fk")
                    };

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