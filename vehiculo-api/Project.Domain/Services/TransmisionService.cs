using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.QueryFilters;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class TransmisionService : ITransmisionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationOptions paginationOptions;

        public TransmisionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            this.unitOfWork = unitOfWork;
            this.paginationOptions = options.Value;
        }

        public async Task<Transmision> GetTransmision(int id)
        {
            return await unitOfWork.TransmisionRepository.GetById(id);
        }

        public PagedList<Transmision> GetAllTransmisiones(TransmisionQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? paginationOptions.DefaultPageSize : filters.PageSize;

            var transmision = unitOfWork.TransmisionRepository.GetAll();

            var pagedVehiculo = PagedList<Transmision>.Create(transmision, filters.PageNumber, filters.PageSize);
            return pagedVehiculo;
        }

        public async Task InsertTransmision(Transmision transmision)
        {
            await unitOfWork.TransmisionRepository.Add(transmision);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTransmision(Transmision transmision)
        {
            unitOfWork.TransmisionRepository.Update(transmision);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTransmision(int id)
        {
            await unitOfWork.TransmisionRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
