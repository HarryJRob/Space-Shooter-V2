using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{

    class Bullet
    {
        private Vector2 bulletLocation;
        private int width;
        private int height;
        private int _bulletSpeedX;
        private int _bulletSpeedY;

        public Bullet(Vector2 shipLocation, int Height, int Width, int bulletSpeedX, int bulletSpeedY)
        {
            _bulletSpeedX = bulletSpeedX;
            _bulletSpeedY = bulletSpeedY;
            width = Width;
            height = Height;
            bulletLocation = shipLocation;
        }

        public void Update()
        {
            bulletLocation.X += _bulletSpeedX;
            bulletLocation.Y += _bulletSpeedY;
        }

        public void DrawSelf(SpriteBatch spriteBatch, Texture2D bulletTexture)
        {
            spriteBatch.Draw(bulletTexture, new Rectangle((int)bulletLocation.X, (int)bulletLocation.Y - height / 2, width, height), new Rectangle(10, 186, 10, 10), Color.White);
        }

        public Vector2 BulletLocation
        {
            get { return bulletLocation; }
        }

        public int BulletSpeedX
        {
            set { _bulletSpeedX = value; }
        }

        public int BulletSpeedY
        {
            set { _bulletSpeedY = value; }
        }
    }
}
