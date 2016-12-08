using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class PlayerShip : Ship
    {
        private int velocity = 10; 

        private byte PlayerID; //Set when initialised. 1 = Player1, 2 = Player2, 3 = SinglePlayer
        private static int MaxVelocity = 14;
        private static int MaxBoostVelocity = 25;
        private static int Acceleration = 1;
        private static int BulletCoolDown = 15;

        private int GameWindowY;
        private int GameWindowX;

        private const int BulletScale =  30;
        private const int shipScale = 13;

        //Pass the ID,ship Texture2D/Location of on texture sheet, Window Size,bullet Texture2D/Location on texture sheet, WindowYSize

        public PlayerShip(byte ID, Texture2D PlayerTex, Texture2D BulletTex, int WindowYSize, int WindowXSize) 
        {
            //Speed of bullets and ships and scale of the bullets need to be made dependant on the window size!!

            //Set all values up.
            shipTexture = PlayerTex;
            bulletTexture = BulletTex;
            
            PlayerID = ID;
            GameWindowY = WindowYSize;
            GameWindowX = WindowXSize;
            //bulletCoolDown = shipScale;
            Height = GameWindowY / shipScale; //ship height will always be a 13th of the window size
            
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

        public override void Update(KeyboardState CurKeyState)
        {
            //System.Diagnostics.Debug.WriteLine("Ship Move Check");
            //Better way to do this needed
            if (PlayerID == 1)
            {
                if (CurKeyState.IsKeyDown(Keys.LeftShift) && velocity < MaxBoostVelocity)
                {
                    velocity += Acceleration;

                }
                else if (velocity > MaxVelocity)
                {
                    velocity -= Acceleration;
                }
                if (CurKeyState.IsKeyDown(Keys.W) && shipLocation.Y > 0)
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
                if (CurKeyState.IsKeyDown(Keys.S) && shipLocation.Y < GameWindowY - Height)
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
                if (CurKeyState.IsKeyDown(Keys.D) && shipLocation.X < GameWindowX - Width)
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
                if (CurKeyState.IsKeyDown(Keys.A) && shipLocation.X > 0)
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
                if (CurKeyState.IsKeyDown(Keys.Space) && CurbulletCoolDown > BulletCoolDown)
                {
                    CurbulletCoolDown = 0;
                    FireBullet();
                }
            }
            else if (PlayerID == 2)
            {
                if ((CurKeyState.IsKeyDown(Keys.RightShift)) && velocity < MaxBoostVelocity)
                {
                    velocity += Acceleration;
                }
                else if (velocity > MaxVelocity)
                {
                    velocity -= Acceleration;
                }
                if (CurKeyState.IsKeyDown(Keys.Up) && shipLocation.Y > 0)
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
                if (CurKeyState.IsKeyDown(Keys.Down) && shipLocation.Y < GameWindowY - Height)
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
                if (CurKeyState.IsKeyDown(Keys.Right) && shipLocation.X < GameWindowX - Width)
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
                if (CurKeyState.IsKeyDown(Keys.Left) && shipLocation.X > 0)
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
                if (CurKeyState.IsKeyDown(Keys.Enter) && CurbulletCoolDown > BulletCoolDown)
                {
                    CurbulletCoolDown = 0;
                    FireBullet();
                }
            }
            else if (PlayerID == 3)
            {
                if ((CurKeyState.IsKeyDown(Keys.LeftShift) || CurKeyState.IsKeyDown(Keys.RightShift)) && velocity < MaxBoostVelocity)
                {
                    velocity += Acceleration;
                }
                else if (velocity > MaxVelocity)
                {
                    velocity -= Acceleration;
                }
                if ((CurKeyState.IsKeyDown(Keys.W) || CurKeyState.IsKeyDown(Keys.Up)) && shipLocation.Y > 0)
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
                if ((CurKeyState.IsKeyDown(Keys.S) || CurKeyState.IsKeyDown(Keys.Down)) && shipLocation.Y < GameWindowY - Height)
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
                if ((CurKeyState.IsKeyDown(Keys.D) || CurKeyState.IsKeyDown(Keys.Right)) && shipLocation.X < GameWindowX - Width)
                {
                    if ((shipLocation.X + velocity) >= GameWindowX - Width)
                    {
                        shipLocation.X = GameWindowX - Width;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Ship 1: {0}", shipLocation.X + Width);
                        shipLocation.X += velocity;
                        System.Diagnostics.Debug.WriteLine("Ship 2: {0}", shipLocation.X + Width);
                    }
                }
                if ((CurKeyState.IsKeyDown(Keys.A) || CurKeyState.IsKeyDown(Keys.Left)) && shipLocation.X > 0)
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
                if ((CurKeyState.IsKeyDown(Keys.Space) || CurKeyState.IsKeyDown(Keys.Enter)) && CurbulletCoolDown > BulletCoolDown)
                {
                    CurbulletCoolDown = 0;
                    FireBullet();
                }
            }
            
            CurbulletCoolDown += 1;

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
                        if (BulletList[i].BulletLocation.X < shipLocation.X + Width)
                        {
                            System.Diagnostics.Debug.WriteLine("{0}", Convert.ToString(BulletList[i].BulletSpeed));
                            System.Diagnostics.Debug.WriteLine("{0}", Convert.ToString(velocity));
                        }
                    }
                }
            }
            //System.Diagnostics.Debug.WriteLine("Bullet Update Check");
            //System.Diagnostics.Debug.WriteLine("Bullet Count: {0}", BulletList.Count);
            //System.Diagnostics.Debug.WriteLine("ShipVelocity: {0}", velocity);
        }

        public override void FireBullet()
        {
            //System.Diagnostics.Debug.WriteLine("Shots Fired");
            BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width,shipLocation.Y + Height / 2), //Split over two lines
                GameWindowY / BulletScale, (GameWindowY/BulletScale) * (int)(bulletTexture.Bounds.Height/bulletTexture.Bounds.Width)));
        }
    }
}
