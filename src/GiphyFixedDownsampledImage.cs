namespace Giphy4NET
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a fixed, down-sampled image object.
    /// </summary>
    public class GiphyFixedDownsampledImage : GiphyDownsizedImage
    {
        /// <summary>
        ///     Gets the direct url to the webp (Web Picture).
        /// </summary>
        [JsonProperty("webp"), JsonRequired]
        public string WebPUrl { get; internal set; }

        /// <summary>
        ///     Gets the total byte size of the webp (Web Picture).
        /// </summary>
        [JsonProperty("webp_size"), JsonRequired]
        public int WebPByteSize { get; internal set; }
    }
}