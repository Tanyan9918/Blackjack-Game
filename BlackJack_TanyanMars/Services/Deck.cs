using BlackJack_TanyanMars.Models;
namespace BlackJack_TanyanMars.Services
{
    /// <summary>
    /// The deck of all 52 cards with no duplicates
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// Creates a stack of cards for the deck
        /// </summary>
        public Stack<Card> deck;

        /// <summary>
        /// Creates the deck and starts the code
        /// </summary>
        public Deck()
        {
            deck = new Stack<Card>();
            StartDeck();
        }

        /// <summary>
        /// Puts the cards in the deck then starts the shuffle
        /// </summary>
        public void StartDeck()
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Push(new Card(suit, rank));
                }
            }

            ShuffleDeck();
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void ShuffleDeck()
        {
            var rand = new Random();
            deck = new Stack<Card>(deck.OrderBy(_ => rand.Next()));
        }

        /// <summary>
        /// Deals the cards if there are still cards left in the deck
        /// </summary>
        /// <returns>The card that was dealt</returns>
        public Card DealCard()
        {
            if(deck.Count == 0)
            {
                throw new Exception("no cards left in deck");
            }
            return deck.Pop();
        }

        /// <summary>
        /// Gives the amount of cards left in the deck
        /// </summary>
        /// <returns>The amount of cards left</returns>
        public int CardsLeftInDeck()
        {
            return deck.Count;
        }
    }
}
