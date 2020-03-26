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
        private int elapsedFrames,
            elapsedSeconds;

        public Timer() : base("Time: ", Color.White, "GameFont", new Vector2(0))
        {

        }

        public override void Reset()
        {
            base.Reset();

            elapsedFrames = 0;
            elapsedSeconds = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedFrames++;
            elapsedSeconds = (int)(elapsedFrames * (float)gameTime.ElapsedGameTime.TotalSeconds);

            TimeElapsed();
        }

        public int TimeElapsed()
        {
            text = "Time: " + elapsedSeconds;
            return elapsedSeconds;
        }
    }
}
