using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Mouse : SpriteGameObject
    {
        Texture2D pointer, hand;
        public bool interact;

        public Mouse() : base("sprites/Mouse/Pointer")
        {
            pointer = GameEnvironment.ContentManager.Load<Texture2D>("sprites/Mouse/Pointer");
            hand = GameEnvironment.ContentManager.Load<Texture2D>("sprites/Mouse/Hand");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (interact)
            {
                texture = hand;
            }
            else
                texture = pointer;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            position = inputHelper.MousePosition;
        }
    }
}