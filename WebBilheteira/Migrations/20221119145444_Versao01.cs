using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBilheteira.Migrations
{
    public partial class Versao01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumLugares = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEspetaculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEspetaculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Espetaculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elenco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEspetaculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espetaculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Espetaculo_TipoEspetaculo_TipoEspetaculoId",
                        column: x => x.TipoEspetaculoId,
                        principalTable: "TipoEspetaculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilhete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspetaculoId = table.Column<int>(type: "int", nullable: true),
                    SalaId = table.Column<int>(type: "int", nullable: true),
                    DataEspetaculo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumBilhetes = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhete_Espetaculo_EspetaculoId",
                        column: x => x.EspetaculoId,
                        principalTable: "Espetaculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bilhete_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BilheteId = table.Column<int>(type: "int", nullable: true),
                    UtilizadorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Bilhete_BilheteId",
                        column: x => x.BilheteId,
                        principalTable: "Bilhete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Utilizador_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Id", "Endereco", "Nome", "NumLugares" },
                values: new object[,]
                {
                    { 1, "Porto", "Cineteatro", 50 },
                    { 2, "Porto", "Batalha", 40 },
                    { 3, "Braga", "Circo", 50 },
                    { 4, "Guimaraes", "Mamede", 30 }
                });

            migrationBuilder.InsertData(
                table: "TipoEspetaculo",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Musical" },
                    { 2, "Teatro" }
                });

            migrationBuilder.InsertData(
                table: "Utilizador",
                columns: new[] { "Id", "Name", "UserName" },
                values: new object[,]
                {
                    { 1, "ze Pintas", "zepin" },
                    { 2, "Maria Calas Pintas", "macalas" },
                    { 3, "Jose oliveira", "zeo" },
                    { 4, "jonana souzas", "jasou" }
                });

            migrationBuilder.InsertData(
                table: "Espetaculo",
                columns: new[] { "Id", "Descricao", "Elenco", "Name", "TipoEspetaculoId" },
                values: new object[,]
                {
                    { 1, null, null, "Lago dos cisnes", 1 },
                    { 2, null, null, "Fantas da opera", 1 },
                    { 3, null, null, "Fanoches", 2 },
                    { 4, null, null, "Princepesinho", 2 }
                });

            migrationBuilder.InsertData(
                table: "Bilhete",
                columns: new[] { "Id", "DataEspetaculo", "EspetaculoId", "NumBilhetes", "Preco", "SalaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 19, 14, 54, 44, 124, DateTimeKind.Local).AddTicks(5234), 1, 20, 50, 2 },
                    { 2, new DateTime(2022, 11, 19, 14, 54, 44, 132, DateTimeKind.Local).AddTicks(8055), 2, 30, 40, 1 },
                    { 3, new DateTime(2022, 11, 19, 14, 54, 44, 132, DateTimeKind.Local).AddTicks(8078), 3, 60, 30, 4 },
                    { 4, new DateTime(2022, 11, 19, 14, 54, 44, 132, DateTimeKind.Local).AddTicks(8082), 3, 70, 70, 3 }
                });

            migrationBuilder.InsertData(
                table: "Venda",
                columns: new[] { "Id", "BilheteId", "UtilizadorID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_EspetaculoId",
                table: "Bilhete",
                column: "EspetaculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_SalaId",
                table: "Bilhete",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Espetaculo_TipoEspetaculoId",
                table: "Espetaculo",
                column: "TipoEspetaculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_BilheteId",
                table: "Venda",
                column: "BilheteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_UtilizadorID",
                table: "Venda",
                column: "UtilizadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Bilhete");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "Espetaculo");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "TipoEspetaculo");
        }
    }
}
