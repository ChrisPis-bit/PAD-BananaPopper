using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;


namespace BananaPopper
{
    class BananaPopper : GameEnvironment
    {
        Song backgroundMusic;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           
            base.LoadContent();
            screen.X = 1920;
            screen.Y = 1080;
            ApplyResolutionSettings();

            backgroundMusic = Content.Load<Song>("MonkeyIslandBand");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

            //lower volume against annoyence
            MediaPlayer.Volume = 0.3f;


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
            gameStateManager.AddGameState("TutorialState", new TutorialState());
            GameStateManager.SwitchTo("TitleMenuState");
        }
    }
}
