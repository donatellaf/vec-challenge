using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.QueryFilters;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Services
{
    public interface ITransmisionService
    {
        PagedList<Transmision> GetAllTransmisiones(TransmisionQueryFilter filters);

        Task<Transmision> GetTransmision(int id);

        Task InsertTransmision(Transmision transmision);

        Task<bool> UpdateTransmision(Transmision transmision);

        Task<bool> DeleteTransmision(int id);
    }
}
