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
    class Balloon : SpriteGameObject
    {
        public int hp = 1,
            score;

        public const int BALLOON_SCORE = 50;
        public Balloon(Vector2 position) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 16, 16))
        {
            GameEnvironment.ChangeColor(texture, Color.Brown);

            score = BALLOON_SCORE;
            this.position = position - origin;
            scale = GameEnvironment.TextureScale;
        }
    }
}
