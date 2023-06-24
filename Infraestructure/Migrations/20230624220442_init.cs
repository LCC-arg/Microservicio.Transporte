using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracteristica",
                columns: table => new
                {
                    CaracteristicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica", x => x.CaracteristicaId);
                });

            migrationBuilder.CreateTable(
                name: "CompaniaTransporte",
                columns: table => new
                {
                    CompaniaTransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniaTransporte", x => x.CompaniaTransporteId);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransporte",
                columns: table => new
                {
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransporte", x => x.TipoTransporteId);
                });

            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    TransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false),
                    CompaniaTransporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.TransporteId);
                    table.ForeignKey(
                        name: "FK_Transporte_CompaniaTransporte_CompaniaTransporteId",
                        column: x => x.CompaniaTransporteId,
                        principalTable: "CompaniaTransporte",
                        principalColumn: "CompaniaTransporteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transporte_TipoTransporte_TipoTransporteId",
                        column: x => x.TipoTransporteId,
                        principalTable: "TipoTransporte",
                        principalColumn: "TipoTransporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicaTransporte",
                columns: table => new
                {
                    CaracteristicaTransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaracteristicaId = table.Column<int>(type: "int", nullable: false),
                    TransporteId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicaTransporte", x => x.CaracteristicaTransporteId);
                    table.ForeignKey(
                        name: "FK_CaracteristicaTransporte_Caracteristica_CaracteristicaId",
                        column: x => x.CaracteristicaId,
                        principalTable: "Caracteristica",
                        principalColumn: "CaracteristicaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaracteristicaTransporte_Transporte_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "Transporte",
                        principalColumn: "TransporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Caracteristica",
                columns: new[] { "CaracteristicaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Cantidad de Asientos" },
                    { 2, "Tipo de Asientos" },
                    { 3, "Velocidad Maxima" }
                });

            migrationBuilder.InsertData(
                table: "CompaniaTransporte",
                columns: new[] { "CompaniaTransporteId", "Cuit", "RazonSocial" },
                values: new object[,]
                {
                    { 1, "0147852369", "PLUSMAR" },
                    { 2, "15615612232", "Chevalier" },
                    { 3, "21561665662", "Sarmiento SRL" },
                    { 4, "123456789", "Roca" },
                    { 5, "1561232", "Despegar" },
                    { 6, "156789456", "Aerolineas Argentinas" }
                });

            migrationBuilder.InsertData(
                table: "TipoTransporte",
                columns: new[] { "TipoTransporteId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Avion" },
                    { 2, "Micro" },
                    { 3, "Tren" }
                });

            migrationBuilder.InsertData(
                table: "Transporte",
                columns: new[] { "TransporteId", "CompaniaTransporteId", "TipoTransporteId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 1, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "CaracteristicaTransporte",
                columns: new[] { "CaracteristicaTransporteId", "CaracteristicaId", "TransporteId", "Valor" },
                values: new object[,]
                {
                    { 1, 1, 1, "50" },
                    { 2, 1, 2, "60" },
                    { 3, 2, 2, "SemiCama" },
                    { 4, 1, 3, "360" },
                    { 5, 3, 3, "300 km/h" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaTransporte_CaracteristicaId",
                table: "CaracteristicaTransporte",
                column: "CaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaTransporte_TransporteId",
                table: "CaracteristicaTransporte",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transporte_CompaniaTransporteId",
                table: "Transporte",
                column: "CompaniaTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transporte_TipoTransporteId",
                table: "Transporte",
                column: "TipoTransporteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaracteristicaTransporte");

            migrationBuilder.DropTable(
                name: "Caracteristica");

            migrationBuilder.DropTable(
                name: "Transporte");

            migrationBuilder.DropTable(
                name: "CompaniaTransporte");

            migrationBuilder.DropTable(
                name: "TipoTransporte");
        }
    }
}
