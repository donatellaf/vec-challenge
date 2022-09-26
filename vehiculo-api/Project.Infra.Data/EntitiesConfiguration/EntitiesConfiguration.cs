using Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Infra.Data.EntitiesConfiguration
{
    public static class EntitiesConfiguration
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Combustible>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Combusti__699FEC5A43AD7FC6");

                entity.Property(e => e.Id).HasColumnName("IdCombustible");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Marca__4076A887470C4659");

                entity.Property(e => e.Id).HasColumnName("IdMarca");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__TipoVehi__DC20741EC1FBE000");

                entity.Property(e => e.Id).HasColumnName("IdTipoVehiculo");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Transmision>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Transmis__B950A0A48CD274CA");

                entity.Property(e => e.Id).HasColumnName("IdTransmision");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Vehiculo__708612156DDBA4E4");

                entity.Property(e => e.Id).HasColumnName("IdVehiculo");
                entity.Property(e => e.IdCombustible).HasColumnName("IdCombustible");
                entity.Property(e => e.IdMarca).HasColumnName("IdMarca");
                entity.Property(e => e.IdTipoVehiculo).HasColumnName("IdTipoVehiculo");
                entity.Property(e => e.IdTransmision).HasColumnName("IdTransmision");


                entity.HasIndex(e => e.NumeroChasis)
                    .HasName("UQ__Vehiculo__FDB1AF9A6EBE91BF")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroPatente)
                    .HasName("UQ__Vehiculo__E8373E0401549449")
                    .IsUnique();

                entity.Property(e => e.ModeloName).IsUnicode(false);

                entity.Property(e => e.NumeroChasis).IsUnicode(false);

                entity.Property(e => e.NumeroPatente).IsUnicode(false);

                entity.HasOne(d => d.IdCombustibleNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdCombustible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehiculo__IdComb__6754599E");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehiculo__IdMarc__66603565");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehiculo__IdTipo__656C112C");

                entity.HasOne(d => d.IdTransmisionNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdTransmision)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehiculo__IdTran__68487DD7");
            });
        }
    }
}
