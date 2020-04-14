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
    class ExplosiveBanana : SpriteGameObject
    {
        public ExplosiveBanana(Vector2 position, float speed, bool flipLine) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 20, 10))
        {
            GameEnvironment.ChangeColor(texture, Color.Red);

            Shoot(position, speed, flipLine);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public void Shoot(Vector2 position, float speed, bool flipLine)
        {
            this.position = position;

            if (flipLine)
            {
                angle = (float)Math.Atan2(-speed, 1);
            }
            else
            {
                angle = (float)Math.Atan2(speed, -1);
            }

            velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 300;
        }
    }
}
