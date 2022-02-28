using Observer.Events;

namespace Observer.Match
{
    public class ScoreRow
    {
        public ScoreRow(Row row)
        {
            Stats = new Dictionary<string, int>
            {
                { "WEATHER", 0 },
                { "COMMANDERS_HORN_SPECIAL", 0 },
                { "COMMANDERS_HORN_UNIT", 0 },
                { "MORALE_BOOST", 0 }
            };

            Row = row;
        }

        public int Strength { get; set; }
        public Row Row { get; set; }
        public Dictionary<string, int> Stats { get; set; }

        public event EventHandler<CardStatsEventArgs> CardStats;

        public void OnUpdateScoreRow(object obj, PlayCardEventArgs handler)
        {
            var strength = this.Strength;
            var newStrength = Row.Cards.Sum(x => x.Score.Strength);

            if (strength != newStrength)
            {
                Strength = newStrength;
                Console.WriteLine($"Row {Row.TypeRow} strength update ({Strength})");
            }
        }

        public void OnRunAbilityUpdateStats(object e, RowStatsEventArgs handler)
        {
            if (Stats.ContainsKey(handler.Stats.FirstOrDefault().Key))
            {
                Stats[handler.Stats.FirstOrDefault().Key] += handler.Stats.FirstOrDefault().Value;

                CardStats?.Invoke(this, new CardStatsEventArgs(
                    new Dictionary<string, int> { { handler.Stats.FirstOrDefault().Key, Stats[handler.Stats.FirstOrDefault().Key] } }));
            }
            else if (handler.Stats.FirstOrDefault().Key.Contains("TIGHT_BOND"))
            {
                Stats[handler.Stats.FirstOrDefault().Key] = handler.Stats.FirstOrDefault().Value;

                CardStats?.Invoke(this, new CardStatsEventArgs(
                    new Dictionary<string, int> { { handler.Stats.FirstOrDefault().Key, handler.Stats.FirstOrDefault().Value } }));
            }

            if (handler.Stats.FirstOrDefault().Key.Contains("CLEAR_WEATHER"))
            {
                var weather = Row.Cards.FirstOrDefault(x => x.Ability == TypeAbility.WEATHER);
                if (weather != null)
                    Row.OnDiscardCard(this, new DiscardCardEventArgs(weather));

                CardStats?.Invoke(this, new CardStatsEventArgs(
                    new Dictionary<string, int> { { "WEATHER", -Stats["WEATHER"] } }));

                var clearWeather = Row.Cards.FirstOrDefault(x => x.Ability == TypeAbility.CLEAR_WEATHER);
                if (clearWeather != null)
                    Row.OnDiscardCard(this, new DiscardCardEventArgs(clearWeather));

                Stats["WEATHER"] = 0;
            }
        }
    }
}
