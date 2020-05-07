using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class MenuState : GameObjectList
    {
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
            mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        protected Button backButton;
        public SpriteGameObject theMouse;


        public MenuState() : base()
        {
            GameEnvironment.ChangeColor(mouse, Color.White);
            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));

            Add(new SpriteGameObject(bg));

            Add(backButton = new Button("arrowKey", Vector2.Zero, -(float)Math.PI/2));
            backButton.Origin = new Vector2(backButton.texture.Width/2, backButton.texture.Height/2);
            backButton.Scale = 3;
            backButton.position += backButton.HitBox / 2;

            Add(theMouse = new SpriteGameObject(mouse));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            theMouse.position = inputHelper.MousePosition;
        }
    }
}
