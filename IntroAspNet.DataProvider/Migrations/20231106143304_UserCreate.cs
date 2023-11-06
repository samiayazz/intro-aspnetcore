using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroAspNet.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class UserCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("72e52ab7-8dae-450a-a809-522ee8762a6a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("75331805-46d0-41ce-a548-134755dd6974"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ImageId", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1f409c5b-8ae7-46c2-b956-1778d35c3403"), new Guid("bcfffae0-0887-418a-9ec6-88d103b61dfe"), "Article 1 Content", new DateTime(2023, 11, 6, 17, 33, 4, 88, DateTimeKind.Local).AddTicks(1864), "sa", null, null, new Guid("88fd2790-9df1-49ec-832e-af8ca7ca4349"), "Article 1", null, null },
                    { new Guid("4a88ec77-0b62-49a5-9aec-ae9038bd41bf"), new Guid("5040350e-2655-4b91-9a39-233ecf87e0c4"), "Article 2 Content", new DateTime(2023, 11, 6, 17, 33, 4, 88, DateTimeKind.Local).AddTicks(1888), "sa", null, null, new Guid("4a765bfa-780c-4c8f-ab94-22f66a2555aa"), "Article 2", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("985da856-3ea2-4780-a7e4-70ddd53b1c3d"), "b05fe868-533e-41bd-81f9-2c73fc9bbfa5", "admin", "Admin" },
                    { new Guid("d54c4496-db72-4c3b-8663-a54c6ba49c5f"), "77de789c-5577-419d-8a95-38afba9adf57", "user", "User" },
                    { new Guid("f73b57e4-c2b5-4a85-8edb-f12be6d2e740"), "8f0b5776-78e5-48ec-bd79-b2e9e90c4586", "superadmin", "Super Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5175a01d-0798-4e23-91da-3d375c565188"), 0, "559dd2fd-4b98-4f44-a74b-13ab0467aaf2", "samiayaz@gmail.com", true, false, null, "Sami", "Sami Ayaz @ Gmail", "Sami Ayaz", "AQAAAAEAACcQAAAAEKO7mH5NehyItmu1jcQ/talPcUuxI0T+XIcSPc50HyN1K1ekfy0oa4dJtQb5nn1zQA==", "5539592102", true, "69094bcd-d876-4a52-b378-a372579f648d", "AYAZ", false, "samiayaz" },
                    { new Guid("643ec9dd-3c9e-4778-bbc6-7ae19b3c6896"), 0, "d73b98f7-92b5-4a6b-9068-d16031ff198b", "sefaayaz@gmail.com", true, false, null, "Sefa", "Sefa Ayaz @ Gmail", "Sefa Ayaz", "AQAAAAEAACcQAAAAEBPa7/4ZZ5qRfbVqPHG77KllyYGARj6isJzi8mZzp6rxiVKQsnFvfMy9DdBWdss2IQ==", "1234567890", true, "c856fb83-898e-43aa-9ef0-a3764de227e2", "AYAZ", false, "sefaayaz" },
                    { new Guid("c36f5ad6-3914-4c98-aebb-6abede07c656"), 0, "7cfa52db-4030-4e7c-bd6d-2caf7e46d075", "numanayaz@gmail.com", true, false, null, "Numan", "Numan Ayaz @ Gmail", "Numan Ayaz", "AQAAAAEAACcQAAAAEMYwp8uztzger60hDGGfiTQGaLXpVGKTGcnsvfzkvh8kl1rtUu/WVba+ZHMLWa62NQ==", "1234567890", true, "a4f73db9-d5d9-4313-bb70-b28fcd7ff2c3", "AYAZ", false, "numanayaz" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5040350e-2655-4b91-9a39-233ecf87e0c4"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 17, 33, 4, 88, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcfffae0-0887-418a-9ec6-88d103b61dfe"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 17, 33, 4, 88, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4a765bfa-780c-4c8f-ab94-22f66a2555aa"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 17, 33, 4, 88, DateTimeKind.Local).AddTicks(2953));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("88fd2790-9df1-49ec-832e-af8ca7ca4349"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 17, 33, 4, 88, DateTimeKind.Local).AddTicks(2937));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f73b57e4-c2b5-4a85-8edb-f12be6d2e740"), new Guid("5175a01d-0798-4e23-91da-3d375c565188") },
                    { new Guid("985da856-3ea2-4780-a7e4-70ddd53b1c3d"), new Guid("643ec9dd-3c9e-4778-bbc6-7ae19b3c6896") },
                    { new Guid("d54c4496-db72-4c3b-8663-a54c6ba49c5f"), new Guid("c36f5ad6-3914-4c98-aebb-6abede07c656") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1f409c5b-8ae7-46c2-b956-1778d35c3403"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4a88ec77-0b62-49a5-9aec-ae9038bd41bf"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ImageId", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("72e52ab7-8dae-450a-a809-522ee8762a6a"), new Guid("5040350e-2655-4b91-9a39-233ecf87e0c4"), "Article 2 Content", new DateTime(2023, 11, 4, 19, 4, 33, 742, DateTimeKind.Local).AddTicks(4936), "sa", null, null, new Guid("4a765bfa-780c-4c8f-ab94-22f66a2555aa"), "Article 2", null, null },
                    { new Guid("75331805-46d0-41ce-a548-134755dd6974"), new Guid("bcfffae0-0887-418a-9ec6-88d103b61dfe"), "Article 1 Content", new DateTime(2023, 11, 4, 19, 4, 33, 742, DateTimeKind.Local).AddTicks(4919), "sa", null, null, new Guid("88fd2790-9df1-49ec-832e-af8ca7ca4349"), "Article 1", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5040350e-2655-4b91-9a39-233ecf87e0c4"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 4, 19, 4, 33, 742, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcfffae0-0887-418a-9ec6-88d103b61dfe"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 4, 19, 4, 33, 742, DateTimeKind.Local).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4a765bfa-780c-4c8f-ab94-22f66a2555aa"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 4, 19, 4, 33, 742, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("88fd2790-9df1-49ec-832e-af8ca7ca4349"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 4, 19, 4, 33, 742, DateTimeKind.Local).AddTicks(5987));
        }
    }
}
