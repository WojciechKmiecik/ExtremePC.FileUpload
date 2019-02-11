using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtremePC.FileUpload.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorCodes",
                columns: table => new
                {
                    ColorCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCodes", x => x.ColorCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    ArtikelCode = table.Column<string>(nullable: true),
                    ColorCodeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DiscountPrice = table.Column<decimal>(nullable: false),
                    DeliveredInMin = table.Column<int>(nullable: false),
                    DeliveredInMax = table.Column<int>(nullable: false),
                    Q1 = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ColorCodes_ColorCodeId",
                        column: x => x.ColorCodeId,
                        principalTable: "ColorCodes",
                        principalColumn: "ColorCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ColorCodes",
                columns: new[] { "ColorCodeId", "Name" },
                values: new object[,]
                {
                    { 3, "Jeans" },
                    { 11, "Short Billy & Bobble" },
                    { 10, "Jeans Willy Boys" },
                    { 9, "Steve Irwin" },
                    { 8, "Top Bill" },
                    { 7, "Top Annie" },
                    { 6, "Top Wilma" },
                    { 5, "Kniebroek Maria" },
                    { 4, "Jeans Willy" },
                    { 12, "jacket" },
                    { 13, "test" },
                    { 1, "broek" },
                    { 2, "Kniebroek Jorge" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "Name" },
                values: new object[,]
                {
                    { 8, "blauw" },
                    { 7, "rood" },
                    { 6, "beige" },
                    { 5, "bruin" },
                    { 4, "zwart" },
                    { 3, "wit" },
                    { 2, "groen" },
                    { 1, "grijs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorCodeId",
                table: "Products",
                column: "ColorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ColorCodes");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
