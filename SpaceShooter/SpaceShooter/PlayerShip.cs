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
        const int MaxBoostVelocity = 15;
        const int Acceleration = 2;

        public PlayerShip()
        {
            //Set all values up.
            
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
                shipLocation.Y -= velocity;
            }
            if (CurKeyState.IsKeyDown(Keys.D))
            {
                shipLocation.X += velocity;
            }
            if (CurKeyState.IsKeyDown(Keys.A))
            {
                shipLocation.X -= velocity;
            }
        }

        public override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, new Rectangle(shipLocation.X, shipLocation.Y, Width, Height), Color.Transparent);
        }

        public override void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet curBullet in BulletList)
            {
                curBullet.DrawSelf(spriteBatch);
            }
        }

        public override void FireBullet()
        {
            BulletList.Add(new Bullet(new Point(shipLocation.X + Width, shipLocation.Y - Height/2)));
        }
    }
}
