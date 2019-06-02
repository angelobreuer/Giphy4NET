namespace UniBot.Giphy
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a original giphy image object.
    /// </summary>
    public class GiphyOriginalImage : GiphyFixedImage
    {
        /// <summary>
        ///     Gets the total frame count of the gif.
        /// </summary>
        [JsonProperty("frames")]
        public int FrameCount { get; internal set; }
    }
}