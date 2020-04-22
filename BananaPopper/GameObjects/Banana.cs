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
    class Banana : SpriteGameObject
    {
        //This bool will stay true after being shot AND hitting an object
        public bool shot;

        public Banana() : base("sprites/IngameSprites/Banana")
        {
            //GameEnvironment.ChangeColor(texture, Color.Yellow);
            scale = GameEnvironment.TextureScale / 2;
            Visible = false;
            shot = false;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public void Shoot(Vector2 position, float speed, bool flipLine)
        {
            this.position = position - new Vector2(texture.Width/2, texture.Height/2);
            Visible = true;
            shot = true;

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
