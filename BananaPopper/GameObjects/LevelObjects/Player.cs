using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class Player : SpriteGameObject
    {
        public Vector2 centerPos,
            Oorsprong;
        private float maxSpeed;

        public Player() : base("sprites/IngameSprites/Monkey")
        {
            spriteEffect = SpriteEffects.FlipHorizontally;
            ResetPlayer(Vector2.Zero);
        }

        public void ResetPlayer(Vector2 startPosition)
        {
            Oorsprong = startPosition;
            Scale = GameEnvironment.TextureScale / 2 - 0.1f;
            position = startPosition - HitBox / 2;
            centerPos = position + HitBox / 2;
            maxSpeed = GameEnvironment.GlobalScale * 40;

            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //position = centerPos - origin;
            centerPos = position + HitBox / 2;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //Movement, checks if player is holding down mouse to swipe the player up
            if (inputHelper.MouseLeftButtonDown())
            {
                velocity.Y = inputHelper.MouseVelocity.Y * 50;

                //Checks if the player is close to a point on the grid
            }
            else if (centerPos.X % GameEnvironment.GlobalScale != 0 || centerPos.Y % GameEnvironment.GlobalScale != 0)
            {
                //Re-positions player if he's closer to the last grid point than the next one
                if (centerPos.X % GameEnvironment.GlobalScale < GameEnvironment.GlobalScale / 2)
                    position.X = centerPos.X - centerPos.X % GameEnvironment.GlobalScale - HitBox.X / 2;

                if (centerPos.Y % GameEnvironment.GlobalScale < GameEnvironment.GlobalScale / 2)
                    position.Y = centerPos.Y - centerPos.Y % GameEnvironment.GlobalScale - HitBox.Y / 2;


                //Re-positions player if he's closer to the next grid point than the last one
                if (centerPos.X % GameEnvironment.GlobalScale >= GameEnvironment.GlobalScale / 2)
                    position.X = centerPos.X + GameEnvironment.GlobalScale - (centerPos.X % GameEnvironment.GlobalScale) - HitBox.X / 2;

                if (centerPos.Y % GameEnvironment.GlobalScale >= GameEnvironment.GlobalScale / 2)
                    position.Y = centerPos.Y + GameEnvironment.GlobalScale - (centerPos.Y % GameEnvironment.GlobalScale) - HitBox.Y / 2;

                velocity = new Vector2(0);
            }
            else velocity = new Vector2(0);


            if (velocity.X > maxSpeed || velocity.X < -maxSpeed)
            {
                velocity.X = maxSpeed * Math.Sign(velocity.X);
            }
            if (velocity.Y > maxSpeed || velocity.Y < -maxSpeed)
            {
                velocity.Y = maxSpeed * Math.Sign(velocity.Y);
            }
        }

        public void CollideWithObject(SpriteGameObject obj)
        {
            if (obj.Overlaps(this))
            {
                if (velocity.X != 0)
                {
                    while (Overlaps(obj))
                    {
                        position.X += -Math.Sign(velocity.X);
                    }
                }
                else if (velocity.Y != 0)
                {
                    while (Overlaps(obj))
                    {
                        position.Y += -Math.Sign(velocity.Y);
                    }
                }
                velocity = Vector2.Zero;
            }
        }

        public void Flip(bool lookingRight)
        {
            if (lookingRight)
            {
                spriteEffect = SpriteEffects.None;
            }
            else
                spriteEffect = SpriteEffects.FlipHorizontally;
        }
    }
}
