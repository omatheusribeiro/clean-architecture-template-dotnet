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
    public class UserContactServiceTests
    {
        private readonly Mock<IUserContactRepository> _userContactRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserContactService _userContactService;
        private readonly Fixture _fixture;

        public UserContactServiceTests()
        {
            _userContactRepositoryMock = new Mock<IUserContactRepository>();
            _mapperMock = new Mock<IMapper>();
            _userContactService = new UserContactService(_mapperMock.Object, _userContactRepositoryMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Put_WithValidContact_ReturnsSuccess()
        {
            // Arrange
            var contactViewModel = _fixture.Create<UserContactViewModel>();
            var contact = _fixture.Create<UserContact>();

            _userContactRepositoryMock.Setup(x => x.GetById(contactViewModel.Id))
                .ReturnsAsync(contact);

            _mapperMock.Setup(x => x.Map<UserContact>(contactViewModel))
                .Returns(contact);

            _userContactRepositoryMock.Setup(x => x.Put(contact))
                .ReturnsAsync(contact);

            _mapperMock.Setup(x => x.Map<UserContactViewModel>(contact))
                .Returns(contactViewModel);

            // Act
            var result = await _userContactService.Put(contactViewModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(contactViewModel, result.Data);
            _userContactRepositoryMock.Verify(x => x.GetById(contactViewModel.Id), Times.Once);
            _userContactRepositoryMock.Verify(x => x.Put(contact), Times.Once);
        }

        [Fact]
        public async Task Put_WithNonExistentContact_ReturnsFail()
        {
            // Arrange
            var contactViewModel = _fixture.Create<UserContactViewModel>();

            _userContactRepositoryMock.Setup(x => x.GetById(contactViewModel.Id))
                .ReturnsAsync((UserContact)null);

            // Act
            var result = await _userContactService.Put(contactViewModel);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("contact not found.", result.Message);
            _userContactRepositoryMock.Verify(x => x.Put(It.IsAny<UserContact>()), Times.Never);
        }

        [Fact]
        public async Task Put_WhenExceptionOccurs_ReturnsFail()
        {
            // Arrange
            var contactViewModel = _fixture.Create<UserContactViewModel>();
            var contact = _fixture.Create<UserContact>();
            var exceptionMessage = "Database error";

            _userContactRepositoryMock.Setup(x => x.GetById(contactViewModel.Id))
                .ReturnsAsync(contact);

            _mapperMock.Setup(x => x.Map<UserContact>(contactViewModel))
                .Returns(contact);

            _userContactRepositoryMock.Setup(x => x.Put(contact))
                .ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _userContactService.Put(contactViewModel);

            // Assert
            Assert.False(result.Success);
            Assert.Equal($"There was an error editing the user contact: {exceptionMessage}", result.Message);
        }

        [Fact]
        public async Task Put_WithNullContact_ReturnsFail()
        {
            // Arrange
            UserContactViewModel contactViewModel = null;

            // Act
            var result = await _userContactService.Put(contactViewModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Object reference not set to an instance of an object", result.Message);
            _userContactRepositoryMock.Verify(x => x.Put(It.IsAny<UserContact>()), Times.Never);
        }

        [Fact]
        public async Task Put_VerifyMappingCalls()
        {
            // Arrange
            var contactViewModel = _fixture.Create<UserContactViewModel>();
            var contact = _fixture.Create<UserContact>();

            _userContactRepositoryMock.Setup(x => x.GetById(contactViewModel.Id))
                .ReturnsAsync(contact);

            _mapperMock.Setup(x => x.Map<UserContact>(contactViewModel))
                .Returns(contact);

            _userContactRepositoryMock.Setup(x => x.Put(contact))
                .ReturnsAsync(contact);

            _mapperMock.Setup(x => x.Map<UserContactViewModel>(contact))
                .Returns(contactViewModel);

            // Act
            await _userContactService.Put(contactViewModel);

            // Assert
            _mapperMock.Verify(x => x.Map<UserContact>(contactViewModel), Times.Once);
            _mapperMock.Verify(x => x.Map<UserContactViewModel>(contact), Times.Once);
        }

        [Fact]
        public async Task Put_VerifyRepositorySequence()
        {
            // Arrange
            var contactViewModel = _fixture.Create<UserContactViewModel>();
            var contact = _fixture.Create<UserContact>();
            var sequence = new List<string>();

            _userContactRepositoryMock.Setup(x => x.GetById(contactViewModel.Id))
                .Callback(() => sequence.Add("GetById"))
                .ReturnsAsync(contact);

            _mapperMock.Setup(x => x.Map<UserContact>(contactViewModel))
                .Returns(contact);

            _userContactRepositoryMock.Setup(x => x.Put(contact))
                .Callback(() => sequence.Add("Put"))
                .ReturnsAsync(contact);

            // Act
            await _userContactService.Put(contactViewModel);

            // Assert
            Assert.Equal(new[] { "GetById", "Put" }, sequence);
        }
    }
} 