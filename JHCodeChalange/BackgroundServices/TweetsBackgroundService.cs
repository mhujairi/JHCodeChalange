using TwitterApi.Data;
using TwitterApi.Web;

namespace JHCodeChalange.BackgroundServices
{

    //Inspired from 
    //https://github.com/shawnwildermuth/ShawnLink/blob/main/src/Services/AccumulatorBackgroundService.cs
    public class TweetsBackgroundService : BackgroundService
    {
        private readonly ILogger<TweetsBackgroundService> logger;
        private readonly ITwitterClient twitterClient;
        private readonly ITweetRepository tweetRepository;

        public TweetsBackgroundService(ILogger<TweetsBackgroundService> logger,
            ITwitterClient twitterClient,
            ITweetRepository tweetRepository)
        {
            this.logger = logger;
            this.twitterClient = twitterClient;
            this.tweetRepository = tweetRepository;
        }
        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    logger.LogError($"Starting Stream");
                    var result = (twitterClient.TweetsAsync(cancellationToken)).GetAsyncEnumerator(cancellationToken);

                    logger.LogError($"Reading Tweets");
                    while (await result.MoveNextAsync())
                    {
                        var tweet = result.Current;
                        var addTask = tweetRepository.AddAsync(tweet, cancellationToken);
                    }

                    logger.LogError($"Stream stopped.. will try restart");
                }
                catch (Exception ex)
                {
                    logger.LogError($"Failure while processing Tweets Stream: {ex}");
                }
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Stopping Background Service");
            await base.StopAsync(cancellationToken);
        }
    }
}
