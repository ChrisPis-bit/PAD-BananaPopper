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
    class LevelFailed : GameObjectList
    {
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
            tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
               mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Button retry, homeScreen;

        SpriteGameObject theMouse;

        public LevelFailed() : base()
        {
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);
            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));

            Add(new SpriteGameObject(bg));

            Add(retry = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10)));
            Add(homeScreen = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 5)));

            Add(new TextGameObject(Color.White, retry.position, "Restart"));
            Add(new TextGameObject(Color.White, homeScreen.position, "Home"));

            Add(theMouse = new SpriteGameObject(mouse));

            Add(new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 3), "Level Failed"));
            Add(new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 2), "Do you want to retry this level?"));

            theMouse.scale = 1;
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


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            theMouse.position = inputHelper.MousePosition;
        }
    }
}
