using System.Text.Json;
using System.Text.Json.Serialization;

using TwitterApi.Model;

namespace TwitterApi.Web
{
    public class SampleTwitterClient : ITwitterClient
    {
        private readonly Func<HttpClient> getClient;
        public SampleTwitterClient(Func<HttpClient> client)
        {
            getClient = client;
        }

        public async IAsyncEnumerable<Tweet> TweetsAsync()
        {
            var client = getClient();

            using var stream = await client.GetStreamAsync("2/tweets/sample/stream?tweet.fields=entities");

            using var streamReader = new StreamReader(stream);

            while (!streamReader.EndOfStream)
            {
                var line = await streamReader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line)) continue;
                var tweet = JsonSerializer.Deserialize<TweetData>(line)?.Data;
                if (tweet == null) continue;
                yield return tweet;
            }
        }

        internal class TweetData
        {

            [JsonPropertyName("data")]
            public Tweet? Data { get; set; }
        }
    }
}