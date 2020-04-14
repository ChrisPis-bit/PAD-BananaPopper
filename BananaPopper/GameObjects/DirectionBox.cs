using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class DirectionBox : SpriteGameObject
    {
        public DirectionBox() : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y))
        {
            GameEnvironment.ChangeColor(texture, new Color(Color.Black, 80));
            scale = 1;
        }

        public void UpdateDirection(bool flip, Vector2 position)
        {
            if (!flip)
            {
                this.position.X = position.X;
            }
            else
                this.position.X = position.X - texture.Width;
        }
    }
}
