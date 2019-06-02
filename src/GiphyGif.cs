namespace UniBot.Giphy
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a giphy gif object (https://developers.giphy.com/docs/#gif-object).
    /// </summary>
    public class GiphyGif
    {
        /// <summary>
        ///     Gets the shorted url for the gif.
        /// </summary>
        [JsonProperty("bitly_url")]
        public string BitlyUrl { get; internal set; }

        /// <summary>
        ///     Gets the time when the gif was created.
        /// </summary>
        [JsonProperty("create_datetime")]
        public string CreateDateTime { get; internal set; }

        /// <summary>
        ///     Gets the giphy url used for embeds.
        /// </summary>
        [JsonProperty("embed_url")]
        public string EmbedUrl { get; internal set; }

        /// <summary>
        ///     Gets the unique gif identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; internal set; }

        /// <summary>
        ///     Gets the url to the giphy image url.
        /// </summary>
        [JsonProperty("url")]
        public string ImageUrl { get; internal set; }

        /// <summary>
        ///     Gets the time when the gif was imported.
        /// </summary>
        [JsonProperty("import_datetime")]
        public string ImportDateTime { get; internal set; }

        /// <summary>
        ///     Gets the gif age rating.
        /// </summary>
        [JsonProperty("rating")]
        public string Rating { get; internal set; }

        /// <summary>
        ///     Gets the gif's slug.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; internal set; }

        /// <summary>
        ///     Gets the gif's source post url.
        /// </summary>
        [JsonProperty("source_post_url")]
        public string SourcePostUrl { get; internal set; }

        /// <summary>
        ///     Gets the TLD (Top-Level domain) of the source url.
        /// </summary>
        [JsonProperty("source_tld")]
        public string SourceTld { get; internal set; }

        /// <summary>
        ///     Gets the source where the gif was taken from.
        /// </summary>
        [JsonProperty("source")]
        public string SourceUrl { get; internal set; }

        /// <summary>
        ///     Gets the image set for the gif.
        /// </summary>
        [JsonRequired, JsonProperty("images")]
        public GiphyImageSet Images { get; internal set; }

        /// <summary>
        ///     Gets the gif title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; internal set; }

        /// <summary>
        ///     Gets the time when the gif was marked as trending (or <see langword="null"/> if the
        ///     gif was never trending).
        /// </summary>
        [JsonProperty("trending_datetime")]
        public string TrendingDateTime { get; internal set; }

        /// <summary>
        ///     Gets the gif type (in the most cases 'gif').
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; internal set; } = "gif";

        /// <summary>
        ///     Gets the time when the gif was updated.
        /// </summary>
        [JsonProperty("update_datetime")]
        public string UpdateDateTime { get; internal set; }

        /// <summary>
        ///     Gets the creator of the gif.
        /// </summary>
        [JsonProperty("user")]
        public GiphyUser User { get; internal set; }

        /// <summary>
        ///     Gets the username of the user that posted the gif.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; internal set; }
    }
}