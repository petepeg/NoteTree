using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteTree.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocNodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentNodeId = table.Column<long>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocNodes_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocNodes_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "DocNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocNodes_DocumentId",
                table: "DocNodes",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocNodes");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
