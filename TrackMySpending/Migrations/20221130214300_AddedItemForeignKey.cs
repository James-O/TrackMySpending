using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMySpending.Migrations
{
    public partial class AddedItemForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ItemId",
                table: "Expenses",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Items_ItemId",
                table: "Expenses",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Items_ItemId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ItemId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Expenses");
        }
    }
}
