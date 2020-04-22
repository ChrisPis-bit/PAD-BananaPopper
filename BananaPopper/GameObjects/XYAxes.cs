using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class XYAxes : GameObjectList
    {
        Texture2D XYas = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 5, 5);
        Vector2 origin;

        public XYAxes() : base()
        {
            GameEnvironment.ChangeColor(XYas, Color.LightGreen);

            ResetAxes(Vector2.Zero);
        }

        public void ResetAxes(Vector2 origin)
        {
            Children.Clear();

            this.origin = origin;


            //Adds the numbers on the X and Y axes
            //Uses 2 for loops for the X and Y lines
            for (int i = 0; i < GameEnvironment.Screen.X / GameEnvironment.GlobalScale; i++)
            {
                Add(new TextGameObject(Color.White, new Vector2(0 + i * GameEnvironment.GlobalScale, origin.Y), 
                    ((0 + i * GameEnvironment.GlobalScale - origin.X) / GameEnvironment.GlobalScale).ToString()));
            }

            for (int i = 0; i < GameEnvironment.Screen.Y / GameEnvironment.GlobalScale; i++)
            {
                Add(new TextGameObject(Color.White, new Vector2(origin.X, 0 + i * GameEnvironment.GlobalScale), 
                    ((0 + i * GameEnvironment.GlobalScale - origin.Y) / GameEnvironment.GlobalScale * -1).ToString()));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            //Draws lines of players movement
            LineRenderer.DrawLine(spriteBatch, XYas, new Vector2(0, origin.Y),
                                                         new Vector2(GameEnvironment.Screen.X, origin.Y));
            LineRenderer.DrawLine(spriteBatch, XYas, new Vector2(origin.X, 0),
                                                         new Vector2(origin.X, GameEnvironment.Screen.Y));
        }
    }
}
