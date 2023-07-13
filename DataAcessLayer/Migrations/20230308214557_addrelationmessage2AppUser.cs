using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcessLayer.Migrations
{
    public partial class addrelationmessage2AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writer_ReceiverID",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writer_SenderID",
                table: "Message2s");

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
                name: "FK_Message2s_AspNetUsers_ReceiverID",
                table: "Message2s",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_SenderID",
                table: "Message2s",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_ReceiverID",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_SenderID",
                table: "Message2s");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writer_ReceiverID",
                table: "Message2s",
                column: "ReceiverID",
                principalTable: "Writer",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writer_SenderID",
                table: "Message2s",
                column: "SenderID",
                principalTable: "Writer",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
