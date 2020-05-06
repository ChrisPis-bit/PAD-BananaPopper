using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper.GameObjects
{
    class Background : SpriteGameObject
    {
        Texture2D grid = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 1, 1);

        public Background() : base("sprites/Background")
        {
            GameEnvironment.ChangeColor(grid, new Color(Color.ForestGreen, 200));

            Scale = (float)GameEnvironment.Screen.X / texture.Width;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            for (int i = 0; i < GameEnvironment.Screen.X/GameEnvironment.GlobalScale; i++)
            {
                LineRenderer.DrawLine(spriteBatch, grid, new Vector2((GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale), 0), new Vector2(GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale, GameEnvironment.Screen.Y));
            }

            for (int j = 0; j < GameEnvironment.Screen.Y / GameEnvironment.GlobalScale; j++)
            {
                LineRenderer.DrawLine(spriteBatch, grid, new Vector2(GameEnvironment.Screen.X, GameEnvironment.GlobalScale + j * GameEnvironment.GlobalScale), new Vector2(0, GameEnvironment.GlobalScale + j * GameEnvironment.GlobalScale));
            }
        }
    }
}
