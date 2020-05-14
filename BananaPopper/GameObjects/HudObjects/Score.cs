using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Score : TextGameObject
    {
        private float score;
        private const int xOffset = 10;

        public Score() : base(Color.White, Vector2.Zero, "Score = 0")
        {        
            position = new Vector2 (xOffset, GameEnvironment.Screen.Y / 6);

            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            score = 0;
        }

        public float GetScore
        {
            get { return score; }
            set
            {
                score = value;
                text = "Score = " + (int)score;
            }
        }
    }
}
