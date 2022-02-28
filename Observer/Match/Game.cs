using Observer.Managers;

namespace Observer.Match
{
    public class Game
    {
        public Game()
        {
            PlayerOne = new Player(PlayerNumber.ONE);
            PlayerTwo = new Player(PlayerNumber.TWO);
        }

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
    }
}
