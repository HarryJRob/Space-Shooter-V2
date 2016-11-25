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
        private const int bulletSpeed = 50;

        public Bullet(Point playerLocation)
        {
            width = 50;
            height = 25;
            bulletLocation = playerLocation;
        }

        public void DrawSelf(SpriteBatch spriteBatch, Texture2D bulletTexture)
        {
            bulletLocation.X += bulletSpeed;
            spriteBatch.Draw(bulletTexture, new Rectangle(bulletLocation.X, bulletLocation.Y - height/2, width, height), Color.White);
        }
    }
}
