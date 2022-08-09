using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Core.Utilities.URI;

public interface IPaginationUriService
{
    public Uri GetPageUri(PaginationFilter filter, string route);
}