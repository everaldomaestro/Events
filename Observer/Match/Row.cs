#nullable disable
using Observer.Events;

namespace Observer.Match
{
    public class Row
    {
        public Row(TypeRow typeRow)
        {
            TypeRow = typeRow;
            Cards = new List<Card>();
            Score = new ScoreRow(this);
        }

        public ScoreRow Score { get; set; }
        public TypeRow TypeRow { get; set; }
        public IList<Card> Cards { get; set; }

        public event EventHandler<CardStatsEventArgs> CardStatsFirstPlay;        

        public void OnPlayCard(object obj, PlayCardEventArgs handler)
        {
            var player = obj as Player;
            var card = handler.Card;

            Cards.Add(handler.Card);

            if (!card.Hero && card.Ability != TypeAbility.WEATHER && card.Ability != TypeAbility.CLEAR_WEATHER)
            {
                CardStatsFirstPlay += card.Score.OnUpdateStatsCard;
                CardStatsFirstPlay?.Invoke(this, new CardStatsEventArgs(Score.Stats, true));
                CardStatsFirstPlay -= card.Score.OnUpdateStatsCard;

                Score.CardStats += card.Score.OnUpdateStatsCard;
                card.Score.UpdateScore += player.Manager.ScoreManager.OnUpdateScoreCard;
            }

            Console.WriteLine($"Player {player.PlayerNumber}: Card {handler.Card.Name} ({handler.Card.Score.Strength}) played on the row {TypeRow}");
        }

        public void OnDiscardCard(object obj, DiscardCardEventArgs handler)
        {
            var card = handler.Card;
            Cards.Remove(card);

            if (!card.Hero && card.Ability != TypeAbility.WEATHER && card.Ability != TypeAbility.CLEAR_WEATHER)
                Score.CardStats -= card.Score.OnUpdateStatsCard;

            if (obj is Player player)
                Console.Write($"Player {player.PlayerNumber}: ");

            Console.WriteLine($"Card {handler.Card.Name} ({handler.Card.Score.Strength}) discarded of the row {TypeRow}");
        }        
    }
}
