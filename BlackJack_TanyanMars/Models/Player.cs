using BlackJack_TanyanMars.Services;
using System.Xml.Linq;
namespace BlackJack_TanyanMars.Models
{
    /// <summary>
    /// The user's character
    /// </summary>
    public class Player : ICharacter
    {
        /// <summary>
        /// Gets the name of the character
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Creates the hand of the character
        /// </summary>
        public Hand hand { get; }

        /// <summary>
        /// Gets the hand value of character's hand
        /// </summary>
        public int handValue => hand.GetHandValue();

        /// <summary>
        /// Gets if the character busted
        /// </summary>
        public bool isBusted => hand.GetHandValue() > 21;

        /// <summary>
        /// Starts the player by getting their name
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            hand = new Hand();
            this.name = name;
        }

        /// <summary>
        /// Adds a card to the character
        /// </summary>
        /// <param name="card">the specific card added to the player</param>
        public void addCard(Card card)
        {
            hand.AddCard(card);
        }

        /// <summary>
        /// Reveals all the cards of the characters
        /// </summary>
        public void RevealAllCards()
        {
            hand.GetAllCards();
        }

        /// <summary>
        /// Overrides tostring to show the hand value of the player
        /// </summary>
        /// <returns>the hand value of the player</returns>
        public override string ToString()
        {
            return $"{name}'s Hand: {hand.GetHandValue} points";
        }
    }
}
