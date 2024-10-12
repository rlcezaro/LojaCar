namespace LojaCar.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string? Email { get; set; }
        public string? Fone { get; set; }
        public string? End { get; set; }
        public string? CPF { get; set; }

        public ICollection<Nota>? Notas { get; set; }
    }

}
