using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;



namespace BananaPopper
{
    class LevelFailed : MenuState
    {
        MenuButton retry, homeScreen;

        public LevelFailed() : base()
        {
            Add(retry = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 3), "Restart"));
            Add(homeScreen = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 5), "Home"));

            Add(new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10), "Level Failed"));
            backButton.Visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Button presses for each button on screen
            if (retry.isPressed)
            {
                //Switches to the level the player last played, so they can retry the level
                
                GameEnvironment.GameStateManager.GetGameState("PlayingState").Reset();
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
            else if (homeScreen.isPressed)
            {
                //Temporary level reset//
                GameEnvironment.GameStateManager.GetGameState("PlayingState").Reset();

                //Switches to the home menu screen
                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
            }
        }
    }
}
