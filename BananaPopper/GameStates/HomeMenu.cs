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
        Texture2D mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        MenuButton startGame, options;

        private SpriteGameObject theMouse, title;

        public HomeMenu() : base()
        {
            GameEnvironment.ChangeColor(mouse, Color.White);

            Add(startGame = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10*3), "Start Game"));
            Add(options = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10*5), "Options"));

            Add(theMouse = new SpriteGameObject(mouse));

            Add(title = new SpriteGameObject("sprites/MenuSprites/Title"));
            title.Origin = title.HitBox / 2;
            title.Scale = 4;
            title.position = new Vector2(GameEnvironment.Screen.X / 2, title.HitBox.Y / 2);
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
