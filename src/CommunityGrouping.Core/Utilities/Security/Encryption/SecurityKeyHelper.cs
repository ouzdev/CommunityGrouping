using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CommunityGrouping.Core
{
    public class SecurityKeyHelper
    {
        /// <summary>
        /// Returns the converted secret key of type <see cref="SecurityKey"/> 
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SecurityKey CreateSecurityKey(string? securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
