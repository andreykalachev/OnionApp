using Xunit;
using Moq;
using OnionApp.Domain.Interfaces;
using System.Linq;
using AutoMapper;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Infrastructure.Mapper;
using OnionApp.Domain.Services;
using OnionApp.Tests.MockRepositories;

namespace OnionApp.Tests.Services
{
    public class RelationServiceTest
    {
        private readonly IRelationService _relationService;
        private readonly MockRelationRepository _relationRepositoryMock;

        public RelationServiceTest()
        {
            _relationRepositoryMock = new MockRelationRepository();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var countryServiceMock = new Mock<ICountryService>();
            var mapper = new Mapper(new MapperConfiguration(expr => expr.AddProfile<RelationProfile>()));
            unitOfWorkMock.SetupGet(x => x.RelationRepository).Returns(_relationRepositoryMock.Object);

            _relationService = new RelationService(unitOfWorkMock.Object, mapper, countryServiceMock.Object);
        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var id = _relationRepositoryMock.RelationsList.First().Id;
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
            var id = _relationRepositoryMock.RelationsList.First().Id;
            await _relationService.DisableAsync(id);

            Assert.True(_relationRepositoryMock.RelationsList.Find(x => x.Id == id).IsDisabled);
        }

        [Fact]
        public async void DisableRangeAsync()
        {
            var idsToDisable = _relationRepositoryMock.RelationsList.Select(x => x.Id).ToList();
            await _relationService.DisableRangeAsync(idsToDisable);

            Assert.False(_relationRepositoryMock.RelationsList.Exists(x => x.IsDisabled == false));
        }
    }
}
