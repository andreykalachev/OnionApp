using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Repositories
{
    public class RelationAddressRepository : GenericRepository<RelationAddress>, IRelationAddressRepository
    {
        public RelationAddressRepository(DataContext context) : base(context)
        {
        }
    }
}
