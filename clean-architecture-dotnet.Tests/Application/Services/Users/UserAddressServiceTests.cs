using AutoFixture;
using AutoMapper;
using clean_architecture_dotnet.Application.Services.Users;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;
using Moq;
using Xunit;

namespace clean_architecture_dotnet.Tests.Application.Services.Users
{
    public class UserAddressServiceTests
    {
        private readonly Mock<IUserAddressRepository> _userAddressRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserAddresService _userAddressService;
        private readonly Fixture _fixture;

        public UserAddressServiceTests()
        {
            _userAddressRepositoryMock = new Mock<IUserAddressRepository>();
            _mapperMock = new Mock<IMapper>();
            _userAddressService = new UserAddresService(_mapperMock.Object, _userAddressRepositoryMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Put_WithValidAddress_ReturnsSuccess()
        {
            // Arrange
            var addressViewModel = _fixture.Create<UserAddressViewModel>();
            var address = _fixture.Create<UserAddress>();

            _userAddressRepositoryMock.Setup(x => x.GetById(addressViewModel.Id))
                .ReturnsAsync(address);

            _mapperMock.Setup(x => x.Map<UserAddress>(addressViewModel))
                .Returns(address);

            _userAddressRepositoryMock.Setup(x => x.Put(address))
                .ReturnsAsync(address);

            _mapperMock.Setup(x => x.Map<UserAddressViewModel>(address))
                .Returns(addressViewModel);

            // Act
            var result = await _userAddressService.Put(addressViewModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(addressViewModel, result.Data);
            _userAddressRepositoryMock.Verify(x => x.GetById(addressViewModel.Id), Times.Once);
            _userAddressRepositoryMock.Verify(x => x.Put(address), Times.Once);
        }

        [Fact]
        public async Task Put_WithNonExistentAddress_ReturnsFail()
        {
            // Arrange
            var addressViewModel = _fixture.Create<UserAddressViewModel>();

            _userAddressRepositoryMock.Setup(x => x.GetById(addressViewModel.Id))
                .ReturnsAsync((UserAddress)null);

            // Act
            var result = await _userAddressService.Put(addressViewModel);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("address not found.", result.Message);
            _userAddressRepositoryMock.Verify(x => x.Put(It.IsAny<UserAddress>()), Times.Never);
        }

        [Fact]
        public async Task Put_WhenExceptionOccurs_ReturnsFail()
        {
            // Arrange
            var addressViewModel = _fixture.Create<UserAddressViewModel>();
            var address = _fixture.Create<UserAddress>();
            var exceptionMessage = "Database error";

            _userAddressRepositoryMock.Setup(x => x.GetById(addressViewModel.Id))
                .ReturnsAsync(address);

            _mapperMock.Setup(x => x.Map<UserAddress>(addressViewModel))
                .Returns(address);

            _userAddressRepositoryMock.Setup(x => x.Put(address))
                .ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _userAddressService.Put(addressViewModel);

            // Assert
            Assert.False(result.Success);
            Assert.Equal($"There was an error editing the user address: {exceptionMessage}", result.Message);
        }

        [Fact]
        public async Task Put_WithNullAddress_ReturnsFail()
        {
            // Arrange
            UserAddressViewModel addressViewModel = null;

            // Act
            var result = await _userAddressService.Put(addressViewModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Object reference not set to an instance of an object", result.Message);
            _userAddressRepositoryMock.Verify(x => x.Put(It.IsAny<UserAddress>()), Times.Never);
        }

        [Fact]
        public async Task Put_VerifyMappingCalls()
        {
            // Arrange
            var addressViewModel = new UserAddressViewModel
            {
                Id = 1,
                Street = "Rua das Flores",
                Number = 123,
                Complement = "",
                Neighborhood = "Test",
                City = "São Paulo",
                State = "SP",
                Country = "Brazil",
                ZipCode = "01000-000"
            };

            var address = new UserAddress
            {
                Id = 1,
                Street = "Rua das Flores",
                Number = 123,
                Complement = "",
                Neighborhood = "Test",
                City = "São Paulo",
                State = "SP",
                Country = "Brazil",
                ZipCode = "01000-000"
            };

            _userAddressRepositoryMock.Setup(x => x.GetById(addressViewModel.Id))
                .ReturnsAsync(address);

            _mapperMock.Setup(x => x.Map<UserAddress>(addressViewModel))
                .Returns(address);

            _userAddressRepositoryMock.Setup(x => x.Put(address))
                .ReturnsAsync(address);

            _mapperMock.Setup(x => x.Map<UserAddressViewModel>(address))
                .Returns(addressViewModel);

            // Act
            await _userAddressService.Put(addressViewModel);

            // Assert
            _mapperMock.Verify(x => x.Map<UserAddress>(addressViewModel), Times.Once);
            _mapperMock.Verify(x => x.Map<UserAddressViewModel>(address), Times.Once);
        }

    }
} 