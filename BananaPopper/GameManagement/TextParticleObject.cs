﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class TextParticleObject : TextGameObject
    {
        protected int fadeTime; //Fade time defines how many frames the particle will be on screen

        protected float gravity;

        public TextParticleObject(string font, string text, Vector2 spawnPosition, Color color, Vector2 velocity, int fadeTime, float gravity = 0, float scale = 1) : base(color, spawnPosition, text, font)
        {
            this.fadeTime = fadeTime;
            this.gravity = gravity;
            this.velocity = velocity;
            this.scale = scale;
            Origin = Size / 2;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            fadeTime--;

            if (fadeTime < 0) Visible = false;

            velocity.Y += gravity;
        }
    }
}