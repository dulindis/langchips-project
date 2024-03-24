using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace langchips_project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Word = table.Column<string>(type: "TEXT", nullable: false),
                    Translation = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageOfWord = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageOfTranslation = table.Column<int>(type: "INTEGER", nullable: false),
                    HasVoiceOption = table.Column<bool>(type: "INTEGER", nullable: false),
                    DictionaryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
