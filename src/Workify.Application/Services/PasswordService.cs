using Microsoft.AspNetCore.Identity;
using Workify.Core.Entities;

namespace Workify.Application.Services
{
    public class PasswordService
    {
        private readonly IPasswordHasher<JobSeekerEntity> _passwordHasher;
        public PasswordService(IPasswordHasher<JobSeekerEntity> passwordHasher) 
        { 
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(JobSeekerEntity user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(JobSeekerEntity user,string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
