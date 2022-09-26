using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;

namespace Project.Infra.Data.Repositories
{
    public class CombustibleRepository : RepositoryBase<Combustible>, ICombustibleRepository
    {
        public CombustibleRepository(ProjectContext context) : base(context) { }
    }
}
