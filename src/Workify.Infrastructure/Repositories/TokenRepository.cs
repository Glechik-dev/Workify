using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;
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

        public async Task UpdateToken(string tokenId, string refreshToken)
        {
            if (!Guid.TryParse(tokenId, out Guid guTokenId))
                return;
            await _context.Token.Where((entity) => entity.Id == guTokenId).ExecuteUpdateAsync((b) => b.SetProperty((u) => u.RefreshToken, refreshToken));
        }
    }
}
