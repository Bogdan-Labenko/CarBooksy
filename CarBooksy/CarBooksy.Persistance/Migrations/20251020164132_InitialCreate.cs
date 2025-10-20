using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooksy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Address_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Address_Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactInfo_Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ContactInfo_Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactInfo_Fax = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NIP = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.CheckConstraint("CK_Companies_NIP_Length", "CHAR_LENGTH(TRIM(BOTH FROM \"NIP\")) =  10");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Make = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    VinCode = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    PlateNumber = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    BodyType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.CheckConstraint("CK_Cars_ProductionYear_Range", "\"ProductionYear\" BETWEEN 1900 AND EXTRACT(YEAR FROM CURRENT_DATE)");
                    table.CheckConstraint("CK_Cars_VinCode_Length", "CHAR_LENGTH(TRIM(BOTH FROM \"VinCode\")) = 17");
                    table.CheckConstraint("CK_Cars_VinCode_Upper", "\"VinCode\" = UPPER(\"VinCode\")");
                    table.ForeignKey(
                        name: "FK_Cars_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ContactInfo_Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ContactInfo_Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactInfo_Fax = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CK_Users_Birthday_MinYear", "\"Birthday\" >= DATE '1900-01-01'");
                    table.CheckConstraint("CK_Users_Birthday_NotFuture", "\"Birthday\" <= CURRENT_DATE");
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CompanyId",
                table: "Cars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PlateNumber",
                table: "Cars",
                column: "PlateNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_NIP",
                table: "Companies",
                column: "NIP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactInfo_Email",
                table: "Users",
                column: "ContactInfo_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactInfo_Phone",
                table: "Users",
                column: "ContactInfo_Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
