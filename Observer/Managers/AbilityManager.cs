#nullable disable
using Observer.Events;
using Observer.Match;

namespace Observer.Managers
{
    public class AbilityManager
    {
        public event EventHandler<RowStatsEventArgs> RunAbility;

        public void OnRunAbility(object e, PlayCardEventArgs handler)
        {
            RunAbility += handler.Row.Score.OnRunAbilityUpdateStats;

            switch (handler.Card.Ability.GetValueOrDefault())
            {
                case TypeAbility.CLEAR_WEATHER:
                    RunAbility?.Invoke(e, new RowStatsEventArgs(handler.Card.Ability.ToString(), 1, handler.Row));
                    break;
                case TypeAbility.WEATHER:
                    RunAbility?.Invoke(e, new RowStatsEventArgs(handler.Card.Ability.ToString(), 1, handler.Row));
                    break;
                case TypeAbility.COMMANDERS_HORN_SPECIAL:
                    RunAbility?.Invoke(e, new RowStatsEventArgs(handler.Card.Ability.ToString(), 1, handler.Row));
                    break;
                case TypeAbility.COMMANDERS_HORN_UNIT:
                    RunAbility?.Invoke(e, new RowStatsEventArgs(handler.Card.Ability.ToString(), 1, handler.Row));
                    break;
                case TypeAbility.MORALE_BOOST:
                    RunAbility?.Invoke(e, new RowStatsEventArgs(handler.Card.Ability.ToString(), 1, handler.Row));
                    break;
                case TypeAbility.TIGHT_BOND:
                    RunAbility?.Invoke(e, new RowStatsEventArgs($"{handler.Card.Ability}-{handler.Card.Name.ToUpper()}", 1, handler.Row));
                    break;
                case TypeAbility.MEDIC:
                    RunAbility?.Invoke(e, new RowStatsEventArgs(handler.Card.Ability.ToString(), 1, handler.Row));
                    break;
                default:
                    break;
            }

            RunAbility -= handler.Row.Score.OnRunAbilityUpdateStats;
            
            Console.WriteLine($"Ability {handler.Card.Ability} of Card {handler.Card.Name} ({handler.Card.Score.Strength}) executed");
        }
    }
}
