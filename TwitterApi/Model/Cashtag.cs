﻿using System.Text.Json.Serialization;

namespace TwitterApi.Model
{
    public class Cashtag
    {
        /// <summary>
        /// The start position (zero-based) of the recognized Cashtag within the Tweet. All start indices are inclusive.
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }

        /// <summary>
        /// The end position (zero-based) of the recognized Cashtag within the Tweet. This end index is exclusive.
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; set; }

        /// <summary>
        /// The text of the Cashtag
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
    }
}