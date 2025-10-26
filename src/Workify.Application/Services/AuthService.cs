
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
        private readonly UserRoleRepository _userRoleRepository;
        private readonly UserRepository _userRepository;

        public AuthService(
            JwtTokenService jwtTokenService,
            TokenRepository tokenRepository, 
            JobSeekerRepository jobSeekerRepository,
            PasswordService passwordService,
            RoleRepository roleRepository,
            UserRoleRepository userRoleRepository,
            UserRepository userRepository
            )
        { 
            _jwtTokenService = jwtTokenService;
            _tokenRepository = tokenRepository;
            _jobSeekerRepository = jobSeekerRepository;
            _passwordService = passwordService;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
        }

        public async Task<Tokens?> Login(LoginDTO login)
        {
           try
            {
                UserEntity? user = await _userRepository.FindUserByEmail(login.Email);
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
                throw ex;
            }
        }

        public async Task<Tokens?> RegistrationJobSeeker(RegistrationDTO registration)
        {
            try 
            {
                UserEntity? user = await _userRepository.FindUserByEmail(registration.Email);
                if(user != null)
                {
                    throw new UserAlreadyExistsException();
                }
                if(registration.Password != registration.ConfirmPassword)
                {
                    throw new PasswordDontMatchException();
                }

                UserEntity newUser = UserEntity.Create(registration.FirstName, registration.SecondName, registration.PhoneNumber, registration.Email, registration.Password);
             
                JobSeekerEntity jobSeeker = new JobSeekerEntity();

                string hashPassword = _passwordService.HashPassword(newUser, registration.Password);

                newUser.Password = hashPassword;

                JobSeekerSettingsEntity userSettings = JobSeekerSettingsEntity.Create(false);
                jobSeeker.JobSeekerSettings = userSettings;

                Tokens tokens = _jwtTokenService.GetTokens(new UserDTO { Id = jobSeeker.Id, Name = newUser.FirstName, Email = newUser.Email });
                TokenEntity token = TokenEntity.Create(tokens.RefreshToken);
                newUser.Token = token;

                RoleEntity role = await _roleRepository.FindRoleByName("JobSeeker");
                if (role == null)
                {
                    throw new Exception("Role 'User' not found");
                }
                jobSeeker.User = newUser;
                await _jobSeekerRepository.AddJobSeeker(jobSeeker);
                await _userRoleRepository.AddRoleToUser(newUser, role);


                return tokens;
            }
            catch (Exception ex) 
            {
                throw ex;
            }


        }
    }
}
