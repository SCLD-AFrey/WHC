using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHC.CommonLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetAddress1 = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress2 = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "NonUSAddress",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress1 = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress2 = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonUSAddress", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserOid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserOid);
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UserOid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_Credential_Users_UserOid",
                        column: x => x.UserOid,
                        principalTable: "Users",
                        principalColumn: "UserOid");
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    AddressType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserOid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_EmailAddress_Users_UserOid",
                        column: x => x.UserOid,
                        principalTable: "Users",
                        principalColumn: "UserOid");
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempt",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Attempted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserOid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempt", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_LoginAttempt_Users_UserOid",
                        column: x => x.UserOid,
                        principalTable: "Users",
                        principalColumn: "UserOid");
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    UserOid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Users_UserOid",
                        column: x => x.UserOid,
                        principalTable: "Users",
                        principalColumn: "UserOid");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    UserOid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserOid",
                        column: x => x.UserOid,
                        principalTable: "Users",
                        principalColumn: "UserOid");
                });

            migrationBuilder.CreateTable(
                name: "UsAddress",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    UserOid = table.Column<int>(type: "INTEGER", nullable: true),
                    StreetAddress1 = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress2 = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsAddress", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_UsAddress_Users_UserOid",
                        column: x => x.UserOid,
                        principalTable: "Users",
                        principalColumn: "UserOid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credential_UserOid",
                table: "Credential",
                column: "UserOid");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_UserOid",
                table: "EmailAddress",
                column: "UserOid");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempt_UserOid",
                table: "LoginAttempt",
                column: "UserOid");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_UserOid",
                table: "PhoneNumber",
                column: "UserOid");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserOid",
                table: "Roles",
                column: "UserOid");

            migrationBuilder.CreateIndex(
                name: "IX_UsAddress_UserOid",
                table: "UsAddress",
                column: "UserOid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "LoginAttempt");

            migrationBuilder.DropTable(
                name: "NonUSAddress");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UsAddress");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
