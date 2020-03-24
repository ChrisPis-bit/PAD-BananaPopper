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
        public float a = 0, b = 0,
            scale = GameEnvironment.GlobalScale;
        public Vector2 end = new Vector2(0, 0);
        public bool flipLine;

        public Formula(Vector2 position) : base("", Color.White, "GameFont", position)
        {
            flipLine = true;
        }

        public void UpdateFormula(float a, Vector2 start, Vector2 origin)
        {
            a = -a;

            //Calculates b in y=ax+b
            float b = start.Y - a * start.X;

            //Sets end coördinate for the line. This way it has 2 points do draw on
            if (flipLine)
            {
                end = new Vector2(GameEnvironment.Screen.X, a * GameEnvironment.Screen.X + b);
            }
            else
                end = new Vector2(0, a * 0 + b);

            b = (start.Y - origin.Y) - a * (start.X - origin.X);

            text = "Y = " + -a + "X +" + Math.Round(-b / scale);
        }
    }
}
