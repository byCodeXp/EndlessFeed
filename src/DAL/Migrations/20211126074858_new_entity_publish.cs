using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class new_entity_publish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 848, DateTimeKind.Utc).AddTicks(5813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 373, DateTimeKind.Utc).AddTicks(3783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 848, DateTimeKind.Utc).AddTicks(2071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 373, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 780, DateTimeKind.Utc).AddTicks(726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 357, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 738, DateTimeKind.Utc).AddTicks(4547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 338, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.CreateTable(
                name: "Publishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 918, DateTimeKind.Utc).AddTicks(5519)),
                    UpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 919, DateTimeKind.Utc).AddTicks(3824))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_PostId",
                table: "Publishes",
                column: "PostId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publishes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 373, DateTimeKind.Utc).AddTicks(3783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 848, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 373, DateTimeKind.Utc).AddTicks(1241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 848, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 357, DateTimeKind.Utc).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 780, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 19, 32, 2, 338, DateTimeKind.Utc).AddTicks(8822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 26, 7, 48, 56, 738, DateTimeKind.Utc).AddTicks(4547));
        }
    }
}
