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
    
    class StrongBalloon : Balloon
    {
        const int STRONG_BALLOON_SCORE = 100;

        public StrongBalloon(Vector2 position) : base(position, "sprites/IngameSprites/Strong Balloon")
        {
            hp = 2;
            //GameEnvironment.ChangeColor(texture, Color.Gray);

            score = STRONG_BALLOON_SCORE;
            scale = GameEnvironment.TextureScale;
        }
    }
}
