using System.Threading.Tasks;

using CrudUser.Dtos.Users;
using CrudUser.Entites;
using CrudUser.Services;
using CrudUser.Tests;

using Xunit;

namespace CrudUser.Tests
{
    public class UserServiceTest
    {

        [Fact]
        public async Task CreateUser()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Name = "Jorge",
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.CreateAsync(user);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateUserRequiredFirstName()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Name = string.Empty,
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.CreateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateUserRequiredLastName()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Name = "Jorge",
                LastName = string.Empty,
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.CreateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateUserInvalidEmail()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Name = "Jorge",
                LastName = "Martinez",
                Email = string.Empty,
                IsActive = true
            };

            // Act
            var result = await service.CreateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUser()
        {
            var context = AppDbContextHelper.Create();
            var user = new User
            {
                Name = "Jorge",
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            context.Users.Add(user);
            context.SaveChanges();

            // Arrange
            var service = new UserService(context);
            var userDto = new UserDto
            {
                Id = 1,
                Name = "Jorge",
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.UpdateAsync(userDto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateUserDontExistId()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Id = -1,
                Name = "Jorge",
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.UpdateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUserRequiredFirstName()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Id = 1,
                Name = string.Empty,
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.UpdateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUserRequiredLastName()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Id = 1,
                Name = "Jorge",
                LastName = string.Empty,
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            // Act
            var result = await service.UpdateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUserInvalidEmail()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);
            var user = new UserDto
            {
                Id = 1,
                Name = "Jorge",
                LastName = "Martinez",
                Email = string.Empty,
                IsActive = true
            };

            // Act
            var result = await service.UpdateAsync(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteUser()
        {
            var context = AppDbContextHelper.Create();
            var user = new User
            {
                Name = "Jorge",
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            context.Users.Add(user);
            context.SaveChanges();

            // Arrange
            var service = new UserService(context);

            // Act
            var result = await service.DeleteAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsActive);
        }

        [Fact]
        public async Task DeleteUserDontExistId()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);

            // Act
            var result = await service.DeleteAsync(-1);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task GetByIdUser()
        {
            var context = AppDbContextHelper.Create();
            var user = new User
            {
                Name = "Jorge",
                LastName = "Martinez",
                Email = "jmartinez@empresa.com",
                IsActive = true
            };

            context.Users.Add(user);
            context.SaveChanges();

            // Arrange
            var service = new UserService(context);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdUserDontExistId()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);

            // Act
            var result = await service.GetByIdAsync(-1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllUsers()
        {
            var context = AppDbContextHelper.Create();

            // Arrange
            var service = new UserService(context);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}
