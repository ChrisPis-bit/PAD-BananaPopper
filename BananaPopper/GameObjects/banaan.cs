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
    class Banaan : SpriteGameObject
    {
        Texture2D banaan;
        
        public Banaan(Vector2 position): base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 35, 20))
        {
            GameEnvironment.ChangeColor(texture, Color.Yellow);
            this.position = position;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.position.X += 1 * 3; //3 = speed
        }
    }
}
