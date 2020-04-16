using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Startup : GameObjectList
    {
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
         tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
            mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Button login, createAccount, offline;

        SpriteGameObject theMouse;

        public Startup() : base()
        {
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);
            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));

            Add(new SpriteGameObject(bg));

            Add(login = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10)));
            Add(createAccount = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 3)));
            Add(offline = new Button(tempButton, new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10 * 5)));

            Add(new TextGameObject("Login", Color.White, "GameFont", login.position));
            Add(new TextGameObject("Create Account", Color.White, "GameFont", createAccount.position));
            Add(new TextGameObject("Play Offline", Color.White, "GameFont", offline.position));

            Add(theMouse = new SpriteGameObject(mouse));

            theMouse.scale = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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
