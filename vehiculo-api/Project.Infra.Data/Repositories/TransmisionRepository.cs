using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;

namespace Project.Infra.Data.Repositories
{
    public class TransmisionRepository : RepositoryBase<Transmision>, ITransmisionRepository
    {
        public TransmisionRepository(ProjectContext context) : base(context) { }
    }
}
