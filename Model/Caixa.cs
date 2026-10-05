using System.ComponentModel.DataAnnotations;

namespace AppPapelaria1.Model
{
    public class Caixa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data de abertura é obrigatória.")]
        public DateTime? DataAbertura { get; set; } = DateTime.Now;

        public DateTime? DataFechamento { get; set; }

        [Required(ErrorMessage = "O valor inicial é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor inicial não pode ser negativo.")]
        public float ValorInicial { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O valor final não pode ser negativo.")]
        public float? ValorFinal { get; set; }

        [Required(ErrorMessage = "O funcionário responsável é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um funcionário válido.")]
        public int IdFuncionario { get; set; }

        // Propriedade calculada para o Razor identificar se está aberto ou fechado
        public string Status => DataFechamento.HasValue ? "Fechado" : "Aberto";
    }
}