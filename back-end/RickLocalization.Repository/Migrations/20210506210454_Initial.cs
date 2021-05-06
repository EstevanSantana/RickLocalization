using Microsoft.EntityFrameworkCore.Migrations;

namespace RickLocalization.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rick",
                columns: table => new
                {
                    RickId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    Morty = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rick", x => x.RickId);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    ViagemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TempoViagem = table.Column<string>(maxLength: 50, nullable: false),
                    Data = table.Column<string>(maxLength: 15, nullable: false),
                    RickId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.ViagemId);
                    table.ForeignKey(
                        name: "FK_Viagem_Rick_RickId",
                        column: x => x.RickId,
                        principalTable: "Rick",
                        principalColumn: "RickId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dimencao",
                columns: table => new
                {
                    IdDimencao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDimensao = table.Column<string>(maxLength: 50, nullable: false),
                    Planeta = table.Column<string>(maxLength: 50, nullable: false),
                    Ano = table.Column<string>(maxLength: 50, nullable: false),
                    RickId = table.Column<int>(nullable: true),
                    ViagemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimencao", x => x.IdDimencao);
                    table.ForeignKey(
                        name: "FK_Dimencao_Rick_RickId",
                        column: x => x.RickId,
                        principalTable: "Rick",
                        principalColumn: "RickId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dimencao_Viagem_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagem",
                        principalColumn: "ViagemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimencao_RickId",
                table: "Dimencao",
                column: "RickId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dimencao_ViagemId",
                table: "Dimencao",
                column: "ViagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_RickId",
                table: "Viagem",
                column: "RickId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimencao");

            migrationBuilder.DropTable(
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "Rick");
        }
    }
}
