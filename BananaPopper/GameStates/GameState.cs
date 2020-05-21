using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class GameState : GameObjectList
    {
        protected Mouse theMouse;

        public GameState() : base()
        {
            Add(theMouse = new Mouse());
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (GameObject button in Children)
            {
                if ((button is Button && (button as Button).isHovered) || (button is MenuButton && (button as MenuButton).isHovered))
                {
                    theMouse.interact = true;
                    break;
                }
                else theMouse.interact = false;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            theMouse.Draw(gameTime, spriteBatch);
        }
    }
}