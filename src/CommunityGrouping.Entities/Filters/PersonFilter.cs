using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Business.Filters
{
    public class PersonFilter: PaginationFilter
    {
        public PersonFilter()
        {
            
        }
        
        public PersonFilter(int page, int pageSize) : base(page, pageSize)
        {

        }
        public PersonFilter(int page, int pageSize, SortOrder? sortOrder,string? firstName,string? lastName) : base(page, pageSize)
        {
            this.SortOrder = sortOrder;
            this.LastName = lastName;
            this.FirstName = firstName;
        }
     
        public string? FirstName  { get; set; }
        public string? LastName { get; set; }

        public SortOrder? SortOrder { get; set; }
    }

    public enum SortOrder
    {
        Ascending = 0,
        Descending = 1
    }
}
