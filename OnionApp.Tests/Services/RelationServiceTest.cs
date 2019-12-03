using System;
using Xunit;
using Moq;
using OnionApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnionApp.Domain.Models.Entities;
using AutoMapper;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Infrastructure.Mapper;
using OnionApp.Domain.Services;

namespace OnionApp.Tests.Services
{
    public class RelationServiceTest
    {
        private IRelationService _relationService;

        private List<Relation> _relationsList = new List<Relation>()
        {
            new Relation(){Id = new Guid("7bf2a77f-70b8-46a3-8d2c-987605cc54de"), IsDisabled = false},
            new Relation(){Id = new Guid("23235f6f-437e-4e4b-975d-ad322957053f"), IsDisabled = false},
            new Relation(){Id = new Guid("74079786-0448-4772-bdd5-cebcfe593f0f"), IsDisabled = true}
        };

        public RelationServiceTest()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var relationRepositoryMock = new Mock<IRelationRepository>();
            var countryServiceMock = new Mock<ICountryService>();
            var mapper = new Mapper(new MapperConfiguration(expr => expr.AddProfile<RelationProfile>()));

            relationRepositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Relation, bool>>>())).
                Returns((Expression<Func<Relation, bool>> x) => GetAsync(x));
            relationRepositoryMock.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Relation, bool>>>())).
                Returns((Expression<Func<Relation, bool>> x) => GetAllAsync(x));
            unitOfWorkMock.SetupGet(x => x.RelationRepository).Returns(relationRepositoryMock.Object);

            _relationService = new RelationService(unitOfWorkMock.Object, mapper, countryServiceMock.Object);
        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var id = new Guid("7bf2a77f-70b8-46a3-8d2c-987605cc54de");
            var result = await _relationService.GetByIdAsync(id);

            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void GetAllEnabledBasicInfoAsyncTest()
        {
            var enabledRelations = await _relationService.GetAllEnabledBasicInfoAsync();

            Assert.Equal(2, enabledRelations.Count());
        }

        [Fact]
        public async void DisableAsyncTest()
        {
            var id = new Guid("23235f6f-437e-4e4b-975d-ad322957053f");
            await _relationService.DisableAsync(id);

            Assert.True(_relationsList.Find(x => x.Id == id).IsDisabled);
        }

        [Fact]
        public async void DisableRangeAsync()
        {
            var idsToDisable = _relationsList.Select(x => x.Id).ToList();
            await _relationService.DisableRangeAsync(idsToDisable);

            Assert.False(_relationsList.Exists(x => x.IsDisabled == false));
        }

        private Task<Relation> GetAsync(Expression<Func<Relation, bool>> predicate)
        {
            var expr = predicate.Compile();
            var relation = _relationsList.Where(predicate.Compile()).FirstOrDefault();

            return Task.FromResult(relation);
        }

        private Task<IEnumerable<Relation>> GetAllAsync(Expression<Func<Relation, bool>> predicate)
        {
            var expr = predicate.Compile();
            var relation = _relationsList.Where(predicate.Compile());

            return Task.FromResult(relation);
        }
    }
}
