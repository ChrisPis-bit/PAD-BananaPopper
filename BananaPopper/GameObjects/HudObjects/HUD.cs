
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BananaPopper
{
    class HUD : GameObjectList
    {
        private const float BUTTON_X_OFFSET = 20;
        public const int HUD_X_OFFSET_RATIO = 13; //Defines how much of screen x the hud takes of the 16/9 ratio

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
            position = new Vector2((GameEnvironment.Screen.X / GameEnvironment.ScreenRatio.X) * HUD_X_OFFSET_RATIO, 0);

            Add(theBG = new SpriteGameObject("sprites/HudSprites/HUDbg"));
            theBG.Scale = (float)GameEnvironment.Screen.Y / theBG.texture.Height;
            Add(flipButton = new HudButton("sprites/HudSprites/FlipButton", new Vector2(BUTTON_X_OFFSET, GameEnvironment.Screen.Y / 6 * 4)));
            Add(restartButton = new HudButton("sprites/Hudsprites/ReturnButton", new Vector2(flipButton.position.X + flipButton.HitBox.X*2 + BUTTON_X_OFFSET, GameEnvironment.Screen.Y / 6 * 4)));
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
