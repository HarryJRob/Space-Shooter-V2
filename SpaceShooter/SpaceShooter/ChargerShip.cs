using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    class ChargerShip : Ship
    {
        private const int chargeTime = 20;
        private int CurCharge = 0;
        private int BulYVel;
        private int BulXVel;

        public ChargerShip(Texture2D EnemyTex, Texture2D BulletTex, int WindowYSize, int WindowXSize)
        {

            shipTexture = EnemyTex;
            bulletTexture = BulletTex;
            shipLocation = new Vector2(WindowXSize/2,WindowYSize/2);
            GameWindowY = WindowYSize;
            GameWindowX = WindowXSize;

            Height = GameWindowY / shipScale;
            Width = Height * (shipTexture.Bounds.Width / shipTexture.Bounds.Height);

            BulXVel = 1;
            BulYVel = 1;
        }

        public override void Update(Vector2 playerPosition)
        {
            if ((CurCharge >= chargeTime) && BulletList.Count < 4)
            {
                BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width, shipLocation.Y + Height / 2), GameWindowY / BulletScale, (GameWindowY / BulletScale) * (bulletTexture.Bounds.Height / bulletTexture.Bounds.Width), 0, BulYVel));
                BulYVel = BulYVel*-1;
                CurCharge = 0;
            }
            else if (BulletList.Count >= 4)
            {
                FireBullet(playerPosition);
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

        public override void FireBullet(Vector2 playerPosition)
        {
            foreach (Bullet CurBullet in BulletList)
            {
                float deltaX = playerPosition.X - shipLocation.X;
                float deltaY = playerPosition.Y - shipLocation.Y;
                int movementRatio = (int)(BulXVel / System.Math.Sqrt((int)deltaX ^ 2 + (int)deltaY ^ 2));
                CurBullet.BulletSpeedX = (int)(movementRatio*deltaX);
                CurBullet.BulletSpeedY = (int)(movementRatio*deltaY);

            }
        }
    }
}
