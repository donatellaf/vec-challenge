using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.QueryFilters;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class TipoVehiculoService : ITipoVehiculoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationOptions paginationOptions;

        public TipoVehiculoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            this.unitOfWork = unitOfWork;
            this.paginationOptions = options.Value;
        }

        public async Task<TipoVehiculo> GetTipoVehiculo(int id)
        {
            return await unitOfWork.TipoVehiculoRepository.GetById(id);
        }

        public PagedList<TipoVehiculo> GetAllTipoVehiculos(TipoVehiculoQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? paginationOptions.DefaultPageSize : filters.PageSize;

            var tipoVehiculo = unitOfWork.TipoVehiculoRepository.GetAll();

            var pagedVehiculo = PagedList<TipoVehiculo>.Create(tipoVehiculo, filters.PageNumber, filters.PageSize);
            return pagedVehiculo;
        }

        public async Task InsertTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            await unitOfWork.TipoVehiculoRepository.Add(tipoVehiculo);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            unitOfWork.TipoVehiculoRepository.Update(tipoVehiculo);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTipoVehiculo(int id)
        {
            await unitOfWork.TipoVehiculoRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
