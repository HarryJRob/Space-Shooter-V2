using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
