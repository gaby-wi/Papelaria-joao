
using AppPapelaria1.Config;
using AppPapelaria1.Model;
namespace AppPapelaria1.DAO;
    public class FornecedorDAO
    {
        private readonly Conexao _conexao;

        public FornecedorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Fornecedor> Listar()
        {
            try
            {
                var lista = new List<Fornecedor>();

                // Buscando a Conexão com o banco de dados
                using var con = _conexao.GetConnection();


                string sql = "SELECT * FROM fornecedor";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();



                while (leitor.Read())
                {
                    var fornecedor = new Fornecedor();
                    fornecedor.Id = leitor.GetInt32("id_for");
                    fornecedor.Nome = leitor.GetString("nome_fantasia_for");
                    fornecedor.Telefone = leitor.GetString("telefone_for");
                    fornecedor.Email = leitor.GetString("email_for");
                    fornecedor.Cnpj = leitor.GetString("cnpj_for");
                    fornecedor.Endereco = leitor.GetString("endereco_for");


                    lista.Add(fornecedor);
                }


                return lista;
            }
            catch
            {
                throw;
            }
        }
    public void Inserir(Fornecedor fornecedor)
    {
        try
        {
            //var fornecedor = new Fornecedor();
            //fornecedor.Id = leitor.GetInt32("id_for");
            //fornecedor.Nome = leitor.GetString("nome_fantasia_for");
            //fornecedor.Telefone = leitor.GetString("telefone_for");
            //fornecedor.Email = leitor.GetString("email_for");
            //fornecedor.Cnpj = leitor.GetString("cnpj_for");
            //fornecedor.Endereco = leitor.GetString("endereco_for");
    //        id_for int auto_increment primary key,
    //nome_fantasia_for varchar(150) not null,
    //telefone_for varchar(30),
    //endereco_for varchar(100),
    //cnpj_for varchar(20),
    //email_for varchar(100)
            using var con = _conexao.GetConnection();
            string sql = @"INSERT INTO fornecedor
                (nome_fantasia_for, telefone_for, endereco_for, cnpj_for, email_for)
                VALUES
                (@Nome, @Telefone, @Email, @Cnpj, @Endereco)";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;
            comando.Parameters.AddWithValue("@Nome", fornecedor.Nome);

            comando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
            comando.Parameters.AddWithValue("@Email", fornecedor.Email);

            comando.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
            comando.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);

            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }

}

