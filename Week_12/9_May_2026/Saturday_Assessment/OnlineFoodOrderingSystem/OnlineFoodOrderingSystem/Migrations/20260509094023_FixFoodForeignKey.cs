using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixFoodForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_FoodItems_FoodItemFoodId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_FoodItems_FoodItemFoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_FoodItemFoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Carts_FoodItemFoodId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "FoodItemFoodId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "FoodItemFoodId",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FoodId",
                table: "OrderDetails",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_FoodId",
                table: "Carts",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_FoodItems_FoodId",
                table: "Carts",
                column: "FoodId",
                principalTable: "FoodItems",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_FoodItems_FoodId",
                table: "OrderDetails",
                column: "FoodId",
                principalTable: "FoodItems",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_FoodItems_FoodId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_FoodItems_FoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_FoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Carts_FoodId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "FoodItemFoodId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodItemFoodId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FoodItemFoodId",
                table: "OrderDetails",
                column: "FoodItemFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_FoodItemFoodId",
                table: "Carts",
                column: "FoodItemFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_FoodItems_FoodItemFoodId",
                table: "Carts",
                column: "FoodItemFoodId",
                principalTable: "FoodItems",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_FoodItems_FoodItemFoodId",
                table: "OrderDetails",
                column: "FoodItemFoodId",
                principalTable: "FoodItems",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
