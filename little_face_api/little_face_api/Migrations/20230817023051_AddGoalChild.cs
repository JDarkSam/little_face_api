using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace little_face_api.Migrations
{
    /// <inheritdoc />
    public partial class AddGoalChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Face = table.Column<int>(type: "int", nullable: false),
                    DateGoal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChildId = table.Column<long>(type: "bigint", nullable: false),
                    GoalId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalChild_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalChild_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GoalChild_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoalChild_ChildId",
                table: "GoalChild",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalChild_GoalId",
                table: "GoalChild",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalChild_UserId",
                table: "GoalChild",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalChild");
        }
    }
}
