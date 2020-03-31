using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class StrongBalloon : Balloon
    {
        public StrongBalloon(Vector2 position) : base(position)
        {

            GameEnvironment.ChangeColor(texture, Color.White);
        }
    }
}
