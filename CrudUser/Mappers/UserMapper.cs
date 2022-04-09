
using CrudUser.Dtos.Users;
using CrudUser.Entites;

using System;

namespace CrudUser.Mappers
{
    public static class UserMapper
    {
        public static UserDto ConvertToDto(this User user)
            => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                IsActive = user.IsActive,
                LastName = user.LastName,
                Name = user.Name
            };

        public static User ConvertToEntity(this CreateUserInput input)
            => new User
            {
                Email = input.Email,
                IsActive = input.IsActive,
                LastName = input.LastName,
                Name = input.Name
            };
    }
}
