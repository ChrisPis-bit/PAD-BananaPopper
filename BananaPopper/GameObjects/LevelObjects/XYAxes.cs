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
                Add(new Vine(new Vector2(GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale, origin.Y), (float)Math.PI/2));

                Add(new TextGameObject(Color.White, new Vector2(0 + i * GameEnvironment.GlobalScale, origin.Y), 
                    (Math.Round((0 + i * GameEnvironment.GlobalScale - origin.X) / GameEnvironment.GlobalScale)).ToString()));
            }

            for (int i = 0; i < GameEnvironment.Screen.Y / GameEnvironment.GlobalScale; i++)
            {
                Add(new Vine(new Vector2(origin.X, 0 + i * GameEnvironment.GlobalScale)));

                Add(new TextGameObject(Color.White, new Vector2(origin.X, 0 + i * GameEnvironment.GlobalScale), 
                    (Math.Round((0 + i * GameEnvironment.GlobalScale - origin.Y) / GameEnvironment.GlobalScale * -1)).ToString()));
            }
        }
    }
}
