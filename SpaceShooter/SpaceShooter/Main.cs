using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerShip Player1;
        PlayerShip Player2;
        bool MPlayer = false;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.ToggleFullScreen();
        }

        protected override void Initialize()
        {
            Player1 = new PlayerShip();
            if (MPlayer) 
            {
                Player2 = new PlayerShip();
            }
            else 
            {
                Player2 = null;
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState CurKeyState = Keyboard.GetState();
            if (CurKeyState.IsKeyDown(Keys.Escape)) { Exit(); }

            //Update Players + Respective Bullets
            Player1.Update(CurKeyState);
            if (Player2 != null)
            {
                Player2.Update(CurKeyState);
            }


            //Update Enemies + Respective Bullets



            //Benchmarking
            System.Text.StringBuilder StringBuild = new System.Text.StringBuilder();
            foreach (var key in CurKeyState.GetPressedKeys())
            {
                StringBuild.Append("Key: ").Append(key).Append(" pressed ");
                System.Diagnostics.Debug.WriteLine(StringBuild.ToString());
            }
            //System.Diagnostics.Debug.WriteLine("Width: {0}, Height: {1}", Window.ClientBounds.Width, Window.ClientBounds.Height);
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            //Draw Background
            GraphicsDevice.Clear(Color.Red);

            // Draw Players + Respective Bullets

            Player1.DrawSelf(spriteBatch);
            Player1.DrawBullets(spriteBatch);
            if (Player2 != null)
            {
                Player2.DrawSelf(spriteBatch);
                Player2.DrawBullets(spriteBatch);
            }

            //Draw Enemies + Respective Bullets

            base.Draw(gameTime);
        }
    }
}
