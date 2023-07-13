using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcessLayer.Migrations
{
    public partial class yenimig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writer_WriterID",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writer_WriterID1",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_WriterID",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_WriterID1",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "WriterID1",
                table: "Message2s");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WriterID1",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_WriterID",
                table: "Message2s",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_WriterID1",
                table: "Message2s",
                column: "WriterID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writer_WriterID",
                table: "Message2s",
                column: "WriterID",
                principalTable: "Writer",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writer_WriterID1",
                table: "Message2s",
                column: "WriterID1",
                principalTable: "Writer",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
