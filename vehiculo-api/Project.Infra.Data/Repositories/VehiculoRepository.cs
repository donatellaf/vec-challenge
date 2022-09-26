using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class VehiculoRepository : RepositoryBase<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ProjectContext context) : base(context) {}

        public override IEnumerable<Vehiculo> GetAll()
        {
            IQueryable<Vehiculo> query = entities
                .Include(e => e.IdTipoVehiculoNavigation)
                .Include(e => e.IdTransmisionNavigation)
                .Include(e => e.IdCombustibleNavigation)
                .Include(e => e.IdMarcaNavigation);


            return query.AsEnumerable();
        }

    }
}
