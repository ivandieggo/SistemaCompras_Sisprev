using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddSolicitacaoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "TotalGeral",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompra",
                newName: "SolicitacaoCompras");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Item_SolicitacaoCompraId",
                table: "Items",
                newName: "IX_Items_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProdutoId",
                table: "Items",
                newName: "IX_Items_ProdutoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompras",
                table: "SolicitacaoCompras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("035bcfc9-b09f-462b-98bc-548c2eb954c6"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Produto_ProdutoId",
                table: "Items",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SolicitacaoCompras_SolicitacaoCompraId",
                table: "Items",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Produto_ProdutoId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_SolicitacaoCompras_SolicitacaoCompraId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompras",
                table: "SolicitacaoCompras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("035bcfc9-b09f-462b-98bc-548c2eb954c6"));

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompras",
                newName: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_SolicitacaoCompraId",
                table: "Item",
                newName: "IX_Item_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProdutoId",
                table: "Item",
                newName: "IX_Item_ProdutoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGeral",
                table: "SolicitacaoCompra",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
