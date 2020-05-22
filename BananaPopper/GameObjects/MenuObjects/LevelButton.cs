using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class LevelButton : MenuButton
    {
        Texture2D cross;
        public bool levelAvailable;

        public LevelButton(Vector2 position, string text) : base(position, text, "sprites/MenuSprites/lvlButton")
        {
            cross = GameEnvironment.ContentManager.Load<Texture2D>("sprites/MenuSprites/Cross");
            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            levelAvailable = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            if (!levelAvailable)
            {
                spriteBatch.Draw(cross, button.GlobalPosition, null, Color.White,
                0,
                button.Origin,
                button.VisualScale,
                button.spriteEffect, 0f);
            }
        }
    }
}
