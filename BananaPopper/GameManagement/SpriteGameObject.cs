using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpriteGameObject : GameObject
{
    public Texture2D texture;
    public Vector2 origin;
    public float angle;

    public SpriteGameObject(String assetName, float angle = 0)
    {
        if (assetName.Length > 0)
            texture = GameEnvironment.ContentManager.Load<Texture2D>(assetName);

        this.angle = angle;
        origin = new Vector2(texture.Width / 2, texture.Height / 2);
    }

    public SpriteGameObject(Texture2D texture, float angle = 0)
    {
        this.texture = texture;

        this.angle = angle;
        origin = new Vector2(texture.Width / 2, texture.Height / 2);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (visible)
            //spriteBatch.Draw(texture, GlobalPosition, Color.White);
            spriteBatch.Draw(texture, GlobalPosition + origin, null, Color.White,
             angle,
             origin,
             1,
             SpriteEffects.None, 0f);
    }

    public Boolean Overlaps(SpriteGameObject other)
    {
        if (visible)
        {
            float w0 = this.texture.Width,
                h0 = this.texture.Height,
                w1 = other.texture.Width,
                h1 = other.texture.Height,
                x0 = this.GlobalPosition.X,
                y0 = this.GlobalPosition.Y,
                x1 = other.GlobalPosition.X,
                y1 = other.GlobalPosition.Y;

            return !(x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1);
        }

        return false;
    }

    //Used for overlap with non-game objects, like mouse click
    public Boolean Overlaps(Vector2 position, Vector2 size)
    {
        if (visible)
        {
            float w0 = this.texture.Width,
                h0 = this.texture.Height,
                w1 = size.X,
                h1 = size.Y,
                x0 = this.GlobalPosition.X,
                y0 = this.GlobalPosition.Y,
                x1 = position.X,
                y1 = position.Y;

            return !(x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1);
        }

        return false;
    }

}

