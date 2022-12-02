using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilevisHackathon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "People",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_TeamId",
                table: "People",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EventId",
                table: "Messages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PersonId",
                table: "Messages",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TeamId",
                table: "Messages",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Events_EventId",
                table: "Messages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_People_PersonId",
                table: "Messages",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Teams_TeamId",
                table: "Messages",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Teams_TeamId",
                table: "People",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Events_EventId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People_PersonId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teams_TeamId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Teams_TeamId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_TeamId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Messages_EventId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_PersonId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TeamId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
