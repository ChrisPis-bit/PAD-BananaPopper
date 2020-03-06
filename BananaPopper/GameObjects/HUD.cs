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
    class HUD : GameObjectList
    {
      public int numBananas;
        Texture2D banaan;
        Vector2 offset;
        public HUD() : base()
        {
            numBananas = 10;
            position = new Vector2(GameEnvironment.Screen.X / 2 - numBananas * 12, 40);
            banaan = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 20, 35);
            GameEnvironment.ChangeColor(banaan, Color.Yellow);
            offset = new Vector2(25, 0);

           
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            for (int i = 0; i<numBananas; i++)
            {
                
                spriteBatch.Draw(banaan, position + i*offset , Color.White);
            }
        }

    }
}
