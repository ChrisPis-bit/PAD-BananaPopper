
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BananaPopper
{
    class HUD : GameObjectList
    {
        Texture2D HudShade;

        Vector2 hudFlipPosition;

        Button flipButton;
        public bool flipLine;

        public Formula theFormula;
        public Score theScore;
        public Timer theTimer;
        public Table theTable;
        public BananaCounter theBananaCounter;

        public HUD() : base()
        {
            position = new Vector2((GameEnvironment.Screen.X / 5) * 4, 0);
            HudShade = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X - (int)hudFlipPosition.X, GameEnvironment.Screen.Y);
            GameEnvironment.ChangeColor(HudShade, new Color(Color.Black, 100));

            Add(new SpriteGameObject(HudShade));
            Add(flipButton = new Button("arrowKey", new Vector2(0, (GameEnvironment.Screen.X / 5) * 2)));
            flipLine = true;

            Add(theFormula = new Formula());
            Add(theScore = new Score());
            Add(theTimer = new Timer());
            Add(theTable = new Table());
            Add(theBananaCounter = new BananaCounter());

            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            theScore.GetScore = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (flipButton.isPressed)
            {
                flipLine = !flipLine;
            }

            /*if (flipLine)
            {
                position = Vector2.Zero;
            }
            else
                position = hudFlipPosition;*/
        }
    }
}
