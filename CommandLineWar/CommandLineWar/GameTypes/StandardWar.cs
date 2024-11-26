using CommandLineWar.Cards;

namespace CommandLineWar.GameTypes
{
    public class StandardWar : WarGame
    {
        private int numberOfTurns;

        public StandardWar(Deck standardDeck, int numberOfTurns)
        {
            this.numberOfTurns = numberOfTurns;
            warDeck = standardDeck;
            InitializeGame();
        }

        /// <summary>
        /// Starts the standard game of war.
        /// </summary>
        /// <returns>The winning player.</returns>
        public String startGame()
        {
            gameLoop();
            return winningPlayer.getName();
        }

        private void gameLoop()
        {
            int currentTurn = 1;
            while (gameRunning)
            {
                if (numberOfTurns == currentTurn)
                {
                    GameOver();
                    break;
                }

                WriteLine("Round %d of Standard War\n", currentTurn);
                playUpCards(1);
                printScores();
                currentTurn++;
            }
        }
    }
}
