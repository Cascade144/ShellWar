using CommandLineWar.Cards;
using CommandLineWar.GamePieces;
using CommandLineWar.Utils;

namespace CommandLineWar.GameTypes
{
    public class WarGame
    {
        protected Deck warDeck;
        protected List<Player> playerList = new List<Player>();
        protected List<StandardCard> table = new List<StandardCard>();
        protected StandardCard currentCard;
        protected Boolean gameRunning = true;
        protected Player winningPlayer;

        public WarGame()
        {
            //generate two players
            playerList.Add(new Player("Bob", 1));
            playerList.Add(new Player("Sue", 2));
        }

        protected void InitializeGame()
        {
            int cardsPerPlayer = warDeck.getCardDeck().size() / playerList.Count;
            ConsoleWriter.WriteLine($"Giving {cardsPerPlayer} card(s) per player.\n");
            foreach (Player player in playerList)
            {
                player.giveHand(warDeck.drawNumberOfCards(cardsPerPlayer));
            }
        }

        protected int playUpCards(int state)
        {
            int endState = state;
            List<StandardCard> playedCards = new List<StandardCard>();
            if (emptyHands())
            {
                GameOver();
                return endState;
            }
            foreach (Player currentPlayer in playerList)
            {
                currentCard = currentPlayer.playCard();
                ConsoleWriter.WriteLine($"{currentPlayer.getName()} plays {currentCard} as up card.");
                playedCards.Insert(currentPlayer.getNumber() - 1, currentCard);
                table.Add(currentCard);
            }
            endState = compareCards(playedCards);
            if (endState == 0)
            {
                playDownCards();
                playUpCards(endState);
            }
            else
            {
                return endState;
            }
            return endState;
        }

        /// <summary>
        /// Checks if any one of all players has an empty hand.
        /// </summary>
        /// <returns>Whether or not a player has an empty hand.</returns>
        private bool emptyHands()
        {
            foreach (Player currentPlayer in playerList)
            {
                if (currentPlayer.getHand().isEmpty())
                {
                    return true;
                }
            }

            return false;
        }

        private void playDownCards()
        {
            foreach (Player currentPlayer in playerList)
            {
                currentCard = currentPlayer.playCard();
                //System.out.println(currentPlayer.getName() + " plays " + currentCard.toString() + " as down card.");
                table.Add(currentCard);
            }
        }

        protected int compareCards(List<StandardCard> playedCards)
        {
            List<int> ordinance = new List<int>();
            int max = 0;
            int playerNumber;
            foreach (StandardCard playedCard in playedCards)
            {
                ordinance.Add(((int)playedCard.getRank()));
            }
            //first check if there are duplicates, if so tie
            max = ordinance.Max();
            playerNumber = ordinance.IndexOf(max) + 1;
            if (findDuplicates(ordinance, max))
            {
                ConsoleWriter.WriteLine("War!");
                return 0;
            }
            else
            {
                //if not find max, one player wins
                playerList[playerNumber - 1].addToScore(tallyScore());
                clearTable(playerList[playerNumber - 1].getHand());
                playedCards.Clear();
                return playerNumber;
            }
        }

        protected bool findDuplicates(List<int> ordinance, int max)
        {
            int frequency = 0;
            frequency = ordinance
            if (frequency > 1)
            {
                return true;
            }
            return false;
        }

        protected int tallyScore()
        {
            int totalScore = 0;
            foreach (StandardCard tableCard in table)
            {
                totalScore++;
            }

            return totalScore;
        }

        protected void clearTable(Hand winningHand)
        {
            foreach (StandardCard tableCard in table)
            {
                winningHand.placeAtBottomDeck(tableCard);
            }

            table.Clear();
        }

        protected void printScores()
        {
            ConsoleWriter.WriteLine("Score is ");
            foreach (Player currentPlayer in playerList)
            {
                ConsoleWriter.WriteLine(currentPlayer.getName() + " " + currentPlayer.getScore());
                ConsoleWriter.WriteLine(", ");
            }

            ConsoleWriter.WriteLine("");
        }

        public void GameOver()
        {
            int playerNumber = 0;
            List<int> playerScores = new List<int>();
            foreach (Player player in playerList)
            {
                playerScores.Add(player.getScore());
            }

            playerNumber = playerScores.IndexOf(playerScores.Max()) + 1;
            winningPlayer = playerList.ElementAt(playerNumber - 1);
            if (findDuplicates(playerScores, winningPlayer.getScore()))
            {
                winningPlayer = new Player("Tie", 0);
                ConsoleWriter.WriteLine("Tie!");
            }
            else
            {
                ConsoleWriter.WriteLine(winningPlayer.getName() + " wins!");
            }

            ConsoleWriter.WriteLine("The game is over.");
            gameRunning = false;
        }
    }
}
