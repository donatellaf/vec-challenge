
using Project.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVehiculoRepository VehiculoRepository { get; }
        ICombustibleRepository CombustibleRepository { get; }
        IMarcaRepository MarcaRepository { get; }
        ITipoVehiculoRepository TipoVehiculoRepository { get; }
        ITransmisionRepository TransmisionRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
