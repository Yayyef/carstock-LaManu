using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carstock.Migrations
{
    public partial class StatusAddedInCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    idAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("admin_PK", x => x.idAdmin);
                });

            migrationBuilder.CreateTable(
                name: "carmodel",
                columns: table => new
                {
                    idModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    model = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("carmodel_PK", x => x.idModel);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    idCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    bankAccount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_PK", x => x.idCustomer);
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    idCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCustomer = table.Column<int>(type: "int", nullable: true),
                    idModel = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_PK", x => x.idCar);
                    table.ForeignKey(
                        name: "car_carmodel0_FK",
                        column: x => x.idModel,
                        principalTable: "carmodel",
                        principalColumn: "idModel");
                    table.ForeignKey(
                        name: "car_customer_FK",
                        column: x => x.idCustomer,
                        principalTable: "customer",
                        principalColumn: "idCustomer");
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_idCustomer",
                table: "car",
                column: "idCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_car_idModel",
                table: "car",
                column: "idModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "carmodel");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
