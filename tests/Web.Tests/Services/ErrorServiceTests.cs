using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Web.DAL.Data;
using Web.DAL.Models;
using Web.DAL.Services;

namespace Web.Tests.Services
{
    public class ErrorServiceTests
    {
        private readonly Mock<IDbContextFactory<AppDbContext>> _mockContextFactory;
        private readonly ErrorService _errorService;

        public ErrorServiceTests()
        {
            _mockContextFactory = new Mock<IDbContextFactory<AppDbContext>>();
            _errorService = new ErrorService(_mockContextFactory.Object);
        }

        private AppDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task GetApp_ErrorsAsync_ShouldReturnAllErrors()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            _mockContextFactory.Setup(f => f.CreateDbContext()).Returns(context);

            var errors = new List<AppError>
            {
                new AppError { ErrorId = 1, Message = "Error 1", ErrorStatus = new ErrorStatus { ErrorStatusId = 1, ErrorStatusText = "New" } },
                new AppError { ErrorId = 2, Message = "Error 2", ErrorStatus = new ErrorStatus { ErrorStatusId = 2, ErrorStatusText = "Acknowledged" } }
            };
            context.AppErrors.AddRange(errors);
            await context.SaveChangesAsync();

            // Act
            var result = await _errorService.GetApp_ErrorsAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(e => e.ErrorId == 1 && e.Message == "Error 1");
            result.Should().Contain(e => e.ErrorId == 2 && e.Message == "Error 2");
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AddErrorAsync_ShouldAddNewError()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            _mockContextFactory.Setup(f => f.CreateDbContext()).Returns(context);

            var newError = new AppError { Message = "New Error", ErrorStatusId = 1 };

            // Act
            var result = await _errorService.AddErrorAsync(newError);

            // Assert
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.ErrorId.Should().BeGreaterThan(0);
            context.AppErrors.Should().Contain(e => e.Message == "New Error");
            Assert.True(result.Success);
        }

        [Fact]
        public async Task AddErrorAsync_ShouldFailForExistingErrorId()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            _mockContextFactory.Setup(f => f.CreateDbContext()).Returns(context);

            var existingError = new AppError { ErrorId = 1, Message = "Existing Error", ErrorStatusId = 1 };
            context.AppErrors.Add(existingError);
            await context.SaveChangesAsync();

            // Act
            var result = await _errorService.AddErrorAsync(existingError);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Error adding an App Error that already exists");
            Assert.False(result.Success);
        }

        [Fact]
        public async Task EditErrorAsync_ShouldUpdateExistingError()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            _mockContextFactory.Setup(f => f.CreateDbContext()).Returns(context);

            var existingError = new AppError { ErrorId = 1, Message = "Original Error", ErrorStatusId = 1 };
            context.AppErrors.Add(existingError);
            await context.SaveChangesAsync();

            var updatedError = new AppError { ErrorId = 1, Message = "Updated Error", ErrorStatusId = 2 };

            // Act
            var result = await _errorService.EditErrorAsync(updatedError);

            // Assert
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Message.Should().Be("Updated Error");
            result.Data.ErrorStatusId.Should().Be(2);
            context.AppErrors.First(e => e.ErrorId == 1).Message.Should().Be("Updated Error");
            Assert.True(result.Success);
        }

        [Fact]
        public async Task EditErrorAsync_ShouldFailForNonExistingError()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            _mockContextFactory.Setup(f => f.CreateDbContext()).Returns(context);

            var nonExistingError = new AppError { ErrorId = 999, Message = "Non-existing Error", ErrorStatusId = 1 };

            // Act
            var result = await _errorService.EditErrorAsync(nonExistingError);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Error editing an App Error that doesn't exists");
            Assert.False(result.Success);
        }
    }
}
