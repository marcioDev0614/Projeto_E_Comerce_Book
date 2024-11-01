using LivroEC_V2.Models;
using LivroEC_V2.Repositorio;
using LivroEC_V2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroEC_V2.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILivroRepositorio livroRepositorio, CarrinhoCompra carrinhoCompra)
        {
            _livroRepositorio = livroRepositorio;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraVewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemDoCarrinhoCompra(int livroId)
        {
            var livroSelecionado = _livroRepositorio.Livros.FirstOrDefault(l => l.LivroId == livroId);

            if(livroSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(livroSelecionado);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int livroId)
        {
            var livroSelecionado = _livroRepositorio.Livros.FirstOrDefault(l => l.LivroId == livroId);

            if (livroSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(livroSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
