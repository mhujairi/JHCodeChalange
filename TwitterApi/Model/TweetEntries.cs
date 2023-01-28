using System.Text.Json.Serialization;

namespace TwitterApi.Model;

public class TweetEntries
{

    /// <summary>
    /// Contains details about annotations relative to the text within a Tweet.
    /// </summary>
    [JsonPropertyName("annotations")]
    public TweetAnnotation[]? Annotations { get; set; }

    /// <summary>
    /// Contains details about text recognized as a URL.
    /// </summary>
    [JsonPropertyName("urls")]
    public TweetUrl[]? Urls { get; set; }

    /// <summary>
    /// Contains details about text recognized as a Hashtag.
    /// </summary>
    [JsonPropertyName("hashtags")]
    public Hashtag[]? Hashtags { get; set; }

    /// <summary>
    /// Contains details about text recognized as a user mention.
    /// </summary>
    [JsonPropertyName("mentions")]
    public Mention[]? Mentions { get; set; }

    /// <summary>
    /// Contains details about text recognized as a Cashtag.
    /// </summary>
    [JsonPropertyName("cashtags")]
    public Cashtag[]? Cashtags { get; set; }

}