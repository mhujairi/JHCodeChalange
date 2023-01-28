namespace TwitterApi.Data
{
    public interface IHashTagRepository
    {
        Task<string[]> GetTopHashTagsAsync(int number);
    }

}
