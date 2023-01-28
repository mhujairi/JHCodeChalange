using System.Collections.Concurrent;

using TwitterApi.Model;

namespace TwitterApi.Data
{
    public class TweetRepository : ITweetRepository, IHashTagRepository
    {
        private int TweetCount { get; set; }
        Task ITweetRepository.AddAsync(Tweet tweet)
        {

            if (tweet != null)
            {
                TweetCount++;
                if(tweet.Entities?.Hashtags != null)
                {
                    foreach(var hashTag in tweet.Entities.Hashtags)
                    {
                        if (string.IsNullOrWhiteSpace(hashTag.Tag))
                            continue;

                        hashTags.AddOrUpdate(hashTag.Tag, 1, (key,value) =>
                        {
                            return value + 1;
                        });
                    }
                }
            }
            return Task.CompletedTask;
        }

        Task<int> ITweetRepository.CountAsync()
        {
            return Task.FromResult(TweetCount);
        }

        private readonly ConcurrentDictionary<string,int> hashTags = new();
        Task<string[]> IHashTagRepository.GetTopHashTagsAsync(int number)
        {
            if (number == 0)
                return Task.FromResult(new string[0]);

            return Task.FromResult(hashTags.OrderByDescending(item=>item.Value).Select(item=>item.Key).Take(number).ToArray());
        }
    }

}
