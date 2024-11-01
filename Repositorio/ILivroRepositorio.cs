using LivroEC_V2.Models;

namespace LivroEC_V2.Repositorio
{
    public interface ILivroRepositorio
    {
        public IEnumerable<Livro> Livros { get; }

        public IEnumerable<Livro> LivrosPreferidos { get; }

        public Livro GetLivroByID(int livroId);
    }
}
