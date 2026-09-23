namespace AppPapelaria1.Model
{
    public class Caixa
    {
     
        
            public int Id { get; set; }
            public DateTime DataAbertura { get; set; }
            public DateTime DataFechamento { get; set; }
            public float ValorInicial { get; set; }
            public float ValorFinal { get; set; }
            public int IdFuncionario { get; set; }
        
    }
}
