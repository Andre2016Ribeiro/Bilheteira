using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bilheteiraaplicacao.Migrations
{
    public partial class Versao01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salas",
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
                    table.PrimaryKey("PK_Salas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEspetaculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEspetaculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Espetaculos",
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
                    table.PrimaryKey("PK_Espetaculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Espetaculos_TipoEspetaculos_TipoEspetaculoId",
                        column: x => x.TipoEspetaculoId,
                        principalTable: "TipoEspetaculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilhetes",
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
                    table.PrimaryKey("PK_Bilhetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Espetaculos_EspetaculoId",
                        column: x => x.EspetaculoId,
                        principalTable: "Espetaculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BilheteId = table.Column<int>(type: "int", nullable: true),
                    UtilizadorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Bilhetes_BilheteId",
                        column: x => x.BilheteId,
                        principalTable: "Bilhetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Id", "Endereco", "Nome", "NumLugares" },
                values: new object[,]
                {
                    { 1, "Porto", "Cineteatro", 50 },
                    { 2, "Porto", "Batalha", 40 },
                    { 3, "Braga", "Circo", 50 },
                    { 4, "Guimaraes", "Mamede", 30 }
                });

            migrationBuilder.InsertData(
                table: "TipoEspetaculos",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Musical" },
                    { 2, "Teatro" }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "Name", "UserName" },
                values: new object[,]
                {
                    { 1, "ze Pintas", "zepin" },
                    { 2, "Maria Calas Pintas", "macalas" },
                    { 3, "Jose oliveira", "zeo" },
                    { 4, "jonana souzas", "jasou" }
                });

            migrationBuilder.InsertData(
                table: "Espetaculos",
                columns: new[] { "Id", "Descricao", "Elenco", "Name", "TipoEspetaculoId" },
                values: new object[,]
                {
                    { 1, null, null, "Lago dos cisnes", 1 },
                    { 2, null, null, "Fantas da opera", 1 },
                    { 3, null, null, "Fanoches", 2 },
                    { 4, null, null, "Princepesinho", 2 }
                });

            migrationBuilder.InsertData(
                table: "Bilhetes",
                columns: new[] { "Id", "DataEspetaculo", "EspetaculoId", "NumBilhetes", "Preco", "SalaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 19, 13, 6, 25, 247, DateTimeKind.Local).AddTicks(804), 1, 20, 50, 2 },
                    { 2, new DateTime(2022, 11, 19, 13, 6, 25, 258, DateTimeKind.Local).AddTicks(3609), 2, 30, 40, 1 },
                    { 3, new DateTime(2022, 11, 19, 13, 6, 25, 258, DateTimeKind.Local).AddTicks(3637), 3, 60, 30, 4 },
                    { 4, new DateTime(2022, 11, 19, 13, 6, 25, 258, DateTimeKind.Local).AddTicks(3641), 3, 70, 70, 3 }
                });

            migrationBuilder.InsertData(
                table: "Vendas",
                columns: new[] { "Id", "BilheteId", "UtilizadorID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_EspetaculoId",
                table: "Bilhetes",
                column: "EspetaculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_SalaId",
                table: "Bilhetes",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Espetaculos_TipoEspetaculoId",
                table: "Espetaculos",
                column: "TipoEspetaculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_BilheteId",
                table: "Vendas",
                column: "BilheteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UtilizadorID",
                table: "Vendas",
                column: "UtilizadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Bilhetes");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Espetaculos");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "TipoEspetaculos");
        }
    }
}
