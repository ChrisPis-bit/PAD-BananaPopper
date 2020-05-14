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
        private const float HITBOX_DOWNSCALE = 0.5f; //Defines how much smaller the hitbox is going to be from the original

        public Balloon(Vector2 position, string assetName = "sprites/IngameSprites/Normal Balloon") : base(assetName)
        {
            score = BALLOON_SCORE;
            Scale = GameEnvironment.TextureScale;
            this.position = position - HitBox/2;
            HitBoxScale = HITBOX_DOWNSCALE;
        }
    }
}
