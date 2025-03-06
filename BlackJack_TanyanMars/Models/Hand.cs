namespace BlackJack_TanyanMars.Models
{
    /// <summary>
    /// Each player has a hand of cards
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// Last in first out so that the card being shown is the last ones that go in
        /// </summary>
        public Stack<Card> hand;

        /// <summary>
        /// Creates the hand stack of cards
        /// </summary>
        public Hand()
        {
            hand = new Stack<Card>();
        }

        /// <summary>
        /// Adds a card to the hand
        /// </summary>
        /// <param name="card">The specific card</param>
        public void AddCard(Card card)
        {
            card.IsFaceUp = false;
            hand.Push(card);

            FlipCardFaceUp();
        }

        /// <summary>
        /// flips the cards face up
        /// </summary>
        public void FlipCardFaceUp()
        {
            if (hand.TryPeek(out Card topCard))
            {
                topCard.IsFaceUp = true;
            }
        }

        /// <summary>
        /// Gets the card count of the hand to determine winner if tie
        /// </summary>
        /// <returns>The amount of cards in the hand</returns>
        public int GetCardCount()
        {
            return hand.Count;
        }

        /// <summary>
        /// Gets all of the cards for display purposes
        /// </summary>
        /// <returns>All cards</returns>
        public IEnumerable<Card> GetAllCards()
        {
            return hand;
        }

        /// <summary>
        /// Gets the hands value and determines if an ace is one or 11 of face up
        /// </summary>
        /// <param name="revealAllCards">If the cards need to all be revealed</param>
        /// <returns>The total value of cards</returns>
        public int GetHandValue(bool revealAllCards = false)
        {
            int totalValue = 0;
            int aceCount = 0;

            foreach(var card in hand)
            {
                if(!card.IsFaceUp && !revealAllCards)
                {
                    continue;
                }

                if(card.Rank == Rank.Ace)
                {
                    totalValue += 1;
                    aceCount++;
                }
                else
                {
                    totalValue += (int)card.Rank;
                }
            }

            for(int i = 0; i < aceCount; i++)
            {
                if(totalValue + 10 <= 21)
                {
                    totalValue += 10;
                }
            }
            return totalValue;
        }
    }
}
