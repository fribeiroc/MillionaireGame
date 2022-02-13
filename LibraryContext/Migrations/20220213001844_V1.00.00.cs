using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryContext.Migrations
{
    public partial class V10000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "A. Portugal" },
                    { 2, "B. Espanha" },
                    { 3, "C. Argentina" },
                    { 4, "D. Malta" },
                    { 5, "A. Gato" },
                    { 6, "B. Coelho" },
                    { 7, "C. Papagaio" },
                    { 8, "D. Coentros" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerId", "Description" },
                values: new object[] { 1, 2, "Qual destes está mais próximo de França?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerId", "Description" },
                values: new object[] { 2, 8, "Qual destes fala?" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
