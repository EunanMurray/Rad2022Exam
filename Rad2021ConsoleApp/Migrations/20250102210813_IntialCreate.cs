using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rad2021ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareBalance = table.Column<double>(type: "float", nullable: false),
                    LoanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepaidInFull = table.Column<bool>(type: "bit", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "Address", "LoanID", "Name", "Phone", "ShareBalance" },
                values: new object[,]
                {
                    { 1, "8 Johnston Road, Dublin", 0, "Elizabeth Anderson", "(01)-12345322", 200.0 },
                    { 2, "Garden House Crowther Way, Dublin 20", 0, "Catherine Autier Miconi", "(01)-62634562", 400.0 },
                    { 3, "1900 Oak St., Dublin 4", 0, "Thomas Axen", "(01)-89377483", 2000.0 },
                    { 4, "8 Johnston Road, Dublin", 0, "John B. Aird", "(01)-12345322", 800.0 },
                    { 5, "8 Johnston Road, Dublin", 0, "Elizabeth Anderson", "(01)-12345322", 600.0 },
                    { 6, "8 Johnston Road, Dublin", 0, "Elizabeth Anderson", "(01)-12345322", 3000.0 },
                    { 7, "8 Johnston Road, Dublin", 0, "Elizabeth Anderson", "(01)-12345322", 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "ApplicationDate", "ApprovalDate", "Approved", "ApprovedBy", "LoanAmount", "MemberID", "RepaidInFull" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 67.00m, 1, false },
                    { 2, new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Paul", 315.00m, 1, true },
                    { 3, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Paul", 2089.00m, 2, false },
                    { 4, new DateTime(2020, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 6000.00m, 3, false },
                    { 5, new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 157.00m, 4, false },
                    { 6, new DateTime(2020, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bill", 4205.00m, 5, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberID",
                table: "Loans",
                column: "MemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
