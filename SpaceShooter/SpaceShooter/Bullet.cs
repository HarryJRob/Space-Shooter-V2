using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class Bullet
    {
        private Vector2 bulletLocation;
        private int width;
        private int height;
        private static int bulletSpeed = 35;
        private int currentFrame = 0;
        private Rectangle sourceRec;
        private static int bulletScale = 3;

        public Bullet(Vector2 playerLocation, int Height, int Width)
        {
            width = Width;
            height = Height;
            bulletLocation = playerLocation;
        }

        public void Update()
        {
            bulletLocation.X += bulletSpeed;

            ////Animation currently hardcoded
            if (currentFrame < 5)
            {
                sourceRec = new Rectangle(10, 186, 10, 10);
                currentFrame += 1;
            }

            //else if (currentFrame < 15)
            //{
            //    sourceRec = new Rectangle(20, 186, 18, 10);
            //    currentFrame += 1;
            //}
            //else if (currentFrame < 25)
            //{
            //    sourceRec = new Rectangle(40, 186, 20, 10);
            //    currentFrame += 1;
            //}
        }

        public void DrawSelf(SpriteBatch spriteBatch, Texture2D bulletTexture) //May be more efficient to do this as a static method
        {
            spriteBatch.Draw(bulletTexture, new Rectangle((int)bulletLocation.X, (int)bulletLocation.Y - (sourceRec.Height * bulletScale)/2, sourceRec.Width*bulletScale, sourceRec.Height*bulletScale),sourceRec, Color.White);
        }

        public Vector2 BulletLocation
        {
            get { return bulletLocation; }
        }
    }
}
