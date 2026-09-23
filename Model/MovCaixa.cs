namespace AppPapelaria1.Model;

public class MovCaixa
{
    public int Id { get; set; }
    public int IdCaixa { get; set; }
    public string Tipo { get; set; }
    public float Valor { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public string FormaPagamento { get; set; }
}