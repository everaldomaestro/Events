#nullable disable
using Observer.Events;

namespace Observer.Match
{
    public class Card
    {
        public Card(string name, int originalStrength, bool hero = false, TypeRow? row = null, TypeAbility? ability = null)
        {
            //OriginalStrength = originalStrength;
            //Strength = originalStrength;
            Name = name;
            Hero = hero;
            Row = row;
            Ability = ability;
            Score = new ScoreCard(originalStrength, this);

            //Stats = new Dictionary<string, int>
            //{
            //    { "WEATHER", 0 },
            //    { "COMMANDERS_HORN_SPECIAL", 0 },
            //    { "COMMANDERS_HORN_UNIT", 0 },
            //    { "MORALE_BOOST", 0 },
            //    { "TIGHT_BOND", 0 }
            //};
        }

        //public int OriginalStrength { get; set; }
        //public int Strength { get; set; }
        public ScoreCard Score { get; set; }
        public string Name { get; set; }
        public bool Hero { get; set; }
        public TypeRow? Row { get; set; }
        public TypeAbility? Ability { get; set; }
        //public Dictionary<string, int> Stats { get; set; }
        
        public override string ToString() => this.Name;
    }
}
