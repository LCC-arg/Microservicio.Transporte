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
                new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "0147852369", RazonSocial = "PLUSMAR" },
                new CompaniaTransporte { CompaniaTransporteId = 2, Cuit = "15615612232", RazonSocial = "Chevalier" },
                new CompaniaTransporte { CompaniaTransporteId = 3, Cuit = "21561665662", RazonSocial = "Sarmiento SRL" },
                new CompaniaTransporte { CompaniaTransporteId = 4, Cuit = "123456789", RazonSocial = "Roca" },
                new CompaniaTransporte { CompaniaTransporteId = 5, Cuit = "1561232", RazonSocial = "Despegar" },
                new CompaniaTransporte { CompaniaTransporteId = 6, Cuit = "156789456", RazonSocial = "Aerolineas Argentinas"}
                );
            modelBuilder.Entity<Transporte>().HasData(
               new Transporte { TransporteId = 1, CompaniaTransporteId = 1, TipoTransporteId = 2 },
               new Transporte { TransporteId = 2, CompaniaTransporteId = 3, TipoTransporteId = 3 },
               new Transporte { TransporteId = 3, CompaniaTransporteId = 5, TipoTransporteId = 1 }
               );
            modelBuilder.Entity<Caracteristica>().HasData(
               new Caracteristica { CaracteristicaId = 1, Descripcion = "Cantidad de Asientos" },
               new Caracteristica { CaracteristicaId = 2, Descripcion = "Tipo de Asientos" },
               new Caracteristica { CaracteristicaId = 3, Descripcion = "Velocidad Maxima" }
               );
            modelBuilder.Entity<CaracteristicaTransporte>().HasData(
               new CaracteristicaTransporte { CaracteristicaTransporteId = 1, CaracteristicaId = 1, TransporteId = 3, Valor = "50" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 2, CaracteristicaId = 2, TransporteId = 2, Valor = "SemiCama" },
               new CaracteristicaTransporte { CaracteristicaTransporteId = 3, CaracteristicaId = 3, TransporteId = 1, Valor = "300 km/h" }
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
