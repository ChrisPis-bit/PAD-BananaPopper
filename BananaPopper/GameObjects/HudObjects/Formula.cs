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
    class Formula : GameObjectList
    {
        private const float TEXT_SCALE = 1.5f,
            BUTTON_SCALE = 2,
            BUTTON_X_OFFSET = 100,
            RC_CHANGE = 0.5f,
            xOffset = 10;

        public float scale;
        public Vector2 end = new Vector2(0, 0);
        public TextGameObject formulaText;
        Button upRC, downRC;
        private float rc;
        /*float[] rc = new float[] { 1, -1, 0.5f, -0.5f, 2, -2 }; //Defines the a in y=ax+b
        int iRc = 0;*/

        public Formula() : base()
        {
            Reset();

            //Position in the hud
            position = new Vector2(xOffset, GameEnvironment.Screen.Y / 6 * 5);

            Add(upRC = new Button("arrowKey", Vector2.Zero));
            Add(downRC = new Button("arrowKey", Vector2.Zero));

            upRC.Scale = BUTTON_SCALE;
            downRC.Scale = BUTTON_SCALE;

            Add(formulaText = new TextGameObject(Color.White, new Vector2(0, upRC.HitBox.X), "Y ="));
            formulaText.scale = TEXT_SCALE;

            upRC.position = new Vector2(BUTTON_X_OFFSET, 0);
            downRC.Origin = new Vector2(downRC.texture.Width / 2, downRC.texture.Height / 2);
            downRC.position = new Vector2(BUTTON_X_OFFSET, formulaText.position.Y + formulaText.Size.Y * formulaText.scale) + downRC.Origin * BUTTON_SCALE;
            downRC.angle = (float)Math.PI;
        }

        public override void Reset()
        {
            base.Reset();

            scale = GameEnvironment.GlobalScale;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (upRC.isPressed) rc += RC_CHANGE;
            if (downRC.isPressed) rc -= RC_CHANGE;

            //Prevents the array from going out of bounds
            /*if (iRc >= rc.Length)
            {
                iRc = 0;
            }
            else if (iRc < 0)
            {
                iRc = rc.Length - 1;
            }
            }*/
        }

        public void UpdateFormula(Vector2 start, Vector2 origin, bool flipline)
        {
            float a = -RC;

            //Calculates b in y=ax+b
            float b = start.Y - a * start.X;

            //Sets end coördinate for the line. This way it has 2 points do draw on
            if (flipline)
            {
                end = new Vector2(GameEnvironment.Screen.X, a * GameEnvironment.Screen.X + b);
            }
            else
                end = new Vector2(0, a * 0 + b);

            //Re-calculates the b so it's accurate for the displayed text
            b = (start.Y - origin.Y) - a * (start.X - origin.X);

            string bText;

            //Places an -/+ behind the b if it's negative/positive
            if (Math.Round(-b / scale) < 0)
            {
                bText = Math.Round(-b / scale).ToString();
            }
            else
                bText = "+" + Math.Round(-b / scale);

            //Displayed text
            formulaText.text = "Y = " + -a + "X " + bText;
        }

        public float RC
        {
            get { return rc; }
        }
    }
}
