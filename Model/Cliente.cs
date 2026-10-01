using System.ComponentModel.DataAnnotations;

namespace AppPapelaria1.Model;

public class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    public string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    public string Telefone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Sexo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    public string Endereco { get; set; } = string.Empty;
}