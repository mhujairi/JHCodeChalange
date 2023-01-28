using TwitterApi.Model;

namespace TwitterApi.Web;

public interface ITwitterClient
{
    IAsyncEnumerable<Tweet> TweetsAsync(CancellationToken? cancellationToken = null);

}