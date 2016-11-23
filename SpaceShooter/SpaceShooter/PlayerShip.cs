using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class PlayerShip : Ship
    {
        
        public PlayerShip()
        {

        }

        public override void DrawSelf(SpriteBatch spriteBatch)
        {
            
        }

        public override void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet curBullet in BulletList)
            {
                curBullet.DrawSelf(spriteBatch);
            }
        }
    }
}
