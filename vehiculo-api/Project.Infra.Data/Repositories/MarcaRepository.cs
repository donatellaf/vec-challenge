using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;

namespace Project.Infra.Data.Repositories
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(ProjectContext context) : base(context) { }
    }
}
