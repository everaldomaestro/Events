#nullable disable
using Observer.Match;

namespace Observer.Events
{
    public class ScoreEventArgs : EventArgs
    {
        public ScoreEventArgs(Card card)
        {
            Card = card;
        }

        public Card Card { get; set; }
    }
}
