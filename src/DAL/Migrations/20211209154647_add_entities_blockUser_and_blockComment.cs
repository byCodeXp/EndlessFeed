using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class add_entities_blockUser_and_blockComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(2860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(2391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(8165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(7697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "BlockedPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(5780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 60, DateTimeKind.Utc).AddTicks(2458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "BlockedPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(5371),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 60, DateTimeKind.Utc).AddTicks(1929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 398, DateTimeKind.Utc).AddTicks(8526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 398, DateTimeKind.Utc).AddTicks(7943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.CreateTable(
                name: "BlockedComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(8710)),
                    UpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(9022))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(7080)),
                    UpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(7465))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockedComments_CommentId",
                table: "BlockedComments",
                column: "CommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_UserId",
                table: "BlockedUsers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedComments");

            migrationBuilder.DropTable(
                name: "BlockedUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(2134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(1530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(8165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 399, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "BlockedPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 60, DateTimeKind.Utc).AddTicks(2458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(5780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "BlockedPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 60, DateTimeKind.Utc).AddTicks(1929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 400, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(8398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 398, DateTimeKind.Utc).AddTicks(8526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(7907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 15, 46, 47, 398, DateTimeKind.Utc).AddTicks(7943));
        }
    }
}
