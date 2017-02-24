namespace SpaceShooter
{
    public static class Globals
    {
        public enum GameState
        {
            MainMenu,
            OptionsMenu,
            LevelSelect,
            PlayingSP, //Playing Single Player
            PlayingMP  //Playing Multi Player
        }

       public static GameState GameStateManager;

       public static int GameWindowY, GameWindowX;
    }
}
