namespace CommunityGrouping.Core.Extensions;

public interface IRelatePaginationUri
{
    public Uri GetPageUri(PaginationFilter filter, string route);
}