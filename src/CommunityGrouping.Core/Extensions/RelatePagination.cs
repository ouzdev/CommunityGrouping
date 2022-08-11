using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Core.Utilities.URI;
namespace CommunityGrouping.Core.Extensions
{
    public static class RelatePagination
    {
        public static void CreatePaginationResponse<Response, Pagination>(this PaginatedResult<Response> response, Pagination pagination, int totalRecords, IPaginationUriService relatePaginationUri, string route) where Pagination : PaginationFilter
        {
            // Assign Query-Resource
            response.PageNumber = pagination.PageNumber;
            response.PageSize = pagination.PageSize;
            // Assign Total-Pages
            var totalPages = ((double)totalRecords / (double)pagination.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            // Assign Next-Page
            response.NextPage = response.PageNumber >= 1 && response.PageNumber < roundedTotalPages
        ? relatePaginationUri.GetPageUri(new PaginationFilter(response.PageNumber + 1, response.PageSize), route)
        : null; ;
            // Assign Previous-Page
            response.PreviousPage = response.PageNumber - 1 >= 1 && response.PageNumber <= roundedTotalPages
        ? relatePaginationUri.GetPageUri(new PaginationFilter(response.PageNumber - 1, response.PageSize), route)
        : null; ;
            response.FirstPage = relatePaginationUri.GetPageUri(new PaginationFilter(1, response.PageSize), route);
            // Assign Last-Page 
            response.LastPage = relatePaginationUri.GetPageUri(new PaginationFilter(roundedTotalPages, response.PageSize), route);
            // Assign Total-Pages
            response.TotalPages = roundedTotalPages;
            // Assign Total-Records
            response.TotalRecords = totalRecords;
        }
    }
}
