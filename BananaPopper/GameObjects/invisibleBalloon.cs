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
    class InvisibleBalloon : Balloon
    {
        public InvisibleBalloon(Vector2 position) : base(position)
        {     
            GameEnvironment.ChangeColor(texture, Color.White);
            scale = GameEnvironment.TextureScale;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        
        }
    }
}
