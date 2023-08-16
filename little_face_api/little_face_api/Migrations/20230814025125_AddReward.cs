using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace little_face_api.Migrations
{
    /// <inheritdoc />
    public partial class AddReward : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberFaceGood = table.Column<int>(type: "int", nullable: false),
                    NumberFaceBad = table.Column<int>(type: "int", nullable: false),
                    ValidateFaceGood = table.Column<bool>(type: "bit", nullable: false),
                    Recompense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reward_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reward_UserId",
                table: "Reward",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reward");
        }
    }
}
