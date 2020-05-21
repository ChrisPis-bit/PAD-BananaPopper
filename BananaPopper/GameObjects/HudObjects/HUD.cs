
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BananaPopper
{
    class HUD : GameObjectList
    {
        Vector2 hudFlipPosition;

        Button flipButton, restartButton;
        public bool flipLine;

        public SpriteGameObject theBG;
        public Formula theFormula;
        public Score theScore;
        public Timer theTimer;
        public Table theTable;
        public BananaCounter theBananaCounter;

        public HUD() : base()
        {
            position = new Vector2((GameEnvironment.Screen.X / 16) * 13, 0);

            Add(theBG = new SpriteGameObject("sprites/HudSprites/HUDbg"));
            theBG.Scale = (float)GameEnvironment.Screen.Y / theBG.texture.Height;
            Add(flipButton = new Button("sprites/HudSprites/FlipButton", new Vector2(20, GameEnvironment.Screen.Y / 6 * 4)));
            Add(restartButton = new Button("sprites/Hudsprites/ReturnButton", new Vector2(20, GameEnvironment.Screen.Y / 6 * 3)));
            flipLine = true;
            flipButton.Scale = 3;
            restartButton.Scale = 3;
            flipButton.Origin = Vector2.Zero;

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

            if (restartButton.isPressed)
            {
                GameEnvironment.GameStateManager.GetGameState("PlayingState").Reset();
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
