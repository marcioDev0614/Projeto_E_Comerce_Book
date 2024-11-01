using LivroEC_V2.Models;

namespace LivroEC_V2.ViewModels
{
    public class PedidoLivroViewModel
    {
        public Pedido Pedido { get; set; }

        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
