namespace TwitterApi
{
    public interface ITwitterClient
    {
        IAsyncEnumerable<Tweet> TweetsAsync();

    }
}