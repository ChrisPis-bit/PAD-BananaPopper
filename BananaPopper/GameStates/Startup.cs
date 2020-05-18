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
        MenuButton login, createAccount, offline;

        public Startup() : base()
        {
            Add(login = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10), "Login"));
            Add(createAccount = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 3), "Create Account"));
            Add(offline = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 5), "Offline"));
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
    }
}
