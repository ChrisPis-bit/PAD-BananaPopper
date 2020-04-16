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
        private int score;

        public Score() : base("Score = 0", Color.White, "GameFont", Vector2.Zero)
        {
            //TEMPORARY
            position.X += GameEnvironment.Screen.X / 4;

            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            score = 0;
        }

        public int GetScore
        {
            get { return score; }
            set
            {
                score = value;
                text = "Score = " + score;
            }
        }
    }
}
