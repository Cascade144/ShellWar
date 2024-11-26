using System.Collections.Generic;
using static CommandLineWar.Cards.FrenchPlayingCards;

namespace CommandLineWar.Cards
{
    public class Deck : CardGroup
    {
        private static List<StandardCard> cardDeck = null;

        public Deck()
        {
            cardDeck = new List<StandardCard>();
        }

        public void generateDeck(int deckSize)
        {
            int currentDeckSize = 0;
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    cardDeck.Add(new StandardCard(rank, suit));
                    currentDeckSize++;
                    if (currentDeckSize == deckSize)
                    {
                        return;
                    }
                }
            }
        }

        public List<StandardCard> drawNumberOfCards(int number)
        {
            int index;
            List<StandardCard> stackOfCards = new List<StandardCard>();
            //draw a number of cards
            for (index = 0; index < number; index++)
            {
                stackOfCards.Add(this.drawCard(cardDeck));
            }
            return stackOfCards;
        }

        public void shuffle()
        {
            Random random = new Random();
            int n = cardDeck.Count;

            for (int i = cardDeck.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                StandardCard value = cardDeck[rnd];
                cardDeck[rnd] = cardDeck[i];
                cardDeck[i] = value;
            }
        }


        public List<StandardCard> getCardDeck()
        {
            return cardDeck;
        }

        public void setCardDeck(List<StandardCard> cardDeck)
        {
            Deck.cardDeck = cardDeck;
        }

        public void addCard(StandardCard card)
        {
            Deck.cardDeck.Add(card);
        }
    }
}
