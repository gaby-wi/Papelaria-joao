using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace AppPapelaria1.Model
{
    public class Fornecedor
    {
       

        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O Nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(20, ErrorMessage = "O CNPJ deve ter no máximo 20 caracteres.")]
        public string Cnpj { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [StringLength(30, ErrorMessage = "O Telefone deve ter no máximo 30 caracteres.")]
        public string Telefone { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Endereço deve ter no máximo 100 caracteres.")]
        public string Endereco { get; set; } = string.Empty;

    }
}
