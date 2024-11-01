using System.ComponentModel.DataAnnotations.Schema;

namespace LivroEC_V2.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
