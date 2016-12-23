using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class Ship
    {
        protected Texture2D shipTexture;
        protected Vector2 shipLocation;
        protected Texture2D bulletTexture;

        protected int Height;
        protected int Width;
        protected int Health;
        protected byte CurBulletCoolDown;
        protected int CurrentScore; //Used by both childs. In PlayerShip use to keep score. In EnemyShip use to determine what you gain by killing them.

        protected int GameWindowY;
        protected int GameWindowX;

        protected static int BulletScale = 60;
        protected static int shipScale = 13;

        protected List<Bullet> BulletList = new List<Bullet> { } ;

        public void Draw(SpriteBatch spriteBatch) 
        {
            DrawSelf(spriteBatch);
            DrawBullets(spriteBatch);
        }

        protected virtual void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, new Rectangle((int)shipLocation.X, (int)shipLocation.Y, Width, Height), Color.White);
        }

        protected virtual void DrawBullets(SpriteBatch spriteBatch)
        {
            if (BulletList.Count != 0)
            {
                foreach (Bullet curBullet in BulletList)
                {
                    curBullet.DrawSelf(spriteBatch, bulletTexture);
                }
            }
        }

        public virtual void FireBullet() { }

        public int Score
        {
            get { return CurrentScore; }
            set { CurrentScore += value; }
        }
    }
}
