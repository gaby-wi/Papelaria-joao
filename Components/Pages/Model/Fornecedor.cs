using Microsoft.AspNetCore.Http.HttpResults;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace AppPapelaria1.Components.Pages.Model
{
    public class Fornecedor
    {
       
        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty;

        public string Cnpj { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public string Observações { get; set; } = string.Empty;

    }
}
