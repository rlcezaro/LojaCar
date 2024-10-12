namespace LojaCar.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public int? Garantia { get; set; } // Nullable
        public decimal ValorVenda { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Comprador { get; set; }

        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }

        public int CarroId { get; set; }
        public Carro? Carro { get; set; }
    }


}
