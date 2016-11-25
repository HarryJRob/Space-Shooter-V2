using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class Bullet
    {
        private Point bulletLocation;
        private int width;
        private int height;
        private static int bulletSpeed = 0;

        public Bullet(Point playerLocation, int Height, int Width)
        {
            width = Width;
            height = Height;
            bulletLocation = playerLocation;
        }

        public void DrawSelf(SpriteBatch spriteBatch, Texture2D bulletTexture) //May be more efficient to do this as a static method
        {
            bulletLocation.X += bulletSpeed;
            spriteBatch.Draw(bulletTexture, new Rectangle(bulletLocation.X, bulletLocation.Y - height/2, width, height), Color.White);
        }
    }
}
