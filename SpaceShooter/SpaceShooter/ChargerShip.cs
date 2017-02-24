using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class ChargerShip : Ship
    {
        private const int chargeTime = 20;
        private const int FiredBulletVelocity = 20;
        private int CurCharge;
        private int BulYVel;
        private int BulXVel;
        private bool _fired;

        public ChargerShip(Texture2D EnemyTex, Texture2D BulletTex)
        {

            shipTexture = EnemyTex;
            bulletTexture = BulletTex;
            shipLocation = new Vector2(Globals.GameWindowX/2,Globals.GameWindowY/2);
            Height = Globals.GameWindowY / shipScale;
            Width = Height * (shipTexture.Bounds.Width / shipTexture.Bounds.Height);

            BulXVel = 1;
            BulYVel = 1;
        }

        public override void Update(Vector2 playerPosition)
        {
            if ((CurCharge >= chargeTime) && BulletList.Count < 4 && _fired == false)
            {
                BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width, shipLocation.Y + Height / 2), Globals.GameWindowY / BulletScale, (Globals.GameWindowY / BulletScale) * (bulletTexture.Bounds.Height / bulletTexture.Bounds.Width), 0, BulYVel));
                BulYVel = BulYVel*-1;
                CurCharge = 0;
            }
            else if (BulletList.Count >= 4 && _fired == false)
            {
                _fired = true;
                FireBullet(playerPosition);
            }
            else if (_fired && BulletList.Count == 0)
            {
                _fired = false;
            }
            CurCharge++;

            if (BulletList.Count != 0)
            {
                for (int i = BulletList.Count - 1; i >= 0; i--)
                {
                    if (BulletList[i].BulletLocation.X > 0 && BulletList[i].BulletLocation.X < Globals.GameWindowX && BulletList[i].BulletLocation.Y > 0 && BulletList[i].BulletLocation.Y < Globals.GameWindowY)
                    {
                        
                        BulletList[i].Update();
                    }
                    else
                    {
                        BulletList.RemoveAt(i);
                    }
                }
            }
        }

        public override void FireBullet(Vector2 playerPosition)
        {
            foreach (Bullet curBullet in BulletList)
            {
                double Angle = GetAngleTwoPoints(playerPosition, curBullet.BulletLocation);
                curBullet.BulletSpeedX = (int)(FiredBulletVelocity*Math.Cos(Angle));
                curBullet.BulletSpeedY = (int)(FiredBulletVelocity*Math.Sin(Angle));
            }
        }

        private double GetAngleTwoPoints(Vector2 point1, Vector2 point2)
        {
            double XDif = point1.X - point2.X;
            double YDif = point1.Y - point2.Y;
            return Math.Atan2(YDif, XDif);

        }
    }
}
