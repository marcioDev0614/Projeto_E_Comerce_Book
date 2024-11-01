using LivroEC_V2.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LivroEC_V2.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaMenu(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepositorio.Categorias.OrderBy(x => x.CategoriaNome);
            return View(categorias);
        }
    }
}
