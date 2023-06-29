using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class precargaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 3,
                column: "Valor",
                value: "Semi Cama");

            migrationBuilder.UpdateData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 5,
                column: "Valor",
                value: "300 Km/h");

            migrationBuilder.InsertData(
                table: "Transporte",
                columns: new[] { "TransporteId", "CompaniaTransporteId", "TipoTransporteId" },
                values: new object[,]
                {
                    { 4, 5, 1 },
                    { 5, 5, 1 },
                    { 6, 5, 1 },
                    { 7, 5, 1 },
                    { 8, 5, 1 },
                    { 9, 5, 1 },
                    { 10, 5, 1 },
                    { 11, 6, 1 },
                    { 12, 6, 1 },
                    { 13, 6, 1 },
                    { 14, 6, 1 },
                    { 15, 6, 1 },
                    { 16, 6, 1 },
                    { 17, 6, 1 },
                    { 18, 6, 1 },
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
                    { 6, 1, 4, "30" },
                    { 7, 2, 4, "Asiento Regular" },
                    { 8, 3, 4, "660 Km/h" },
                    { 9, 1, 5, "40" },
                    { 10, 2, 5, "Asiento Regular" },
                    { 11, 3, 5, "500 Km/h" },
                    { 12, 1, 6, "10" },
                    { 13, 2, 6, "Asiento Ejecutivo" },
                    { 14, 3, 6, "900 Km/h" },
                    { 15, 1, 7, "40" },
                    { 16, 2, 7, "Asiento Económico" },
                    { 17, 3, 7, "800 Km/h" },
                    { 18, 1, 8, "45" },
                    { 19, 2, 8, "Asiento Regular" },
                    { 20, 3, 8, "800 Km/h" },
                    { 21, 1, 9, "20" },
                    { 22, 2, 9, "Asiento Regular" },
                    { 23, 3, 9, "500 Km/h" },
                    { 24, 1, 10, "10" },
                    { 25, 2, 10, "Asiento Ejecutivo" },
                    { 26, 3, 10, "1000 Km/h" },
                    { 27, 1, 11, "5" },
                    { 28, 2, 11, "Asiento Ejecutivo" },
                    { 29, 3, 11, "950 Km/h" },
                    { 30, 1, 12, "50" },
                    { 31, 2, 12, "Asiento Económico" },
                    { 32, 3, 12, "700 Km/h" },
                    { 33, 1, 13, "45" },
                    { 34, 2, 13, "Asiento Económico" },
                    { 35, 3, 13, "600 Km/h" },
                    { 36, 1, 14, "60" },
                    { 37, 2, 14, "Asiento Económico" },
                    { 38, 3, 14, "500 Km/h" },
                    { 39, 1, 15, "30" },
                    { 40, 2, 15, "Asiento Regular" },
                    { 41, 3, 15, "850 Km/h" },
                    { 42, 1, 16, "30" },
                    { 43, 2, 16, "Asiento Regular" },
                    { 44, 3, 16, "800 Km/h" },
                    { 45, 1, 17, "25" },
                    { 46, 2, 17, "Asiento Regular" },
                    { 47, 3, 17, "800 Km/h" },
                    { 48, 1, 18, "35" },
                    { 49, 2, 18, "Asiento Regular" },
                    { 50, 3, 18, "750 Km/h" },
                    { 51, 1, 19, "30" },
                    { 52, 2, 19, "Semi Cama" },
                    { 53, 3, 19, "120 Km/h" },
                    { 54, 1, 20, "50" },
                    { 55, 2, 20, "Semi Cama" },
                    { 56, 3, 20, "120 Km/h" },
                    { 57, 1, 21, "50" },
                    { 58, 2, 21, "Semi Cama" },
                    { 59, 3, 21, "120 Km/h" },
                    { 60, 1, 22, "40" },
                    { 61, 2, 22, "Semi Cama" },
                    { 62, 3, 22, "150 Km/h" },
                    { 63, 1, 23, "35" },
                    { 64, 2, 23, "Semi Cama" },
                    { 65, 3, 23, "120 Km/h" },
                    { 66, 1, 24, "30" },
                    { 67, 2, 24, "Asiento Regular" },
                    { 68, 3, 24, "120 Km/h" },
                    { 69, 1, 25, "60" },
                    { 70, 2, 25, "Asiento Regular" },
                    { 71, 3, 25, "100 Km/h" },
                    { 72, 1, 26, "50" },
                    { 73, 2, 26, "Asiento Regular" },
                    { 74, 3, 26, "110 Km/h" },
                    { 75, 1, 27, "30" },
                    { 76, 2, 27, "Asiento Regular" },
                    { 77, 3, 27, "130 Km/h" },
                    { 78, 1, 28, "30" },
                    { 79, 2, 28, "Asiento Regular" },
                    { 80, 3, 28, "130 Km/h" },
                    { 81, 1, 29, "45" },
                    { 82, 2, 29, "Asiento Regular" },
                    { 83, 3, 29, "100 Km/h" },
                    { 84, 1, 30, "20" },
                    { 85, 2, 30, "Cama Ejecutivo" },
                    { 86, 3, 30, "150 Km/h" },
                    { 87, 1, 31, "15" },
                    { 88, 2, 31, "Cama Ejecutivo" },
                    { 89, 3, 31, "160 Km/h" },
                    { 90, 1, 32, "10" },
                    { 91, 2, 32, "Cama Ejecutivo" },
                    { 92, 3, 32, "190 Km/h" },
                    { 93, 1, 33, "5" },
                    { 94, 2, 33, "Cama Ejecutivo" },
                    { 95, 3, 33, "200 Km/h" },
                    { 96, 1, 34, "200" },
                    { 97, 2, 34, "Semi Cama" },
                    { 98, 3, 34, "150 Km/h" },
                    { 99, 1, 35, "150" },
                    { 100, 2, 35, "Semi Cama" },
                    { 101, 3, 35, "150 Km/h" },
                    { 102, 1, 36, "120" },
                    { 103, 2, 36, "Semi Cama" },
                    { 104, 3, 36, "150 Km/h" },
                    { 105, 1, 37, "200" },
                    { 106, 2, 37, "Semi Cama" },
                    { 107, 3, 37, "180 Km/h" },
                    { 108, 1, 38, "120" },
                    { 109, 2, 38, "Semi Cama" },
                    { 110, 3, 38, "160 Km/h" },
                    { 111, 1, 39, "130" },
                    { 112, 2, 39, "Semi Cama" },
                    { 113, 3, 39, "150 Km/h" },
                    { 114, 1, 40, "120" },
                    { 115, 2, 40, "Asiento Regular" },
                    { 116, 3, 40, "180 Km/h" },
                    { 117, 1, 41, "110" },
                    { 118, 2, 41, "Asiento Regular" },
                    { 119, 3, 41, "180 Km/h" },
                    { 120, 1, 42, "100" },
                    { 121, 2, 42, "Asiento Regular" },
                    { 122, 3, 42, "170 Km/h" },
                    { 123, 1, 43, "120" },
                    { 124, 2, 43, "Asiento Regular" },
                    { 125, 3, 43, "180 Km/h" },
                    { 126, 1, 44, "100" },
                    { 127, 2, 44, "Asiento Regular" },
                    { 128, 3, 44, "190 Km/h" },
                    { 129, 1, 45, "120" },
                    { 130, 2, 45, "Asiento Regular" },
                    { 131, 3, 45, "180 Km/h" },
                    { 132, 1, 46, "80" },
                    { 133, 2, 46, "Cama Ejecutivo" },
                    { 134, 3, 46, "200 Km/h" },
                    { 135, 1, 47, "50" },
                    { 136, 2, 47, "Cama Ejecutivo" },
                    { 137, 3, 47, "250 Km/h" },
                    { 138, 1, 48, "40" },
                    { 139, 2, 48, "Cama Ejecutivo" },
                    { 140, 3, 48, "250 Km/h" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 48);

            migrationBuilder.UpdateData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 3,
                column: "Valor",
                value: "SemiCama");

            migrationBuilder.UpdateData(
                table: "CaracteristicaTransporte",
                keyColumn: "CaracteristicaTransporteId",
                keyValue: 5,
                column: "Valor",
                value: "300 km/h");
        }
    }
}
