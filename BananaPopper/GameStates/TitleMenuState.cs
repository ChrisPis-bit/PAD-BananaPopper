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
    class TitleMenuState : MenuState
    {
        Texture2D tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
               mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        MenuButton startGame;

        SpriteGameObject theMouse, title;

        public TitleMenuState() : base()
        {
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);

            Add(title = new SpriteGameObject("sprites/MenuSprites/Title"));
            title.Origin = title.HitBox / 2;
            title.Scale = 4;
            title.position = new Vector2(GameEnvironment.Screen.X / 2, title.HitBox.Y/2);

            Add(startGame = new MenuButton(Vector2.Zero, "Start Game"));
            startGame.position = new Vector2(GameEnvironment.Screen.X / 2 - startGame.HitBox.X / 2, GameEnvironment.Screen.Y / 3);
            Add(theMouse = new SpriteGameObject(mouse));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Button presses for each button on screen
            if (startGame.isPressed)
            {
                //Switches to startup screen so the player can choose how they want to start the game
                GameEnvironment.GameStateManager.SwitchTo("Startup");
            }

        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            theMouse.position = inputHelper.MousePosition;
        }
    }
}

