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

        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Window.AllowUserResizing = false;
            graphics.ToggleFullScreen();

            graphics.ApplyChanges();

            Globals.GameWindowX = graphics.PreferredBackBufferWidth;
            Globals.GameWindowY = graphics.PreferredBackBufferHeight;

        }

        protected override void Initialize()
        {
            Globals.GameStateManager = Globals.GameState.PlayingMP;
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

            if (Globals.GameStateManager == Globals.GameState.PlayingSP || Globals.GameStateManager == Globals.GameState.PlayingMP)
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

            if (Globals.GameStateManager == Globals.GameState.PlayingSP || Globals.GameStateManager == Globals.GameState.PlayingMP)
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

            if (Globals.GameStateManager == Globals.GameState.PlayingSP)
            {
                CurGame = new MainGame();
                CurGame.LoadTextures(Content);
                CurGame.Initialise(false, Window);
            }
            else if (Globals.GameStateManager == Globals.GameState.PlayingMP)
            {
                CurGame = new MainGame();
                CurGame.LoadTextures(Content);
                CurGame.Initialise(true, Window);
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
