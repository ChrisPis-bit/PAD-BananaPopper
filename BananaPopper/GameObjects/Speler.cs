using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class Speler : SpriteGameObject
    {
        public Speler(Vector2 startPosition) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 40, 40))
        {
            GameEnvironment.ChangeColor(texture, Color.Green);

            position = startPosition - origin;
        }


    }
}
