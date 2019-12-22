using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Weight = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    IdentificationNo = table.Column<string>(nullable: false),
                    IdentificationType = table.Column<string>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    PrimaryPhoneNo = table.Column<string>(nullable: false),
                    AdditionalPhoneNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    NumberOfChildren = table.Column<int>(nullable: false),
                    PreExistingConditions = table.Column<string>(nullable: true),
                    HadMajorSurgery = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TakafulPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    PaymentFrequency = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakafulPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PolicyNo = table.Column<string>(nullable: false),
                    OwnerFK = table.Column<Guid>(nullable: false),
                    SpouseFK = table.Column<Guid>(nullable: false),
                    PlanFK = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_TakafulPlan_Id",
                        column: x => x.Id,
                        principalTable: "TakafulPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Policy_Person_OwnerFK",
                        column: x => x.OwnerFK,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Policy_TakafulPlan_PlanFK",
                        column: x => x.PlanFK,
                        principalTable: "TakafulPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Policy_Person_SpouseFK",
                        column: x => x.SpouseFK,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Nomination",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NomineeFK = table.Column<Guid>(nullable: false),
                    RelationshipType = table.Column<string>(nullable: false),
                    PayoutPercentage = table.Column<double>(nullable: false),
                    PolicyFK = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nomination_Policy_Id",
                        column: x => x.Id,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Nomination_Person_NomineeFK",
                        column: x => x.NomineeFK,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Nomination_Policy_PolicyFK",
                        column: x => x.PolicyFK,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nomination_NomineeFK",
                table: "Nomination",
                column: "NomineeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Nomination_PolicyFK",
                table: "Nomination",
                column: "PolicyFK");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_OwnerFK",
                table: "Policy",
                column: "OwnerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PlanFK",
                table: "Policy",
                column: "PlanFK");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_SpouseFK",
                table: "Policy",
                column: "SpouseFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nomination");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "TakafulPlan");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
