using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace BananaPopper
{
    class TextGameObject : GameObject
    {
        public Color color;
        public String text;
        public SpriteFont font;

        public TextGameObject(String text, Color color, String font, Vector2 position) : base()
        {
            this.text = text;
            this.color = color;
            this.font = GameEnvironment.ContentManager.Load<SpriteFont>(font);
            this.position = position;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, text, GlobalPosition, color);
        }
    }
}
