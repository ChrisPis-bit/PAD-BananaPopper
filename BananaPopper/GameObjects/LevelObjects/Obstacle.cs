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
        public Obstacle(Vector2 position) : base("sprites/IngameSprites/Obstacle")
        {
            Reset();
            this.position = position - HitBox / 2;
            
        }

        public override void Reset()
        {
            Scale = GameEnvironment.TextureScale/2;

            base.Reset();
        }
    }
}
