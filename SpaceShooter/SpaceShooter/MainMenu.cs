using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class MainMenu
    {
        private List<MenuButton> buttonList = new List<MenuButton> {};
        private Texture2D buttonTex;

        public void LoadTextures(ContentManager Content)
        {
            //buttonTex = Content.Load<Texture2D>("");
        }

        public void Initialise()
        {
            
        }

        public void Update(MouseState curMouseState)
        {
            //For each menu obj check click
            if (curMouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (MenuButton curButton in buttonList)
                {
                    curButton.CheckClick(curMouseState);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw each menu obj + background
            foreach (MenuButton curButton in buttonList)
            {
                curButton.Draw(spriteBatch);
            }
        }
    }
}
