using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class Bullet
    {
        private Texture2D bulletTexture;
        private Point bulletLocation;
        private int width;
        private int height;

        public void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTexture, new Rectangle(bulletLocation.X, bulletLocation.Y, width, height), Color.Transparent);
        }
    }
}
