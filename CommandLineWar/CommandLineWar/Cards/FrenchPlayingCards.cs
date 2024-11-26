

namespace CommandLineWar.Cards
{
    /// <summary>
    /// The version of cards that use French Suits.
    /// A standard 52 cards.
    /// </summary>
    public interface FrenchPlayingCards
    {
        /// <summary>
        /// The different card ranks per suit.
        /// </summary>
        public enum CardRank
        {
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        };

        /// <summary>
        /// Different suites allowed in the deck.
        /// </summary>
        public enum CardSuit { CLUBS, SPADES, HEARTS, DIAMONDS };

        /// <summary>
        /// Number of ranks per suits.
        /// </summary>
        public static int numberOfRanks = 13;

        /// <summary>
        /// Number of suits
        /// </summary>
        public static int numberOfSuits = 4;
    }
}
