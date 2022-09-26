using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.QueryFilters;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Services
{
    public interface ITipoVehiculoService
    {
        PagedList<TipoVehiculo> GetAllTipoVehiculos(TipoVehiculoQueryFilter filters);

        Task<TipoVehiculo> GetTipoVehiculo(int id);

        Task InsertTipoVehiculo(TipoVehiculo tipoVehiculo);

        Task<bool> UpdateTipoVehiculo(TipoVehiculo tipoVehiculo);

        Task<bool> DeleteTipoVehiculo(int id);
    }
}
