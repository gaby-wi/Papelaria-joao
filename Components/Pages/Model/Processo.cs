namespace AppPapelaria1.Components.Pages.Model
{
    public class Processo
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public DateOnly Data { get; set; }

        public string Interresado { get; set; } = string.Empty;

        public string Assunto { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public string Situacao { get; set; } = "aberto";
    }
}
