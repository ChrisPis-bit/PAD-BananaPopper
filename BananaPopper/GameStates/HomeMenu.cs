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
    class HomeMenu : MenuState
    {
        Texture2D tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
               mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Button startGame, options, back;

        SpriteGameObject theMouse;

        public HomeMenu() : base()
        {
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);


            Add(startGame = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10*3)));
            Add(options = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10*5)));

            Add(new TextGameObject(Color.White, startGame.position, "Start Game"));
            Add(new TextGameObject(Color.White, options.position, "Options"));

            Add(theMouse = new SpriteGameObject(mouse));

            Add(new TextGameObject(Color.Cyan, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10), "BananaPopper"));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Button presses for each button on screen
            if (startGame.isPressed)
            {
                //Switches to the playingstate so the player can play the game
                GameEnvironment.GameStateManager.SwitchTo("LevelSelector");
            }

            if (backButton.isPressed)
                GameEnvironment.GameStateManager.SwitchTo("Startup");

            // else if (options.isPressed)
            // {
            //Switches to options screen so the player lower or increase the in-game sound
            //     GameEnvironment.GameStateManager.SwitchTo("Options");
            //}

        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            theMouse.position = inputHelper.MousePosition;
        }
    }
}
