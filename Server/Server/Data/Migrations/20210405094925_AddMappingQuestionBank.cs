using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddMappingQuestionBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId_ExamEntryCode",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId_ExamEntryCode",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ExamEntryCode",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    ExamsId = table.Column<int>(type: "int", nullable: false),
                    ExamsEntryCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.QuestionsId, x.ExamsId, x.ExamsEntryCode });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exams_ExamsId_ExamsEntryCode",
                        columns: x => new { x.ExamsId, x.ExamsEntryCode },
                        principalTable: "Exams",
                        principalColumns: new[] { "Id", "EntryCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamsId_ExamsEntryCode",
                table: "ExamQuestion",
                columns: new[] { "ExamsId", "ExamsEntryCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.AddColumn<string>(
                name: "ExamEntryCode",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId_ExamEntryCode",
                table: "Questions",
                columns: new[] { "ExamId", "ExamEntryCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId_ExamEntryCode",
                table: "Questions",
                columns: new[] { "ExamId", "ExamEntryCode" },
                principalTable: "Exams",
                principalColumns: new[] { "Id", "EntryCode" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
