using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    public static class LineRenderer
    {
        public static void DrawLine(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 end)
        {
            //Defines angle of line
            float angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);

            //Draws the line
            spriteBatch.Draw(texture, start, null, Color.White,
                         angle,
                         new Vector2(0f, (float)texture.Height / 2),
                         new Vector2(Vector2.Distance(start, end), 1f),
                         SpriteEffects.None, 0f);
        }
    }
}
