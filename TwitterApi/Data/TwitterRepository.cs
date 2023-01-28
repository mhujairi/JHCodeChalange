using System.Collections.Concurrent;

using TwitterApi.Model;

namespace TwitterApi.Data;

public class TwitterRepository : ITweetRepository, IHashTagRepository
{
    public TwitterRepository(int HashTagBufferSize)
    {
        this.HashTagBufferSize = HashTagBufferSize;
        hashTags = new(3, HashTagBufferSize + 100);
    }
    private int TweetCount { get; set; }
    public int HashTagBufferSize { get; }

    Task ITweetRepository.AddAsync(Tweet tweet, CancellationToken? cancellationToken = null)
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
        if (hashTags.Count >= HashTagBufferSize)
        {
            var tagsToRemove = hashTags.OrderByDescending(item => item.Value).Skip(HashTagBufferSize).ToArray();
            foreach (var hashtag in tagsToRemove)
                hashTags.TryRemove(hashtag);
        }
        return Task.CompletedTask;
    }

    Task<int> ITweetRepository.CountAsync()
    {
        return Task.FromResult(TweetCount);
    }

    private readonly ConcurrentDictionary<string, int> hashTags;
    Task<HashtageEntry[]> IHashTagRepository.GetTopHashTagsAsync(int number)
    {
        if (number == 0 || hashTags.Count == 0)
            return Task.FromResult(new HashtageEntry[0]);

        return Task.FromResult(hashTags.OrderByDescending(item => item.Value).Select(item =>
        new HashtageEntry
        {
            Count= item.Value,
            Tag= item.Key
        }).Take(number).ToArray());
    }

    Task<int> IHashTagRepository.CountAsync()
    {
        return Task.FromResult(hashTags.Count);
    }
}
