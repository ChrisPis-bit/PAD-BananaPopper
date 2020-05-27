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
    class LevelCleared : MenuState
    {
        MenuButton nextLevel, homeScreen;

        TextGameObject scoreText;
        private int score;

        public LevelCleared() : base()
        {
            Add(nextLevel = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 3), "Next Level"));
            Add(homeScreen = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 5), "Home"));

            Add(new TextGameObject(Color.Black, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10), "Level Cleared, Well Done!"));
            Add(scoreText = new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10 * 2)));
            backButton.Visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Button presses for each button on screen
            if (nextLevel.isPressed)
            {
                if ((GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex >= (GameEnvironment.GameStateManager.GetGameState("LevelSelector") as LevelSelector).levelCounter)
                {
                    GameEnvironment.GameStateManager.SwitchTo("LevelSelector");

                }
                else
                {

                    //Switches to startup screen so the player can choose how they want to start the game
                    (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex++;
                    (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).StartLevel((GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex);
                    GameEnvironment.GameStateManager.SwitchTo("PlayingState");
                }
            }
            else if (homeScreen.isPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
            }

            score = (int)(GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).hud.theScore.GetScore;
            scoreText.text = "Score = " + score;
        }
    }
}
