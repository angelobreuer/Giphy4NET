namespace Giphy4NET
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a downsized giphy image.
    /// </summary>
    public class GiphyDownsizedImage : GiphyImage
    {
        /// <summary>
        ///     Gets the total byte size of the image.
        /// </summary>
        [JsonProperty("size")]
        public int ByteSize { get; internal set; }
    }
}