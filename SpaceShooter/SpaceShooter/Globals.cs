namespace SpaceShooter
{
    public static class Globals
    {
        public enum GameState
        {
            MainMenu,
            OptionsMenu,
            LevelSelect,
            Playing
        }

       public static GameState GameStateManager;
    }
}
