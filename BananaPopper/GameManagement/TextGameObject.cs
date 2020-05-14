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
        public float scale;
        private Vector2 origin;

        public TextGameObject(Color color, Vector2 position, String text = "", String font = "GameFont") : base()
        {
            this.text = text;
            this.color = color;
            this.font = GameEnvironment.ContentManager.Load<SpriteFont>(font);
            this.position = position;
            scale = 1;
            origin = Vector2.Zero;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, text, GlobalPosition, color, 0f, Origin, scale, SpriteEffects.None, 0);
        }

        public Vector2 Size
        {
            get
            { return font.MeasureString(text); }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
    }
}
