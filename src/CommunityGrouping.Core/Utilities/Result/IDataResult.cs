namespace CommunityGrouping.Core
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
