using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class Ship
    {
        protected Texture2D shipTexture;
        protected Point shipLocation;
        protected int Height;
        protected int Width;
        protected int Health;
        protected int Score; //Used by both childs. In PlayerShip use to keep score. In EnemyShip use to determine what you gain by killing them.
        protected List<Bullet> BulletList = new List<Bullet> { };

        public virtual void DrawSelf(SpriteBatch spriteBatch)
        {

        }

        public virtual void DrawBullets(SpriteBatch spriteBatch)
        {

        }

        public virtual void Update()
        {

        }
    }
}
