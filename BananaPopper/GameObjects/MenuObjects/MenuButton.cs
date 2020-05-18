using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class MenuButton : GameObjectList
    {
        private const float BUTTON_SCALE = 3,
                            TEXT_SCALE = 1.5f;

        private Button button;
        private TextGameObject text;

        private float tweenTime = 0;
        private const float TWEEN_SPEED = 0.1f,
                            TWEEN_AMPLITUDE = 0.01f;

        public MenuButton(Vector2 position, string text) : base()
        {
            this.position = position;
            Add(button = new Button("sprites/MenuSprites/Button", Vector2.Zero));
            button.Origin = button.HitBox / 2;
            button.Scale = BUTTON_SCALE;
            button.position = button.HitBox / 2;
            Add(this.text = new TextGameObject(Color.White, button.HitBox/2, text));
            this.text.Origin = this.text.Size / 2;
            this.text.scale = TEXT_SCALE;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            tweenTime += TWEEN_SPEED;
            if (button.isHovered)
            {
                button.VisualScale = new Vector2(button.VisualScale.X + TWEEN_AMPLITUDE * (float)Math.Sin(tweenTime - Math.PI), button.VisualScale.Y + TWEEN_AMPLITUDE * (float)Math.Sin(tweenTime - Math.PI));
            }
            else
                button.VisualScale = new Vector2(BUTTON_SCALE);
        }

        public bool isPressed
        {
            get { return button.isPressed; }
        }

        public bool isHovered
        {
            get { return button.isHovered; }
        }

        public Vector2 HitBox
        {
            get { return button.HitBox; }
        }
    }
}
