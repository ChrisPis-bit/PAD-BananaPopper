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
    class Obstacle : SpriteGameObject
    {
        public int ObstacleHP = 1;
        public Obstacle(Vector2 position) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 32, 32))
        {
            GameEnvironment.ChangeColor(texture, Color.Purple);
            Reset();
            this.position = position - origin;
            
        }

        public override void Reset()
        {
            scale = GameEnvironment.TextureScale;

            base.Reset();
        }
    }
}
