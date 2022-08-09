using CommunityGrouping.Core.BaseModel;
using Microsoft.AspNetCore.WebUtilities;

namespace CommunityGrouping.Core.Utilities.URI
{
    public class PaginationUriService : IPaginationUriService
    {
        private readonly string _baseUri;
        public PaginationUriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
