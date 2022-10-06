using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YG.Data.Migrations
{
    public partial class YG7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Des = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    TargetNum = table.Column<int>(type: "int", nullable: false),
                    CountDown = table.Column<int>(type: "int", nullable: false),
                    EffectiveTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonterSkill",
                columns: table => new
                {
                    MonterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonterSkill", x => new { x.MonterID, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MonterSkill_Monter_MonterID",
                        column: x => x.MonterID,
                        principalTable: "Monter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonterSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTypeSkill",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTypeSkill", x => new { x.SkillId, x.TypeSkillId });
                    table.ForeignKey(
                        name: "FK_SkillTypeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTypeSkill_TypeSkill_TypeSkillId",
                        column: x => x.TypeSkillId,
                        principalTable: "TypeSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonterSkill_SkillId",
                table: "MonterSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTypeSkill_TypeSkillId",
                table: "SkillTypeSkill",
                column: "TypeSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonterSkill");

            migrationBuilder.DropTable(
                name: "SkillTypeSkill");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "TypeSkill");
        }
    }
}
