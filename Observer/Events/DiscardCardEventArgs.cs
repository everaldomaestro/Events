using Observer.Match;

namespace Observer.Events
{
    public class DiscardCardEventArgs : EventArgs
    {
        public DiscardCardEventArgs(Card card)
        {
            Card = card;
        }

        public Card Card { get; set; }
    }
}
