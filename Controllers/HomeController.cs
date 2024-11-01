using LivroEC_V2.Models;
using LivroEC_V2.Repositorio;
using LivroEC_V2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LivroEC_V2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public HomeController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LivrosPreferidos = _livroRepositorio.LivrosPreferidos,
            };

            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}