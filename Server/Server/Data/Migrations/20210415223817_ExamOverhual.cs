using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class ExamOverhual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_Exams_ExamId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamParticipants",
                table: "ExamParticipants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnswer");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "UserAnswer",
                newName: "ExamAttemptId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswer_ExamId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_ExamAttemptId");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Exams",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ExamParticipants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExamParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ExamParticipants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ExamParticipants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamParticipants",
                table: "ExamParticipants",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExamParticipants_ExamId",
                table: "ExamParticipants",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_ExamParticipants_ExamAttemptId",
                table: "UserAnswer",
                column: "ExamAttemptId",
                principalTable: "ExamParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_ExamParticipants_ExamAttemptId",
                table: "UserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamParticipants",
                table: "ExamParticipants");

            migrationBuilder.DropIndex(
                name: "IX_ExamParticipants_ExamId",
                table: "ExamParticipants");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExamParticipants");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ExamParticipants");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ExamParticipants");

            migrationBuilder.RenameColumn(
                name: "ExamAttemptId",
                table: "UserAnswer",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswer_ExamAttemptId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_ExamId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserAnswer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ExamParticipants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamParticipants",
                table: "ExamParticipants",
                columns: new[] { "ExamId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Exams_ExamId",
                table: "UserAnswer",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
