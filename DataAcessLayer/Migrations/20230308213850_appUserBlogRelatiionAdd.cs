using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcessLayer.Migrations
{
    public partial class appUserBlogRelatiionAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writer_WriterID",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Blogs",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterID",
                table: "Blogs",
                newName: "IX_Blogs_AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserID",
                table: "Blogs",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserID",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Blogs",
                newName: "WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AppUserID",
                table: "Blogs",
                newName: "IX_Blogs_WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writer_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "Writer",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
