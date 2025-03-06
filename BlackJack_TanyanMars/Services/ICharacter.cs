using BlackJack_TanyanMars.Models;
namespace BlackJack_TanyanMars.Services
{
    /// <summary>
    /// Creates an outline for the characters to use
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Gets the name of the character
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// Creates the hand of the character
        /// </summary>
        Hand hand { get; }

        /// <summary>
        /// Gets the hand value of character's hand
        /// </summary>
        int handValue { get; }

        /// <summary>
        /// Gets if the character busted
        /// </summary>
        bool isBusted { get; }

        /// <summary>
        /// Adds a card to the character
        /// </summary>
        /// <param name="card">the specific card added to the player</param>
        void addCard(Card card);

        /// <summary>
        /// Reveals all the cards of the characters
        /// </summary>
        void RevealAllCards();
    }
}
