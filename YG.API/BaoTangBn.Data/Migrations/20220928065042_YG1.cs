using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YG.Data.Migrations
{
    public partial class YG1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAttribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtkBase = table.Column<int>(type: "int", nullable: false),
                    DefBase = table.Column<int>(type: "int", nullable: false),
                    SpeedBase = table.Column<int>(type: "int", nullable: false),
                    StrengBase = table.Column<int>(type: "int", nullable: false),
                    AdRateAtk = table.Column<int>(type: "int", nullable: false),
                    ApRateAtk = table.Column<int>(type: "int", nullable: false),
                    AdRateDef = table.Column<int>(type: "int", nullable: false),
                    ApRateDef = table.Column<int>(type: "int", nullable: false),
                    Tenacity = table.Column<int>(type: "int", nullable: false),
                    Intelligent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtkBase = table.Column<int>(type: "int", nullable: false),
                    DefBase = table.Column<int>(type: "int", nullable: false),
                    SpeedBase = table.Column<int>(type: "int", nullable: false),
                    StrengBase = table.Column<int>(type: "int", nullable: false),
                    AdRateAtk = table.Column<int>(type: "int", nullable: false),
                    ApRateAtk = table.Column<int>(type: "int", nullable: false),
                    AdRateDef = table.Column<int>(type: "int", nullable: false),
                    ApRateDef = table.Column<int>(type: "int", nullable: false),
                    Tenacity = table.Column<int>(type: "int", nullable: false),
                    Intelligent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Atk = table.Column<int>(type: "int", nullable: false),
                    Def = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Monter_Attribute_AtributeId",
                        column: x => x.AtributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monter_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monter_AtributeId",
                table: "Monter",
                column: "AtributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Monter_TypeId",
                table: "Monter",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monter");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
