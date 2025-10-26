
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
        private readonly JobSeekerRepository _jobSeekerRepository;
        private readonly PasswordService _passwordService;
        private readonly RoleRepository _roleRepository;
        private readonly JobSeekerRoleRepository _jobSeekerRoleRepository;

        public AuthService(
            JwtTokenService jwtTokenService,
            TokenRepository tokenRepository, 
            JobSeekerRepository JobSeekerRepository,
            PasswordService passwordService,
            RoleRepository roleRepository,
            JobSeekerRoleRepository jobSeekerRoleRepository
            )
        { 
            _jwtTokenService = jwtTokenService;
            _tokenRepository = tokenRepository;
            _jobSeekerRepository = _jobSeekerRepository;
            _passwordService = passwordService;
            _roleRepository = roleRepository;
            _jobSeekerRoleRepository = jobSeekerRoleRepository;
        }

        public async Task<Tokens?> Login(LoginDTO login)
        {
           try
            {
                JobSeekerEntity? user = await _jobSeekerRepository.GetUserByEmail(login.Email);
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
                JobSeekerEntity? user = await _jobSeekerRepository.GetUserByEmail(registration.Email);
                if(user != null)
                {
                    throw new UserAlreadyExistsException();
                }
                if(registration.Password != registration.ConfirmPassword)
                {
                    throw new PasswordDontMatchException();
                }

                JobSeekerEntity newUser = JobSeekerEntity.Create(registration.FirstName, registration.SecondName, registration.PhoneNumber, registration.Email, registration.Password);

                string hashPassword = _passwordService.HashPassword(newUser, registration.Password);

                newUser.Password = hashPassword;
  

                JobSeekerSettingsEntity userSettings = JobSeekerSettingsEntity.Create(false);
                newUser.JobSeekerSettings = userSettings;

                Tokens tokens = _jwtTokenService.GetTokens(new UserDTO { Id = newUser.Id, Name = newUser.FirstName, Email = newUser.Email });
                TokenEntity token = TokenEntity.Create(tokens.RefreshToken);
                newUser.Token = token;

                RoleEntity role = await _roleRepository.FindRoleByName("JoobSeeker");
                if (role == null)
                {
                    throw new Exception("Role 'User' not found");
                }
                await _jobSeekerRepository.AddUser(newUser);
                await _jobSeekerRoleRepository.AddRoleToUser(newUser, role);


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
