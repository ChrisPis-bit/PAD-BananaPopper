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
    class plusBanana : SpriteGameObject
    {
        public plusBanana(Vector2 position) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 32, 32))
        {
            GameEnvironment.ChangeColor(texture, Color.GreenYellow);
            scale = GameEnvironment.TextureScale;
            this.position = position - origin;

        }
    }
}
