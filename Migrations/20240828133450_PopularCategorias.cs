using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivroEC_V2.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) " +
                                 "VALUES ('Romance','Gênero narrativo da prosa literária no qual há um maior detalhamento e sucessão de ações...')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) " +

                                "VALUES('Drama', 'Imita a ação direta dos indivíduos. Não se refere a Drama – classificação de características tristes...')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) " +
                                "VALUES('Novela', 'Narrativa em prosa intermediária ao romance e ao conto...')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) " +
                                "VALUES('Conto', 'Narrativa mais curta do que o romance e a novela...')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
