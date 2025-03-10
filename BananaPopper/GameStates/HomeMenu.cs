﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;



namespace BananaPopper
{
    class HomeMenu : MenuState
    {
        MenuButton startGame;

        private SpriteGameObject title;

        public HomeMenu() : base()
        {
            Add(startGame = new MenuButton(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y / 10*3), "Start Game"));

            Add(title = new SpriteGameObject("sprites/MenuSprites/Title"));
            title.Origin = title.HitBox / 2;
            title.Scale = 4;
            title.position = new Vector2(GameEnvironment.Screen.X / 2, title.HitBox.Y / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Button presses for each button on screen
            if (startGame.isPressed)
            {
                //Switches to the playingstate so the player can play the game
                GameEnvironment.GameStateManager.SwitchTo("LevelSelector");
            }

            if (backButton.isPressed)
                GameEnvironment.GameStateManager.SwitchTo("Startup");
        }
    }
}
