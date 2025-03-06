namespace BlackJack_TanyanMars.Models
{
    /// <summary>
    /// Is the card being compared and added to the other values
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets the suit of the card
        /// </summary>
        public Suit Suit { get; set; }

        /// <summary>
        /// Gets the rank of the card from the enum
        /// </summary>
        public Rank Rank { get; set; }
        
        /// <summary>
        /// Determines if the card is faceup
        /// </summary>
        public bool IsFaceUp { get; set; }

        /// <summary>
        /// Gives the face down iamge url so it doesn't have to assign it each time
        /// </summary>
        public string ImageUrl = "https://images.squarespace-cdn.com/content/v1/56ba85d9cf80a17a6f304b72/17021f49-d2e2-449f-a7c4-5d0ce8e08b7b/Card-Back.jpg?format=500w";

        /// <summary>
        /// Makes the card have to have a rank and a suit to exist
        /// </summary>
        /// <param name="suit">The suit of the card</param>
        /// <param name="rank">The rank of the card</param>
        /// <param name="isFaceUp">If the card is face up</param>
        public Card(Suit suit, Rank rank, bool isFaceUp = false)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.IsFaceUp = isFaceUp;
            //this.Url = url;
        }

        /// <summary>
        /// Overrides string to show what card is dealt
        /// </summary>
        /// <returns>A string of the card shown</returns>
        public override string ToString()
        {
            return IsFaceUp ? $"{Rank} of {Suit}" : "Face-down Card";
        }
    }
}
