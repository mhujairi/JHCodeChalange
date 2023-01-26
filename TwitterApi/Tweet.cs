
using System.Text.Json.Serialization;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TwitterApi
{
    public class Tweet
    {
        /// <summary>
        /// The unique identifier of the requested Tweet.
        /// Use this to programmatically retrieve a specific Tweet.
        /// </summary>
        /// <example>
        /// "id": "1050118621198921728"
        /// </example>
        [JsonPropertyName("id")]

        public string? Id { get; set; }

        /// <summary>
        /// The actual UTF-8 text of the Tweet. See twitter-text for details on what characters are currently considered valid.    
        /// Keyword extraction and sentiment analysis/classification.
        /// </summary>
        /// <example>
        /// "text": "To make room for more expression, we will now count all emojis as equal—including those with gender‍‍‍ ‍‍and skin tone modifiers 👍🏻👍🏽👍🏿. This is now reflected in Twitter-Text, our Open Source library. \n\nUsing Twitter-Text? See the forum post for detail: https://t.co/Nx1XZmRCXA"
        /// </example>
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        /// <summary>
        /// Unique identifiers indicating all versions of a Tweet. For Tweets with no edits, there will be one ID. For Tweets with an edit history, there will be multiple IDs, arranged in ascending order reflecting the order of edits. The most recent version is the last position of the array.
        /// Use this information to find the edit history of a Tweet.
        /// </summary>
        /// <example>
        /// "edit_history_tweet_ids": [  "1584717154800521216"]
        /// </example>
        [JsonPropertyName("edit_history_tweet_ids")]
        public string[]? EditHistoryTweetIds { get; set; }

        /// <summary>
        /// Specifies the type of attachments (if any) present in this Tweet.
        /// understanding the objects returned for requested expansions 
        /// </summary>
        /// <example>
        /// "attachments": {
        ///     "poll_ids": [
        ///         "1199786642468413448"
        ///     ]
        /// }
        /// </example>
        /// <example>
        /// "attachments": {
        ///     "media_keys": [
        ///         "3_1136048009270239232"
        ///     ]
        /// }
        /// </example>
        [JsonPropertyName("attachments")]
        public object? Attachments { get; set; }

        /// <summary>
        /// The unique identifier of the User who posted this Tweet.
        /// Hydrating User object, sharing dataset for peer review
        /// </summary>
        /// <example>
        /// "author_id": "2244994945"
        /// </example>
        [JsonPropertyName("author_id")]
        public string? AuthorId { get; set; }

        /// <summary>
        /// Contains context annotations for the Tweet.
        /// Entity recognition/extraction, topical analysis 
        /// </summary>
        /// <example>
        /// "context_annotations": [
        ///     {
        ///         "domain": {
        ///             "id": "65",
        ///             "name": "Interests and Hobbies Vertical",
        ///             "description": "Top level interests and hobbies groupings, like Food or Travel"
        ///          },
        ///         "entity": {
        ///             "id": "834828264786898945",
        ///             "name": "Drinks",
        ///             "description": "Drinks"
        ///         }
        ///     },
        ///     {
        ///         "domain": {
        ///             "id": "66",
        ///             "name": "Interests and Hobbies Category",
        ///             "description": "A grouping of interests and hobbies entities, like Novelty Food or Destinations"
        ///          },
        ///         "entity": {
        ///             "id": "834828445238431744",
        ///             "name": "Generic Drinks",
        ///             "description": "Generic Drinks"
        ///         }
        ///     }
        /// ]
        /// </example>
        [JsonPropertyName("context_annotations")]
        public object? ContextAnnotations { get; set; }


        /// <summary>
        /// date (ISO 8601)
        /// Creation time of the Tweet.
        /// This field can be used to understand when a Tweet was created and used for time-series analysis etc. 
        /// </summary>
        /// <example>
        /// "created_at": "2019-06-04T23:12:08.000Z"
        /// </example>
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }


        /// <summary>
        /// The Tweet ID of the original Tweet of the conversation (which includes direct replies, replies of replies).
        /// Use this to reconstruct the conversation from a Tweet.  
        /// </summary>
        /// <example>
        /// "conversation_id": "1050118621198921728"
        /// </example>
        [JsonPropertyName("conversation_id")]
        public string? ConversationId { get; set; }

        /// <summary>
        /// When present, this indicates how much longer the Tweet can be edited and the number of remaining edits. Tweets are only editable for the first 30 minutes after creation and can be edited up to five times.
        /// Use this to determine if a Tweet is eligible for editing.
        /// </summary>
        /// <example>
        /// "edit_controls": {
        ///   "edits_remaining": 5,
        ///   "is_edit_eligible": true,
        ///   "editable_until": "2022-10-25T01:53:06.000Z"
        /// }
        /// </example>
        [JsonPropertyName("edit_controls")]
        public object? EditControls { get; set; }

        /// <summary>
        /// Entities that have been parsed out of the text of the Tweet. Additionally, see entities in Twitter Objects.
        /// Entities are JSON objects that provide additional information about hash tags, URLs, user mentions, and cash tags associated with a Tweet. Reference each respective entity for further details.
        /// Please note that all start indicates are inclusive. The majority of end indicates are exclusive, except for entities.annotations.end, which is currently inclusive. We will be changing this to exclusive with our v3 bump since it is a breaking change. 
        /// </summary>
        /// <example>
        /// "entities": {
        ///     "annotations": [
        ///         {
        ///            "start": 144,
        ///            "end": 150,
        ///            "probability": 0.626,
        ///            "type": "Product",
        ///            "normalized_text": "Twitter"
        ///         }
        ///     ],
        ///    "cashtags": [
        ///         {
        ///             "start": 18,
        ///             "end": 23,
        ///             "tag": "twtr"
        ///         }
        ///     ],
        ///     "hashtags": [
        ///         {
        ///             "start": 0,
        ///             "end": 17,
        ///             "tag": "blacklivesmatter"
        ///         }
        ///     ],
        ///     "mentions": [
        ///         {
        ///             "start": 24,
        ///             "end": 35,
        ///             "tag": "TwitterDev"
        ///         }
        ///     ],
        ///     "urls": [
        ///         {
        ///            "start": 44,
        ///            "end": 67,
        ///            "url": "https://t.co/crkYRdjUB0",
        ///            "expanded_url": "https://twitter.com",
        ///            "display_url": "twitter.com",
        ///            "status": "200",
        ///            "title": "bird",
        ///            "description": "From breaking news and entertainment to sports and politics, get the full story with all the live commentary.",
        ///             "unwound_url": "https://twitter.com"
        ///         }
        ///     ]
        /// }
        /// </example>
        [JsonPropertyName("entities")]
        public object? Entities { get; set; }

        /// <summary>
        /// If the represented Tweet is a reply, this field will contain the original Tweet’s author ID. This will not necessarily always be the user directly mentioned in the Tweet.
        /// Use this to determine if this Tweet was in reply to another Tweet.
        /// </summary>
        /// <example>
        /// "in_reply_to_user_id": "2244994945"
        /// </example>
        [JsonPropertyName("in_reply_to_user_id")]
        public string? InReplyToUserId { get; set; }

        /// <summary>
        /// Language of the Tweet, if detected by Twitter. Returned as a BCP47 language tag.
        /// Classify Tweets by spoken language.
        /// </summary>
        /// <example>
        /// "lang": "en"
        /// </example>
        [JsonPropertyName("lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Non-public engagement metrics for the Tweet at the time of the request. 
        /// Requires user context authentication.
        /// Use this to determine the total number of impressions generated for the Tweet.
        /// </summary>
        /// <example>
        /// "non_public_metrics": {
        ///       "impression_count": 99
        ///       "url_link_clicks": 37
        ///       "user_profile_clicks": 22
        ///  }
        /// </example>
        [JsonPropertyName("non_public_metrics")]
        public object? NonPublicMetrics { get; set; }


        /// <summary>
        /// Engagement metrics, tracked in an organic context, for the Tweet at the time of the request.
        /// Requires user context authentication.
        /// Use this to measure organic engagement for the Tweet.
        /// </summary>
        /// <example>
        /// "organic_metrics": {
        ///      "impression_count": 3880,
        ///      "like_count": 8,
        ///      "reply_count": 0,
        ///      "retweet_count": 4
        ///      "url_link_clicks": 3
        ///      "user_profile_clicks": 2
        /// }
        /// </example>
        [JsonPropertyName("organic_metrics")]
        public object? OrganicMetrics { get; set; }


        /// <summary>
        /// This field indicates content may be recognized as sensitive. The Tweet author can select within their own account preferences and choose “Mark media you tweet as having material that may be sensitive” so each Tweet created after has this flag set.
        /// This may also be judged and labeled by an internal Twitter support agent.
        /// Studying circulation of certain types of content.
        /// </summary>
        [JsonPropertyName("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }


        /// <summary>
        /// Engagement metrics, tracked in a promoted context, for the Tweet at the time of the request.
        /// Requires user context authentication.
        /// Use this to measure engagement for the Tweet when it was promoted.
        /// </summary>
        /// <example>
        /// "promoted_metrics": {
        ///       "impression_count": 1082,
        ///       "like_count": 187,
        ///       "reply_count": 6,
        ///       "retweet_count": 25
        ///       "url_link_clicks": 30
        ///       "user_profile_clicks": 2
        ///  }
        /// </example>
        [JsonPropertyName("promoted_metrics")]
        public object? PromotedMetrics { get; set; }


        /// <summary>
        /// Public engagement metrics for the Tweet at the time of the request.
        /// Use this to measure Tweet engagement.
        /// </summary>
        /// <example>
        /// "public_metrics" : {
        ///          "retweet_count": 8,
        ///          "reply_count": 2,
        ///          "like_count": 39,
        ///          "quote_count": 1
        ///  }
        /// </example>
        [JsonPropertyName("public_metrics")]
        public object? PublicMetrics { get; set; }


        /// <summary>
        /// A list of Tweets this Tweet refers to. For example, if the parent Tweet is a Retweet, a Retweet with comment (also known as Quoted Tweet) or a Reply, it will include the related Tweet referenced to by its parent.
        /// This field can be used to understand conversational aspects of retweets etc.
        /// reply_settings	string	Shows you who can reply to a given Tweet. Fields returned are "everyone", "mentioned_users", and "followers".
        /// "reply_settings": "everyone"	This field allows you to determine whether conversation reply settings have been set for the Tweet and if so, what settings have been set.
        /// </summary>
        /// <example>
        /// "referenced_tweets": [
        ///        {
        ///            "type": "replied_to",
        ///            "id": "1242125486844604425"
        ///        }
        ///    ]
        /// "referenced_tweets": [
        ///        {
        ///            "type": "quoted",
        ///            "id": "1265712391578214400"
        ///        }
        ///    ]
        /// </example>
        [JsonPropertyName("referenced_tweets")]
        public object[]? ReferencedTweets { get; set; }


        /// <summary>
        /// The name of the app the user Tweeted from.
        /// Determine if a Twitter user posted from the web, mobile device, or other app.

        /// </summary>
        /// <example>
        /// "source": "Twitter Web App"
        /// </example>
        [JsonPropertyName("source")]
        public string? Source { get; set; }

        /// <summary>
        /// When present, contains withholding details for withheld content.
        /// </summary>
        /// <example>
        /// "withheld": {
        ///        "copyright": false,
        ///        "country_codes": [
        ///           "IN"
        ///        ]
        ///    }
        /// </example>
        [JsonPropertyName("withheld")]
        public object? Withheld { get; set; }

    }
}