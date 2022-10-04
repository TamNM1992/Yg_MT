using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YG.Data.Migrations
{
    public partial class YG6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter");

            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Type_TypeId",
                table: "Monter");

            migrationBuilder.DropIndex(
                name: "IX_Monter_AttributeId",
                table: "Monter");

            migrationBuilder.DropIndex(
                name: "IX_Monter_TypeId",
                table: "Monter");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "Monter");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Monter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttributeId",
                table: "Monter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Monter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monter_AttributeId",
                table: "Monter",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Monter_TypeId",
                table: "Monter",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monter_Type_TypeId",
                table: "Monter",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id");
        }
    }
}
