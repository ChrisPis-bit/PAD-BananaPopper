using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class BananaPopper : GameEnvironment
    {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            screen.X = 1600;
            screen.Y = 900;
            ApplyResolutionSettings();

            //Use globalScale on object pos and size to make it change in scale with the screen width/height
            globalScale = screen.X / 10;

            // TODO: Add gamestates here
            gameStateList.Add(new PlayingState());

            SwitchTo(0);
        }
    }
}
