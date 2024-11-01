using LivroEC_V2.Data;
using LivroEC_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroEC_V2.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BancoContext _bancoContext;

        public LivroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IEnumerable<Livro> Livros => _bancoContext.Livros.Include(c => c.Categorias);

        public IEnumerable<Livro> LivrosPreferidos => _bancoContext.Livros.
                    Where(c => c.IsLivroPreferido)
                    .Include(c => c.Categorias);

        public Livro GetLivroByID(int livroId)
        {
            return _bancoContext.Livros.FirstOrDefault(c => c.LivroId == livroId);
        }
    }
}
