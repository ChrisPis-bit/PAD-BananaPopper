
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaPopper
{
    class HUD : GameObjectList
    {
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

        public HUD() : base()
        {
            numBananas = 10;
            numEBananas = 1;
            position = new Vector2(GameEnvironment.Screen.X / 2 - numBananas * 12, 40);
            positionE = new Vector2(GameEnvironment.Screen.X / 1 - numEBananas * 670, 40);
            banaan = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 20, 35);
            eBanaan = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 20, 35);
            GameEnvironment.ChangeColor(banaan, Color.Yellow);
            GameEnvironment.ChangeColor(eBanaan, Color.Red);
            offset = new Vector2(25, 0);
            offsetE = new Vector2(25, 0);
            Add(flipButton = new Button("arrowKey", new Vector2(500, 400)));
            flipLine = true;

            theFormula = new Formula(new Vector2(-GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y - GameEnvironment.Screen.Y / 10));
            Add(theFormula);
            Add(theScore = new Score());
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

        }

    }

    
}
