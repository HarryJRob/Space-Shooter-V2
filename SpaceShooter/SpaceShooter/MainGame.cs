using System.Runtime.Remoting.Channels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class MainGame
    {
        private PlayerShip Player1;
        private PlayerShip Player2;

        private EnemyShip EnemyShip1;

        private Texture2D Background;
        private Texture2D bulletTexSheet;
        private Texture2D shipTex;

        private GameWindow Window;

        private ShipManager shipManager;

        public void Initialise(bool MultiplePlayer, GameWindow window)
        {
            Window = window;

            if (MultiplePlayer)
            {
                Player1 = new PlayerShip(1, shipTex, bulletTexSheet, Window.ClientBounds.Height, Window.ClientBounds.Width);
                Player2 = new PlayerShip(2, shipTex, bulletTexSheet, Window.ClientBounds.Height, Window.ClientBounds.Width);
            }
            else
            {
                Player1 = new PlayerShip(3, shipTex, bulletTexSheet, Window.ClientBounds.Height, Window.ClientBounds.Width);
                Player2 = null;
            }
            EnemyShip1 = new EnemyShip(shipTex,bulletTexSheet , Window.ClientBounds.Height, Window.ClientBounds.Width);
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            //Content.Load<Texture2D>("Name")
            Background = Content.Load<Texture2D>("GameResources/BackGrounds/Background");
            shipTex = Content.Load<Texture2D>("GameResources/Ships/ship");
            bulletTexSheet = Content.Load<Texture2D>("GameResources/Bullets/BulletSheet");
        }

        public void Update(KeyboardState CurKeyState)
        {
            Player1.Update(CurKeyState);
            if (Player2 != null)
            {
                Player2.Update(CurKeyState);
            }
            EnemyShip1.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Players + Respective Bullets
            spriteBatch.Draw(Background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            Player1.Draw(spriteBatch);
            if (Player2 != null)
            {
                Player2.Draw(spriteBatch);
            }
            EnemyShip1.Draw(spriteBatch);
        }

    }
}
