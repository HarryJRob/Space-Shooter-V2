using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class MainGame
    {
        private Texture2D Background;
        private Texture2D bulletTexSheet;
        private Texture2D shipTex;

        private GameWindow Window;

        private List<Ship> ShipList = new List<Ship>();

        public void Initialise(bool MultiplePlayer, GameWindow window)
        {
            Window = window;

            if (MultiplePlayer)
            {
                ShipList.Add(new PlayerShip(1, shipTex, bulletTexSheet));
                ShipList.Add(new PlayerShip(2, shipTex, bulletTexSheet));
            }
            else
            {
                ShipList.Add(new PlayerShip(3, shipTex, bulletTexSheet));
            }
            ShipList.Add(new ChargerShip(shipTex,bulletTexSheet));
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            //Content.Load<Texture2D>("Name")
            Background = Content.Load<Texture2D>("GameResources/BackGrounds/Background");
            shipTex = Content.Load<Texture2D>("GameResources/Ships/ship");
            bulletTexSheet = Content.Load<Texture2D>("GameResources/Bullets/BulletSheet");
        }

        public void Update(KeyboardState curKeyState)
        {
            foreach (Ship CurShip in ShipList)
            {
                if (CurShip.GetType() == typeof(PlayerShip))
                {
                    CurShip.Update(curKeyState);
                }
                else if(CurShip.GetType() == typeof(ChargerShip))
                {
                    if (ShipList[1].GetType() == typeof(PlayerShip))
                    {
                        Random rnd = new Random();
                        int i = rnd.Next(0, 2);
                        CurShip.Update(ShipList[i].shipPosition);
                    }
                    else
                    {
                        CurShip.Update(ShipList[0].shipPosition);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Players + Respective Bullets
            spriteBatch.Draw(Background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            foreach (Ship CurShip in ShipList)
            {
                CurShip.Draw(spriteBatch);
            }
        }

    }
}
