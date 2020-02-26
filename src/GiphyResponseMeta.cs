namespace Giphy4NET
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The response meta for giphy api responses.
    /// </summary>
    public sealed class GiphyResponseMeta
    {
        /// <summary>
        ///     Gets the HTTP response message.
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; internal set; }

        /// <summary>
        ///     Gets the unique response identifier.
        /// </summary>
        [JsonProperty("response_id")]
        public string ReponseId { get; internal set; }

        /// <summary>
        ///     Gets the HTTP status response code.
        /// </summary>
        [JsonRequired, JsonProperty("status")]
        public int StatusCode { get; internal set; }
    }
}