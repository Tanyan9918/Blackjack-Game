using BlackJack_TanyanMars.Services;
using System.Xml.Linq;
namespace BlackJack_TanyanMars.Models
{
    /// <summary>
    /// The bot/npc that faces the user
    /// </summary>
    public class Dealer : ICharacter
    {
        /// <summary>
        /// The name of the dealer
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The dealer's hand
        /// </summary>
        public Hand hand { get; set; }

        /// <summary>
        /// Gets the value of the hand
        /// </summary>
        public int handValue => hand.GetHandValue();

        /// <summary>
        /// Gets if the dealer busted
        /// </summary>
        public bool isBusted => hand.GetHandValue() > 21;

        /// <summary>
        /// Creates the dealer's hand and sets their name
        /// </summary>
        public Dealer()
        {
            hand = new Hand();
            name = "Dealer";
        }

        /// <summary>
        /// Adds the specific card to the dealer's hand
        /// </summary>
        /// <param name="card">The specific card</param>
        public void addCard(Card card)
        {
            hand.AddCard(card);
        }

        /// <summary>
        /// Reveals all the dealer's cards by setting them to face up.
        /// </summary>
        public void RevealAllCards()
        {
            foreach (var card in hand.hand)
            {
                card.IsFaceUp = true;
            }
        }

        /// <summary>
        /// Looked it up and made sure that an actual dealer would hit if the value is less than 17
        /// </summary>
        /// <returns>Wether the dealer should hit</returns>
        public bool ShouldHit()
        {
            if(handValue < 17)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Has the dealer take their turn by hitting when they should
        /// </summary>
        /// <param name="deck">The deck the dealer is getting cards from</param>
        public void TakeTurn(Deck deck)
        {
            while (ShouldHit())
            {
                addCard(deck.DealCard());
            }
        }

        /// <summary>
        /// Overrides tostring to show the hand value of the dealer
        /// </summary>
        /// <returns>the hand value of the dealer</returns>
        public override string ToString()
        {
            return $"{name}'s Hand: {hand.GetHandValue} points";
        }
    }
}
