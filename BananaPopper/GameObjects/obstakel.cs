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
    class Obstakel : SpriteGameObject
    {
        public Obstakel(Vector2 position) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, (int)GameEnvironment.GlobalScale, (int)GameEnvironment.GlobalScale))
        {
            GameEnvironment.ChangeColor(texture, Color.Purple);
            this.position = position;
            
        }
    }
}
