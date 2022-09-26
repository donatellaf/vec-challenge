using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.API.Model
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Combustible> Combustible { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Transmision> Transmision { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=CARS_DATABASE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combustible>(entity =>
            {
                entity.HasKey(e => e.IdCombustible)
                    .HasName("PK__Combusti__699FEC5A43AD7FC6");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__4076A887470C4659");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK__TipoVehi__DC20741EC1FBE000");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Transmision>(entity =>
            {
                entity.HasKey(e => e.IdTransmision)
                    .HasName("PK__Transmis__B950A0A48CD274CA");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__708612156DDBA4E4");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
