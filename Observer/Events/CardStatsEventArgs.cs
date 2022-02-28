namespace Observer.Events
{
    public class CardStatsEventArgs : EventArgs
    {
        public CardStatsEventArgs(Dictionary<string, int> stats, bool firstPlay = false)
        {
            Stats = stats;
            FirstPlay = firstPlay;
        }

        public Dictionary<string, int> Stats { get; set; }
        public bool FirstPlay { get; set; }
    }
}
