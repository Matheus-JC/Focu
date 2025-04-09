using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Focu.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityClaim_IdentityUsers_UserId",
                table: "IdentityClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin_IdentityUsers_UserId",
                table: "IdentityUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityUsers_UserId",
                table: "IdentityUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken_IdentityUsers_UserId",
                table: "IdentityUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserToken",
                table: "IdentityUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRole",
                table: "IdentityUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityClaim",
                table: "IdentityClaim");

            migrationBuilder.RenameTable(
                name: "IdentityUserToken",
                newName: "IdentityUserTokens");

            migrationBuilder.RenameTable(
                name: "IdentityUserRole",
                newName: "IdentityUserRoles");

            migrationBuilder.RenameTable(
                name: "IdentityUserLogin",
                newName: "IdentityUserLogins");

            migrationBuilder.RenameTable(
                name: "IdentityClaim",
                newName: "IdentityUserClaims");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserLogin_UserId",
                table: "IdentityUserLogins",
                newName: "IX_IdentityUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityClaim_UserId",
                table: "IdentityUserClaims",
                newName: "IX_IdentityUserClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserTokens",
                table: "IdentityUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRoles",
                table: "IdentityUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogins",
                table: "IdentityUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserClaims",
                table: "IdentityUserClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaims_IdentityUsers_UserId",
                table: "IdentityUserClaims",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogins_IdentityUsers_UserId",
                table: "IdentityUserLogins",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRoles_IdentityUsers_UserId",
                table: "IdentityUserRoles",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserTokens_IdentityUsers_UserId",
                table: "IdentityUserTokens",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaims_IdentityUsers_UserId",
                table: "IdentityUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogins_IdentityUsers_UserId",
                table: "IdentityUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRoles_IdentityUsers_UserId",
                table: "IdentityUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserTokens_IdentityUsers_UserId",
                table: "IdentityUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserTokens",
                table: "IdentityUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRoles",
                table: "IdentityUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogins",
                table: "IdentityUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserClaims",
                table: "IdentityUserClaims");

            migrationBuilder.RenameTable(
                name: "IdentityUserTokens",
                newName: "IdentityUserToken");

            migrationBuilder.RenameTable(
                name: "IdentityUserRoles",
                newName: "IdentityUserRole");

            migrationBuilder.RenameTable(
                name: "IdentityUserLogins",
                newName: "IdentityUserLogin");

            migrationBuilder.RenameTable(
                name: "IdentityUserClaims",
                newName: "IdentityClaim");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserLogins_UserId",
                table: "IdentityUserLogin",
                newName: "IX_IdentityUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserClaims_UserId",
                table: "IdentityClaim",
                newName: "IX_IdentityClaim_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserToken",
                table: "IdentityUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRole",
                table: "IdentityUserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityClaim",
                table: "IdentityClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityClaim_IdentityUsers_UserId",
                table: "IdentityClaim",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin_IdentityUsers_UserId",
                table: "IdentityUserLogin",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityUsers_UserId",
                table: "IdentityUserRole",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken_IdentityUsers_UserId",
                table: "IdentityUserToken",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
