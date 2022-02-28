#nullable disable
using Observer.Events;
using Observer.Managers;

namespace Observer.Match
{
    public class Player
    {
        public Player(PlayerNumber player)
        {
            Manager = new Manager();
            PlayerNumber = player;

            Rows = new List<Row>
            {
                new Row(TypeRow.CLOSE),
                new Row(TypeRow.RANGED),
                new Row(TypeRow.SIEGE)
            };

            Hand = new List<Card>();
            Discard = new List<Card>();
            Deck = new List<Card>();
        }

        public Manager Manager { get; set; }
        public PlayerNumber PlayerNumber { get; set; }
        public IList<Row> Rows { get; set; }
        public IList<Card> Hand { get; set; }
        public IList<Card> Discard { get; set; }
        public IList<Card> Deck { get; set; }

        public event EventHandler<PlayCardEventArgs> PlayCardOnTheBattle;

        public void PlayCardOnTheRow(Card card, TypeRow? typeRow = null)
        {
            if (card.Name.Equals("clearWeather"))
            {
                foreach (var row in Rows)
                {
                    PlayCardOnTheBattle += row.OnPlayCard;

                    if (card.Ability.HasValue)
                        PlayCardOnTheBattle += Manager.AbilityManager.OnRunAbility;

                    PlayCardOnTheBattle += row.Score.OnUpdateScoreRow;

                    PlayCardOnTheBattle?.Invoke(this, new PlayCardEventArgs(card, row));

                    if (card.Ability.HasValue)
                        PlayCardOnTheBattle -= Manager.AbilityManager.OnRunAbility;

                    PlayCardOnTheBattle -= row.OnPlayCard;
                    PlayCardOnTheBattle -= row.Score.OnUpdateScoreRow;
                }
            }
            else
            {
                var row =
                    typeRow.HasValue ?
                    this.Rows.FirstOrDefault(x => x.TypeRow == typeRow.GetValueOrDefault()) :
                    this.Rows.FirstOrDefault(x => x.TypeRow == card.Row.GetValueOrDefault());

                PlayCardOnTheBattle += row.OnPlayCard;

                if (card.Ability.HasValue)
                    PlayCardOnTheBattle += Manager.AbilityManager.OnRunAbility;

                PlayCardOnTheBattle += row.Score.OnUpdateScoreRow;

                PlayCardOnTheBattle?.Invoke(this, new PlayCardEventArgs(card, row));

                if (card.Ability.HasValue)
                    PlayCardOnTheBattle -= Manager.AbilityManager.OnRunAbility;

                PlayCardOnTheBattle -= row.OnPlayCard;
                PlayCardOnTheBattle -= row.Score.OnUpdateScoreRow;
            }
        }
    }
}
