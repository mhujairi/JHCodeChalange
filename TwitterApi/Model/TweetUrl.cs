using System.Text.Json.Serialization;

namespace TwitterApi.Model
{
    public class TweetUrl
    {
        /// <summary>
        /// The start position (zero-based) of the recognized URL within the Tweet. All start indices are inclusive.
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }

        /// <summary>
        /// The end position (zero-based) of the recognized URL within the Tweet. This end index is exclusive.
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; set; }

        /// <summary>
        /// The URL in the format tweeted by the user.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// The fully resolved URL.
        /// </summary>
        [JsonPropertyName("expanded_url")]
        public string? ExpandedUrl { get; set; }

        /// <summary>
        /// The URL as displayed in the Twitter client.
        /// </summary>
        [JsonPropertyName("display_url")]
        public string? DisplayUrl { get; set; }

        /// <summary>
        /// The full destination URL.
        /// </summary>
        [JsonPropertyName("unwound_url")]
        public string? UnwoundUrl { get; set; }
    }
}