using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BananaPopper
{
    
    class StrongBalloon : Balloon
    {
        public StrongBalloon(Vector2 position) : base(position)
        {
            hp = 2;
            GameEnvironment.ChangeColor(texture, Color.Gray);
            scale = GameEnvironment.TextureScale;
        }
    }
}
