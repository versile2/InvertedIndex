using FluentAssertions;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Moq;
using Web.DAL.Services;

namespace Web.Tests.ServiceTests
{
    public class LocalStorageServiceTests
    {
        private readonly Mock<ProtectedLocalStorage> _mockProtectedLocalStorage;
        private readonly LocalStorageService _localStorageService;

        public LocalStorageServiceTests()
        {
            _mockProtectedLocalStorage = new Mock<ProtectedLocalStorage>();
            _localStorageService = new LocalStorageService(_mockProtectedLocalStorage.Object);
        }

        [Fact]
        public async Task ContainKeyAsync_KeyExists_ReturnsTrue()
        {
            // Arrange
            var key = "testKey";
            //_mockProtectedLocalStorage
            //    .Setup(m => m.GetAsync<object>(key))
            //       .ReturnsAsync(new ValueTask<ProtectedBrowserStorageResult<object>>(
            //        Task.FromResult(new ProtectedBrowserStorageResult<object>())));

            // Act
            var result = await _localStorageService.ContainKeyAsync(key);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetItemAsync_KeyExists_ReturnsValue()
        {
            // Arrange
            var key = "testKey";
            var expectedValue = "testValue";
            //_mockProtectedLocalStorage
            //    .Setup(m => m.GetAsync<string>(key))
            //    .ReturnsAsync(ProtectedBrowserStorageResult<string>.Success(expectedValue));

            // Act
            var result = await _localStorageService.GetItemAsync<string>(key);

            // Assert
            result.Success.Should().BeTrue();
            result.Value.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetItemAsync_ValidInput_CallsSetAsync()
        {
            // Arrange
            var key = "testKey";
            var value = "testValue";

            // Act
            await _localStorageService.SetItemAsync(key, value);

            // Assert
            _mockProtectedLocalStorage.Verify(m => m.SetAsync(key, value), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_ValidKey_CallsDeleteAsync()
        {
            // Arrange
            var key = "testKey";

            // Act
            await _localStorageService.DeleteItemAsync(key);

            // Assert
            _mockProtectedLocalStorage.Verify(m => m.DeleteAsync(key), Times.Once);
        }
    }
}
