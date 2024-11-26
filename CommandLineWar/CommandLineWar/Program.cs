
using CommandLineWar.Cards;
using CommandLineWar.GameTypes;

public class Program {
    private static String line = "_______________________________";

    public static void main(String[] args)
    {
        Console.WriteLine("Hello, World!");
        createWarGame();
        printLines();
        createThreeWarGame();
        printLines();
        createGraveWarGame();
        printLines();
    }

    /* STANDARD WAR GAME */
    private static void createWarGame()
    {
        Deck standardDeck = new Deck();
        standardDeck = new Deck();
        standardDeck.generateDeck(52);
        standardDeck.shuffle();
        StandardWar warGame = new StandardWar(standardDeck, 20);
        warGame.startGame();
    }

    /* THREE PLAYER WAR GAME */
    private static void createThreeWarGame()
    {
        Deck standardDeck = new Deck();
        standardDeck = new Deck();
        standardDeck.generateDeck(52);
        standardDeck.shuffle();
        ThreePlayerWar graveWarGameThree = new ThreePlayerWar(standardDeck);
        graveWarGameThree.startGame();
    }

    /* GRAVEYARD WAR GAME */
    private static void createGraveWarGame()
    {
        Deck standardDeck = new Deck();
        standardDeck = new Deck();
        standardDeck.generateDeck(52);
        standardDeck.shuffle();
        GraveyardWar graveWarGame = new GraveyardWar(standardDeck);
        graveWarGame.startGame();
    }

    private static void printLines()
    {
        Console.WriteLine(line);
        Console.WriteLine();
    }
}