
using CrudUser.Dtos.Users;
using CrudUser.Entites;

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

        public static User ConvertToEntity(this UserDto user)
            => new User
            {
                Id = user.Id,
                Email = user.Email,
                IsActive = user.IsActive,
                LastName = user.LastName,
                Name = user.Name
            };
    }
}
