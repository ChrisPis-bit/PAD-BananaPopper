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
        List<Vector2> points;

        //Defines spacing between each value in the table
        Vector2 pointOffset = new Vector2(GameEnvironment.Screen.X / 20, GameEnvironment.Screen.Y / 25);
        Texture2D lineTexture = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 2, 2);

        public Table(int pointAmount, List<Vector2> points, Vector2 origin, Vector2 position) : base()
        {
            GameEnvironment.ChangeColor(lineTexture, Color.White);

            this.position = position;
            this.points = points;

            //Sorts the list, so that the X value is always ascending in the table
            if (this.points[0].X > this.points[points.Count() - 1].X)
                this.points.Reverse();

            //Adds the X and Y indication to the table
            Add(new TextGameObject("X", Color.White, "GameFont", new Vector2(pointOffset.X / 2, 0)));
            Add(new TextGameObject("Y", Color.White, "GameFont", new Vector2(pointOffset.X / 2, pointOffset.Y)));


            //Adds each point given to the table instance
            for (int i = 0; i < pointAmount; i++)
            {
                Add(new TextGameObject(Math.Round((points[i].X - origin.X) / GameEnvironment.GlobalScale).ToString(),
                    Color.White, "GameFont", new Vector2(pointOffset.X + pointOffset.X / 2 + i * pointOffset.X, 0)));

                Add(new TextGameObject(Math.Round((points[i].Y - origin.Y) / GameEnvironment.GlobalScale * -1).ToString(),
                    Color.White, "GameFont", new Vector2(pointOffset.X + pointOffset.X / 2 + i * pointOffset.X, pointOffset.Y)));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            LineRenderer.DrawLine(spriteBatch, lineTexture, new Vector2(position.X, position.Y + pointOffset.Y),
                                                            new Vector2(Children[Children.Count() - 1].GlobalPosition.X - pointOffset.X, position.Y + pointOffset.Y));

            //Draws a line inbetween every point
            for (int i = 0; i < Children.Count() - 2; i += 2)
            {
                LineRenderer.DrawLine(spriteBatch, lineTexture, new Vector2(Children[i].GlobalPosition.X + pointOffset.X / 2, position.Y),
                     new Vector2(Children[i].GlobalPosition.X + pointOffset.X / 2, position.Y + pointOffset.Y));
            }
        }
    }
}