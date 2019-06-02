namespace UniBot.Giphy
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a giphy user.
    /// </summary>
    public sealed class GiphyUser
    {
        /// <summary>
        ///     Gets the avatar url of the user.
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; internal set; }

        /// <summary>
        ///     Gets the banner url of the user.
        /// </summary>
        [JsonProperty("banner_url")]
        public string BannerUrl { get; internal set; }

        /// <summary>
        ///     Gets the display name of the user.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; internal set; }

        /// <summary>
        ///     Gets the profile url of the user.
        /// </summary>
        [JsonProperty("profile_url")]
        public string ProfileUrl { get; internal set; }

        /// <summary>
        ///     Gets the twitter mention (starting with @) of the user.
        /// </summary>
        [JsonProperty("twitter")]
        public string Twitter { get; internal set; }

        /// <summary>
        ///     Gets the username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; internal set; }
    }
}