using System.Threading.Tasks;
using OnionApp.Domain.Interfaces.Repositories;

namespace OnionApp.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRelationRepository RelationRepository { get; set; }

        ICountryRepository CountryRepository { get; set; }

        ICategoryRepository CategoryRepository { get; set; }

        Task CommitAsync();

        Task RejectChangesAsync();
    }
}
