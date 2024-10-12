namespace LojaCar.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string? Matricula { get; set; }
        public decimal Salario { get; set; }

        //public decimal ComissaoAcumulada { get; set; } // Novo campo

        public decimal CalcComissao()
        {
            // Implementação do cálculo de comissão
            return Salario * 0.1m; // Exemplo
        }

        public ICollection<Nota>? Notas { get; set; }
    }

}
