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
        Texture2D lineTest = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 5, 5); //temporary texture for line
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10); //temporary texture for bg

        Formula theFormula = new Formula(new Vector2(0 + GameEnvironment.GlobalScale, GameEnvironment.Screen.Y - GameEnvironment.GlobalScale));

        Vector2 startPosLine = new Vector2(200, GameEnvironment.Screen.Y / 2); //start position of the line
        float rc = 0; //Defines the a in y=ax+b



        public PlayingState() : base()
        {
            //Sets color for test texture for line
            Color[] data = new Color[lineTest.Width * lineTest.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            lineTest.SetData(data);

            //Sets color for temporary background
            Color[] data1 = new Color[10 * 10];
            for (int i = 0; i < data1.Length; ++i) data1[i] = Color.Black;
            bg.SetData(data1);



            //Add GameObjects here
            Add(theFormula);

            for (int iButton = 0; iButton < 2; iButton++)
                Add(new Button("arrowKey", (float)Math.PI * (float)iButton,
                    new Vector2(theFormula.position.X + GameEnvironment.GlobalScale/2.5f, theFormula.position.Y - 10 + 30 * iButton)));
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

            //For testing, flips line
            if (inputHelper.KeyPressed(Keys.Space)) theFormula.flipLine = !theFormula.flipLine;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draws the bg across the screen
            spriteBatch.Draw(bg,
               new Rectangle(0, 0, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
               new Rectangle(0, 0, bg.Width, bg.Height),
               Color.White);

            base.Draw(spriteBatch);

            //Draws a test line, startPosLine must be player coords
            LineRenderer.DrawLine(spriteBatch, lineTest, startPosLine, theFormula.end);
        }
    }
}
