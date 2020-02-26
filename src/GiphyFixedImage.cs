namespace Giphy4NET
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a fixed giphy image object.
    /// </summary>
    public class GiphyFixedImage : GiphyFixedDownsampledImage
    {
        /// <summary>
        ///     Gets the direct url to the mp4 video.
        /// </summary>
        [JsonProperty("mp4")]
        public string Mp4Url { get; internal set; }

        /// <summary>
        ///     Gets the size in bytes of the mp4 video.
        /// </summary>
        [JsonProperty("mp4_size")]
        public int Mp4ByteSize { get; internal set; }
    }
}