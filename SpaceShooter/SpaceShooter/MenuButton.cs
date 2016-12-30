using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class MenuButton
    {
        private Vector2 _buttonPosition;
        private Texture2D _buttonTexture;
        private int _buttonWidth;
        private int _buttonHeight;
        private string _buttonText;


        public MenuButton(Vector2 buttonPosition, int width, int height, Texture2D buttonTex, string buttonText )
        {
            _buttonPosition = buttonPosition;
            _buttonWidth = width;
            _buttonHeight = height;
            _buttonTexture = buttonTex;
            _buttonText = buttonText;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public bool CheckClick(MouseState mouseState)
        {
            if ((mouseState.Position.X >= _buttonPosition.X) && (mouseState.Position.X <= _buttonPosition.X + _buttonWidth) && (mouseState.Position.Y <= _buttonPosition.Y) && (mouseState.Position.Y >= _buttonPosition.Y - _buttonHeight) && mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
    }
}
