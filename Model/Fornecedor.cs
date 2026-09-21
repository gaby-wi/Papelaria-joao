namespace AppPapelaria1.Model
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
