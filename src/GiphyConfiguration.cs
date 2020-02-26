namespace Giphy4NET
{
    /// <summary>
    ///     The configuration for the <see cref="GiphyService"/>.
    /// </summary>
    public sealed class GiphyConfiguration
    {
        /// <summary>
        ///     Gets or sets the GIPHY api authentication token used for requests.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Gets or sets the GIPHY api base address.
        /// </summary>
        public string BaseAddress { get; set; } = "https://api.giphy.com/v1/";
    }
}