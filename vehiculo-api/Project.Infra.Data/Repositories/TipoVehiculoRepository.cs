using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;

namespace Project.Infra.Data.Repositories
{
    public class TipoVehiculoRepository : RepositoryBase<TipoVehiculo>, ITipoVehiculoRepository
    {
        public TipoVehiculoRepository(ProjectContext context) : base(context) { }
    }
}
