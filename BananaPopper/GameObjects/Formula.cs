using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class Formula : TextGameObject
    {
        public float a = 0, b = 0;
        public Vector2 end = new Vector2(0,0);

        public Formula() : base("", Color.White, "GameFont", new Vector2(GameEnvironment.Screen.Y - 30, 20))
        {

        }

        public void UpdateFormula(float a, Vector2 start)
        {
            float b = start.Y - a * start.X;

            //Sets end coördinate for the line. This way it has 2 points do draw on
            end = new Vector2(GameEnvironment.Screen.X, (a * GameEnvironment.Screen.X + b) * -1 + GameEnvironment.Screen.Y);

            text = "Y = " + a + "X +" + b;
        }
    }
}
