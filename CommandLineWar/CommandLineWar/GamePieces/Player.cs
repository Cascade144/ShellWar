using CommandLineWar.Cards;

namespace CommandLineWar.GamePieces
{
    public class Player
    {
        private Hand hand;
        private String playerName;
        private int playerNumber;
        private int score = 0;

        public Player(String name, int number)
        {
            playerName = name;
            playerNumber = number;
        }

        public int numberOfCardsLeft()
        {
            return hand.numberOfCards();
        }

        public StandardCard playCard()
        {
            return hand.drawCard();
        }

        public Hand getHand()
        {
            return hand;
        }

        public void giveHand(List<StandardCard> cards)
        {
            this.hand = new Hand(cards);
        }

        public String getName()
        {
            return playerName;
        }

        public void setName(String playerName)
        {
            this.playerName = playerName;
        }

        public int getNumber()
        {
            return playerNumber;
        }

        public int getScore()
        {
            return score;
        }

        public void addToScore(int points)
        {
            score += points;
        }
    }
}
