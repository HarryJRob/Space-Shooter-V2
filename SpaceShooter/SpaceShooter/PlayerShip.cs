using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class PlayerShip : Ship
    {
        private byte PlayerID; //Set when initialised. 1 = Player1, 2 = Player2, 3 = SinglePlayer

        private static byte MaxVelocity = 10;
        private int velocity = MaxVelocity;
        private static byte MaxBoostVelocity = 15;
        private static byte Acceleration = 1;
        private static byte BulletCoolDown = 20;

        private List<Keys> ControlScheme = new List<Keys> { Keys.W, Keys.A, Keys.D, Keys.S, Keys.LeftShift, Keys.Space }; //Currently hard coded will need to be loaded from a file
        private List<bool> MoveList = new List<bool> { false, false, false, false, false, false }; //Up, Left ,Right ,Down ,Boost, Space

        private readonly int GameWindowY;
        private readonly int GameWindowX;

        private const int BulletScale = 60;
        private const int shipScale = 13;

        //Pass the ID,ship Texture2D/Location of on texture sheet, Window Size,bullet Texture2D/Location on texture sheet, WindowYSize

        public PlayerShip(byte ID, Texture2D PlayerTex, Texture2D BulletTex, int WindowYSize, int WindowXSize) 
        {
            //Set all values up.
            shipTexture = PlayerTex;
            bulletTexture = BulletTex;

            PlayerID = ID;
            GameWindowY = WindowYSize;
            GameWindowX = WindowXSize;
            //bulletCoolDown = shipScale;
            Height = GameWindowY / shipScale; 
            
            Width = Height * (int)(shipTexture.Bounds.Width / shipTexture.Bounds.Height);

            if (PlayerID == 1)
            {
                shipLocation.Y = GameWindowY / 2 - Height * 2;
            }
            else if (PlayerID == 2)
            {
                shipLocation.Y = GameWindowY / 2 + Height * 2;
            }
            else if (PlayerID == 3)
            {
                shipLocation.Y = GameWindowY / 2 - Height / 2;
            }
            shipLocation.X += 40;
        }

        public void Update(KeyboardState CurKeyState)
        {

            for (int i = 0; i < ControlScheme.Count; i++)
            {
                if (CurKeyState.IsKeyDown(ControlScheme[i]))
                {
                    MoveList[i] = true;
                }
                else
                {
                    MoveList[i] = false;
                }
            }

            PlayerMoveCheck();
            BulletUpdate();
        }

        public void PlayerMoveCheck()
        {
            //Up, Left ,Right ,Down ,Boost
            if (MoveList[4] && velocity < MaxBoostVelocity)
            {
                velocity += Acceleration;
            }
            else if (velocity > MaxVelocity)
            {
                velocity -= Acceleration;
            }
            if (MoveList[0])
            {
                if ((shipLocation.Y - velocity) <= 0)
                {
                    shipLocation.Y = 0;
                }
                else
                {
                    shipLocation.Y -= velocity;
                }
            }
            if (MoveList[1])
            {
                if ((shipLocation.X - velocity) <= 0)
                {
                    shipLocation.X = 0;
                }
                else
                {
                    shipLocation.X -= velocity;
                }
            }
            if (MoveList[2])
            {
                if ((shipLocation.X + velocity) >= GameWindowX - Width)
                {
                    shipLocation.X = GameWindowX - Width;
                }
                else
                {
                    shipLocation.X += velocity;
                }
            }
            if (MoveList[3])
            {
                if ((shipLocation.Y + velocity) >= GameWindowY - Height)
                {
                    shipLocation.Y = GameWindowY - Height;
                }
                else
                {
                    shipLocation.Y += velocity;
                }
            }
            if (MoveList[5] && CurBulletCoolDown >= BulletCoolDown)
            {
                FireBullet();
                CurBulletCoolDown = 0;
            }
        }

        public void BulletUpdate()
        {
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
            if (CurBulletCoolDown < BulletCoolDown)
            {
                CurBulletCoolDown += 1;
            }
        }

        public override void FireBullet()
        {
            //System.Diagnostics.Debug.WriteLine("Shots Fired");
            BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width,shipLocation.Y + Height/2), GameWindowY / BulletScale, (GameWindowY/BulletScale) * (int)(bulletTexture.Bounds.Height/bulletTexture.Bounds.Width)));
        }
    }
}