using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Startup : MenuState
    {
        Texture2D tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
            mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Button login, createAccount, offline;

        SpriteGameObject theMouse;

        public Startup() : base()
        {
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);


            Add(login = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10)));
            Add(createAccount = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 3)));
            Add(offline = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 5)));

            Add(new TextGameObject(Color.White, login.position, "Login"));
            Add(new TextGameObject(Color.White, createAccount.position, "Create Account"));
            Add(new TextGameObject(Color.White, offline.position, "Play Offline"));

            Add(theMouse = new SpriteGameObject(mouse));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (backButton.isPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("TitleMenuState");
            }

            //Button presses for each button on screen
            if (login.isPressed)
            {
                //Switches to login screen and sets createAccount to false so the player can log in
                GameEnvironment.GameStateManager.SwitchTo("Login");
                (GameEnvironment.GameStateManager.GetGameState("Login") as Login).createAccount = false;
            }
            else if (createAccount.isPressed)
            {
                //Switches to login screen and sets createAccount to true so the player can create an account
                GameEnvironment.GameStateManager.SwitchTo("Login");
                (GameEnvironment.GameStateManager.GetGameState("Login") as Login).createAccount = true;
            }
            else if (offline.isPressed)
            {
                //If player doesn't have internet, or isn't interested in an account, he/she can skip the login and play without account info
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
