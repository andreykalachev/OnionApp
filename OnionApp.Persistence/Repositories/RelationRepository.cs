using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Repositories
{
    public class RelationRepository : GenericRepository<Relation>
    {
        public RelationRepository(DataContext context) : base(context)
        {
        }

        public override async Task<Relation> GetAsync(Guid id)
        {
            return await FindAsync(x => x.Id == id);
        }

        public override async Task<Relation> FindAsync(Expression<Func<Relation, bool>> predicate)
        {
            return await DbSet.Where(predicate).Include(x => x.RelationAddress).FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Relation>> GetAllAsync()
        {
            return await DbSet.Include(x => x.RelationAddress).ToListAsync();
        }

        public override async Task<IEnumerable<Relation>> GetAllAsync(Expression<Func<Relation, bool>> predicate)
        {
            return await DbSet.Where(predicate).Include(x => x.RelationAddress).ToListAsync();
        }
    }
}
