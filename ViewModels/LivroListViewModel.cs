using LivroEC_V2.Models;

namespace LivroEC_V2.ViewModels
{
    public class LivroListViewModel
    {
        public IEnumerable<Livro> Livros { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
