using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilevisHackathon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventAndTeamMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMessages_Messages_MessageId",
                table: "EventMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMessages_Messages_MessageId",
                table: "TeamMessages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMessages",
                table: "TeamMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMessages",
                table: "EventMessages");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "TeamMessages",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "EventMessages",
                newName: "AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeamMessages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "TeamMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventMessages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "EventMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMessages",
                table: "TeamMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMessages",
                table: "EventMessages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMessages_AuthorId",
                table: "TeamMessages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventMessages_AuthorId",
                table: "EventMessages",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMessages_People_AuthorId",
                table: "EventMessages",
                column: "AuthorId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMessages_People_AuthorId",
                table: "TeamMessages",
                column: "AuthorId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMessages_People_AuthorId",
                table: "EventMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMessages_People_AuthorId",
                table: "TeamMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMessages",
                table: "TeamMessages");

            migrationBuilder.DropIndex(
                name: "IX_TeamMessages_AuthorId",
                table: "TeamMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMessages",
                table: "EventMessages");

            migrationBuilder.DropIndex(
                name: "IX_EventMessages_AuthorId",
                table: "EventMessages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeamMessages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "TeamMessages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventMessages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "EventMessages");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "TeamMessages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "EventMessages",
                newName: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMessages",
                table: "TeamMessages",
                columns: new[] { "MessageId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMessages",
                table: "EventMessages",
                columns: new[] { "MessageId", "EventId" });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PersonId",
                table: "Messages",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMessages_Messages_MessageId",
                table: "EventMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMessages_Messages_MessageId",
                table: "TeamMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
