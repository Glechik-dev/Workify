
using Workify.Application.DTO;
using Workify.Core.Entities;
using Workify.Core.Exceptions;
using Workify.Infrastructure.Repositories;

namespace Workify.Application.Services
{
    public class AuthService
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly TokenRepository _tokenRepository;
        private readonly UserRepository _userRepository;
        private readonly UserSettingsRepository _userSettingsRepository;
        private readonly PasswordService _passwordService;

        public AuthService(
            JwtTokenService jwtTokenService,
            TokenRepository tokenRepository, 
            UserRepository userRepository,
            UserSettingsRepository userSettingsRepository,
            PasswordService passwordService
            )
        { 
            _jwtTokenService = jwtTokenService;
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _userSettingsRepository = userSettingsRepository;
            _passwordService = passwordService;
        }

        public async Task<Tokens> Login(LoginDTO login)
        {
           try
            {
                UserEntity? user = await _userRepository.GetUserByEmail(login.Email);
                if (user == null)
                {
                    throw new UserNotExistsException();
                }
                bool verifyPass = _passwordService.VerifyPassword(user, user.Password, login.Password);
                if (!verifyPass) 
                { 
                    throw new PasswordDontMatchException();
                }

            } catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<Tokens> Registration(RegistrationDTO registration)
        {

        }
    }
}
