
using Workify.Application.DTO;
using Workify.Infrastructure.Repositories;

namespace Workify.Application.Services
{
    public class AuthService
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly TokenRepository _tokenRepository;
        private readonly UserRepository _userRepository;
        private readonly UserSettingsRepository _userSettingsRepository;

        public AuthService(JwtTokenService jwtTokenService, TokenRepository tokenRepository, 
            UserRepository userRepository, UserSettingsRepository userSettingsRepository)
        { 
            _jwtTokenService = jwtTokenService;
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _userSettingsRepository = userSettingsRepository;
        }

        public Tokens Login(LoginDTO login)
        {

        }
    }
}
