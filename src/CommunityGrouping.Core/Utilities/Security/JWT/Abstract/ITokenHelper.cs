
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Core
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User applicationUser);
    }
}
