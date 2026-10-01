using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AppPapelaria1.Model
{
    public class Funcionario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF deve ter no máximo 14 caracteres.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sexo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O sexo deve ter no máximo 50 caracteres.")]
        public string Sexo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(200, ErrorMessage = "O email deve ter no máximo 200 caracteres.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; } = string.Empty;
    }

}
