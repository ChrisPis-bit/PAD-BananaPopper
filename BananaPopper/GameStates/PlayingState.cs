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
    class PlayingState : GameObjectList
    {
        Texture2D lineTest = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 30);
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y);
        Formula theFormula = new Formula();
        Vector2 startPosLine = new Vector2(0, 0);
        float rc = 0; //Defines the a in y=ax+b

        public PlayingState() : base()
        {
            //Sets color for test texture for line
            Color[] data = new Color[10 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            lineTest.SetData(data);

            Add(theFormula);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Updates the formula on screen
            theFormula.UpdateFormula(rc, startPosLine);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //For testing, changes line direction
            if (inputHelper.KeyPressed(Keys.Up)) rc++;
            if (inputHelper.KeyPressed(Keys.Down)) rc--;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            //Draws a test line
            LineRenderer.DrawLine(spriteBatch, lineTest, startPosLine, theFormula.end);
        }
    }
}
