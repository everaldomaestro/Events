namespace Observer.Managers
{
    public class Manager
    {
        public Manager()
        {
            AbilityManager = new AbilityManager();
            ScoreManager = new ScoreManager();
        }

        public AbilityManager AbilityManager { get; set; }
        public ScoreManager ScoreManager { get; set; }
    }
}
