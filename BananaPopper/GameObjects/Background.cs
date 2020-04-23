using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper.GameObjects
{
    class Background : SpriteGameObject
    {
        public Background() : base("sprites/Background")
        {
            scale = GameEnvironment.Screen.X / texture.Width;
            origin = Vector2.Zero;
        }
    }
}
