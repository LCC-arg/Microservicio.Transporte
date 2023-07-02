using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infraestructure
{
    public class TransporteContext : DbContext
    {
        public TransporteContext(DbContextOptions<TransporteContext> options)
            : base(options) { }
        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<TipoTransporte> TipoTransporte { get; set; }
        public DbSet<CaracteristicaTransporte> CaracteristicaTransporte { get; set; }
        public DbSet<Transporte> Transporte { get; set; }
        public DbSet<CompaniaTransporte> CompaniaTransporte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoTransporte>().HasData(
                new TipoTransporte { TipoTransporteId = 1, Descripcion = "Avion" },
                new TipoTransporte { TipoTransporteId = 2, Descripcion = "Micro" },
                new TipoTransporte { TipoTransporteId = 3, Descripcion = "Tren" }
                );
            modelBuilder.Entity<CompaniaTransporte>().HasData(
                new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "0147852369", RazonSocial = "PLUSMAR" , ImagenLogo= "https://upload.wikimedia.org/wikipedia/commons/5/5e/Plusmar_logo.png" },
                new CompaniaTransporte { CompaniaTransporteId = 2, Cuit = "15615612232", RazonSocial = "Chevalier" , ImagenLogo= "https://www.centraldepasajes.com.ar/empresas-de-micro/img/logos/chevallier-logo.png" },
                new CompaniaTransporte { CompaniaTransporteId = 3, Cuit = "21561665662", RazonSocial = "Sarmiento SRL" , ImagenLogo= "https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Ferrocarriles_Argentinos.svg/1280px-Ferrocarriles_Argentinos.svg.png" },
                new CompaniaTransporte { CompaniaTransporteId = 4, Cuit = "123456789", RazonSocial = "Roca" , ImagenLogo= "https://yt3.googleusercontent.com/r2dUpnRqDqQ8g-P17-UTpv5LZ7SuJGBNxto_Wp-OCwnJ9q0saSxGs1GQyov8LNftLYNJExTiqw=s900-c-k-c0x00ffffff-no-rj" },
                new CompaniaTransporte { CompaniaTransporteId = 5, Cuit = "1561232", RazonSocial = "Despegar" , ImagenLogo= "https://upload.wikimedia.org/wikipedia/commons/thumb/d/db/Despegar.com_logo.svg/1280px-Despegar.com_logo.svg.png" },
                new CompaniaTransporte { CompaniaTransporteId = 6, Cuit = "156789456", RazonSocial = "Aerolineas Argentinas" , ImagenLogo= "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Aerol%C3%ADneas_Argentinas_Logo_2010.svg/512px-Aerol%C3%ADneas_Argentinas_Logo_2010.svg.png" }
                );
            modelBuilder.Entity<Transporte>().HasData(
               new Transporte { TransporteId = 1, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 2, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 3, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren

               new Transporte { TransporteId = 4, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 5, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 6, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 7, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 8, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 9, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 10, CompaniaTransporteId = 5, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 11, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 12, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 13, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 14, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 15, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 16, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 17, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion
               new Transporte { TransporteId = 18, CompaniaTransporteId = 6, TipoTransporteId = 1 }, // Avion

               new Transporte { TransporteId = 19, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 20, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 21, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 22, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 23, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 24, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 25, CompaniaTransporteId = 1, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 26, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 27, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 28, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 29, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 30, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 31, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 32, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro
               new Transporte { TransporteId = 33, CompaniaTransporteId = 2, TipoTransporteId = 2 }, // Micro

               new Transporte { TransporteId = 34, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 35, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 36, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 37, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 38, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 39, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 40, CompaniaTransporteId = 3, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 41, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 42, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 43, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 44, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 45, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 46, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 47, CompaniaTransporteId = 4, TipoTransporteId = 3 },  // Tren
               new Transporte { TransporteId = 48, CompaniaTransporteId = 4, TipoTransporteId = 3 }  // Tren

               );
            modelBuilder.Entity<Caracteristica>().HasData(
               new Caracteristica { CaracteristicaId = 1, Descripcion = "Cantidad de Asientos" },
               new Caracteristica { CaracteristicaId = 2, Descripcion = "Tipo de Asientos" },
               new Caracteristica { CaracteristicaId = 3, Descripcion = "Velocidad Maxima" }
               );
            modelBuilder.Entity<CaracteristicaTransporte>().HasData(
               new CaracteristicaTransporte { CaracteristicaTransporteId = 1, CaracteristicaId = 1, TransporteId = 1, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 2, CaracteristicaId = 1, TransporteId = 2, Valor = "60" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 3, CaracteristicaId = 2, TransporteId = 2, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 4, CaracteristicaId = 1, TransporteId = 3, Valor = "360" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 5, CaracteristicaId = 3, TransporteId = 3, Valor = "300 Km/h" },

               new CaracteristicaTransporte { CaracteristicaTransporteId = 6, CaracteristicaId = 1, TransporteId = 4, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 7, CaracteristicaId = 2, TransporteId = 4, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 8, CaracteristicaId = 3, TransporteId = 4, Valor = "660 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 9, CaracteristicaId = 1, TransporteId = 5, Valor = "40" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 10, CaracteristicaId = 2, TransporteId = 5, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 11, CaracteristicaId = 3, TransporteId = 5, Valor = "500 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 12, CaracteristicaId = 1, TransporteId = 6, Valor = "10" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 13, CaracteristicaId = 2, TransporteId = 6, Valor = "Asiento Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 14, CaracteristicaId = 3, TransporteId = 6, Valor = "900 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 15, CaracteristicaId = 1, TransporteId = 7, Valor = "40" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 16, CaracteristicaId = 2, TransporteId = 7, Valor = "Asiento Económico" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 17, CaracteristicaId = 3, TransporteId = 7, Valor = "800 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 18, CaracteristicaId = 1, TransporteId = 8, Valor = "45" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 19, CaracteristicaId = 2, TransporteId = 8, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 20, CaracteristicaId = 3, TransporteId = 8, Valor = "800 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 21, CaracteristicaId = 1, TransporteId = 9, Valor = "20" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 22, CaracteristicaId = 2, TransporteId = 9, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 23, CaracteristicaId = 3, TransporteId = 9, Valor = "500 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 24, CaracteristicaId = 1, TransporteId = 10, Valor = "10" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 25, CaracteristicaId = 2, TransporteId = 10, Valor = "Asiento Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 26, CaracteristicaId = 3, TransporteId = 10, Valor = "1000 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 27, CaracteristicaId = 1, TransporteId = 11, Valor = "5" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 28, CaracteristicaId = 2, TransporteId = 11, Valor = "Asiento Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 29, CaracteristicaId = 3, TransporteId = 11, Valor = "950 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 30, CaracteristicaId = 1, TransporteId = 12, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 31, CaracteristicaId = 2, TransporteId = 12, Valor = "Asiento Económico" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 32, CaracteristicaId = 3, TransporteId = 12, Valor = "700 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 33, CaracteristicaId = 1, TransporteId = 13, Valor = "45" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 34, CaracteristicaId = 2, TransporteId = 13, Valor = "Asiento Económico" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 35, CaracteristicaId = 3, TransporteId = 13, Valor = "600 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 36, CaracteristicaId = 1, TransporteId = 14, Valor = "60" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 37, CaracteristicaId = 2, TransporteId = 14, Valor = "Asiento Económico" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 38, CaracteristicaId = 3, TransporteId = 14, Valor = "500 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 39, CaracteristicaId = 1, TransporteId = 15, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 40, CaracteristicaId = 2, TransporteId = 15, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 41, CaracteristicaId = 3, TransporteId = 15, Valor = "850 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 42, CaracteristicaId = 1, TransporteId = 16, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 43, CaracteristicaId = 2, TransporteId = 16, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 44, CaracteristicaId = 3, TransporteId = 16, Valor = "800 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 45, CaracteristicaId = 1, TransporteId = 17, Valor = "25" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 46, CaracteristicaId = 2, TransporteId = 17, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 47, CaracteristicaId = 3, TransporteId = 17, Valor = "800 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 48, CaracteristicaId = 1, TransporteId = 18, Valor = "35" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 49, CaracteristicaId = 2, TransporteId = 18, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 50, CaracteristicaId = 3, TransporteId = 18, Valor = "750 Km/h" },

               new CaracteristicaTransporte { CaracteristicaTransporteId = 51, CaracteristicaId = 1, TransporteId = 19, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 52, CaracteristicaId = 2, TransporteId = 19, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 53, CaracteristicaId = 3, TransporteId = 19, Valor = "120 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 54, CaracteristicaId = 1, TransporteId = 20, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 55, CaracteristicaId = 2, TransporteId = 20, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 56, CaracteristicaId = 3, TransporteId = 20, Valor = "120 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 57, CaracteristicaId = 1, TransporteId = 21, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 58, CaracteristicaId = 2, TransporteId = 21, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 59, CaracteristicaId = 3, TransporteId = 21, Valor = "120 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 60, CaracteristicaId = 1, TransporteId = 22, Valor = "40" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 61, CaracteristicaId = 2, TransporteId = 22, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 62, CaracteristicaId = 3, TransporteId = 22, Valor = "150 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 63, CaracteristicaId = 1, TransporteId = 23, Valor = "35" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 64, CaracteristicaId = 2, TransporteId = 23, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 65, CaracteristicaId = 3, TransporteId = 23, Valor = "120 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 66, CaracteristicaId = 1, TransporteId = 24, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 67, CaracteristicaId = 2, TransporteId = 24, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 68, CaracteristicaId = 3, TransporteId = 24, Valor = "120 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 69, CaracteristicaId = 1, TransporteId = 25, Valor = "60" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 70, CaracteristicaId = 2, TransporteId = 25, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 71, CaracteristicaId = 3, TransporteId = 25, Valor = "100 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 72, CaracteristicaId = 1, TransporteId = 26, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 73, CaracteristicaId = 2, TransporteId = 26, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 74, CaracteristicaId = 3, TransporteId = 26, Valor = "110 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 75, CaracteristicaId = 1, TransporteId = 27, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 76, CaracteristicaId = 2, TransporteId = 27, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 77, CaracteristicaId = 3, TransporteId = 27, Valor = "130 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 78, CaracteristicaId = 1, TransporteId = 28, Valor = "30" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 79, CaracteristicaId = 2, TransporteId = 28, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 80, CaracteristicaId = 3, TransporteId = 28, Valor = "130 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 81, CaracteristicaId = 1, TransporteId = 29, Valor = "45" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 82, CaracteristicaId = 2, TransporteId = 29, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 83, CaracteristicaId = 3, TransporteId = 29, Valor = "100 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 84, CaracteristicaId = 1, TransporteId = 30, Valor = "20" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 85, CaracteristicaId = 2, TransporteId = 30, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 86, CaracteristicaId = 3, TransporteId = 30, Valor = "150 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 87, CaracteristicaId = 1, TransporteId = 31, Valor = "15" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 88, CaracteristicaId = 2, TransporteId = 31, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 89, CaracteristicaId = 3, TransporteId = 31, Valor = "160 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 90, CaracteristicaId = 1, TransporteId = 32, Valor = "10" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 91, CaracteristicaId = 2, TransporteId = 32, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 92, CaracteristicaId = 3, TransporteId = 32, Valor = "190 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 93, CaracteristicaId = 1, TransporteId = 33, Valor = "5" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 94, CaracteristicaId = 2, TransporteId = 33, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 95, CaracteristicaId = 3, TransporteId = 33, Valor = "200 Km/h" },

               new CaracteristicaTransporte { CaracteristicaTransporteId = 96, CaracteristicaId = 1, TransporteId = 34, Valor = "200" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 97, CaracteristicaId = 2, TransporteId = 34, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 98, CaracteristicaId = 3, TransporteId = 34, Valor = "150 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 99, CaracteristicaId = 1, TransporteId = 35, Valor = "150" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 100, CaracteristicaId = 2, TransporteId = 35, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 101, CaracteristicaId = 3, TransporteId = 35, Valor = "150 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 102, CaracteristicaId = 1, TransporteId = 36, Valor = "120" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 103, CaracteristicaId = 2, TransporteId = 36, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 104, CaracteristicaId = 3, TransporteId = 36, Valor = "150 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 105, CaracteristicaId = 1, TransporteId = 37, Valor = "200" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 106, CaracteristicaId = 2, TransporteId = 37, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 107, CaracteristicaId = 3, TransporteId = 37, Valor = "180 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 108, CaracteristicaId = 1, TransporteId = 38, Valor = "120" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 109, CaracteristicaId = 2, TransporteId = 38, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 110, CaracteristicaId = 3, TransporteId = 38, Valor = "160 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 111, CaracteristicaId = 1, TransporteId = 39, Valor = "130" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 112, CaracteristicaId = 2, TransporteId = 39, Valor = "Semi Cama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 113, CaracteristicaId = 3, TransporteId = 39, Valor = "150 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 114, CaracteristicaId = 1, TransporteId = 40, Valor = "120" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 115, CaracteristicaId = 2, TransporteId = 40, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 116, CaracteristicaId = 3, TransporteId = 40, Valor = "180 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 117, CaracteristicaId = 1, TransporteId = 41, Valor = "110" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 118, CaracteristicaId = 2, TransporteId = 41, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 119, CaracteristicaId = 3, TransporteId = 41, Valor = "180 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 120, CaracteristicaId = 1, TransporteId = 42, Valor = "100" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 121, CaracteristicaId = 2, TransporteId = 42, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 122, CaracteristicaId = 3, TransporteId = 42, Valor = "170 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 123, CaracteristicaId = 1, TransporteId = 43, Valor = "120" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 124, CaracteristicaId = 2, TransporteId = 43, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 125, CaracteristicaId = 3, TransporteId = 43, Valor = "180 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 126, CaracteristicaId = 1, TransporteId = 44, Valor = "100" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 127, CaracteristicaId = 2, TransporteId = 44, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 128, CaracteristicaId = 3, TransporteId = 44, Valor = "190 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 129, CaracteristicaId = 1, TransporteId = 45, Valor = "120" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 130, CaracteristicaId = 2, TransporteId = 45, Valor = "Asiento Regular" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 131, CaracteristicaId = 3, TransporteId = 45, Valor = "180 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 132, CaracteristicaId = 1, TransporteId = 46, Valor = "80" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 133, CaracteristicaId = 2, TransporteId = 46, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 134, CaracteristicaId = 3, TransporteId = 46, Valor = "200 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 135, CaracteristicaId = 1, TransporteId = 47, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 136, CaracteristicaId = 2, TransporteId = 47, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 137, CaracteristicaId = 3, TransporteId = 47, Valor = "250 Km/h" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 138, CaracteristicaId = 1, TransporteId = 48, Valor = "40" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 139, CaracteristicaId = 2, TransporteId = 48, Valor = "Cama Ejecutivo" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 140, CaracteristicaId = 3, TransporteId = 48, Valor = "250 Km/h" }

               );

            modelBuilder.Entity<Caracteristica>()
                 .HasMany(g => g.CaracteristicaTransporte)
                 .WithOne(s => s.Caracteristica)
                 .HasForeignKey(s => s.CaracteristicaId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transporte>()
                .HasMany(g => g.CaracteristicaTransporte)
                .WithOne(s => s.Transporte)
                .HasForeignKey(s => s.TransporteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<TipoTransporte>()
                .HasMany(g => g.Transporte)
                .WithOne(s => s.TipoTransporte)
                .HasForeignKey(s => s.TipoTransporteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompaniaTransporte>()
                .HasMany(g => g.Transporte)
                .WithOne(s => s.CompaniaTransporte)
                .HasForeignKey(s => s.CompaniaTransporteId)
                .OnDelete(DeleteBehavior.Cascade);
                

            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.Property(c => c.Descripcion)
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar")
                      .IsRequired();
            });

            modelBuilder.Entity<CaracteristicaTransporte>(entity =>
            {
                entity.Property(c => c.Valor)
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar")
                      .IsRequired();
            });

            modelBuilder.Entity<CompaniaTransporte>(entity =>
            {
                entity.Property(c => c.Cuit)
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar")
                      .IsRequired();

                entity.Property(c => c.RazonSocial)
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar")
                      .IsRequired();
            });

            modelBuilder.Entity<TipoTransporte>(entity =>
            {
                entity.Property(c => c.Descripcion)
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar")
                      .IsRequired();
            });

            modelBuilder.Entity<Caracteristica>().Property(p => p.CaracteristicaId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TipoTransporte>().Property(p => p.TipoTransporteId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CaracteristicaTransporte>().Property(p => p.CaracteristicaTransporteId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Transporte>().Property(p => p.TransporteId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CompaniaTransporte>().Property(p => p.CompaniaTransporteId).ValueGeneratedOnAdd();
        }
    }
}
