#nullable disable
using Observer.Events;

namespace Observer.Match
{
    public class ScoreCard
    {
        public ScoreCard(int originalStrength, Card card)
        {
            OriginalStrength = originalStrength;
            Strength = originalStrength;
            Card = card;    
            Stats = new Dictionary<string, int>
            {
                { "WEATHER", 0 },
                { "COMMANDERS_HORN_SPECIAL", 0 },
                { "COMMANDERS_HORN_UNIT", 0 },
                { "MORALE_BOOST", 0 },
                { "TIGHT_BOND", 0 }
            };
        }

        public int OriginalStrength { get; set; }
        public int Strength { get; set; }
        public Card Card { get; set; }
        public Dictionary<string, int> Stats { get; set; }

        public event EventHandler<ScoreEventArgs> UpdateScore;

        public void OnUpdateStatsCard(object obj, CardStatsEventArgs handler)
        {
            var strength = this.Strength;

            foreach (var stat in handler.Stats)
            {
                if (Stats.ContainsKey(stat.Key))
                {
                    if ((Card.Ability == TypeAbility.COMMANDERS_HORN_UNIT && stat.Key.Contains("COMMANDERS_HORN_UNIT")) ||
                        (Card.Ability == TypeAbility.MORALE_BOOST && stat.Key.Contains("MORALE_BOOST")))
                    {
                        var value = !handler.FirstPlay ? stat.Value - 1 : stat.Value;
                        Stats[stat.Key] += value;
                    }
                    else
                    {
                        Stats[stat.Key] += stat.Value;
                    }

                }
                else if (stat.Key.Contains("TIGHT_BOND") && Card.Ability == TypeAbility.TIGHT_BOND && stat.Key.Equals($"{TypeAbility.TIGHT_BOND}-{Card.Name.ToUpper()}"))
                {
                    Stats["TIGHT_BOND"] = stat.Value;
                }
            }

            var newStrength = OriginalStrength;

            if (Stats["WEATHER"] > 0)
                newStrength = 1;

            if (Stats["MORALE_BOOST"] > 0)
                newStrength++;

            if (Stats["TIGHT_BOND"] > 0)
                newStrength *= Stats["TIGHT_BOND"];

            if (Stats["COMMANDERS_HORN_UNIT"] > 0)
            {
                var count = Stats["COMMANDERS_HORN_UNIT"] + 1;
                newStrength *= count;
            }

            if (Stats["COMMANDERS_HORN_SPECIAL"] > 0)
            {
                var count = Stats["COMMANDERS_HORN_UNIT"] + 1;
                newStrength *= count;
            }

            if (strength != newStrength)
            {
                Strength = newStrength;
                Console.WriteLine($"Card {this.Card.Name} ({this.Strength}) strength update");

                UpdateScore?.Invoke(obj, new ScoreEventArgs(Card));
            }
        }
    }
}
