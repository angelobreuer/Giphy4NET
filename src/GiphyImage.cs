namespace UniBot.Giphy
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a giphy image object.
    /// </summary>
    public class GiphyImage
    {
        /// <summary>
        ///     Gets the direct url to the image.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        ///     Gets the width of the image.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; internal set; }

        /// <summary>
        ///     Gets the height of the image.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; internal set; }
    }
}