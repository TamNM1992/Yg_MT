using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YG.Data.Migrations
{
    public partial class YG5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter");

            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Type_TypeId",
                table: "Monter");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Monter",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttributeId",
                table: "Monter",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Attribute",
                table: "Monter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Monter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter");

            migrationBuilder.DropForeignKey(
                name: "FK_Monter_Type_TypeId",
                table: "Monter");

            migrationBuilder.DropColumn(
                name: "Attribute",
                table: "Monter");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Monter");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Monter",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AttributeId",
                table: "Monter",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Monter_Attribute_AttributeId",
                table: "Monter",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monter_Type_TypeId",
                table: "Monter",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
