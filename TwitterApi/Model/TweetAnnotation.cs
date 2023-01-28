using System.Text.Json.Serialization;

namespace TwitterApi.Model;

public class TweetAnnotation
{
    /// <summary>
    /// The start position (zero-based) of the text used to annotate the Tweet. All start indices are inclusive.
    /// </summary>
    [JsonPropertyName("start")]
    public int Start { get; set; }

    /// <summary>
    /// The end position (zero based) of the text used to annotate the Tweet. While all other end indices are exclusive, this one is inclusive.
    /// </summary>
    [JsonPropertyName("end")]
    public int End { get; set; }

    /// <summary>
    /// The confidence score for the annotation as it correlates to the Tweet text.
    /// </summary>
    [JsonPropertyName("probability")]
    public float Probability { get; set; }

    /// <summary>
    /// The description of the type of entity identified when the Tweet text was interpreted.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The text used to determine the annotation type.
    /// </summary>
    [JsonPropertyName("normalized_text")]
    public string? NormalizedText { get; set; }
}