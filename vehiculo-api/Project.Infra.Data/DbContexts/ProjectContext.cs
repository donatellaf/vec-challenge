using Project.Domain.Entities;
using Project.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Project.Infra.Data.DbContexts
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();           
        }
    }
}
