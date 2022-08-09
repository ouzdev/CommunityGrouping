namespace CommunityGrouping.Core.BaseModel
{
    public class PaginationFilter
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public PaginationFilter(int page, int pageSize)
        {
            PageNumber = page;
            PageSize = pageSize;

            if (PageNumber <= 0)
                PageNumber = 1;

            if (PageSize <= 0 || PageSize > 20)
                PageSize = 10;
        }
    }
}
