using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BananaPopper
{
    class LevelSelector : GameObjectList
    {
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
               tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
                  mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10),
        levelTexture = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 100, 100);
        Button Back, level;

        SpriteGameObject theMouse;
        GameObjectList levelButtons;
        int levelCounter, horizontalCounter, verticalCounter;
        // buttonoffset = distance between side and first button.
        // buttondistance = distance between each button.
        const int BUTTONOFFSET = 100, BUTTONDISTANCE = 200;
        public LevelSelector() : base()
        {
            levelCounter = System.IO.Directory.GetFiles("Content/Maps").Length;
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(mouse, Color.White);
            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));
            GameEnvironment.ChangeColor(levelTexture, new Color(179, 107, 0));

            Add(new SpriteGameObject(bg));

            Add(levelButtons = new GameObjectList());
            for (horizontalCounter = 0; horizontalCounter < levelCounter; horizontalCounter++)
            {
                levelButtons.Add(new Button(levelTexture, new Vector2(100 + ((horizontalCounter % 5) * 150), 300 + (verticalCounter * 200))));
                Add(new TextGameObject(Color.White, new Vector2(100 + ((horizontalCounter % 5) * 150), 300 + (verticalCounter * 200)), (horizontalCounter +1).ToString()));
                if (horizontalCounter % 5 == 4)
                {
                    verticalCounter++;
                }
            }
            Add(theMouse = new SpriteGameObject(mouse));


        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for (int i = 0; i < levelButtons.Children.Count(); i++)
            {
                if ((levelButtons.Children[i] as Button).isPressed)
                {
                    Console.WriteLine("Pressed");
                    (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).StartLevel(i+1);
                    GameEnvironment.GameStateManager.SwitchTo("PlayingState");
                }
            }
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            theMouse.position = inputHelper.MousePosition;
        }
    }
}
