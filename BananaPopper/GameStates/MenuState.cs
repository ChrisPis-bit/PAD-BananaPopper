using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class MenuState : GameState
    {
        protected Button backButton;
        protected SpriteGameObject backGround;


        public MenuState() : base()
        {
            Add(backGround = new SpriteGameObject("sprites/Background"));
            backGround.Scale = (float)GameEnvironment.Screen.X / backGround.texture.Width;

            Add(backButton = new Button("arrowKey", Vector2.Zero, -(float)Math.PI/2));
            backButton.Origin = new Vector2(backButton.texture.Width/2, backButton.texture.Height/2);
            backButton.Scale = 3;
            backButton.position += backButton.HitBox / 2;
        }
    }
}
