using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;

using TwitterApi.Data;
using TwitterApi.Web;

namespace TwitterApi.Tests
{
    [TestClass]
    public class TwitterClientTests
    {
        static TwitterClientTests()
        {
            var builder = new ConfigurationBuilder()
                            .AddUserSecrets<TwitterClientTests>();

            var configuration = builder.Build();

            var twitterBearerKey = configuration["twitter:BearerKey"];
            twitterBearerAuthenticationHeader = new AuthenticationHeaderValue("Bearer", twitterBearerKey);
        }

        private static readonly Uri BaseAddress = new Uri("https://api.twitter.com");
        private static readonly AuthenticationHeaderValue twitterBearerAuthenticationHeader;
        private static HttpClient GetHttpClient()
        {
            var result = new HttpClient
            {
                BaseAddress = BaseAddress
            };
            result.DefaultRequestHeaders.Authorization = twitterBearerAuthenticationHeader;

            return result;
        }

        [TestMethod]
        public async Task Can_read_100_tweets_and_add_them_to_the_tweets_repository()
        {
            var subject = new SampleTwitterClient(GetHttpClient);
            ITweetRepository tweetRepository = new TwitterRepository(100);

            var result = (subject.TweetsAsync()).GetAsyncEnumerator();
        
            var addTasks = new List<Task>();
            int i = 0;
            for (; i < 100 && await result.MoveNextAsync(); i++)
            {
                var tweet = result.Current;
                addTasks.Add(tweetRepository.AddAsync(tweet));
            }

            foreach(var addTask in addTasks)
            {
                await addTask;
            }

            Assert.AreEqual(i, await tweetRepository.CountAsync());

        }
    }
}