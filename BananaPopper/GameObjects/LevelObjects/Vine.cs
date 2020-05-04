using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Vine : SpriteGameObject
    {
        public Vine(Vector2 position, float angle = 0) : base("sprites/IngameSprites/Vines", angle)
        {
            Scale = GameEnvironment.TextureScale;
            this.position = position;

            if (angle == 0)
            {
                this.position.X -= HitBox.X / 2;
            }
            else
                this.position.Y -= HitBox.Y / 2;
        }
    }
}
