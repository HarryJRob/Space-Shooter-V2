using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class PlayerShip : Ship
    {
        private byte PlayerID; //Set when initialised. 1 = Player1, 2 = Player2, 3 = SinglePlayer

        private int velocity;
        private static byte BulletCoolDown = 20;

        private List<Keys> ControlScheme = new List<Keys> { Keys.W, Keys.A, Keys.D, Keys.S, Keys.Space }; //Currently hard coded will need to be loaded from a file
        private List<bool> MoveList = new List<bool> { false, false, false, false, false }; //Up, Left ,Right ,Down ,Boost, Space

        //Pass the ID,ship Texture2D/Location of on texture sheet, Window Size,bullet Texture2D/Location on texture sheet, WindowYSize

        public PlayerShip(byte ID, Texture2D PlayerTex, Texture2D BulletTex) 
        {
            //Set all values up.
            shipTexture = PlayerTex;
            bulletTexture = BulletTex;

            PlayerID = ID;
            velocity = Globals.GameWindowX / 200;
            Height = Globals.GameWindowY / shipScale; 
            
            Width = Height * (shipTexture.Bounds.Width / shipTexture.Bounds.Height);

            if (PlayerID == 1)
            {
                shipLocation.Y = Globals.GameWindowY / 2 - Height * 2;
            }
            else if (PlayerID == 2)
            {
                shipLocation.Y = Globals.GameWindowY / 2 + Height * 2;
            }
            else if (PlayerID == 3)
            {
                shipLocation.Y = Globals.GameWindowY / 2 - Height / 2;
            }
            shipLocation.X += 40;
        }

        public override void Update(KeyboardState curKeyState)
        {

            for (int i = 0; i < ControlScheme.Count; i++)
            {
                if (curKeyState.IsKeyDown(ControlScheme[i]))
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
            if (MoveList[0])
            {
                if (shipLocation.Y - velocity <= 0)
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
                if (shipLocation.X - velocity <= 0)
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
                if ((shipLocation.X + velocity) >= Globals.GameWindowX - Width)
                {
                    shipLocation.X = Globals.GameWindowX - Width;
                }
                else
                {
                    shipLocation.X += velocity;
                }
            }
            if (MoveList[3])
            {
                if ((shipLocation.Y + velocity) >= Globals.GameWindowY - Height)
                {
                    shipLocation.Y = Globals.GameWindowY - Height;
                }
                else
                {
                    shipLocation.Y += velocity;
                }
            }
            if (MoveList[4] && CurBulletCoolDown >= BulletCoolDown)
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
                    if (BulletList[i].BulletLocation.X > Globals.GameWindowX)
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
            BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width, shipLocation.Y + Height / 2), Globals.GameWindowY / BulletScale, (Globals.GameWindowY / BulletScale) * (int)(bulletTexture.Bounds.Height / bulletTexture.Bounds.Width), 35, 0));
        }
    }
}