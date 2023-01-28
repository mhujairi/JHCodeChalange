using TwitterApi.Model;

namespace TwitterApi.Data
{
    public interface IHashTagRepository
    {
        Task<HashtageEntry[]> GetTopHashTagsAsync(int number);

        Task<int> CountAsync();
    }
}
