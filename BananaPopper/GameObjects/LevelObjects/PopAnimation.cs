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
    class PopAnimation : SpriteGameObject
    {
        int frameCounter = 0;
        public PopAnimation() : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 32, 32))
        {
            GameEnvironment.ChangeColor(texture, Color.Orange);
            Scale = GameEnvironment.TextureScale;
            visible = false;
        }
        public override void Update(GameTime gameTime)
        {
            if (visible == true)
            {
                frameCounter++;
                if (frameCounter == 15)
                {
                    visible = false;
                    frameCounter = 0;
                }
            }
            base.Update(gameTime);
        }
    }
}
