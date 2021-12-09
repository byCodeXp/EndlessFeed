using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class add_entity_blockPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(2134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 796, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(1530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 796, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 805, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 805, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(8398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 789, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(7907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 785, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.CreateTable(
                name: "BlockedPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 60, DateTimeKind.Utc).AddTicks(1929)),
                    UpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 60, DateTimeKind.Utc).AddTicks(2458))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockedPosts_PostId",
                table: "BlockedPosts",
                column: "PostId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedPosts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 796, DateTimeKind.Utc).AddTicks(9503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 796, DateTimeKind.Utc).AddTicks(8671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 805, DateTimeKind.Utc).AddTicks(9804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 805, DateTimeKind.Utc).AddTicks(9220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 59, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 789, DateTimeKind.Utc).AddTicks(3739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 7, 15, 37, 23, 785, DateTimeKind.Utc).AddTicks(3479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 9, 13, 44, 9, 58, DateTimeKind.Utc).AddTicks(7907));
        }
    }
}
