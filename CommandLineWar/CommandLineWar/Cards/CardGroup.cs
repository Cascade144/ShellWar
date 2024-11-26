namespace CommandLineWar.Cards
{
    public class CardGroup
    {
        public StandardCard drawCard(List<StandardCard> givenGroup)
        {
            StandardCard drawnCard = givenGroup[0];
            givenGroup.RemoveAt(0);
            return drawnCard;
        }
    }
}
