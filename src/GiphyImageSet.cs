namespace UniBot.Giphy
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a giphy images object (https://developers.giphy.com/docs/#images-object).
    /// </summary>
    public sealed class GiphyImageSet
    {
        /// <summary>
        ///     Gets the gif in downsized format.
        /// </summary>
        [JsonRequired, JsonProperty("downsized")]
        public GiphyDownsizedImage Downsized { get; internal set; }

        /// <summary>
        ///     Gets the gif in downsized (large) format.
        /// </summary>
        [JsonRequired, JsonProperty("downsized_large")]
        public GiphyDownsizedImage DownsizedLarge { get; internal set; }

        /// <summary>
        ///     Gets the gif in downsized (medium) format.
        /// </summary>
        [JsonRequired, JsonProperty("downsized_medium")]
        public GiphyDownsizedImage DownsizedMedium { get; internal set; }

        /// <summary>
        ///     Gets the gif in downsized (small) format.
        /// </summary>
        [JsonRequired, JsonProperty("downsized_small")]
        public GiphyDownsizedImage DownsizedSmall { get; internal set; }

        /// <summary>
        ///     Gets the gif in downsized (still) format.
        /// </summary>
        [JsonRequired, JsonProperty("downsized_still")]
        public GiphyImage DownsizedStill { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_height")]
        public GiphyFixedImage FixedHeight { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (down-sampled) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_height_downsampled")]
        public GiphyFixedDownsampledImage FixedHeightDownsampled { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (small) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_height_small")]
        public GiphyFixedImage FixedHeightSmall { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (small, still) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_height_small_still")]
        public GiphyImage FixedHeightSmallStill { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (still) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_height_still")]
        public GiphyImage FixedHeightStill { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed width format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_width")]
        public GiphyFixedImage FixedWidth { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (down-sampled) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_width_downsampled")]
        public GiphyFixedDownsampledImage FixedWidthDownsampled { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (small) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_width_small")]
        public GiphyFixedImage FixedWidthSmall { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (small, still) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_width_small_still")]
        public GiphyImage FixedWidthSmallStill { get; internal set; }

        /// <summary>
        ///     Gets the gif in fixed height (still) format.
        /// </summary>
        [JsonRequired, JsonProperty("fixed_width_still")]
        public GiphyImage FixedWidthStill { get; internal set; }

        /// <summary>
        ///     Gets the gif as a looped 15 seconds video.
        /// </summary>
        [JsonRequired, JsonProperty("looping")]
        public GiphyVideo Looping { get; internal set; }

        /// <summary>
        ///     Gets the original gif.
        /// </summary>
        [JsonRequired, JsonProperty("original")]
        public GiphyOriginalImage Original { get; internal set; }

        /// <summary>
        ///     Gets the original gif (still).
        /// </summary>
        [JsonRequired, JsonProperty("original_still")]
        public GiphyImage OriginalStill { get; internal set; }

        /// <summary>
        ///     Gets the gif preview video.
        /// </summary>
        [JsonRequired, JsonProperty("preview")]
        public GiphyPreviewVideo Preview { get; internal set; }

        /// <summary>
        ///     Gets the gif preview gif.
        /// </summary>
        [JsonRequired, JsonProperty("preview_gif")]
        public GiphyDownsizedImage PreviewGif { get; internal set; }
    }
}