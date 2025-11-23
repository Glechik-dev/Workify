
using Workify.Application.DTO;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;
using Workify.Core.Entities.Other;
using Workify.Core.Entities.User;
using Workify.Core.Exceptions;
using Workify.Infrastructure.Repositories;

namespace Workify.Application.Services
{

    public class TokensAndUser
    {
        public UserEntity User { get; set; }
        public Tokens Tokens { get; set; }
    }
     public class AuthService
     {
            private readonly JwtTokenService _jwtTokenService;
            private readonly TokenRepository _tokenRepository;
            private readonly JobSeekerRepository _jobSeekerRepository;
            private readonly PasswordService _passwordService;
            private readonly RoleRepository _roleRepository;
            private readonly UserRoleRepository _userRoleRepository;
            private readonly UserRepository _userRepository;
            private readonly EmployerRepository _employerRepository;

            public AuthService(
                JwtTokenService jwtTokenService,
                TokenRepository tokenRepository,
                JobSeekerRepository jobSeekerRepository,
                PasswordService passwordService,
                RoleRepository roleRepository,
                UserRoleRepository userRoleRepository,
                UserRepository userRepository,
                EmployerRepository employerRepository
                )
            {
                _jwtTokenService = jwtTokenService;
                _tokenRepository = tokenRepository;
                _jobSeekerRepository = jobSeekerRepository;
                _passwordService = passwordService;
                _roleRepository = roleRepository;
                _userRoleRepository = userRoleRepository;
                _userRepository = userRepository;
                _employerRepository = employerRepository;
            }

            public async Task<Tokens?> Login(LoginDTO login)
            {
                try
                {
                    UserEntity? user = await _userRepository.FindUserByEmailAndRole(login.Email);
                    if (user == null)
                    {
                        throw new UserNotExistsException();
                    }
                    bool verifyPass = _passwordService.VerifyPassword(user, user.Password, login.Password);
                    if (!verifyPass)
                    {
                        throw new PasswordDontMatchException();
                    }


                    Tokens tokens = _jwtTokenService.GetTokens(new UserDTO { Id = user.Id, Name = user.FirstName, Email = user.Email }, user.UserRoles.First().Role.RoleName);
                    TokenEntity token = TokenEntity.Create(tokens.RefreshToken);
                    user.Token = token;


                return tokens;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<Tokens?> RegistrationJobSeeker(RegistrationDTO registration)
            {
                try
                {
                    await CheckUserExistsAndPassword(registration);

                    JobSeekerEntity jobSeeker = JobSeekerEntity.Create();
                    JobSeekerSettingsEntity jobSeekerSettings = JobSeekerSettingsEntity.Create();
                    jobSeeker.JobSeekerSettings = jobSeekerSettings;
                    TokensAndUser tokensAndUser = await CreateAndGetUser(registration, "JobSeeker");

                    jobSeeker.User = tokensAndUser.User;
                    await _jobSeekerRepository.AddJobSeeker(jobSeeker);


                    return tokensAndUser.Tokens;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<Tokens?> RegistrationEmployer(RegistrationDTO registration)
            {
                try
                {
                    await CheckUserExistsAndPassword(registration);

                    EmployerEntity employer = EmployerEntity.Create();
                    EmployerSettingsEntity employerSettings = EmployerSettingsEntity.Create();
                    employer.EmployerSettings = employerSettings;
                    TokensAndUser tokensAndUser = await CreateAndGetUser(registration, "Employer");
                    employer.User = tokensAndUser.User;
                    await _employerRepository.AddEmployer(employer);

                    return tokensAndUser.Tokens;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task LogOut(Guid Id)
            {
                try
                {
                    TokenEntity tokenEntity = await _tokenRepository.FindTokenByUserId(Id);
                    await _tokenRepository.DeleteToken(tokenEntity);
                }
                catch (Exception ex) 
                {
                    throw ex;
                }
            }

            private async Task CheckUserExistsAndPassword(RegistrationDTO registration)
            {
                UserEntity? user = await _userRepository.FindUserByEmail(registration.Email);
                if (user != null)
                {
                    throw new UserAlreadyExistsException();
                }
                if (registration.Password != registration.ConfirmPassword)
                {
                    throw new PasswordDontMatchException();
                }
            }


            private async Task<TokensAndUser> CreateAndGetUser(RegistrationDTO registration, string roleName)
            {
                UserEntity newUser = UserEntity.Create(registration.FirstName, registration.SecondName, registration.PhoneNumber, registration.Email, registration.Password);
                string hashPassword = _passwordService.HashPassword(newUser, registration.Password);
                newUser.Password = hashPassword;
                UserSettingsEntity userSettings = UserSettingsEntity.Create(false);
                newUser.UserSettings = userSettings;
                Tokens tokens = _jwtTokenService.GetTokens(new UserDTO { Id = newUser.Id, Name = newUser.FirstName, Email = newUser.Email }, roleName);
                TokenEntity token = TokenEntity.Create(tokens.RefreshToken);
                newUser.Token = token;
                RoleEntity role = await _roleRepository.FindRoleByName(roleName);
                if (role == null)
                {
                    throw new Exception("Role 'User' not found");
                }
                await _userRoleRepository.AddRoleToUser(newUser, role);
                return new TokensAndUser { Tokens = tokens, User = newUser };
            }
    }
}
