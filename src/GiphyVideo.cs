namespace Giphy4NET
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a giphy video.
    /// </summary>
    public class GiphyVideo
    {
        /// <summary>
        ///     Gets the url to the video.
        /// </summary>
        [JsonProperty("mp4")]
        public string VideoUrl { get; internal set; }
    }
}