namespace CommunityGrouping.Core
{
    /// <summary>
    /// Paginated response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResult<T> : Result, IPagingResult<T>
    {
        public PagingResult(IEnumerable<T> data, int totalItemCount, bool success, string message) : base(success, message)
        {
            Data = data;
            TotalItemCount = totalItemCount;
        }

        public IEnumerable<T> Data { get; }
        public int TotalItemCount { get; }
    }
}
