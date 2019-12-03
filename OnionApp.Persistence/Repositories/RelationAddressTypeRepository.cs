using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Repositories
{
    public class RelationAddressTypeRepository : GenericRepository<AddressType>, IRelationAddressTypeRepository
    {
        public RelationAddressTypeRepository(DataContext context) : base(context)
        {
        }

        public async Task<AddressType> GetFirst()
        {
            return await DbSet.FirstOrDefaultAsync();
        }
    }
}
