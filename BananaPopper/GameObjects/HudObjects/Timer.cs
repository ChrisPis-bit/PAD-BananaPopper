using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class Timer : TextGameObject
    {
        const int BEGIN_TIME = 300;

        private int elapsedFrames,
            elapsedSeconds,
            displayedSeconds;

        public Timer() : base(Color.White, Vector2.Zero)
        {
            position.Y = GameEnvironment.Screen.Y / 5 + GameEnvironment.Screen.Y / 10;
        }

        public override void Reset()
        {
            base.Reset();

            displayedSeconds = BEGIN_TIME;
            elapsedFrames = 0;
            elapsedSeconds = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedFrames++;
            elapsedSeconds = (int)(elapsedFrames * (float)gameTime.ElapsedGameTime.TotalSeconds);

            displayedSeconds = BEGIN_TIME - elapsedSeconds;

            //Displays time
            if (displayedSeconds <= 0)
            {
                displayedSeconds = 0;
            }

            text = "Time: " + displayedSeconds;
        }
    }
}
