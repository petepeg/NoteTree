using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteTree.Migrations
{
    public partial class AddedDocTreeProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocNode_TreeDocuments_TreeDocumentId",
                table: "DocNode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocNode",
                table: "DocNode");

            migrationBuilder.RenameTable(
                name: "DocNode",
                newName: "DocNodes");

            migrationBuilder.RenameIndex(
                name: "IX_DocNode_TreeDocumentId",
                table: "DocNodes",
                newName: "IX_DocNodes_TreeDocumentId");

            migrationBuilder.AlterColumn<long>(
                name: "TreeDocumentId",
                table: "DocNodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocNodes",
                table: "DocNodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocNodes_TreeDocuments_TreeDocumentId",
                table: "DocNodes",
                column: "TreeDocumentId",
                principalTable: "TreeDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocNodes_TreeDocuments_TreeDocumentId",
                table: "DocNodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocNodes",
                table: "DocNodes");

            migrationBuilder.RenameTable(
                name: "DocNodes",
                newName: "DocNode");

            migrationBuilder.RenameIndex(
                name: "IX_DocNodes_TreeDocumentId",
                table: "DocNode",
                newName: "IX_DocNode_TreeDocumentId");

            migrationBuilder.AlterColumn<long>(
                name: "TreeDocumentId",
                table: "DocNode",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocNode",
                table: "DocNode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocNode_TreeDocuments_TreeDocumentId",
                table: "DocNode",
                column: "TreeDocumentId",
                principalTable: "TreeDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
