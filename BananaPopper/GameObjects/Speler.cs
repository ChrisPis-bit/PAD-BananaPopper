using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class Speler : SpriteGameObject
    {
        public Vector2 centerPos,
            Oorsprong;

        public Speler(Vector2 startPosition) : base(new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 40, 40))
        {
            GameEnvironment.ChangeColor(texture, Color.Green);
            Oorsprong = startPosition;

            position = startPosition - origin;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            centerPos = position + origin;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //Movement
            if (inputHelper.MouseLeftButtonDown())
            {
                if (centerPos == Oorsprong)
                {
                    if (Math.Abs(inputHelper.MouseVelocity.X) > Math.Abs(inputHelper.MouseVelocity.Y))
                    {
                        velocity.X = inputHelper.MouseVelocity.X * 50;
                    }
                    else velocity.Y = inputHelper.MouseVelocity.Y * 50;
                } 

                else if (centerPos.X != Oorsprong.X) {
                    velocity.X = inputHelper.MouseVelocity.X * 50;
                } 

                else if(centerPos.Y != Oorsprong.Y)
                {
                    velocity.Y = inputHelper.MouseVelocity.Y * 50;
                }

                else
                {
                    velocity = new Vector2(0);
                }
            } else if(Overlaps(Oorsprong - new Vector2(50), new Vector2(100, 100))){
                position = Oorsprong - origin;
                velocity = new Vector2(0);
            }
            else velocity = new Vector2(0);

        }
    }
}
