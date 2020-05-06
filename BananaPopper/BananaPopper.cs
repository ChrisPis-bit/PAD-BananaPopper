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
            globalScale = screen.X / 20;
            textureScale = globalScale / 32;

            // TODO: Add gamestates here
            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.AddGameState("Login", new Login());
            GameStateManager.AddGameState("Startup", new Startup());
            GameStateManager.AddGameState("TitleMenuState", new TitleMenuState());
            GameStateManager.AddGameState("HomeMenu", new HomeMenu());
            GameStateManager.AddGameState("LevelCleared", new LevelCleared ());
            GameStateManager.AddGameState("LevelFailed", new LevelFailed());
            GameStateManager.AddGameState("LevelSelector", new LevelSelector());
            GameStateManager.SwitchTo("TitleMenuState");
        }
    }
}
