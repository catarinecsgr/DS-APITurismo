using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Turismo_Catsy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtrativoTuristicos",
                columns: table => new
                {
                    IdAtrativo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Gratuidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaGratuidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regiao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtrativoTuristicos", x => x.IdAtrativo);
                });

            migrationBuilder.CreateTable(
                name: "TipoTuristicos",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Segmento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTuristicos", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "AtrativoTipos",
                columns: table => new
                {
                    IdAtrativo = table.Column<int>(type: "int", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtrativoTipos", x => new { x.IdAtrativo, x.IdTipo });
                    table.ForeignKey(
                        name: "FK_AtrativoTipos_AtrativoTuristicos_IdAtrativo",
                        column: x => x.IdAtrativo,
                        principalTable: "AtrativoTuristicos",
                        principalColumn: "IdAtrativo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtrativoTipos_TipoTuristicos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TipoTuristicos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AtrativoTuristicos",
                columns: new[] { "IdAtrativo", "DiaGratuidade", "Endereco", "Foto", "Gratuidade", "Nome", "Regiao" },
                values: new object[,]
                {
                    { 1, "Terça e 1ª Quinta de cada mês", "Av. Paulista, 1578, Bela Vista, São Paulo - SP", null, "V", "MASP", 5 },
                    { 2, "Todos os dias", "Av. Rio Branco, 1269, Campos Elíseos, São Paulo - SP", null, "V", "Museu das Favelas", 5 },
                    { 3, "Sábado", "Praça da Luz, 2, Luz, São Paulo - SP", null, "V", "Pinacoteca do Estado", 5 },
                    { 4, "Sábado", "Praça da Luz, s/n, Luz, São Paulo - SP", null, "V", "Museu da Língua Portuguesa", 5 },
                    { 5, "Todos os dias", "R. Álvares Penteado, 112, Centro Histórico de São Paulo, São Paulo - SP", null, "V", "CCBB SP", 5 },
                    { 6, "Todos os dias", "Av. Pedro Álvares Cabral, 5300, Vila Mariana, São Paulo - SP", null, "V", "Parque do Ibirapuera", 4 },
                    { 7, "Todos os dias", "Av. Prof. Fonseca Rodrigues, 2001, Alto de Pinheiros, São Paulo - SP", null, "V", "Parque Villa-Lobos", 3 },
                    { 8, "Todos os dias", "Av. Afonso de Sampaio e Sousa, 951, Itaquera, São Paulo - SP", null, "V", "Parque do Carmo", 2 },
                    { 9, "Todos os dias", "Av. Francisco Matarazzo, 455, Água Branca, São Paulo - SP", null, "V", "Parque da Água Branca", 3 },
                    { 10, "Todos os dias", "Av. Henrique Chamma, 420, Pinheiros, São Paulo - SP", null, "V", "Parque do Povo", 3 },
                    { 11, " ", "R. Américo de Campos, 36, Liberdade, São Paulo - SP", null, "F", "Alteza Doceria", 5 },
                    { 12, " ", "Av. São Luís, 187, piso 02, lj 02, República, São Paulo - SP", null, "F", "Gatcha (Cat Café/Cat Matcha Café)", 5 },
                    { 13, " ", "R. Maria Cândida, 1153, Vila Guilherme, São Paulo - SP", null, "F", "Antique Café", 1 },
                    { 14, " ", "Av. Ipiranga, 200-21, Centro Histórico de São Paulo, São Paulo - SP", null, "F", "Café Floresta", 5 },
                    { 15, " ", "R. Silveira Martins, 86, lj 02, Sé, São Paulo - SP", null, "F", "Cafeteria Gosto de Grão", 5 }
                });

            migrationBuilder.InsertData(
                table: "TipoTuristicos",
                columns: new[] { "IdTipo", "Segmento" },
                values: new object[,]
                {
                    { 1, "Museu" },
                    { 2, "Parque" },
                    { 3, "Cafeteria" }
                });

            migrationBuilder.InsertData(
                table: "AtrativoTipos",
                columns: new[] { "IdAtrativo", "IdTipo" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtrativoTipos_IdTipo",
                table: "AtrativoTipos",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtrativoTipos");

            migrationBuilder.DropTable(
                name: "AtrativoTuristicos");

            migrationBuilder.DropTable(
                name: "TipoTuristicos");
        }
    }
}
