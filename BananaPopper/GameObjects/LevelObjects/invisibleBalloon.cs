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
        const int INV_BALLOON_SCORE = 80;

        public InvisibleBalloon(Vector2 position) : base(position)
        {     
            score = INV_BALLOON_SCORE;
            scale = GameEnvironment.TextureScale;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
