using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class InitialModelSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    CountyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.CountyId);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementAgency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementAgency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guidline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guidline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naics = table.Column<string>(nullable: true),
                    SectorName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Occupancy = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WomanOwned = table.Column<bool>(nullable: true),
                    MinorityBusiness = table.Column<bool>(nullable: true),
                    VeteranOwned = table.Column<bool>(nullable: true),
                    Verified = table.Column<bool>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    BRCCode = table.Column<string>(nullable: false),
                    LanguageCode = table.Column<string>(nullable: true),
                    CountyId = table.Column<int>(nullable: false),
                    SectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.UniqueConstraint("AK_Business_BRCCode", x => x.BRCCode);
                    table.ForeignKey(
                        name: "FK_Business_County_CountyId",
                        column: x => x.CountyId,
                        principalTable: "County",
                        principalColumn: "CountyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Business_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    CertificateNumber = table.Column<string>(nullable: true),
                    AgencyId = table.Column<int>(nullable: false),
                    InspectionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspection_EnforcementAgency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "EnforcementAgency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspection_Business_CertificateNumber",
                        column: x => x.CertificateNumber,
                        principalTable: "Business",
                        principalColumn: "BRCCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "InspectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionGuideline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(nullable: false),
                    GuidlineId = table.Column<int>(nullable: false),
                    Pass = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionGuideline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionGuideline_Guidline_GuidlineId",
                        column: x => x.GuidlineId,
                        principalTable: "Guidline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionGuideline_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_CountyId",
                table: "Business",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_SectorId",
                table: "Business",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_AgencyId",
                table: "Inspection",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_CertificateNumber",
                table: "Inspection",
                column: "CertificateNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_InspectionTypeId",
                table: "Inspection",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionGuideline_GuidlineId",
                table: "InspectionGuideline",
                column: "GuidlineId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionGuideline_InspectionId",
                table: "InspectionGuideline",
                column: "InspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionGuideline");

            migrationBuilder.DropTable(
                name: "Guidline");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "EnforcementAgency");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "InspectionType");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
