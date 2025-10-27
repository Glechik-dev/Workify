using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.Other;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class TokenRepository
    {
        private readonly MyDBContext _context;
        public TokenRepository(MyDBContext context) 
        { 
            _context = context;
        }

        public async Task AddToken(TokenEntity token)
        {
            await _context.Token.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateToken(Guid tokenId, string refreshToken)
        {
            await _context.Token.Where((entity) => entity.Id == tokenId).ExecuteUpdateAsync((b) => b.SetProperty((u) => u.RefreshToken, refreshToken));
        }
    }
}
