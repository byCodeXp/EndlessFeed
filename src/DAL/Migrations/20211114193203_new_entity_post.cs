using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class new_entity_post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 357, DateTimeKind.Utc).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 20, 38, 55, 608, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 338, DateTimeKind.Utc).AddTicks(8822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 20, 38, 55, 589, DateTimeKind.Utc).AddTicks(3146));

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 373, DateTimeKind.Utc).AddTicks(1241)),
                    UpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 373, DateTimeKind.Utc).AddTicks(3783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 20, 38, 55, 608, DateTimeKind.Utc).AddTicks(8610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 357, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 20, 38, 55, 589, DateTimeKind.Utc).AddTicks(3146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 338, DateTimeKind.Utc).AddTicks(8822));
        }
    }
}
