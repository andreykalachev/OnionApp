using System.Threading.Tasks;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Domain.Interfaces.Repositories
{
    public interface IRelationAddressTypeRepository : IGenericRepository<AddressType>
    {
        Task<AddressType> GetFirst();
    }
}
