using static CommandLineWar.Cards.FrenchPlayingCards;

namespace CommandLineWar.Cards
{
    /// <summary>
    /// The standard card that is used in the game of War.
    /// </summary>
    public class StandardCard : FrenchPlayingCards
    {
        /// <summary>
        /// The backing rank.
        /// </summary>
        private CardRank rank;

        /// <summary>
        /// The backing suit.
        /// </summary>
        private CardSuit suit;

        /// <summary>
        /// Creates a new standard card.
        /// </summary>
        /// <param name="givenRank">The given rank to save to the card.</param>
        /// <param name="givenSuit">The given suit to save to the card.</param>
        public StandardCard(CardRank givenRank, CardSuit givenSuit)
        {
            rank = givenRank;
            suit = givenSuit;
        }

        /// <summary>
        /// Gets the current rank of the selected card.
        /// </summary>
        public CardRank getRank()
        {
            return rank;
        }

        /// <summary>
        /// Gets the current suit of the selected card.
        /// </summary>
        public CardSuit getSuit()
        {
            return suit;
        }
    }
}
