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
    class Banana : SpriteGameObject
    {
        //This bool will stay true after being shot AND hitting an object
        private const float SCORE_MULT_INCREASE = 0.25f,
            SCORE_MULT_START = 1,
            SPINNING_SPEED = 0.2f,
            THROW_SPEED = 300;

        public bool shot;
        public int hitBalloonsAmount;
        private float scoreMult;

        public Banana(string assetName = "sprites/IngameSprites/Banana") : base(assetName)
        {
            scoreMult = SCORE_MULT_START;
            Visible = false;
            shot = false;
        }

        public override void Update(GameTime gameTime)
        {
            scoreMult = SCORE_MULT_START + SCORE_MULT_INCREASE * hitBalloonsAmount;

            base.Update(gameTime);
            angle -= SPINNING_SPEED;
        }

        public void Shoot(Vector2 position, float speed, bool flipLine)
        {
            hitBalloonsAmount = 0;
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);

            Scale = GameEnvironment.TextureScale / 2;
            this.position = position;

            Visible = true;
            shot = true;

            if (flipLine)
            {
                angle = (float)Math.Atan2(-speed, 1);
            }
            else
            {
                angle = (float)Math.Atan2(speed, -1);
            }

            velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * THROW_SPEED;
        }

        public float ScoreMultiplier
        {
            get { return scoreMult; }
        }
    }
}
