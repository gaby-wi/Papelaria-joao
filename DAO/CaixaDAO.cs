using System;
using System.Collections.Generic;
using AppPapelaria1.Config;
using AppPapelaria1.Model;

namespace AppPapelaria1.DAO
{
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

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Caixa";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var caixa = new Caixa();
                    caixa.Id = leitor.GetInt32("id_cai");

                    if (leitor["DataDabertura_cai"] != DBNull.Value)
                        caixa.DataAbertura = leitor.GetDateTime("DataDabertura_cai");

                    if (leitor["DataDfechamento_cai"] != DBNull.Value)
                        caixa.DataFechamento = leitor.GetDateTime("DataDfechamento_cai");

                    if (leitor["ValorInicial_cai"] != DBNull.Value)
                        caixa.ValorInicial = leitor.GetFloat("ValorInicial_cai");

                    if (leitor["ValorFinal_cai"] != DBNull.Value)
                        caixa.ValorFinal = leitor.GetFloat("ValorFinal_cai");

                    if (leitor["status_cai"] != DBNull.Value)
                        caixa.Status = leitor.GetString("status_cai");

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
}