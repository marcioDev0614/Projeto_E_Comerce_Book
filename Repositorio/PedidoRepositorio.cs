using LivroEC_V2.Data;
using LivroEC_V2.Models;

namespace LivroEC_V2.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepositorio(BancoContext bancoContext, CarrinhoCompra carrinhoCompra)
        {
            _bancoContext = bancoContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _bancoContext.Pedidos.Add(pedido);
            _bancoContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LivroId = carrinhoItem.Livro.LivroId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Livro.Preco
                };

                _bancoContext.PedidoDetalhes.Add(pedidoDetail);
            }

            _bancoContext.SaveChanges();
        }
    }
}
