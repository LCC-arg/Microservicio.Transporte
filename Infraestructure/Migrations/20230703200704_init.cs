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
                    RazonSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImagenLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "CompaniaTransporteId", "Cuit", "ImagenLogo", "RazonSocial" },
                values: new object[,]
                {
                    { 1, "0147852369", "https://upload.wikimedia.org/wikipedia/commons/5/5e/Plusmar_logo.png", "PLUSMAR" },
                    { 2, "15615612232", "https://www.centraldepasajes.com.ar/empresas-de-micro/img/logos/chevallier-logo.png", "Chevalier" },
                    { 3, "21561665662", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Ferrocarriles_Argentinos.svg/1280px-Ferrocarriles_Argentinos.svg.png", "Sarmiento SRL" },
                    { 4, "123456789", "https://yt3.googleusercontent.com/r2dUpnRqDqQ8g-P17-UTpv5LZ7SuJGBNxto_Wp-OCwnJ9q0saSxGs1GQyov8LNftLYNJExTiqw=s900-c-k-c0x00ffffff-no-rj", "Roca" },
                    { 5, "1561232", "https://flybondi.com/static/media/logo.ebbd0b77.svg", "Flybondi" },
                    { 6, "156789456", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Aerol%C3%ADneas_Argentinas_Logo_2010.svg/512px-Aerol%C3%ADneas_Argentinas_Logo_2010.svg.png", "Aerolineas Argentinas" },
                    { 7, "1561482123", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c2/Qatar_Airways_Logo.png/800px-Qatar_Airways_Logo.png", "Qatar Airways" }
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
                    { 3, 3, 3 },
                    { 4, 5, 1 },
                    { 5, 6, 1 },
                    { 6, 7, 1 },
                    { 7, 5, 1 },
                    { 8, 6, 1 },
                    { 9, 7, 1 },
                    { 10, 5, 1 },
                    { 11, 6, 1 },
                    { 12, 7, 1 },
                    { 13, 5, 1 },
                    { 14, 6, 1 },
                    { 15, 7, 1 },
                    { 16, 5, 1 },
                    { 17, 6, 1 },
                    { 18, 7, 1 },
                    { 19, 1, 2 },
                    { 20, 1, 2 },
                    { 21, 1, 2 },
                    { 22, 1, 2 },
                    { 23, 1, 2 },
                    { 24, 1, 2 },
                    { 25, 1, 2 },
                    { 26, 2, 2 },
                    { 27, 2, 2 },
                    { 28, 2, 2 },
                    { 29, 2, 2 },
                    { 30, 2, 2 },
                    { 31, 2, 2 },
                    { 32, 2, 2 },
                    { 33, 2, 2 },
                    { 34, 3, 3 },
                    { 35, 3, 3 },
                    { 36, 3, 3 },
                    { 37, 3, 3 },
                    { 38, 3, 3 },
                    { 39, 3, 3 },
                    { 40, 3, 3 },
                    { 41, 4, 3 },
                    { 42, 4, 3 },
                    { 43, 4, 3 },
                    { 44, 4, 3 },
                    { 45, 4, 3 },
                    { 46, 4, 3 },
                    { 47, 4, 3 },
                    { 48, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "CaracteristicaTransporte",
                columns: new[] { "CaracteristicaTransporteId", "CaracteristicaId", "TransporteId", "Valor" },
                values: new object[,]
                {
                    { 1, 1, 1, "300" },
                    { 2, 1, 2, "85" },
                    { 3, 2, 2, "Semi Cama" },
                    { 4, 1, 3, "250" },
                    { 5, 3, 3, "300 Km/h" },
                    { 6, 1, 4, "300" },
                    { 7, 2, 4, "Asiento Regular" },
                    { 8, 3, 4, "660 Km/h" },
                    { 9, 1, 5, "350" },
                    { 10, 2, 5, "Asiento Regular" },
                    { 11, 3, 5, "500 Km/h" },
                    { 12, 1, 6, "275" },
                    { 13, 2, 6, "Asiento Ejecutivo" },
                    { 14, 3, 6, "900 Km/h" },
                    { 15, 1, 7, "300" },
                    { 16, 2, 7, "Asiento Econ贸mico" },
                    { 17, 3, 7, "800 Km/h" },
                    { 18, 1, 8, "290" },
                    { 19, 2, 8, "Asiento Regular" },
                    { 20, 3, 8, "800 Km/h" },
                    { 21, 1, 9, "350" },
                    { 22, 2, 9, "Asiento Regular" },
                    { 23, 3, 9, "500 Km/h" },
                    { 24, 1, 10, "330" },
                    { 25, 2, 10, "Asiento Ejecutivo" },
                    { 26, 3, 10, "1000 Km/h" },
                    { 27, 1, 11, "280" },
                    { 28, 2, 11, "Asiento Ejecutivo" },
                    { 29, 3, 11, "950 Km/h" },
                    { 30, 1, 12, "250" },
                    { 31, 2, 12, "Asiento Econ贸mico" },
                    { 32, 3, 12, "700 Km/h" },
                    { 33, 1, 13, "350" },
                    { 34, 2, 13, "Asiento Econ贸mico" },
                    { 35, 3, 13, "600 Km/h" },
                    { 36, 1, 14, "280" },
                    { 37, 2, 14, "Asiento Econ贸mico" },
                    { 38, 3, 14, "500 Km/h" },
                    { 39, 1, 15, "300" },
                    { 40, 2, 15, "Asiento Regular" },
                    { 41, 3, 15, "850 Km/h" },
                    { 42, 1, 16, "315" },
                    { 43, 2, 16, "Asiento Regular" },
                    { 44, 3, 16, "800 Km/h" },
                    { 45, 1, 17, "265" },
                    { 46, 2, 17, "Asiento Regular" },
                    { 47, 3, 17, "800 Km/h" },
                    { 48, 1, 18, "310" },
                    { 49, 2, 18, "Asiento Regular" },
                    { 50, 3, 18, "750 Km/h" },
                    { 51, 1, 19, "85" },
                    { 52, 2, 19, "Semi Cama" },
                    { 53, 3, 19, "120 Km/h" },
                    { 54, 1, 20, "80" },
                    { 55, 2, 20, "Semi Cama" },
                    { 56, 3, 20, "120 Km/h" },
                    { 57, 1, 21, "75" },
                    { 58, 2, 21, "Semi Cama" },
                    { 59, 3, 21, "120 Km/h" },
                    { 60, 1, 22, "85" },
                    { 61, 2, 22, "Semi Cama" },
                    { 62, 3, 22, "150 Km/h" },
                    { 63, 1, 23, "80" },
                    { 64, 2, 23, "Semi Cama" },
                    { 65, 3, 23, "120 Km/h" },
                    { 66, 1, 24, "75" },
                    { 67, 2, 24, "Asiento Regular" },
                    { 68, 3, 24, "120 Km/h" },
                    { 69, 1, 25, "85" },
                    { 70, 2, 25, "Asiento Regular" },
                    { 71, 3, 25, "100 Km/h" },
                    { 72, 1, 26, "80" },
                    { 73, 2, 26, "Asiento Regular" },
                    { 74, 3, 26, "110 Km/h" },
                    { 75, 1, 27, "75" },
                    { 76, 2, 27, "Asiento Regular" },
                    { 77, 3, 27, "130 Km/h" },
                    { 78, 1, 28, "85" },
                    { 79, 2, 28, "Asiento Regular" },
                    { 80, 3, 28, "130 Km/h" },
                    { 81, 1, 29, "80" },
                    { 82, 2, 29, "Asiento Regular" },
                    { 83, 3, 29, "100 Km/h" },
                    { 84, 1, 30, "75" },
                    { 85, 2, 30, "Cama Ejecutivo" },
                    { 86, 3, 30, "150 Km/h" },
                    { 87, 1, 31, "85" },
                    { 88, 2, 31, "Cama Ejecutivo" },
                    { 89, 3, 31, "160 Km/h" },
                    { 90, 1, 32, "80" },
                    { 91, 2, 32, "Cama Ejecutivo" },
                    { 92, 3, 32, "190 Km/h" },
                    { 93, 1, 33, "75" },
                    { 94, 2, 33, "Cama Ejecutivo" },
                    { 95, 3, 33, "200 Km/h" },
                    { 96, 1, 34, "200" },
                    { 97, 2, 34, "Semi Cama" },
                    { 98, 3, 34, "150 Km/h" },
                    { 99, 1, 35, "220" },
                    { 100, 2, 35, "Semi Cama" },
                    { 101, 3, 35, "150 Km/h" },
                    { 102, 1, 36, "240" },
                    { 103, 2, 36, "Semi Cama" },
                    { 104, 3, 36, "150 Km/h" },
                    { 105, 1, 37, "200" },
                    { 106, 2, 37, "Semi Cama" },
                    { 107, 3, 37, "180 Km/h" },
                    { 108, 1, 38, "220" },
                    { 109, 2, 38, "Semi Cama" },
                    { 110, 3, 38, "160 Km/h" },
                    { 111, 1, 39, "240" },
                    { 112, 2, 39, "Semi Cama" },
                    { 113, 3, 39, "150 Km/h" },
                    { 114, 1, 40, "200" },
                    { 115, 2, 40, "Asiento Regular" },
                    { 116, 3, 40, "180 Km/h" },
                    { 117, 1, 41, "220" },
                    { 118, 2, 41, "Asiento Regular" },
                    { 119, 3, 41, "180 Km/h" },
                    { 120, 1, 42, "240" },
                    { 121, 2, 42, "Asiento Regular" },
                    { 122, 3, 42, "170 Km/h" },
                    { 123, 1, 43, "200" },
                    { 124, 2, 43, "Asiento Regular" },
                    { 125, 3, 43, "180 Km/h" },
                    { 126, 1, 44, "220" },
                    { 127, 2, 44, "Asiento Regular" },
                    { 128, 3, 44, "190 Km/h" },
                    { 129, 1, 45, "240" },
                    { 130, 2, 45, "Asiento Regular" },
                    { 131, 3, 45, "180 Km/h" },
                    { 132, 1, 46, "200" },
                    { 133, 2, 46, "Cama Ejecutivo" },
                    { 134, 3, 46, "200 Km/h" },
                    { 135, 1, 47, "220" },
                    { 136, 2, 47, "Cama Ejecutivo" },
                    { 137, 3, 47, "250 Km/h" },
                    { 138, 1, 48, "240" },
                    { 139, 2, 48, "Cama Ejecutivo" },
                    { 140, 3, 48, "250 Km/h" }
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
