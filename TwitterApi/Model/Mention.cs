using System.Text.Json.Serialization;

namespace TwitterApi.Model
{
    public class Mention
    {

        /// <summary>
        /// The start position (zero-based) of the recognized user mention within the Tweet. All start indices are inclusive.
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }

        /// <summary>
        /// The end position (zero-based) of the recognized user mention within the Tweet. This end index is exclusive.
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; set; }

        /// <summary>
        /// The part of text recognized as a user mention.
        /// </summary>
        /// <remarks>
        /// You can obtain the expanded object in includes.users by adding expansions=entities.mentions.username in the request's query parameter.
        /// </remarks>
        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}