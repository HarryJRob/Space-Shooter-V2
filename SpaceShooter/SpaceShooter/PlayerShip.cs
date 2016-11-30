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
        private const int MaxVelocity = 10;
        private const int MaxBoostVelocity = 20;
        private const int Acceleration = 2;
        private int GameWindowY;
        private int GameWindowX;

        private const int BulletScale =  30;
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
            bulletCoolDown = shipScale;
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
                    if ((shipLocation.Y -= velocity) <= 0)
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
                    if ((shipLocation.Y += velocity) >= GameWindowY - Height)
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
                    if ((shipLocation.X += velocity) >= GameWindowX - Width)
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
                    if ((shipLocation.X -= velocity) <= 0)
                    {
                        shipLocation.X = 0;
                    }
                    else
                    {
                        shipLocation.X -= velocity;
                    }
                }
                if (CurKeyState.IsKeyDown(Keys.Space) && bulletCoolDown > 40)
                {
                    bulletCoolDown = 0;
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
                    if ((shipLocation.Y -= velocity) <= 0)
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
                    if ((shipLocation.Y += velocity) >= GameWindowY - Height)
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
                    if ((shipLocation.X += velocity) >= GameWindowX - Width)
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
                    if ((shipLocation.X -= velocity) <= 0)
                    {
                        shipLocation.X = 0;
                    }
                    else
                    {
                        shipLocation.X -= velocity;
                    }
                }
                if (CurKeyState.IsKeyDown(Keys.Enter) && bulletCoolDown > 40)
                {
                    bulletCoolDown = 0;
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
                    if ((shipLocation.Y -= velocity) <= 0)
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
                    if ((shipLocation.Y += velocity) >= GameWindowY - Height)
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
                    if ((shipLocation.X += velocity) >= GameWindowX - Width)
                    {
                        shipLocation.X = GameWindowX - Width;
                    }
                    else
                    {
                        shipLocation.X += velocity;
                    }
                }
                if ((CurKeyState.IsKeyDown(Keys.A) || CurKeyState.IsKeyDown(Keys.Left)) && shipLocation.X > 0)
                {
                    if ((shipLocation.X -= velocity) <= 0)
                    {
                        shipLocation.X = 0;
                    }
                    else
                    {
                        shipLocation.X -= velocity;
                    }
                }
                if ((CurKeyState.IsKeyDown(Keys.Space) || CurKeyState.IsKeyDown(Keys.Enter)) && bulletCoolDown > 40)
                {
                    bulletCoolDown = 0;
                    FireBullet();
                }
            }
            
            bulletCoolDown++;

            foreach (Bullet curBullet in BulletList)
            {
                if (curBullet.BulletLocation.X <= GameWindowX)
                {
                    curBullet.Update();
                }
                else
                {
                    
                }
            }
            //System.Diagnostics.Debug.WriteLine("ShipVelocity: {0}", velocity);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, new Rectangle((int)shipLocation.X, (int)shipLocation.Y, Width, Height), Color.White);

            //Ignore only for testing
            //spriteBatch.Draw(shipTexture, new Rectangle((int)shipLocation.X, (int)shipLocation.Y, 2, 2), Color.Black);
            //spriteBatch.Draw(shipTexture, new Rectangle((int)shipLocation.X, (int)shipLocation.Y + Height, 2, 2), Color.Black);
            //spriteBatch.Draw(shipTexture, new Rectangle((int)shipLocation.X + Width, (int)shipLocation.Y + Height, 2, 2), Color.Black);
            //spriteBatch.Draw(shipTexture, new Rectangle((int)shipLocation.X + Width, (int)shipLocation.Y, 2, 2), Color.Black);
        }

        protected override void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet curBullet in BulletList)
            {
                curBullet.DrawSelf(spriteBatch, bulletTexture);
                //System.Diagnostics.Debug.WriteLine("Bullet Drawn. BulletNo: {0}", BulletList.Count);
            }
        }

        public override void FireBullet()
        {
            //System.Diagnostics.Debug.WriteLine("Bullet Fired");
            BulletList.Add(new Bullet(new Vector2(shipLocation.X + Width,shipLocation.Y + Height / 2), //Split over two lines
                GameWindowY / BulletScale, (GameWindowY/BulletScale) * (int)(bulletTexture.Bounds.Height/bulletTexture.Bounds.Width)));
        }
    }
}
