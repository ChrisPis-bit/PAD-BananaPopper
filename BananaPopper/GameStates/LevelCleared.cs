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
    class LevelCleared : GameObjectList
    {
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
            tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
               mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Button nextLevel, homeScreen;

        SpriteGameObject theMouse;

        public LevelCleared() : base()
        {
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);
            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));

            Add(new SpriteGameObject(bg));

            Add(nextLevel = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10)));
            Add(homeScreen = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10*5)));

            Add(new TextGameObject(Color.White, nextLevel.position, "Next Level"));
            Add(new TextGameObject(Color.White, homeScreen.position, "Home"));

            Add(theMouse = new SpriteGameObject(mouse));

            Add(new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 2), "Level Cleared"));
            Add(new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 2), "well done"));

            theMouse.scale = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Button presses for each button on screen
            if (nextLevel.isPressed)
            {
                //Switches to startup screen so the player can choose how they want to start the game
                (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex++;
                (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).StartLevel((GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex);
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
            else if(homeScreen.isPressed)
            {
                (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex++;
                (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).StartLevel((GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).levelIndex);

                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
            }
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            theMouse.position = inputHelper.MousePosition;
        }
    }
}
