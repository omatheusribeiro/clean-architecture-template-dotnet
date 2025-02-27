using AutoFixture;
using AutoMapper;
using clean_architecture_dotnet.Application.Services.Products;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;
using Moq;
using Xunit;

namespace clean_architecture_dotnet.Tests.Application.Services.Products
{
    public class ProductTypeServiceTests
    {
        private readonly Mock<IProductTypeRepository> _productTypeRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductTypeService _productTypeService;
        private readonly Fixture _fixture;

        public ProductTypeServiceTests()
        {
            _productTypeRepositoryMock = new Mock<IProductTypeRepository>();
            _mapperMock = new Mock<IMapper>();
            _productTypeService = new ProductTypeService(_mapperMock.Object, _productTypeRepositoryMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Put_WithValidProductType_ReturnsSuccess()
        {
            // Arrange
            var productTypeViewModel = _fixture.Create<ProductTypeViewModel>();
            var productType = _fixture.Create<ProductType>();

            _productTypeRepositoryMock.Setup(x => x.GetById(productTypeViewModel.Id))
                .ReturnsAsync(productType);

            _mapperMock.Setup(x => x.Map<ProductType>(productTypeViewModel))
                .Returns(productType);

            _productTypeRepositoryMock.Setup(x => x.Put(productType))
                .ReturnsAsync(productType);

            _mapperMock.Setup(x => x.Map<ProductTypeViewModel>(productType))
                .Returns(productTypeViewModel);

            // Act
            var result = await _productTypeService.Put(productTypeViewModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(productTypeViewModel, result.Data);
        }

        [Fact]
        public async Task Post_WithValidProductType_ReturnsSuccess()
        {
            // Arrange
            var productTypeViewModel = _fixture.Create<ProductTypeViewModel>();
            var productType = _fixture.Create<ProductType>();

            _mapperMock.Setup(x => x.Map<ProductType>(productTypeViewModel))
                .Returns(productType);

            _productTypeRepositoryMock.Setup(x => x.Post(productType))
                .ReturnsAsync(productType);

            _mapperMock.Setup(x => x.Map<ProductTypeViewModel>(productType))
                .Returns(productTypeViewModel);

            // Act
            var result = await _productTypeService.Post(productTypeViewModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(productTypeViewModel, result.Data);
        }
    }
} 