using LivroEC_V2.Models;
using LivroEC_V2.Repositorio;
using LivroEC_V2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LivroEC_V2.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [Authorize]
        public IActionResult List(string categoria)
        {
            // Código para rederizar na view a quantidade de livros no banco
            ViewBag.TotalDeLivros = _livroRepositorio.Livros.Count();

            IEnumerable<Livro> livros;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                livros = _livroRepositorio.Livros.OrderBy(l => l.LivroId);
                categoriaAtual = "Todos os livros";
            }
            else
            {
                //if (string.Equals("Política", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    livros = _livroRepositorio.Livros
                //        .Where(l => l.Categorias.CategoriaNome
                //        .Equals("Política"))
                //        .OrderBy(l => l.Titulo);
                //}
                //else
                //{
                //    livros = _livroRepositorio.Livros
                //                   .Where(l => l.Categorias.CategoriaNome
                //                   .Equals("Romance"))
                //                   .OrderBy(l => l.Titulo);
                //}

                livros = _livroRepositorio.Livros
                    .Where(l => l.Categorias.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Titulo);

                categoriaAtual = categoria;
            }

            var livrosListViewModel = new LivroListViewModel
            {
                Livros = livros,
                CategoriaAtual = categoria
            };

            return View(livrosListViewModel);
        }

        public IActionResult Details(int livroId)
        {
            var livro = _livroRepositorio.Livros.FirstOrDefault(l => l.LivroId == livroId);
            return View(livro);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Livro> livros;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                livros = _livroRepositorio.Livros.OrderBy(x => x.LivroId);
                categoriaAtual = "Todos os livros";
            }
            else
            {
                livros = _livroRepositorio.Livros
                    .Where(x => x.Titulo
                    .ToLower()
                    .Contains(searchString
                    .ToLower()));

                if(livros.Any())
                {
                    categoriaAtual = "Livros";
                }
                else
                
                    categoriaAtual = "Nenhum livro foi encontrado";
                                       
            }

            return View("~/Views/Livro/List.cshtml", new LivroListViewModel
            {
                Livros = livros,
                CategoriaAtual = categoriaAtual
            }) ;
        }
    }
}         


