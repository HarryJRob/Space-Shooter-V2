using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class ShipManager
    {

        private Texture2D PlayerTex;
        private Texture2D enemyTex;
        private Texture2D bulletTex;

        private string LevelString;
        //Ships

        public ShipManager(Texture2D playerShipTex, Texture2D enemyShipTex, Texture2D bulletTexSheet)
        {
            PlayerTex = playerShipTex;
            enemyTex = enemyShipTex;
            bulletTex = bulletTexSheet;
        }

        public void Update()
        {
           //if randomiser do randomise else do level
        }

        private void DoRandomise()
        {
            
        }

        private void DoLevel()
        {
            
        }

        public void DrawShips(SpriteBatch spriteBatch)
        {
            
        }
    }
}
