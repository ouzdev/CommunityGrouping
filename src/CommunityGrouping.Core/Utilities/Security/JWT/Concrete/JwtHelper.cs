using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommunityGrouping.Core.BaseModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CommunityGrouping.Core.Utilities.Security.JWT.Concrete
{
    public class JwtHelper : ITokenHelper
    {

        private readonly IOptions<TokenOptions> _tokenOptions;

        private DateTime _accessTokenExpiration;
        public JwtHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }
        public AccessToken CreateToken(User applicationUser)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.Value.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.Value.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions.Value, applicationUser, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration

            };

        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
          SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
       

        private static IEnumerable<Claim> SetClaims(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var claims = new List<Claim> { new Claim("ApplicationUserId",user.Id.ToString()) };
            return claims;
        }
    }
}
