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
        public Banaan(): base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 35, 20))
        {
            GameEnvironment.ChangeColor(texture, Color.Yellow);
            visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
 
        }

        public void Shoot(Vector2 position, float speed, bool flipLine)
        {
            visible = true;
            this.position = position;
            if (flipLine) velocity = new Vector2(1, speed * -1) * 100;
            else velocity = new Vector2(1, speed * -1) * -100;
        }
    }
}
