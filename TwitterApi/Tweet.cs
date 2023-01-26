
namespace TwitterApi
{
    public class Tweet
    {
        /// <summary>
        /// The unique identifier of the requested Tweet.
        /// se this to programmatically retrieve a specific Tweet.
        /// </summary>
        /// <example>
        /// "id": "1050118621198921728"
        /// </example>
        public string id { get; set; }

        /// <summary>
        /// The actual UTF-8 text of the Tweet. See twitter-text for details on what characters are currently considered valid.    
        /// Keyword extraction and sentiment analysis/classification.
        /// </summary>
        /// <example>
        /// "text": "To make room for more expression, we will now count all emojis as equal—including those with gender‍‍‍ ‍‍and skin tone modifiers 👍🏻👍🏽👍🏿. This is now reflected in Twitter-Text, our Open Source library. \n\nUsing Twitter-Text? See the forum post for detail: https://t.co/Nx1XZmRCXA"
        /// </example>
        public string text { get; set; }

        /// <summary>
        /// nique identifiers indicating all versions of a Tweet. For Tweets with no edits, there will be one ID. For Tweets with an edit history, there will be multiple IDs, arranged in ascending order reflecting the order of edits. The most recent version is the last position of the array.

        /// se this information to find the edit history of a Tweet.
        /// </summary>
        /// <example>
        /// "edit_history_tweet_ids": [  "1584717154800521216"]
        /// </example>
        public string[] edit_history_tweet_ids { get; set; }

        /// <summary>
        /// Specifies the type of attachments (if any) present in this Tweet.
        /// nderstanding the objects returned for requested expansions 
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
        public object attachments { get; set; }

        /// <summary>
        /// The unique identifier of the User who posted this Tweet.
        /// Hydrating User object, sharing dataset for peer review
        /// </summary>
        /// <example>
        /// "author_id": "2244994945"
        /// </example>
        public string author_id { get; set; }

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
        public ContextAnnotation context_annotations { get; set; }

        /// <summary>
        /// conversation_id
        /// string
        /// The Tweet ID of the original Tweet of the conversation (which includes direct replies, replies of replies).
        /// "conversation_id": "1050118621198921728"
        /// se this to reconstruct the conversation from a Tweet.
        /// created_at
        /// date (ISO 8601)
        /// Creation time of the Tweet.
        /// "created_at": "2019-06-04T23:12:08.000Z"
        /// This field can be used to understand when a Tweet was created and used for time-series analysis etc. 
        /// </summary>
        /// <example>
        /// </example>
        public string conversation_id { get; set; }

        /// <summary>
        /// When present, this indicates how much longer the Tweet can be edited and the number of remaining edits. Tweets are only editable for the first 30 minutes after creation and can be edited up to five times.
        /// se this to determine if a Tweet is eligible for editing.
        /// </summary>
        /// <example>
        /// "edit_controls": {
        ///   "edits_remaining": 5,
        ///   "is_edit_eligible": true,
        ///   "editable_until": "2022-10-25T01:53:06.000Z"
        /// }
        /// </example>
        public object edit_controls { get; set; }


        /// <summary>
        /// Entities that have been parsed out of the text of the Tweet. Additionally, see entities in Twitter Objects.
        /// Entities are JSON objects that provide additional information about hashtags, urls, user mentions, and cashtags associated with a Tweet. Reference each respective entity for further details.
        /// Please note that all start indices are inclusive. The majority of end indices are exclusive, except for entities.annotations.end, which is currently inclusive. We will be changing this to exclusive with our v3 bump since it is a breaking change. 
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
        public object entities { get; set; }

        /// <summary>
        /// If the represented Tweet is a reply, this field will contain the original Tweet’s author ID. This will not necessarily always be the user directly mentioned in the Tweet.
        /// Use this to determine if this Tweet was in reply to another Tweet.
        /// </summary>
        /// <example>
        /// "in_reply_to_user_id": "2244994945"
        /// </example>
        public string in_reply_to_user_id { get; set; }

        /// <summary>
        /// Language of the Tweet, if detected by Twitter. Returned as a BCP47 language tag.
        /// Classify Tweets by spoken language.
        /// </summary>
        /// <example>
        /// "lang": "en"
        /// </example>
        public string lang { get; set; }

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
        public object non_public_metrics { get; set; }


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
        public object organic_metrics { get; set; }


        /// <summary>
        /// This field indicates content may be recognized as sensitive. The Tweet author can select within their own account preferences and choose “Mark media you tweet as having material that may be sensitive” so each Tweet created after has this flag set.
        /// This may also be judged and labeled by an internal Twitter support agent.
        /// Studying circulation of certain types of content.
        /// </summary>
        public bool possibly_sensitive { get; set; }


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
        public object promoted_metrics { get; set; }


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
        public object public_metrics { get; set; }


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
        public object[] referenced_tweets { get; set; }


        /// <summary>
        /// The name of the app the user Tweeted from.
        /// "source": "Twitter Web App"
        /// Determine if a Twitter user posted from the web, mobile device, or other app.

        /// </summary>
        /// <example>
        /// </example>
        public string source { get; set; }

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
        public object withheld { get; set; }

    }
}