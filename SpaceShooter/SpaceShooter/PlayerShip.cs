using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class PlayerShip : Ship
    {
        int velocity = 10;
        byte PlayerID; //Set when initialised. 1 = Player1, 2 = Player2, 3 = SinglePlayer
        const int MaxVelocity = 10;
        const int MaxBoostVelocity = 14;
        const int Acceleration = 2;
        
        public PlayerShip(byte ID, Texture2D PlayerTex, Texture2D BulletTex ,int WindowYSize) //Pass the ID,ship Texture2D/Location of on texture sheet, Starting Location,bullet Texture2D/Location on texture sheet
        {
            //Set all values up.
            shipTexture = PlayerTex;
            bulletTexture = BulletTex;

            PlayerID = ID;

            bulletCoolDown = 40;
            Width = 200;
            Height = 100;

            if (PlayerID == 1)
            {
                shipLocation.Y = WindowYSize / 2 - Height * 2;
            }
            else if (PlayerID == 2)
            {
                shipLocation.Y = WindowYSize / 2 + Height * 2;
            }
            else if (PlayerID == 3)
            {
                shipLocation.Y = WindowYSize / 2 - Height / 2;
            }
            shipLocation.X += 40;
        }

        public override void Update(KeyboardState CurKeyState)
        {
            if (PlayerID == 1)
            {
                if (CurKeyState.IsKeyDown(Keys.LeftShift) && velocity < MaxBoostVelocity)
                {
                    velocity += Acceleration;
                }
                else if (velocity > MaxVelocity)
                {
                    velocity -= Acceleration;
                }
                if (CurKeyState.IsKeyDown(Keys.W))
                {
                    shipLocation.Y -= velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.S))
                {
                    shipLocation.Y += velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.D))
                {
                    shipLocation.X += velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.A))
                {
                    shipLocation.X -= velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.Space) && bulletCoolDown > 40)
                {
                    bulletCoolDown = 0;
                    FireBullet();
                }
            }
            else if (PlayerID == 2)
            {
                if ((CurKeyState.IsKeyDown(Keys.RightShift)) && velocity < MaxBoostVelocity)
                {
                    velocity += Acceleration;
                }
                else if (velocity > MaxVelocity)
                {
                    velocity -= Acceleration;
                }
                if (CurKeyState.IsKeyDown(Keys.Up))
                {
                    shipLocation.Y -= velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.Down))
                {
                    shipLocation.Y += velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.Right))
                {
                    shipLocation.X += velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.Left))
                {
                    shipLocation.X -= velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.Enter) && bulletCoolDown > 40)
                {
                    bulletCoolDown = 0;
                    FireBullet();
                }
            }
            else if (PlayerID == 3)
            {
                if ((CurKeyState.IsKeyDown(Keys.LeftShift) || CurKeyState.IsKeyDown(Keys.RightShift)) && velocity < MaxBoostVelocity)
                {
                    velocity += Acceleration;
                }
                else if (velocity > MaxVelocity)
                {
                    velocity -= Acceleration;
                }
                if (CurKeyState.IsKeyDown(Keys.W) || CurKeyState.IsKeyDown(Keys.Up))
                {
                    shipLocation.Y -= velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.S) || CurKeyState.IsKeyDown(Keys.Down))
                {
                    shipLocation.Y += velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.D) || CurKeyState.IsKeyDown(Keys.Right))
                {
                    shipLocation.X += velocity;
                }
                if (CurKeyState.IsKeyDown(Keys.A) || CurKeyState.IsKeyDown(Keys.Left))
                {
                    shipLocation.X -= velocity;
                }
                if ((CurKeyState.IsKeyDown(Keys.Space) || CurKeyState.IsKeyDown(Keys.Enter)) && bulletCoolDown > 40)
                {
                    bulletCoolDown = 0;
                    FireBullet();
                }
            }
            
            bulletCoolDown++;
            //System.Diagnostics.Debug.WriteLine("ShipVelocity: {0}", velocity);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y, Width, Height), Color.White);

            //Ignore only for testing
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y, 2, 2), Color.Black);
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y + Height, 2, 2), Color.Black);
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X + Width, shipLocation.Y + Height, 2, 2), Color.Black);
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X + Width, shipLocation.Y, 2, 2), Color.Black);
        }

        protected override void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet curBullet in BulletList)
            {
                curBullet.DrawSelf(spriteBatch, bulletTexture); //Animation will be done here as well!
                //System.Diagnostics.Debug.WriteLine("Bullet Drawn. BulletNo: {0}", BulletList.Count);
            }
        }

        public override void FireBullet()
        {
            //System.Diagnostics.Debug.WriteLine("Bullet Fired");
            BulletList.Add(new Bullet(new Point(shipLocation.X + Width, shipLocation.Y + Height/2)));
        }
    }
}
