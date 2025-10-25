
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

        public async Task<Tokens?> Login(LoginDTO login)
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
                return new Tokens();
            } catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<Tokens> Registration(RegistrationDTO registration)
        {
            try 
            {
                UserEntity? user = await _userRepository.GetUserByEmail(registration.Email);
                if(user != null)
                {
                    throw new UserAlreadyExistsException();
                }
                if(registration.Password != registration.ConfirmPassword)
                {
                    throw new PasswordDontMatchException();
                }

                string hashPassword = _passwordService.HashPassword(UserEntity.Create(registration.FirstName, registration.SecondName, registration.PhoneNumber, registration.Email, registration.Password), registration.Password);
                


            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }


        }
    }
}
