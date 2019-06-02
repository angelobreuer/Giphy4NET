namespace UniBot.Giphy
{
    /// <summary>
    ///     A set of MPAA-style-Ratings supported by giphy.
    /// </summary>
    /// <remarks>
    ///     See
    ///     https://en.wikipedia.org/wiki/Motion_Picture_Association_of_America_film_rating_system
    ///     and https://github.com/Giphy/GiphyAPI/issues/55 for more details.
    /// </remarks>
    public enum GiphyRating
    {
        /// <summary>
        ///     The gif to show should be unrated. (Not part of the MPAA-Rating)
        /// </summary>
        Unrated,

        /// <summary>
        ///     Shows only explicit illustrated content (e.g. cartoons) ["Y"]. (Not part of the MPAA-Rating)
        /// </summary>
        IllustratedContent,

        /// <summary>
        ///     The MPAA-Rating: G – General Audiences
        /// </summary>
        /// <remarks>
        ///     All ages admitted. Nothing that would offend parents for viewing by children.
        /// </remarks>
        GeneralAudiences,

        /// <summary>
        ///     The MPAA-Rating: PG – Parental Guidance Suggested
        /// </summary>
        /// <remarks>
        ///     Some material may not be suitable for children. Parents urged to give "parental
        ///     guidance". May contain some material parents might not like for their young children.
        /// </remarks>
        ParentalGuidanceSuggested,

        /// <summary>
        ///     The MPAA-Rating: PG-13 – Parents Strongly Cautioned
        /// </summary>
        /// <remarks>
        ///     Some material may be inappropriate for children under 13. Parents are urged to be
        ///     cautious. Some material may be inappropriate for pre-teenagers.
        /// </remarks>
        ParentsStronglyCautioned,

        /// <summary>
        ///     The MPAA-Rating: R – Restricted
        /// </summary>
        /// <remarks>
        ///     Under 17 requires accompanying parent or adult guardian. Contains some adult
        ///     material. Parents are urged to learn more about the film before taking their young
        ///     children with them.
        /// </remarks>
        Restricted,

        /// <summary>
        ///     The MPAA-Rating: NC-17 – Adults Only (Giphys equivalent: ["nsfw"])
        /// </summary>
        /// <remarks>No One 17 and Under Admitted. Clearly adult. Children are not admitted.</remarks>
        AdultsOnly
    }
}