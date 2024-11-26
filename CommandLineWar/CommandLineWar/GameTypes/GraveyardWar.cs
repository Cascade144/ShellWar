using CommandLineWar.Cards;
using CommandLineWar.GamePieces;
using CommandLineWar.Utils;

namespace CommandLineWar.GameTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class GraveyardWar : WarGame
    {
        /// <summary>
        /// 
        /// </summary>
        private List<Hand> graveyards = new List<Hand>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="standardDeck"></param>
        public GraveyardWar(Deck standardDeck)
        {
            warDeck = standardDeck;
            InitializeGame();
            generateGraveyards();
        }

        public String startGame()
        {
            gameLoop();
            return winningPlayer.getName();
        }

        private void generateGraveyards()
        {
            foreach (Player player in playerList)
            {
                List<StandardCard> empty = new List<StandardCard>();
                Hand emptyHand = new Hand(empty);
                graveyards.Add(emptyHand);
            }
        }

        private void gameLoop()
        {
            int currentTurn = 1;
            while (true)
            {
                ConsoleWriter.WriteLine($"Round {currentTurn} of Graveyard War");
                playUpCards(1);
                printScores();
                currentTurn++;
                if (gameRunning == false)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Compares the played cards.
        /// </summary>
        /// <param name="playedCards"></param>
        /// <returns></returns>
        protected int compareCards(List<StandardCard> playedCards)
        {
            List<int> ordinance = new List<int>();
            int max = 0;
            int playerNumber;
            foreach (StandardCard playedCard in playedCards)
            {
                ordinance.Add(playedCard.getRank());
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
                clearTable(playerNumber - 1);
                playedCards.Clear();
                return playerNumber;
            }
        }

        private void clearTable(int playerNumber)
        {
            foreach (StandardCard tableCard in table)
            {
                graveyards[playerNumber].placeAtBottomDeck(tableCard);
            }
            table.Clear();
        }
    }
}
