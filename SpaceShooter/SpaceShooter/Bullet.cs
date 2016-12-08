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

        public Bullet(Vector2 playerLocation, int Height, int Width)
        {
            width = Width;
            height = Height;
            bulletLocation = playerLocation;
        }

        public void Update()
        {
            bulletLocation.X += bulletSpeed;
        }

        public void DrawSelf(SpriteBatch spriteBatch, Texture2D bulletTexture)
        {
            spriteBatch.Draw(bulletTexture, new Rectangle((int)BulletLocation.X, (int)BulletLocation.Y - height/2, width, height), new Rectangle(10, 186, 10, 10), Color.White);
        }

        public Vector2 BulletLocation
        {
            get { return bulletLocation; }
        }

        public int BulletSpeed
        {
            get { return bulletSpeed; }
        }
    }
}
