using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.QueryFilters;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Services
{
    public interface IVehiculoService
    {
        PagedList<Vehiculo> GetAllVehiculos(VehiculoQueryFilter filters);

        Task<Vehiculo> GetVehiculo(int id);

        Task InsertVehiculo(Vehiculo vehiculo);

        Task<bool> UpdateVehiculo(Vehiculo vehiculo);

        Task<bool> DeleteVehiculo(int id);
    }
}
