using BananaPopper;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ParticleObjectList : GameObjectList
{
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        for (int iParticle = 0; iParticle < Children.Count(); iParticle++)
        {
            //Removes invisible particles
            if (!Children[iParticle].Visible)
            {
                Children.RemoveAt(iParticle);
                iParticle--;
            }
        }
    }

    //Places particles in the list with the filled in paramaters
    //The max velocity defines the maximum speed the particle can have once it spawns
    //The direction of the particle is randomized
    public void SpawnSpriteParticles(string assetname, Vector2 spawnPosition, Vector2 maxVelocity, int particleAmount, int fadeTime, float gravity = 0, float scale = 1)
    {
        for (int iParticle = 0; iParticle < particleAmount; iParticle++)
        {
            Add(new ParticleObject(assetname, spawnPosition, new Vector2(GameEnvironment.Random.Next((int)-maxVelocity.X, (int)maxVelocity.X), GameEnvironment.Random.Next((int)-maxVelocity.Y, (int)maxVelocity.Y)),
                fadeTime, gravity, scale));
        }
    }

    public void SpawnTextParticles(string font, string text, Vector2 spawnPosition, Color color, Vector2 velocity, int fadeTime, int particleAmount = 1, float gravity = 0, float scale = 1)
    {
        for (int iParticle = 0; iParticle < particleAmount; iParticle++)
        {
            Add(new TextParticleObject("GameFont", text, spawnPosition, color, velocity, fadeTime, gravity, scale));
        }
    }
}

