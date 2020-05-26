
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BananaPopper
{
    class HUD : GameObjectList
    {
        private const float BUTTON_X_OFFSET = 20;
        public const int HOME_BUTTON_SCALE = 2,
                         HUD_X_OFFSET_RATIO = 13; //Defines how much of screen x the hud takes of the 16/9 ratio

        Button flipButton, restartButton, homeButton;
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
            Add(homeButton = new HudButton("sprites/Hudsprites/Home", Vector2.Zero));
            homeButton.Scale = HOME_BUTTON_SCALE;
            homeButton.position = new Vector2(theBG.HitBox.X - homeButton.HitBox.X, 0);
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

            if (homeButton.isPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
            }
        }
    }
}
