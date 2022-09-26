using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.QueryFilters;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationOptions paginationOptions;

        public VehiculoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            this.unitOfWork = unitOfWork;
            this.paginationOptions = options.Value;
        }

        public async Task<Vehiculo> GetVehiculo(int id)
        {
            return await unitOfWork.VehiculoRepository.GetById(id);
        }

        public PagedList<Vehiculo> GetAllVehiculos(VehiculoQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? paginationOptions.DefaultPageSize : filters.PageSize;

            var vehiculo = unitOfWork.VehiculoRepository.GetAll();

            var pagedVehiculo = PagedList<Vehiculo>.Create(vehiculo, filters.PageNumber, filters.PageSize);
            return pagedVehiculo;
        }

        public async Task InsertVehiculo(Vehiculo vehiculo)
        {
            await unitOfWork.VehiculoRepository.Add(vehiculo);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateVehiculo(Vehiculo vehiculo)
        {
            unitOfWork.VehiculoRepository.Update(vehiculo);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehiculo(int id)
        {
            await unitOfWork.VehiculoRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
