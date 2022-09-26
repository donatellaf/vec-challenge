
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;
using System.Threading.Tasks;

namespace Project.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext context;
        private readonly IVehiculoRepository vehiculoRepository;
        private readonly ICombustibleRepository combustibleRepository;
        private readonly IMarcaRepository marcaRepository;
        private readonly ITipoVehiculoRepository tipoVehiculoRepository;
        private readonly ITransmisionRepository transmisionRepository;

        public UnitOfWork(ProjectContext context)
        {
            this.context = context;
        }

        public IVehiculoRepository VehiculoRepository => vehiculoRepository ?? new VehiculoRepository(context);
        public ICombustibleRepository CombustibleRepository => combustibleRepository ?? new CombustibleRepository(context);
        public IMarcaRepository MarcaRepository => marcaRepository ?? new MarcaRepository(context);
        public ITipoVehiculoRepository TipoVehiculoRepository => tipoVehiculoRepository ?? new TipoVehiculoRepository(context);
        public ITransmisionRepository TransmisionRepository => transmisionRepository ?? new TransmisionRepository(context);


        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
