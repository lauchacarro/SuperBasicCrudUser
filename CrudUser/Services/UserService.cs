using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CrudUser.Data;
using CrudUser.Dtos.Users;
using CrudUser.Mappers;

namespace CrudUser.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<UserDto> DeleteAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);

    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CreateAsync(UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                return null;

            if (string.IsNullOrWhiteSpace(user.LastName))
                return null;

            if (string.IsNullOrWhiteSpace(user.Email))
                return null;

            var entity = user.ConvertToEntity();

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.ConvertToDto();

        }

        public async Task<UserDto> DeleteAsync(int id)
        {
            var entity = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return null;

            entity.IsActive = false;

            _context.Users.Update(entity);

            await _context.SaveChangesAsync();

            return entity.ConvertToDto();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _context.Users.Select(x => x.ConvertToDto()).ToListAsync();
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var entity = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return null;

            return entity.ConvertToDto();
        }

        public async Task<UserDto> UpdateAsync(UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                return null;

            if (string.IsNullOrWhiteSpace(user.LastName))
                return null;

            if (string.IsNullOrWhiteSpace(user.Email))
                return null;

            var entity = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            if (entity is null)
                return null;

            entity.Name = user.Name;
            entity.LastName = user.LastName;
            entity.Email = user.Email;

            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

            return entity.ConvertToDto();
        }
    }
}
