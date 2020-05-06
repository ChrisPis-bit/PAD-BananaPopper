using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class Table : GameObjectList
    {
        private const int xOffset = 10;

        List<Vector2> points;

        //Defines spacing between each value in the table
        Vector2 pointOffset = new Vector2(50, 10);
        Texture2D lineTexture = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 1, 2);

        public Table() : base()
        {
            position = new Vector2(xOffset, GameEnvironment.Screen.Y / 6 * 3);

            GameEnvironment.ChangeColor(lineTexture, Color.White);

            ResetTable(new List<Vector2>(), Vector2.Zero);
        }

        public void ResetTable(List<Vector2> points, Vector2 origin)
        {
            Children.Clear();

            if (points.Count() != 0)
            {
                //Adds the X and Y indication to the table
                Add(new TextGameObject(Color.White, new Vector2(pointOffset.X / 2, 0), "X"));
                Add(new TextGameObject(Color.White, new Vector2(pointOffset.X / 2, pointOffset.Y + (Children[Children.Count() - 1] as TextGameObject).Size.Y), "Y"));

                this.points = points;

                //Sorts the list, so that the X value is always ascending in the table
                if (this.points[0].X > this.points[points.Count() - 1].X)
                    this.points.Reverse();

                //Adds each point given to the table instance
                for (int i = 0; i < points.Count(); i++)
                {
                    Add(new TextGameObject(Color.White, 
                        new Vector2(pointOffset.X + Children[Children.Count()-1].position.X + (Children[Children.Count() - 1] as TextGameObject).Size.X, 0), 
                        Math.Round((points[i].X - origin.X) / GameEnvironment.GlobalScale).ToString()));

                    Add(new TextGameObject(Color.White, 
                        new Vector2(pointOffset.X + Children[Children.Count() - 2].position.X + (Children[Children.Count() - 1] as TextGameObject).Size.X, 
                        pointOffset.Y + (Children[Children.Count() - 1] as TextGameObject).Size.Y), 
                        Math.Floor((int)(points[i].Y - origin.Y) / GameEnvironment.GlobalScale * -1).ToString()));
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            if (Children.Count() > 0)
            {

                //Draws line that seperates x and y parts of the table
                LineRenderer.DrawLine(spriteBatch, lineTexture, new Vector2(GlobalPosition.X, GlobalPosition.Y + (Children[Children.Count() - 1] as TextGameObject).Size.Y),
                 new Vector2(Children[Children.Count()-1].GlobalPosition.X + (Children[Children.Count() - 1] as TextGameObject).Size.X, GlobalPosition.Y + (Children[Children.Count() - 1] as TextGameObject).Size.Y));

                //Draws a line inbetween every point
                for (int i = 0; i < Children.Count() - 2; i += 2)
                {
                    LineRenderer.DrawLine(spriteBatch, lineTexture, new Vector2(Children[i].GlobalPosition.X + (Children[i] as TextGameObject).Size.X + pointOffset.X/2, position.Y),
                         new Vector2(Children[i].GlobalPosition.X + (Children[i] as TextGameObject).Size.X + pointOffset.X/2, position.Y + (Children[i] as TextGameObject).Size.Y * 2));
                }
            }
        }
    }
}