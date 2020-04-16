
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BananaPopper
{
    class HUD : GameObjectList
    {
        Texture2D HudShade;

        public int numBananas;
        public int numEBananas;
        Texture2D banaan;
        Texture2D eBanaan;

        Vector2 offset;
        Vector2 offsetE;

        Button flipButton;
        public bool flipLine;

        public Formula theFormula;
        public Score theScore;
        public Timer theTimer;
        public Table theTable;

        public HUD() : base()
        {
            Reset();

            position = new Vector2((GameEnvironment.Screen.X / 5) * 4, 0);
            positionE = new Vector2(GameEnvironment.Screen.X / 1 - numEBananas * 670, 40);

            HudShade = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X - (int)position.X, GameEnvironment.Screen.Y);
            GameEnvironment.ChangeColor(HudShade, new Color(Color.Black, 100));

            banaan = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 20, 35);
            eBanaan = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 20, 35);
            GameEnvironment.ChangeColor(banaan, Color.Yellow);
            GameEnvironment.ChangeColor(eBanaan, Color.Red);

            offset = new Vector2(25, 0);
            offsetE = new Vector2(25, 0);

            Add(new SpriteGameObject(HudShade));
            Add(flipButton = new Button("arrowKey", new Vector2(0, (GameEnvironment.Screen.X / 5) * 2)));
            flipLine = true;
      
            Add(theFormula = new Formula());
            Add(theScore = new Score());
            Add(theTimer = new Timer());
            Add(theTable = new Table());
        }

        public override void Reset()
        {
            base.Reset();

            numBananas = 10;
            numEBananas = 1;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            for (int i = 0; i < numBananas; i++)
            {
                spriteBatch.Draw(banaan, position + i * offset, Color.White);
            }

            for (int i = 0; i < numEBananas; i++)
            {
                spriteBatch.Draw(eBanaan, positionE + i * offsetE, Color.White);
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (flipButton.isPressed)
            {
                flipLine = !flipLine;
            }
        }
    }  
}
