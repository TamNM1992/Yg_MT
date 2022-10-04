using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YG.Data.Migrations
{
    public partial class YG2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Attribute_AtributeId",
                table: "Monter");

            migrationBuilder.RenameColumn(
                name: "AtributeId",
                table: "Monter",
                newName: "AttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_Monter_AtributeId",
                table: "Monter",
                newName: "IX_Monter_AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter");

            migrationBuilder.RenameColumn(
                name: "AttributeId",
                table: "Monter",
                newName: "AtributeId");

            migrationBuilder.RenameIndex(
                name: "IX_Monter_AttributeId",
                table: "Monter",
                newName: "IX_Monter_AtributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monter_Attribute_AtributeId",
                table: "Monter",
                column: "AtributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
