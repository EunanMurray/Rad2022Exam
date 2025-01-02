using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rad2021MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "606823c7-81f9-40cc-8550-f43d32872f6c", "Committee Admin", "COMMITTEE ADMIN" },
                    { "2", "40af632e-cb9f-46e2-8b22-83ba9d3ec55a", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "7b688621-07ad-4793-a93d-473b646e2dac", "admin@terenurecc.ie", false, "Paul", "Dalton", false, null, "ADMIN@TERENURECC.IE", "ADMIN@TERENURECC.IE", "AQAAAAIAAYagAAAAEI0WxrnjvJvybZjeVGt/0Wlp4d+VrOlYUufVV77C88VQZX034DekBdhRPj+PSYyVkg==", null, false, "c28fcc26-a3e0-4639-8884-2c4027c1c175", false, "admin@terenurecc.ie" },
                    { "2", 0, "fe4d5afa-b12c-4acf-954f-13a9b298ecda", "bloggsb@terenurecc.ie", false, "Bill", "Bloggs", false, null, "BLOGGSB@TERENURECC.IE", "BLOGGSB@TERENURECC.IE", "AQAAAAIAAYagAAAAEAPkybqINFmCF7LXPWIcAvglzINDOh21Jy/4c17zzBzeuK9c1UJKPcPV/aGiit1aLw==", null, false, "fc7a774d-0c7e-4df9-a05e-0c1160e928d1", false, "bloggsb@terenurecc.ie" },
                    { "3", 0, "72c91bc8-17fd-4d48-96f7-ce149ff44098", "blighb@terenurecc.ie", false, "Mary", "Bligh", false, null, "BLIGHB@TERENURECC.IE", "BLIGHB@TERENURECC.IE", "AQAAAAIAAYagAAAAEBVrYijfdlla8nqXWlZtzS6ZFuTpiz7a8el2EyjFMx+uNolZMfBW3NLQ40a6gCzGEg==", null, false, "233052fb-abdd-44c1-a680-ea8ab3dc5118", false, "blighb@terenurecc.ie" },
                    { "4", 0, "4dd8fa1b-60c2-4024-8907-2c65f87ca1c9", "rotterm@terenurecc.ie", false, "Martha", "Rotter", false, null, "ROTTERM@TERENURECC.IE", "ROTTERM@TERENURECC.IE", "AQAAAAIAAYagAAAAEB64KzC1biH/b0MO7C1q+5lzy51tKdwf37r/Z2Fkqn/poeSeQmdZkwkTl2o8mu2Y3Q==", null, false, "48d861db-4a10-4b07-b93b-fc8feccbdabb", false, "rotterm@terenurecc.ie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "1" },
                    { "1", "2" },
                    { "2", "2" },
                    { "2", "3" },
                    { "2", "4" }
                });
        }
    }
}
