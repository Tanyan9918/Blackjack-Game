namespace BlackJack_TanyanMars.Services
{
    /// <summary>
    /// Gives the outline of what the fileservice needs to look like
    /// </summary>
    public interface IFileService
    {

        /// <summary>
        /// Fetches the ImageURL for a card based on its Rank and Suit.
        /// </summary>
        /// <param name="rank">The rank of the card</param>
        /// <param name="suit">The suit of the card</param>
        /// <returns>The ImageURL as a string</returns>
        Task<string?> GetCardImageUrlAsync(string rank, string suit);
    }
}
