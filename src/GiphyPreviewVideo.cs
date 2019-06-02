namespace UniBot.Giphy
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a giphy preview video.
    /// </summary>
    public class GiphyPreviewVideo : GiphyVideo
    {
        /// <summary>
        ///     Gets the video size in bytes.
        /// </summary>
        [JsonProperty("mp4_size")]
        public int VideoByteSize { get; internal set; }

        /// <summary>
        ///     Gets the width of the video.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; internal set; }

        /// <summary>
        ///     Gets the height of the video.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; internal set; }
    }
}