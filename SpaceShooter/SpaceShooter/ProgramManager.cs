using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class GameManager : Game
    {

        private MainGame CurGame;
        private MainMenu CurMenu;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardState CurKeyState;
        private MouseState CurMouseState;

        private Globals.GameState LastState;

        private bool MPlayer = false;

        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            graphics.ToggleFullScreen();
            Window.AllowUserResizing = false;
        }

        protected override void Initialize()
        {
            Globals.GameStateManager = Globals.GameState.Playing;
            ChangeState(Globals.GameStateManager);
            base.Initialize();    
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (LastState != Globals.GameStateManager)
            {
                ChangeState(Globals.GameStateManager);
            }

            CurKeyState = Keyboard.GetState();
            CurMouseState = Mouse.GetState();
            if (CurKeyState.IsKeyDown(Keys.Escape)) { Exit(); }

            if (Globals.GameStateManager == Globals.GameState.Playing)
            {
                CurGame.Update(CurKeyState);
            }
            else if (Globals.GameStateManager == Globals.GameState.MainMenu)
            {
                CurMenu.Update(CurMouseState);
            }

            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();

            if (Globals.GameStateManager == Globals.GameState.Playing)
            {
                CurGame.Draw(spriteBatch);
            }
            else if (Globals.GameStateManager == Globals.GameState.MainMenu)
            {
                CurMenu.Draw(spriteBatch);
            }

            base.Draw(gameTime);
            spriteBatch.End();
        }

        private void ChangeState(Globals.GameState changeGameState)
        {
            LastState = changeGameState;

            if (Globals.GameStateManager == Globals.GameState.Playing)
            {
                CurGame = new MainGame();
                CurGame.LoadTextures(Content);
                CurGame.Initialise(MPlayer, Window);
            }
            else if (Globals.GameStateManager == Globals.GameState.MainMenu)
            {
                CurMenu = new MainMenu();
                CurMenu.LoadTextures(Content);
                CurMenu.Initialise();
            }

        }
    }
}
