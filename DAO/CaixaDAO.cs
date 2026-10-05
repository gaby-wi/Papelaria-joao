namespace AppPapelaria1.DAO;

using AppPapelaria1.Config;
using AppPapelaria1.Model;
using System;
using System.Collections.Generic;

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

            string sql = "SELECT * FROM Caixa ORDER BY id_cai DESC";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var caixa = new Caixa
                {
                    Id = leitor.GetInt32("id_cai"),

                    DataAbertura = leitor.IsDBNull(leitor.GetOrdinal("data_abertura_cai"))
                        ? null
                        : leitor.GetDateTime("data_abertura_cai"),

                    DataFechamento = leitor.IsDBNull(leitor.GetOrdinal("data_fechamento_cai"))
                        ? null
                        : leitor.GetDateTime("data_fechamento_cai"),

                    ValorInicial = leitor.GetFloat("valor_inicial_cai"),

                    ValorFinal = leitor.IsDBNull(leitor.GetOrdinal("valor_final_cai"))
                        ? null
                        : leitor.GetFloat("valor_final_cai"),

                    IdFuncionario = leitor.GetInt32("id_fun_fk")
                };

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

            comando.Parameters.AddWithValue("@dataAbertura", (object?)caixa.DataAbertura ?? DBNull.Value);
            comando.Parameters.AddWithValue("@dataFechamento", (object?)caixa.DataFechamento ?? DBNull.Value);
            comando.Parameters.AddWithValue("@valorInicial", caixa.ValorInicial);
            comando.Parameters.AddWithValue("@valorFinal", (object?)caixa.ValorFinal ?? DBNull.Value);
            comando.Parameters.AddWithValue("@idFuncionario", caixa.IdFuncionario);

            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }
}