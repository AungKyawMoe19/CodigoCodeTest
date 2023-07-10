using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Application.Interfaces;
using Core.Entities;
using Core.Entities.Models;
using InfraStructure.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InfraStructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private CryptoKey _cryptoKey;
        private readonly Appsettings _appSettings;
        private readonly TokenLifeTime _tokenLifeTime;
        private readonly Jwt _jwt;

        public LoginRepository(IOptions<CryptoKey> cryptoKey, IOptions<Appsettings> appSettings, IOptions<TokenLifeTime> tokenLifeTime, IOptions<Jwt> jwt)
        {
            _cryptoKey = cryptoKey.Value;
            _appSettings = appSettings.Value;
            _tokenLifeTime = tokenLifeTime.Value;
            _jwt = jwt.Value;
        }

        public Tokens GenenrateToken(UserModel info)
        {
            try
            {
                //var temp = Controller_TextEncryption.Encrypt("paiapi", "PaxDataEnc");
               
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, info.UserName.ToString()),
                new Claim(ClaimTypes.Email, info.Email.ToString()),
                new Claim(ClaimTypes.Role, info.Role.ToString())
                };
                var token = new JwtSecurityToken(
                            issuer: _jwt.Issuer,
                            audience: _jwt.Audience,
                            claims: claims,
                            expires: DateTime.Now.AddDays(_tokenLifeTime.Time),
                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                            );
                //var refreshToken = GenerateRefreshToken();
                var refreshToken = Controller_TextEncryption.Encrypt(RefreshTokenInfo.key, _cryptoKey.Key);
                return new Tokens
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken
                };
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public UserModel AuthenticateUser(UserLogin userLogin)
        {
            var currentUser = UserInfo.users.FirstOrDefault(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }


            return principal;
        }
    }
}
