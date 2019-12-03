using Xunit;
using Moq;
using OnionApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnionApp.Domain.Models.Entities;
using AutoMapper;
using OnionApp.Domain.Interfaces.Repositories;
using OnionApp.Domain.Interfaces.Services;
using OnionApp.Infrastructure.Mapper;
using OnionApp.Domain.Services;

namespace OnionApp.Tests.Services
{
    public class CategoryServiceTest
    {
        private ICategoryService _service;

        public CategoryServiceTest()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<ICategoryRepository>();
            var mapper = new Mapper(new MapperConfiguration(expr => expr.AddProfile<CategoryProfile>()));

            repositoryMock.Setup(r => r.GetAllAsync()).Returns(GetAllCategoriesBasicInfo());
            unitOfWorkMock.SetupGet(x => x.CategoryRepository).Returns(repositoryMock.Object);

            _service = new CategoryService(unitOfWorkMock.Object, mapper);
        }

        [Fact]
        public async void GetBasicInfoAllAsyncTest()
        {
            var result = await _service.GetBasicInfoAllAsync();

            Assert.Equal(2, result.Count());
        }

        private Task<IEnumerable<Category>> GetAllCategoriesBasicInfo()
        {
            var result = new List<Category>();
            result.AddRange(Enumerable.Repeat(new Category(), 2));
            
            return Task.FromResult((IEnumerable<Category>) result);
        }
    }
}
