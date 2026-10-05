using System.ComponentModel.DataAnnotations;

namespace AppPapelaria1.Model
{
    public class Estoque
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Quantidade Inicial é obrigatório.")]
        public string QuantidadeInicial { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Quantidade Final é obrigatório.")]
        public int QuantidadeFinal { get; set; }
        [Required(ErrorMessage = "O campo Id Produto é obrigatório.")]
        public decimal IdProduto { get; set; }
    }
}
