using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroEC_V2.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }
        [Required(ErrorMessage = "O título deve ser informado")]
        [Display(Name = "Titulo do livro")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O título deve ser informado")]
        [Display(Name = "Descrição do livro")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não deve exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "Informe o preço do livro")]
        [Display(Name = "Preço R$")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999,999")]
        public decimal Preco { get; set; }
        [Display(Name = "Imagem")]
        public string CaminhoImagem { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsLivroPreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categorias { get; set; }
    }
}
