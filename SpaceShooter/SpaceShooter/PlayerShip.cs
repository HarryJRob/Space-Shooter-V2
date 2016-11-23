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
        const int MaxVelocity = 10;
        const int MaxBoostVelocity = 20;
        const int Acceleration = 2;
        

        public PlayerShip()
        {
            //Set all values up.
            Width = 200;
            Height = 100;
            
        }

        public override void Update(KeyboardState CurKeyState)
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
            bulletCoolDown++;
            //System.Diagnostics.Debug.WriteLine("ShipVelocity: {0}", velocity);
        }

        public override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y, Width, Height), Color.White);

            //Ignore only for testing
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y, 2, 2), Color.Black);
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y + Height, 2, 2), Color.Black);
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X + Width, shipLocation.Y + Height, 2, 2), Color.Black);
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X + Width, shipLocation.Y, 2, 2), Color.Black);
        }

        public override void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet curBullet in BulletList)
            {
                curBullet.DrawSelf(spriteBatch, BulletTexture); //Animation will be done here as well!
                //System.Diagnostics.Debug.WriteLine("Bullet Drawn. BulletNo: {0}", BulletList.Count);
            }
        }

        public override void FireBullet()
        {
            //System.Diagnostics.Debug.WriteLine("Bullet Fired");
            BulletList.Add(new Bullet(new Point(shipLocation.X + Width, shipLocation.Y + Height/2)));
        }

        //Temporary texture loading for testing
        public Texture2D ShipTexture
        {
            get { return shipTexture; }
            set { shipTexture = value; }
        }

        public Texture2D BulletTexture
        {
            get { return bulletTexture; }
            set { bulletTexture = value; }

        }
    }
}
