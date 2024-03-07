using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeTree.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TreeNodes_Name",
                table: "TreeNodes",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TreeNodes_Name",
                table: "TreeNodes");
        }
    }
}
