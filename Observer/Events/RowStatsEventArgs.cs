using Observer.Match;

namespace Observer.Events
{
    public class RowStatsEventArgs : EventArgs
    {
        public RowStatsEventArgs(string key, int value, Row row)
        {
            Stats = new Dictionary<string, int>
            {
                { key, value },
            };

            Row = row;
        }

        public Dictionary<string, int> Stats { get; set; }
        public Row Row { get; set; }
    }
}
