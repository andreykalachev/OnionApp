using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Interfaces;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DataContext context, IRelationRepository relationRepository, ICountryRepository countryRepository, ICategoryRepository categoryRepository, 
            IRelationAddressRepository relationAddressRepository, IRelationAddressTypeRepository relationAddressTypeRepository)
        {
            _context = context;
            RelationRepository = relationRepository;
            CountryRepository = countryRepository;
            CategoryRepository = categoryRepository;
            RelationAddressRepository = relationAddressRepository;
            RelationAddressTypeRepository = relationAddressTypeRepository;
        }

        private readonly DataContext _context;

        public IRelationRepository RelationRepository { get; set; }

        public ICountryRepository CountryRepository { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }

        public IRelationAddressRepository RelationAddressRepository { get; set; }

        public IRelationAddressTypeRepository RelationAddressTypeRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task RejectChangesAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync();
                        break;
                }
            }
        }
    }
}
