using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Workify.Application.DTO;
using System.Security.Principal;



namespace Workify.Application.Services
{

    public class Tokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
    public class JwtTokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public bool VerifyAccessToken(string accesToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationAccessTokenParameters();
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(accesToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerifyRefreshToken(string refreshToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationRefreshTokenParameters();
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TokenValidationParameters GetValidationAccessTokenParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = _config["JwtConfig:Issuer"],
                ValidAudience = _config["JwtConfig:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:AccessKey"]!)),
            };
        }

        public TokenValidationParameters GetValidationRefreshTokenParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = _config["JwtConfig:Issuer"],
                ValidAudience = _config["JwtConfig:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:RefreshKey"]!)),
            };
        }

        public Tokens GetTokens(UserDTO user)
            {
                string accessToken = GenerateAccessToken(user);
                string refreshToken = GenerateRefreshToken(user);
                return new Tokens { AccessToken = accessToken, RefreshToken = refreshToken};
            }

        public string GenerateAccessToken(UserDTO user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:AccessKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                issuer: _config["JwtConfig:Issuer"],
                audience: _config["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            ));
        }

        public string GenerateRefreshToken(UserDTO user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:RefreshKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtConfig:Issuer"],
                audience: _config["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
