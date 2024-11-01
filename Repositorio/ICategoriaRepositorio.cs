using LivroEC_V2.Models;

namespace LivroEC_V2.Repositorio
{
    public interface ICategoriaRepositorio
    {
        public IEnumerable<Categoria> Categorias { get; }
    }
}
