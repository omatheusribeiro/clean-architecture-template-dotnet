using AutoFixture;
using AutoMapper;
using clean_architecture_dotnet.Application.Services.Sales;
using clean_architecture_dotnet.Application.ViewModels.Sales;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Domain.Entities.Sales;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Sales.Interfaces;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;
using Moq;
using Xunit;

namespace clean_architecture_dotnet.Tests.Application.Services.Sales
{
    public class SaleServiceTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly SaleService _saleService;
        private readonly Fixture _fixture;

        public SaleServiceTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _saleService = new SaleService(
                _saleRepositoryMock.Object,
                _productRepositoryMock.Object,
                _userRepositoryMock.Object,
                _mapperMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAll_ReturnsAllSales()
        {
            // Arrange
            var sales = _fixture.CreateMany<Sale>().ToList();
            var salesViewModel = _fixture.CreateMany<SaleViewModel>().ToList();

            _saleRepositoryMock.Setup(x => x.GetAll())
                .ReturnsAsync(sales);

            _mapperMock.Setup(x => x.Map<IEnumerable<SaleViewModel>>(sales))
                .Returns(salesViewModel);

            // Act
            var result = await _saleService.GetAll();

            // Assert
            Assert.True(result.Success);
            Assert.Equal(salesViewModel, result.Data);
        }

        [Fact]
        public async Task Post_WithValidSale_ReturnsSuccess()
        {
            // Arrange
            var saleViewModel = _fixture.Create<SaleViewModel>();
            var sale = _fixture.Create<Sale>();
            var product = _fixture.Create<Product>();
            var user = _fixture.Create<User>();

            _productRepositoryMock.Setup(x => x.GetById(saleViewModel.ProductId))
                .ReturnsAsync(product);

            _userRepositoryMock.Setup(x => x.GetById(saleViewModel.UserId))
                .ReturnsAsync(user);

            _mapperMock.Setup(x => x.Map<Sale>(saleViewModel))
                .Returns(sale);

            _saleRepositoryMock.Setup(x => x.Post(sale))
                .ReturnsAsync(sale);

            _mapperMock.Setup(x => x.Map<SaleViewModel>(sale))
                .Returns(saleViewModel);

            // Act
            var result = await _saleService.Post(saleViewModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(saleViewModel, result.Data);
        }
    }
} 