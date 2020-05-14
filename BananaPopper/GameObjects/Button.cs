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
    class Button : SpriteGameObject
    {
        public bool isPressed, isHovered;

        public Button(String texture, Vector2 position, float angle = 0) : base(texture, angle)
        {        
            this.position = position;
            Reset();
        }
        public Button(Texture2D texture, Vector2 position, float angle = 0) : base(texture, angle)
        {
            this.position = position;
            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            isPressed = false;
            isHovered = false;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //Checks overlap with mouse, and detects if mouse presses on the button
            if (Overlaps(inputHelper.MousePosition, new Vector2(0)))
            {
                isHovered = true;
                if (inputHelper.MouseLeftButtonPressed())
                {
                    isPressed = true;
                }
                else
                    isPressed = false;
            }
            else
            {
                isHovered = false;
                isPressed = false;
            }
        }
    }
}
