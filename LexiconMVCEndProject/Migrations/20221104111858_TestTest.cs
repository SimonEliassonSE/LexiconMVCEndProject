using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVCEndProject.Migrations
{
    public partial class TestTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a18a108-c833-499c-907e-f2e8b475a20f", "3f43054c-46de-43c5-901a-cb37820d89d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a18a108-c833-499c-907e-f2e8b475a20f", "430cbe72-a50e-4b07-b731-2c2a59e86eab" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a18a108-c833-499c-907e-f2e8b475a20f", "bc392b4a-48f8-4033-86e0-a3905d11992d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9336c3c7-d072-422d-a921-6828d891dd51", "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a18a108-c833-499c-907e-f2e8b475a20f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9336c3c7-d072-422d-a921-6828d891dd51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f43054c-46de-43c5-901a-cb37820d89d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430cbe72-a50e-4b07-b731-2c2a59e86eab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc392b4a-48f8-4033-86e0-a3905d11992d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e8e3c04-1269-4b4d-8204-c1a737403703", "2dbe8457-0392-46d9-98bf-5825bcf5d7fa", "User", "USER" },
                    { "6637157a-cdb8-4279-a105-418dd604282a", "649ba3aa-1ad6-4096-aa95-db553e7a730b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "34df0f82-895f-4bb6-a64c-d5b5db9c64d4", 0, "bac2ae10-79fa-4cd0-9ecd-1f9b65a516ba", "test4@test.se", false, false, null, "TEST4@TEST.SE", "TEST4@TEST.SE", "AQAAAAEAACcQAAAAENxjV49NB/OQ/pJgvoYmt9BzEaaIEcz+7Xu6aEZIZg+d+NBcizJhX/6ru4tcHzrG0A==", null, false, "b6608c3e-b910-4f68-9357-698eb063d842", false, "test4@test.se" },
                    { "617729b1-ff17-4e5b-9191-68e9697587a9", 0, "a2d00d83-6a1a-4d7a-ba6e-59df1a833d5e", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBs7m/2076kPG6IJhrevK2SgG7ckeO/B3fHA0dRlYawKuufVKYyKmmAztOVzLeq0aQ==", null, false, "33d2eb3d-535f-4dd9-ba4d-200bae737280", false, "admin@admin.com" },
                    { "bb8b013c-c9a0-44a8-a067-0f6fdd9e7045", 0, "8e51209d-5bdd-4716-8968-eee0bc959995", "test1@test.se", false, false, null, "TEST1@TEST.SE", "TEST1@TEST.SE", "AQAAAAEAACcQAAAAECW836VNNak7A0IK3Czq2WstAqPTFeJFI+8UBGeNSap0HuAvGh1jAKReQ/y0z6BvKw==", null, false, "0c9b7d39-60f7-4b3a-9ee9-3ba4b2fe7893", false, "test1@test.se" },
                    { "ebc0d83b-10bb-49a1-9d81-8fa69df1300c", 0, "8d8ff142-64e6-4230-96a3-e092cb1a502d", "test2@test.se", false, false, null, "TEST2@TEST.SE", "TEST2@TEST.SE", "AQAAAAEAACcQAAAAEFexe//KSEupvlrxmefl5PIb/SuxJRnvYWxZG1UXG0yluMdPZDcgjASS9klVHKl1yw==", null, false, "4d5738b6-17cf-411f-a671-ae1f6544b2fb", false, "test2@test.se" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1e8e3c04-1269-4b4d-8204-c1a737403703", "34df0f82-895f-4bb6-a64c-d5b5db9c64d4" },
                    { "6637157a-cdb8-4279-a105-418dd604282a", "617729b1-ff17-4e5b-9191-68e9697587a9" },
                    { "1e8e3c04-1269-4b4d-8204-c1a737403703", "bb8b013c-c9a0-44a8-a067-0f6fdd9e7045" },
                    { "1e8e3c04-1269-4b4d-8204-c1a737403703", "ebc0d83b-10bb-49a1-9d81-8fa69df1300c" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "bb8b013c-c9a0-44a8-a067-0f6fdd9e7045");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "ebc0d83b-10bb-49a1-9d81-8fa69df1300c");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "34df0f82-895f-4bb6-a64c-d5b5db9c64d4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e8e3c04-1269-4b4d-8204-c1a737403703", "34df0f82-895f-4bb6-a64c-d5b5db9c64d4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6637157a-cdb8-4279-a105-418dd604282a", "617729b1-ff17-4e5b-9191-68e9697587a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e8e3c04-1269-4b4d-8204-c1a737403703", "bb8b013c-c9a0-44a8-a067-0f6fdd9e7045" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e8e3c04-1269-4b4d-8204-c1a737403703", "ebc0d83b-10bb-49a1-9d81-8fa69df1300c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e8e3c04-1269-4b4d-8204-c1a737403703");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6637157a-cdb8-4279-a105-418dd604282a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34df0f82-895f-4bb6-a64c-d5b5db9c64d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "617729b1-ff17-4e5b-9191-68e9697587a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb8b013c-c9a0-44a8-a067-0f6fdd9e7045");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc0d83b-10bb-49a1-9d81-8fa69df1300c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "20cb26a4-c078-4aeb-b7b8-d9924495f702", "User", "USER" },
                    { "9336c3c7-d072-422d-a921-6828d891dd51", "91ae4c32-e26c-4e14-a2e1-8eaad6a9e8dc", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f43054c-46de-43c5-901a-cb37820d89d5", 0, "31e9a18b-c158-4a45-bc10-4f6c2653a791", "test1@test.se", false, false, null, "TEST1@TEST.SE", "TEST1@TEST.SE", "AQAAAAEAACcQAAAAEOe/6E1exg9/5RefZmhhy7g6/hr4v0Z/4/gxpl4opfp0EMUM3w/alOdXo6lT1XlHSA==", null, false, "87ff5e62-79d2-4408-9f29-ce86c261978f", false, "test1@test.se" },
                    { "430cbe72-a50e-4b07-b731-2c2a59e86eab", 0, "171fd790-9f45-486c-aea1-6768b38dfbfe", "test2@test.se", false, false, null, "TEST2@TEST.SE", "TEST2@TEST.SE", "AQAAAAEAACcQAAAAEOlg9Ji2D8Og9FbwRr9HAlvZH3cj068uFGnvblAYW1nHPXZ1Gt7N1qYZ2qjMDqyYFg==", null, false, "e5895a5d-c84a-4afc-ae67-558e8cc87dd9", false, "test2@test.se" },
                    { "bc392b4a-48f8-4033-86e0-a3905d11992d", 0, "1d3e368e-4b30-46b9-84ab-1e6b1e4a9e48", "test4@test.se", false, false, null, "TEST4@TEST.SE", "TEST4@TEST.SE", "AQAAAAEAACcQAAAAENLEBQr+jpXp90TOSjNpdQUNPwXX1ZHw5hvix/qMVlfeHSOLzH1oLIf3epBPU8VCxg==", null, false, "1d3ba67c-a45e-492d-bc48-fc5d22c1de71", false, "test4@test.se" },
                    { "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6", 0, "936f9de3-3274-4e5e-a452-e656fdfb52cd", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEL9aNTX+UhTPsZvv9ouMoNCmanxALoeLUQcR2GWy7iAZhzleoEDSYtSsQK3eZ6IlJw==", null, false, "93dd33a6-3020-4cbc-960d-dc31269357a2", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "3f43054c-46de-43c5-901a-cb37820d89d5" },
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "430cbe72-a50e-4b07-b731-2c2a59e86eab" },
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "bc392b4a-48f8-4033-86e0-a3905d11992d" },
                    { "9336c3c7-d072-422d-a921-6828d891dd51", "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "3f43054c-46de-43c5-901a-cb37820d89d5");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "430cbe72-a50e-4b07-b731-2c2a59e86eab");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "bc392b4a-48f8-4033-86e0-a3905d11992d");
        }
    }
}
