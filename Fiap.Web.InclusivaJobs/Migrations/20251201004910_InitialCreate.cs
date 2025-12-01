using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.InclusivaJobs.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "INCLUSIVAJOBS");

            migrationBuilder.CreateSequence<int>(
                name: "VAGAS_SEQ",
                schema: "INCLUSIVAJOBS");

            migrationBuilder.CreateTable(
                name: "VAGAS",
                schema: "INCLUSIVAJOBS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITULO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    EMPRESA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SALARIO = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    OFERECE_ACESSIBILIDADE = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    RECURSOS_ACESSIBILIDADE = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    VAGAS_PCD = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    QUANTIDADE_VAGAS_PCD = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ATIVA = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DATA_EXPIRACAO = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGAS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_VAGAS_ATIVA",
                schema: "INCLUSIVAJOBS",
                table: "VAGAS",
                column: "ATIVA");

            migrationBuilder.CreateIndex(
                name: "IDX_VAGAS_DATA_EXP",
                schema: "INCLUSIVAJOBS",
                table: "VAGAS",
                column: "DATA_EXPIRACAO");

            migrationBuilder.CreateIndex(
                name: "IDX_VAGAS_PCD",
                schema: "INCLUSIVAJOBS",
                table: "VAGAS",
                column: "VAGAS_PCD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VAGAS",
                schema: "INCLUSIVAJOBS");

            migrationBuilder.DropSequence(
                name: "VAGAS_SEQ",
                schema: "INCLUSIVAJOBS");
        }
    }
}
