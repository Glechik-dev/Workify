﻿using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.User;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly MyDBContext _context;
        public UserRepository(MyDBContext context) 
        {
            _context = context;
        }

        public async Task<UserEntity> FindUserById(Guid id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<UserEntity> FindUserByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync((e) => e.Email == email);
        }

        public async Task AddUser(UserEntity user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
