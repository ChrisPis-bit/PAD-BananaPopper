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
        public bool isPressed;

        public Button(String texture, float angle, Vector2 position) : base(texture, angle)
        {
            isPressed = false;
            this.position = position;
            scale /= 2;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //Checks overlap with mouse, and detects if mouse presses on the button
            if (Overlaps(inputHelper.MousePosition, new Vector2(0)) && inputHelper.MouseLeftButtonPressed())
            {
                isPressed = true;
            }
            else
                isPressed = false;
        }
    }
}
