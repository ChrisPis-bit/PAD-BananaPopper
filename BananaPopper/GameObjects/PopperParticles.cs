using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class PopperParticles : ParticleObjectList
    {
        private const float POP_SPEED = 100,
                            POP_GRAVITY = 1,

                            OBST_SPEED = 80,
                            OBST_GRAVITY = 2,

                            BANANA_SPEED = 50,
                            BANANA_GRAVITY = 2,

                            PLUS_SPEED = 50,
                            PLUS_GRAVITY = 2,

                            SCORE_TXT_Y_SPEED = -200,
                            SCORE_TXT_GRAVITY = 1,
                            SCORE_TXT_SCALE = 1.5f;

        private const int POP_AMOUNT = 30,
                          POP_FADETIME = 30,

                          BANANA_AMOUNT = 20,
                          BANANA_FADETIME = 30,

                          PLUS_AMOUNT = 20,
                          PLUS_FADETIME = 30,

                          OBST_AMOUNT = 40,
                          OBST_FADETIME = 30,

                          SCORE_TXT_FADETIME = 30;

        public PopperParticles() : base()
        {

        }

        public override void Reset()
        {
            base.Reset();

            Children.Clear();
        }

        public void SpawnBalloonPop(Vector2 position, float scale)
        {
            Vector2 speed = new Vector2(POP_SPEED) * scale;
            float gravity = POP_GRAVITY * scale;

            SpawnSpriteParticles("sprites/Particles/PopParticle", position, speed, POP_AMOUNT, POP_FADETIME, gravity, scale);
        }

        public void SpawnObstacleExp(Vector2 position, float scale)
        {
            Vector2 speed = new Vector2(OBST_SPEED) * scale;
            float gravity = OBST_GRAVITY * scale;

            SpawnSpriteParticles("sprites/Particles/ExpParticle", position, speed, OBST_AMOUNT, OBST_FADETIME, gravity, scale);
        }

        public void SpawnBananaPop(Vector2 position, float scale)
        {
            Vector2 speed = new Vector2(BANANA_SPEED) * scale;
            float gravity = BANANA_GRAVITY * scale;

            SpawnSpriteParticles("sprites/Particles/BananaParticle", position, speed, BANANA_AMOUNT, BANANA_FADETIME, gravity, scale);
        }
        public void SpawnPlusBananaPop(Vector2 position, float scale)
        {
            Vector2 speed = new Vector2(PLUS_SPEED) * scale;
            float gravity = PLUS_GRAVITY * scale;

            SpawnSpriteParticles("sprites/Particles/PlusParticle", position, speed, PLUS_AMOUNT, PLUS_FADETIME, gravity, scale);
        }

        public void SpawnScoreText(Vector2 position, int score)
        {

            SpawnTextParticles("GameFont", score + "+", position, Color.GreenYellow, new Vector2(0, SCORE_TXT_Y_SPEED), SCORE_TXT_FADETIME, 1, SCORE_TXT_GRAVITY, SCORE_TXT_SCALE);
        }
    }
}