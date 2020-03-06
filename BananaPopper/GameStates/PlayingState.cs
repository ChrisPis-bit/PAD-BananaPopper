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
        Texture2D mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10); //temporary texture for mouse
        Texture2D XYas = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 5, 5);
        Texture2D grid = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 1, 1);

        HUD hud = new HUD();
        Formula theFormula = new Formula(new Vector2(0 + GameEnvironment.GlobalScale, GameEnvironment.Screen.Y - GameEnvironment.GlobalScale));
        SpriteGameObject theMouse;
        Speler thePlayer = new Speler(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.GlobalScale * 5));

        float rc = 0; //Defines the a in y=ax+b



        public PlayingState() : base()
        {
            //Sets color for test textures
            GameEnvironment.ChangeColor(lineTest, Color.Blue);
            GameEnvironment.ChangeColor(bg, Color.Black);
            GameEnvironment.ChangeColor(mouse, Color.White);
            GameEnvironment.ChangeColor(XYas, Color.LightGray);
            GameEnvironment.ChangeColor(XYas, Color.LightGreen);

            GameEnvironment.ChangeColor(grid, new Color(Color.ForestGreen, 200));


            theMouse = new SpriteGameObject(mouse);
            //Add GameObjects here
            Add(theFormula);
            Add(theMouse);

            Add(hud);
            Add(thePlayer);


            for (int iButton = 0; iButton < 2; iButton++)
                Add(new Button("arrowKey", (float)Math.PI * (float)iButton,
                    new Vector2(theFormula.position.X + BananaPopper.GlobalScale / 2.5f, theFormula.position.Y - 10 + 30 * iButton)));
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (GameObject banaan in Children)
            {
                if (banaan is Banaan)
                {
                    if (banaan.position.X < 0 || banaan.position.X > GameEnvironment.Screen.X * 3 / 4 || banaan.position.Y < 0 || banaan.position.Y > GameEnvironment.Screen.Y)
                    {
                        banaan.Visible = false;
                    }
                }
            }
            for (int i = 0; i < Children.Count; i++)
            {
                if (!Children[i].Visible)
                {
                    if (Children[i] is Banaan)
                    {
                        remove(Children[i]);
                        i--;
                        Console.WriteLine("works");
                    }
                }
            }

            //Updates the formula on screen
            theFormula.UpdateFormula(rc, thePlayer.centerPos, thePlayer.Oorsprong);
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //For testing, changes line direction
            if (inputHelper.KeyPressed(Keys.Up)) rc++;
            if (inputHelper.KeyPressed(Keys.Down)) rc--;

            //For testing, flips line
            if (inputHelper.KeyPressed(Keys.F))
            {
                theFormula.flipLine = !theFormula.flipLine;
                
            }



            theMouse.position = inputHelper.MousePosition;

            if (inputHelper.KeyPressed(Keys.Space))
            {
                if (hud.numBananas != 0)
                {
                    Add(new Banaan(thePlayer.position, rc, theFormula.flipLine));
                    hud.numBananas--;
                }
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draws the bg across the screen
            spriteBatch.Draw(bg,
               new Rectangle(0, 0, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
               new Rectangle(0, 0, bg.Width, bg.Height),
               Color.White);

            for (int i = 0; i < 30; i++)
            {
                LineRenderer.DrawLine(spriteBatch, grid, new Vector2((GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale), 0), new Vector2(GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale, GameEnvironment.Screen.Y));
            }

            for (int j = 0; j < 15; j++)
            {
                LineRenderer.DrawLine(spriteBatch, grid, new Vector2(GameEnvironment.Screen.X, GameEnvironment.GlobalScale + j * GameEnvironment.GlobalScale), new Vector2(0, GameEnvironment.GlobalScale + j * GameEnvironment.GlobalScale));
            }

            //Draws lines of players movement
            LineRenderer.DrawLine(spriteBatch, XYas, new Vector2(0, thePlayer.Oorsprong.Y),
                                                         new Vector2(GameEnvironment.Screen.X, thePlayer.Oorsprong.Y));
            LineRenderer.DrawLine(spriteBatch, XYas, new Vector2(thePlayer.Oorsprong.X, 0),
                                                         new Vector2(thePlayer.Oorsprong.X, GameEnvironment.Screen.Y));

            //Draws a test line, startPosLine must be player coords
            LineRenderer.DrawLine(spriteBatch, lineTest, thePlayer.centerPos, theFormula.end);

            base.Draw(spriteBatch);
        }
    }
}
