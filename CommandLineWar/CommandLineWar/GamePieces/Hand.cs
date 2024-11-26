using CommandLineWar.Cards;

namespace CommandLineWar.GamePieces
{
    public class Hand
    {
        private List<StandardCard> cardHand = new List<StandardCard>();

        public Hand(List<StandardCard> givenCards)
        {
            generateHand(givenCards);

        }

        private void generateHand(List<StandardCard> givenCards)
        {
            cardHand.AddRange(givenCards);
        }

        public int numberOfCards()
        {
            return cardHand.Count - 1;
        }

        public StandardCard drawCard()
        {
            StandardCard drawnCard = cardHand[cardHand.Count - 1];
            cardHand.RemoveAt(cardHand.Count - 1);
            return drawnCard;
        }

        public bool isEmpty()
        {
            return cardHand.Count == 0;
        }

        public void placeAtBottomDeck(StandardCard givenCard)
        {
            cardHand.Insert(0, givenCard);
        }
    }
}
