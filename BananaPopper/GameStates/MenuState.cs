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
        Texture2D mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        protected Button backButton;
        protected SpriteGameObject theMouse, backGround;


        public MenuState() : base()
        {
            GameEnvironment.ChangeColor(mouse, Color.White);

            Add(backGround = new SpriteGameObject("sprites/Background"));
            backGround.Scale = (float)GameEnvironment.Screen.X / backGround.texture.Width;

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
