using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class EnemyShip : Ship
    {
        private const int chargeTime = 20;
        private int CurCharge = 0;

        //Needs to be put into parent

        public EnemyShip(Texture2D EnemyTex, Texture2D BulletTex, int WindowYSize, int WindowXSize)
        {

            shipTexture = EnemyTex;
            bulletTexture = BulletTex;
            shipLocation = new Vector2(200f,200f);
            GameWindowY = WindowYSize;
            GameWindowX = WindowXSize;

            Height = GameWindowY / shipScale;

            Width = Height * (shipTexture.Bounds.Width / shipTexture.Bounds.Height);
        }

        public void Update()
        {
            if ((CurCharge >= chargeTime) && BulletList.Count < 4)
            {
                BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width, shipLocation.Y + Height / 2), GameWindowY / BulletScale, (GameWindowY / BulletScale) * (bulletTexture.Bounds.Height / bulletTexture.Bounds.Width), 0, 0));
                CurCharge = 0;
            }
            else if (BulletList.Count >= 4)
            {
                FireBullet();
            }
            CurCharge++;

            if (BulletList.Count != 0)
            {
                for (int i = BulletList.Count - 1; i >= 0; i--)
                {
                    if (BulletList[i].BulletLocation.X > GameWindowX)
                    {
                        BulletList.RemoveAt(i);
                    }
                    else
                    {
                        BulletList[i].Update();
                    }
                }
            }
        }

        public override void FireBullet()
        {
            foreach (Bullet CurBullet in BulletList)
            {
                CurBullet.BulletSpeedX = 20;
            }
        }
    }
}
