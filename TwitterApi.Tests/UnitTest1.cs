
using System.Net;
using System.Net.Http.Headers;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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
        public async Task CanRead10Tweets()
        {
            var subject = new SampleTwitterClient(GetHttpClient);

            var result = (subject.TweetsAsync()).GetAsyncEnumerator();
            int i = 0;
            while (await result.MoveNextAsync())
            {
                var tweet = result.Current;
                Console.WriteLine($"{tweet.AuthorId}: {tweet.Text}");

                if (i >= 10)
                {
                    Console.WriteLine("stopped reading");
                    return;
                }
                i++;
            }
        }
    }
}