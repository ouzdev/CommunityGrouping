using Microsoft.IdentityModel.Tokens;

namespace CommunityGrouping.Core
{
    public class SigningCredentialsHelper
    {
        /// <summary>
        /// Returns security key key of instance <see cref="SigningCredentials"/> 
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
