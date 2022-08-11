namespace CommunityGrouping.Business.Filters
{
    public class PersonFilter
    {
        public string FirstName  { get; set; }
        public string LastName { get; set; }

        public SortOrder SortOrder { get; set; }
    }

    public enum SortOrder
    {
        Ascending = 0,
        Descending = 1
    }
}
