using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Tests.MockRepositories
{
    public class MockRelationRepository : Mock<IRelationRepository>
    {
        public List<Relation> RelationsList { get; set; }

        public MockRelationRepository()
        {
            Setup(r => r.FindAsync(It.IsAny<Expression<Func<Relation, bool>>>())).
                Returns((Expression<Func<Relation, bool>> x) => GetAsync(x));
            Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Relation, bool>>>())).
                Returns((Expression<Func<Relation, bool>> x) => GetAllAsync(x));

            RelationsList = new List<Relation>()
            {
                new Relation{Id = new Guid("7bf2a77f-70b8-46a3-8d2c-987605cc54de"), IsDisabled = false},
                new Relation{Id = new Guid("23235f6f-437e-4e4b-975d-ad322957053f"), IsDisabled = false},
                new Relation{Id = new Guid("74079786-0448-4772-bdd5-cebcfe593f0f"), IsDisabled = true}
            };
        }

        private Task<Relation> GetAsync(Expression<Func<Relation, bool>> predicate)
        {
            var relation = RelationsList.Where(predicate.Compile()).FirstOrDefault();

            return Task.FromResult(relation);
        }

        private Task<IEnumerable<Relation>> GetAllAsync(Expression<Func<Relation, bool>> predicate)
        {
            var relation = RelationsList.Where(predicate.Compile());

            return Task.FromResult(relation);
        }
    }
}
