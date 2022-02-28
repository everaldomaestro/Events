using Observer.Match;

namespace Observer.Events
{
    public class PlayCardEventArgs : EventArgs
    {
        public PlayCardEventArgs(Card card, Row row)
        {
            Card = card;
            Row = row;
        }

        public Card Card { get; set; }
        public Row Row { get; set; }
    }
}
