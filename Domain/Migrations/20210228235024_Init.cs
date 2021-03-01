using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acconts",
                columns: table => new
                {
                    AccountId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    BankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acconts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Consultant",
                columns: table => new
                {
                    ConsultantId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.ConsultantId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantsVendors",
                columns: table => new
                {
                    ConsultantId = table.Column<string>(nullable: false),
                    VendorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantsVendors", x => new { x.ConsultantId, x.VendorId });
                    table.ForeignKey(
                        name: "FK_ConsultantsVendors_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantsVendors_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    ConsultantId = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Acconts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Acconts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantsVendors_VendorId",
                table: "ConsultantsVendors",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ConsultantId",
                table: "Transactions",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProjectId",
                table: "Transactions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VendorId",
                table: "Transactions",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantsVendors");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Acconts");

            migrationBuilder.DropTable(
                name: "Consultant");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
