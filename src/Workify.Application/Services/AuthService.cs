
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
        private readonly RoleRepository _roleRepository;
        private readonly UserRoleRepository _userRoleRepository;

        public AuthService(
            JwtTokenService jwtTokenService,
            TokenRepository tokenRepository, 
            UserRepository userRepository,
            UserSettingsRepository userSettingsRepository,
            PasswordService passwordService,
            RoleRepository roleRepository,
            UserRoleRepository userRoleRepository
            )
        { 
            _jwtTokenService = jwtTokenService;
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _userSettingsRepository = userSettingsRepository;
            _passwordService = passwordService;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
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

                Tokens tokens = _jwtTokenService.GetTokens(new UserDTO { Id = user.Id, Name = user.FirstName, Email = user.Email });
                await _tokenRepository.UpdateToken(user.Token.Id, tokens.RefreshToken);

                return tokens;
            } catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<Tokens?> Registration(RegistrationDTO registration)
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

                UserEntity newUser = UserEntity.Create(registration.FirstName, registration.SecondName, registration.PhoneNumber, registration.Email, hashPassword);

                UserSettingsEntity userSettings = UserSettingsEntity.Create(false);
                newUser.UserSettings = userSettings;

                Tokens tokens = _jwtTokenService.GetTokens(new UserDTO { Id = newUser.Id, Name = newUser.FirstName, Email = newUser.Email });
                TokenEntity token = TokenEntity.Create(tokens.RefreshToken);
                newUser.Token = token;

                RoleEntity role = await _roleRepository.FindRoleByName("JobSeeker");
                await _userRoleRepository.AddRoleToUser(newUser, role);

                await _userRepository.AddUser(newUser);

                return tokens;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            }


        }
    }
}
