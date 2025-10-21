using Microsoft.AspNetCore.Identity;
using Workify.Core.Entities;

namespace Workify.Application.Services
{
    public class PasswordService
    {
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        public PasswordService(IPasswordHasher<UserEntity> passwordHasher) 
        { 
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(UserEntity user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(UserEntity user,string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
