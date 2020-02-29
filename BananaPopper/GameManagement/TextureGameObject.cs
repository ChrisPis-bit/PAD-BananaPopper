using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class TextureGameObject : GameObject
    {
        public Texture2D texture;

        public TextureGameObject(Texture2D texture)
        {
                this.texture = texture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
                spriteBatch.Draw(texture, GlobalPosition, Color.White);
        }

        public Boolean Overlaps(TextureGameObject other)
        {
            if (visible)
            {
                float w0 = this.texture.Width,
                    h0 = this.texture.Height,
                    w1 = other.texture.Width,
                    h1 = other.texture.Height,
                    x0 = this.GlobalPosition.X,
                    y0 = this.GlobalPosition.Y,
                    x1 = other.GlobalPosition.X,
                    y1 = other.GlobalPosition.Y;

                return !(x0 > x1 + w1 || x0 + w0 < x1 ||
                  y0 > y1 + h1 || y0 + h0 < y1);
            }

            return false;
        }

    }
}
