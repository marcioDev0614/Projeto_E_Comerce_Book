using LivroEC_V2.Data;
using LivroEC_V2.Models;

namespace LivroEC_V2.Repositorio
{

    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CategoriaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IEnumerable<Categoria> Categorias => _bancoContext.Categorias;
    }
}