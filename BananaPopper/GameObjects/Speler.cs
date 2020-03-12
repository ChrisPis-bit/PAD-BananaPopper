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
            centerPos = position + origin;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //position = centerPos - origin;
            centerPos = position + origin;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //Movement, checks if player is holding down mouse to swipe the player up
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

                //Free movement on x if player is gone from 0,0
                else if (centerPos.X != Oorsprong.X)
                {
                    velocity.X = inputHelper.MouseVelocity.X * 50;
                }

                //Free movement on y if player is gone from 0,0
                else if (centerPos.Y != Oorsprong.Y)
                {
                    velocity.Y = inputHelper.MouseVelocity.Y * 50;
                }
                else
                {
                    velocity = new Vector2(0);
                }

                //Checks if the player is close to a point on the grid
            }
            else if (centerPos.X % GameEnvironment.GlobalScale != 0 || centerPos.Y % GameEnvironment.GlobalScale != 0)
            {
                //Re-positions player if he's closer to the last grid point than the next one
                if (centerPos.X % GameEnvironment.GlobalScale < GameEnvironment.GlobalScale / 2)
                    position.X = centerPos.X - centerPos.X % GameEnvironment.GlobalScale - origin.X;
                
                if (centerPos.Y % GameEnvironment.GlobalScale < GameEnvironment.GlobalScale / 2)
                    position.Y = centerPos.Y - centerPos.Y % GameEnvironment.GlobalScale - origin.Y;


                //Re-positions player if he's closer to the next grid point than the last one
                if (centerPos.X % GameEnvironment.GlobalScale >= GameEnvironment.GlobalScale / 2)              
                    position.X = centerPos.X + GameEnvironment.GlobalScale - (centerPos.X % GameEnvironment.GlobalScale) - origin.X;
                
                if (centerPos.Y % GameEnvironment.GlobalScale >= GameEnvironment.GlobalScale / 2)
                    position.Y = centerPos.Y + GameEnvironment.GlobalScale - (centerPos.Y % GameEnvironment.GlobalScale) - origin.Y;

                velocity = new Vector2(0);
            }
            else velocity = new Vector2(0);

            Console.WriteLine(centerPos.X % GameEnvironment.GlobalScale);
        }
    }
}
