namespace AppPapelaria1.Model
{
    public class Financeiro
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        public int IdFuncionario { get; set; }
        public int IdVenda { get; set; }
    }
}