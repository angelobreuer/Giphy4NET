namespace Giphy4NET
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     A service used to request gifs from the GIPHY api.
    /// </summary>
    public sealed class GiphyService
    {
        /// <summary>
        ///     The HTTP request client used for requests to the GIPHY api.
        /// </summary>
        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        ///     The authentication api key.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        ///     The base request address.
        /// </summary>
        private readonly Uri _baseAddress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GiphyService"/> class.
        /// </summary>
        /// <param name="configuration">the service configuration</param>
        /// <exception cref="ArgumentNullException">
        ///     thrown if the specified <paramref name="configuration"/> is <see langword="null"/>.
        /// </exception>
        public GiphyService(GiphyConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _apiKey = configuration.Token;
            _baseAddress = new Uri(configuration.BaseAddress);
        }

        /// <summary>
        ///     Builds the api endpoint Uri for the specified <paramref name="endpoint"/> and <paramref name="queryParameters"/>.
        /// </summary>
        /// <param name="endpoint">
        ///     the GIPHY api endpoint (relative to the base address specified in the service configuration)
        /// </param>
        /// <param name="queryParameters">the query parameters (without api_key)</param>
        /// <returns>the request uri</returns>
        private Uri BuildUri(string endpoint, NameValueCollection queryParameters = null)
        {
            var uriBuilder = new UriBuilder(new Uri(_baseAddress, endpoint));
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            if (queryParameters != null)
            {
                parameters.Add(queryParameters);
            }

            parameters["api_key"] = _apiKey;

            uriBuilder.Query = parameters.ToString();
            return uriBuilder.Uri;
        }

        /// <summary>
        ///     Gets the error message for the specified <paramref name="uri"/> and <paramref name="responseMeta"/>.
        /// </summary>
        /// <param name="uri">the requested resource uri</param>
        /// <param name="responseMeta">the meta from the response</param>
        /// <returns>
        ///     the error message; or <see langword="null"/> if no error message is available
        /// </returns>
        private string GetErrorMessage(Uri uri, GiphyResponseMeta responseMeta)
        {
            switch (responseMeta.StatusCode)
            {
                case 403:
                case 404:
                case 400:
                    return $"Error while requesting {uri}: {responseMeta.Message}.";

                case 429:
                    return "You're being rate limited! Your Giphy API key is rate limited.";
            }

            return null;
        }

        /// <summary>
        ///     Throws an exception if the specified <paramref name="responseMeta"/> is invalid.
        /// </summary>
        /// <param name="uri">the uri of the requested api resource</param>
        /// <param name="responseMeta">the meta from the response</param>
        private void ValidateResponseMeta(Uri uri, GiphyResponseMeta responseMeta)
        {
            if (responseMeta.StatusCode != 200)
            {
                throw new Exception(GetErrorMessage(uri, responseMeta));
            }
        }

        private string GetRatingValue(GiphyRating rating)
        {
            switch (rating)
            {
                case GiphyRating.Unrated:
                    return "unrated";

                case GiphyRating.IllustratedContent:
                    return "y";

                case GiphyRating.GeneralAudiences:
                    return "g";

                case GiphyRating.ParentalGuidanceSuggested:
                    return "pg";

                case GiphyRating.ParentsStronglyCautioned:
                    return "pg-13";

                case GiphyRating.Restricted:
                    return "r";

                case GiphyRating.AdultsOnly:
                    return "nsfw";

                default:
                    throw new ArgumentException("Unknown rating.");
            }
        }

        /// <summary>
        ///     Gets a random gif from the GIPHY api asynchronously.
        /// </summary>
        /// <param name="tag">the gif tag</param>
        /// <param name="rating">the gif rating</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>
        ///     a task that represents the asynchronous operation
        ///     <para>
        ///         the gif search result; or null if no gif could be found with the specified
        ///         <paramref name="tag"/> and gif <paramref name="rating"/>.
        ///     </para>
        /// </returns>
        public async Task<GiphyGif> GetRandomGifAsync(string tag = null, GiphyRating? rating = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(tag))
            {
                parameters["tag"] = tag;
            }

            if (rating != null)
            {
                parameters["rating"] = GetRatingValue(rating.Value);
            }

            var uri = BuildUri("gifs/random", parameters);

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var payload = JsonConvert.DeserializeObject<GiphyResponse<JToken>>(responseContent);
                ValidateResponseMeta(uri, payload.ResponseMeta);

                // giphy returns an empty array if there are no results
                if (payload.Data is JArray)
                {
                    return null;
                }

                return payload.Data.ToObject<GiphyGif>();
            }
        }

        /// <summary>
        ///     Searches a gif asynchronously.
        /// </summary>
        /// <param name="query">the search term</param>
        /// <param name="offset">the search offset</param>
        /// <param name="rating">the age rating</param>
        /// <param name="language">the gif language</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async Task<GiphyGif> SearchGifAsync(string query, int offset = 0,
            GiphyRating? rating = null, string language = "en", CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var gifs = await SearchGifsAsync(query, limit: 1, offset, rating, language, cancellationToken);
            return gifs?.FirstOrDefault();
        }

        /// <summary>
        ///     Searches gifs asynchronously.
        /// </summary>
        /// <param name="query">the search term</param>
        /// <param name="limit">the search limit</param>
        /// <param name="offset">the search offset</param>
        /// <param name="rating">the age rating</param>
        /// <param name="language">the gif language</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async Task<IEnumerable<GiphyGif>> SearchGifsAsync(string query, int limit = 25, int offset = 0,
            GiphyRating? rating = null, string language = "en", CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection { ["q"] = query };

            if (limit != 25)
            {
                parameters["limit"] = limit.ToString();
            }

            if (offset != 0)
            {
                parameters["offset"] = offset.ToString();
            }

            if (rating != null)
            {
                parameters["rating"] = GetRatingValue(rating.Value);
            }

            if (language != null && !language.Equals("en"))
            {
                parameters["lang"] = language;
            }

            var uri = BuildUri("gifs/search", parameters);

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var payload = JsonConvert.DeserializeObject<GiphyResponse<GiphyGif[]>>(responseContent);
                ValidateResponseMeta(uri, payload.ResponseMeta);

                return payload.Data;
            }
        }

        /// <summary>
        ///     Gets the trending gifs asynchronously.
        /// </summary>
        /// <param name="limit">the gif limit</param>
        /// <param name="offset">the search offset</param>
        /// <param name="rating">the age rating</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async Task<IEnumerable<GiphyGif>> GetTrendingGifsAsync(int limit = 25, int offset = 0, string rating = null
            , CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection();

            if (limit != 25)
            {
                parameters["limit"] = limit.ToString();
            }

            if (offset != 0)
            {
                parameters["offset"] = offset.ToString();
            }

            if (!string.IsNullOrWhiteSpace(rating))
            {
                parameters["rating"] = rating;
            }

            var uri = BuildUri("gifs/trending", parameters);

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var payload = JsonConvert.DeserializeObject<GiphyResponse<GiphyGif[]>>(responseContent);
                ValidateResponseMeta(uri, payload.ResponseMeta);

                return payload.Data;
            }
        }

        /// <summary>
        ///     Translates the specified <paramref name="query"/> into an animated sticker asynchronously.
        /// </summary>
        /// <param name="query">the text to translate into a sticker</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async Task<GiphyGif> TranslateStickerAsync(string query, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Empty search query.", nameof(query));
            }

            var uri = BuildUri("stickers/translate", new NameValueCollection { ["s"] = query });

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var payload = JsonConvert.DeserializeObject<GiphyResponse<GiphyGif>>(responseContent);
                ValidateResponseMeta(uri, payload.ResponseMeta);

                return payload.Data;
            }
        }

        /// <summary>
        ///     Translates the specified <paramref name="query"/> into an animated gif asynchronously.
        /// </summary>
        /// <param name="query">the text to translate into a gif</param>
        /// <param name="weirdness">the translation weirdness</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async Task<GiphyGif> TranslateAsync(string query, int weirdness, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Empty search query.", nameof(query));
            }

            if (weirdness < 0 || weirdness > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(weirdness), weirdness, "Weirdness out of range: 0 - 10");
            }

            var uri = BuildUri("gifs/translate", new NameValueCollection
            {
                ["weirdness"] = weirdness.ToString(),
                ["s"] = query
            });

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var payload = JsonConvert.DeserializeObject<GiphyResponse<GiphyGif>>(responseContent);
                ValidateResponseMeta(uri, payload.ResponseMeta);

                return payload.Data;
            }
        }

        /// <summary>
        ///     Gets the gif specified by <paramref name="gifId"/> asynchronously.
        /// </summary>
        /// <param name="gifId">the gif identifier</param>
        /// <param name="cancellationToken">
        ///     the cancellation token used to propagate notification that the asynchronous operation
        ///     should be canceled
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async Task<GiphyGif> GetGifAsync(string gifId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(gifId))
            {
                throw new ArgumentException("Empty gif identifier.", nameof(gifId));
            }

            var uri = BuildUri("gifs/" + gifId);

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var payload = JsonConvert.DeserializeObject<GiphyResponse<GiphyGif[]>>(responseContent);
                ValidateResponseMeta(uri, payload.ResponseMeta);

                return payload.Data.FirstOrDefault();
            }
        }
    }
}