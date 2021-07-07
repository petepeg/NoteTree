using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteTree.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ParentNode = table.Column<int>(type: "INTEGER", nullable: true),
                    data = table.Column<string>(type: "TEXT", nullable: true),
                    TreeDocumentId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocNode_TreeDocuments_TreeDocumentId",
                        column: x => x.TreeDocumentId,
                        principalTable: "TreeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocNode_TreeDocumentId",
                table: "DocNode",
                column: "TreeDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocNode");

            migrationBuilder.DropTable(
                name: "TreeDocuments");
        }
    }
}
