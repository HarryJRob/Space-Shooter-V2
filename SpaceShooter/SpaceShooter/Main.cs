using System.Runtime.Remoting.Channels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private PlayerShip Player1;
        private PlayerShip Player2;

        //Need to think of a better way to do texture loading. Maybe do a texture sheet?
        private Texture2D Background;
        private Texture2D bulletTemp;
        private Texture2D shipTemp;
        bool MPlayer = true;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            graphics.ToggleFullScreen();
        }

        protected override void Initialize()
        {
            Window.AllowUserResizing = false;
            shipTemp = Content.Load<Texture2D>("Resources/Ships/ship");
            bulletTemp = Content.Load<Texture2D>("Resources/Bullets/Bullet");
            if (MPlayer) 
            {
                Player1 = new PlayerShip(1, shipTemp, bulletTemp, Window.ClientBounds.Height);
                Player2 = new PlayerShip(2, shipTemp, bulletTemp, Window.ClientBounds.Height);
            }
            else 
            {
                Player1 = new PlayerShip(3, shipTemp, bulletTemp, Window.ClientBounds.Height);
                Player2 = null;
            }
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Background = Content.Load<Texture2D>("Resources/BackGrounds/Background");
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
            string KeyString = "Keys Pressed";
            foreach (var key in CurKeyState.GetPressedKeys())
            {
                KeyString = KeyString + ": " + key;
                System.Diagnostics.Debug.WriteLine(KeyString);
            }
            //System.Diagnostics.Debug.WriteLine("Width: {0}, Height: {1}", Window.ClientBounds.Width, Window.ClientBounds.Height);
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            //Draw Background
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            // Draw Players + Respective Bullets
            spriteBatch.Draw(Background,new Rectangle(0,0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            Player1.Draw(spriteBatch);
            if (Player2 != null)
            {
                Player2.Draw(spriteBatch);
            }

            //Draw Enemies + Respective Bullets
            
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
