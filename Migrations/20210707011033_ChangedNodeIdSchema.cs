using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteTree.Migrations
{
    public partial class ChangedNodeIdSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentNode",
                table: "DocNode",
                newName: "ParentNodeId");

            migrationBuilder.AddColumn<long>(
                name: "NodeId",
                table: "DocNode",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "DocNode");

            migrationBuilder.RenameColumn(
                name: "ParentNodeId",
                table: "DocNode",
                newName: "ParentNode");
        }
    }
}
