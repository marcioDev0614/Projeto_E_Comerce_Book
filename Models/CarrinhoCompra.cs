using LivroEC_V2.Data;
using Microsoft.EntityFrameworkCore;

namespace LivroEC_V2.Models
{
    public class CarrinhoCompra
    {

        private readonly BancoContext _bancoContext;

        public CarrinhoCompra(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public void RemoverDoCarrinho(Livro livro)
        {
            var carrinhoCompraItem = _bancoContext.CarrinhoCompraItens.SingleOrDefault(
                c => c.Livro.LivroId == livro.LivroId && 
                c.CarrinhoCompraId == CarrinhoCompraId);

            //var quantidadeLocal = 0;

            if(carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    //quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _bancoContext.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _bancoContext.SaveChanges();
            //return quantidadeLocal;
        }
        public void AdicionarAoCarrinho(Livro livro)
        {
            var carrinhoCompraItem = _bancoContext.CarrinhoCompraItens.SingleOrDefault(
                c => c.Livro.LivroId == livro.LivroId && 
                c.CarrinhoCompraId == CarrinhoCompraId); 

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem 
                { 
                    CarrinhoCompraId = CarrinhoCompraId,
                    Livro = livro,
                    Quantidade = 1
                };

                _bancoContext.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _bancoContext.SaveChanges();
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _bancoContext.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Livro)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _bancoContext.CarrinhoCompraItens.
                Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _bancoContext.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _bancoContext.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _bancoContext.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Livro.Preco * c.Quantidade).Sum();

            return total;
        }


        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Defini uma sessão
            ISession session =  services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obter um serviço do tipo no contexto
            var context = services.GetService<BancoContext>();

            // Obter ou gerar o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // Atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
    }
}
