namespace Giphy4NET
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    ///     The representation of a giphy response payload.
    /// </summary>
    /// <typeparam name="TData">the type of the data returned with the request</typeparam>
    public sealed class GiphyResponse<TData>
    {
        /// <summary>
        ///     Gets the response payload inner data.
        /// </summary>
        [JsonProperty("data")]
        public TData Data { get; internal set; }

        /// <summary>
        ///     Gets the response meta given with the request.
        /// </summary>
        [JsonRequired, JsonProperty("meta")]
        public GiphyResponseMeta ResponseMeta { get; internal set; }
    }
}