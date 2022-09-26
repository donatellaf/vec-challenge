using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.QueryFilters;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationOptions paginationOptions;

        public MarcaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            this.unitOfWork = unitOfWork;
            this.paginationOptions = options.Value;
        }

        public async Task<Marca> GetMarca(int id)
        {
            return await unitOfWork.MarcaRepository.GetById(id);
        }

        public PagedList<Marca> GetAllMarcas(MarcaQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? paginationOptions.DefaultPageSize : filters.PageSize;

            var marca = unitOfWork.MarcaRepository.GetAll();

            var pagedMarca = PagedList<Marca>.Create(marca, filters.PageNumber, filters.PageSize);
            return pagedMarca;
        }

        public async Task InsertMarca(Marca marca)
        {
            await unitOfWork.MarcaRepository.Add(marca);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateMarca(Marca marca)
        {
            unitOfWork.MarcaRepository.Update(marca);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMarca(int id)
        {
            await unitOfWork.MarcaRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
