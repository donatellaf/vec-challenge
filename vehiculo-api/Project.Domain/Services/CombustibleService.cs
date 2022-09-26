using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.QueryFilters;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class CombustibleService : ICombustibleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationOptions paginationOptions;

        public CombustibleService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            this.unitOfWork = unitOfWork;
            this.paginationOptions = options.Value;
        }

        public async Task<Combustible> GetCombustible(int id)
        {
            return await unitOfWork.CombustibleRepository.GetById(id);
        }

        public PagedList<Combustible> GetAllCombustibles(CombustibleQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? paginationOptions.DefaultPageSize : filters.PageSize;

            var combustible = unitOfWork.CombustibleRepository.GetAll();

            var pagedCombustible = PagedList<Combustible>.Create(combustible, filters.PageNumber, filters.PageSize);
            return pagedCombustible;
        }

        public async Task InsertCombustible(Combustible combustible)
        {
            await unitOfWork.CombustibleRepository.Add(combustible);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCombustible(Combustible combustible)
        {
            unitOfWork.CombustibleRepository.Update(combustible);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCombustible(int id)
        {
            await unitOfWork.CombustibleRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
