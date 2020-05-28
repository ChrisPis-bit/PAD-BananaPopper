using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class HudButton : Button
    {
        //Base class for buttons in the HUD

        private const float BUTTON_SCALE = 3;

        private float tweenTime = 0;
        private const float TWEEN_SPEED = 0.1f,
                            TWEEN_AMPLITUDE = 0.01f;

        public HudButton(string assetName, Vector2 position) : base(assetName, position)
        {
            Scale = BUTTON_SCALE;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            tweenTime += TWEEN_SPEED;
            if (isHovered)
            {
                VisualScale = new Vector2(VisualScale.X + TWEEN_AMPLITUDE * (float)Math.Sin(tweenTime - Math.PI), VisualScale.Y + TWEEN_AMPLITUDE * (float)Math.Sin(tweenTime - Math.PI));
            }
            else
                VisualScale = new Vector2(Scale);
        }
    }
}
