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
    public Vector2 origin, hitbox;
    public float angle,
        scale;

    public SpriteGameObject(String assetName, float angle = 0)
    {
        if (assetName.Length > 0)
            texture = GameEnvironment.ContentManager.Load<Texture2D>(assetName);

        this.angle = angle;
        origin = new Vector2(texture.Width / 2, texture.Height / 2);
        scale = GameEnvironment.TextureScale;
        hitbox = new Vector2(texture.Width * scale, texture.Height * scale);
    }

    public SpriteGameObject(Texture2D texture, float angle = 0)
    {
        this.texture = texture;

        this.angle = angle;
        origin = new Vector2(texture.Width / 2, texture.Height / 2);
        scale = GameEnvironment.TextureScale;
        hitbox = new Vector2(texture.Width * scale, texture.Height * scale);
    }

    public Vector2 HitBox
    {
        get { return hitbox; }
    }

    public Vector2 HitBoxPosition
    {
        get { return new Vector2(GlobalPosition.X - (hitbox.X / 2 - texture.Width / 2), GlobalPosition.Y - (hitbox.Y / 2 - texture.Height / 2)); }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (visible)
            //spriteBatch.Draw(texture, GlobalPosition, Color.White);
            spriteBatch.Draw(texture, GlobalPosition + origin, null, Color.White,
             angle,
             origin,
             scale,
             SpriteEffects.None, 0f);
    }

    public override void Update(GameTime gameTime)
    {
        if (Visible)
        {
            base.Update(gameTime);
        }
    }

    public Boolean Overlaps(SpriteGameObject other)
    {
        if (visible)
        {
            float w0 = this.HitBox.X,
                h0 = this.HitBox.Y,
                w1 = other.HitBox.X,
                h1 = other.HitBox.Y,
                x0 = this.HitBoxPosition.X,
                y0 = this.HitBoxPosition.Y,
                x1 = other.HitBoxPosition.X,
                y1 = other.HitBoxPosition.Y;

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
            float w0 = this.HitBox.X,
                h0 = this.HitBox.Y,
                w1 = size.X,
                h1 = size.Y,
                x0 = this.HitBoxPosition.X,
                y0 = this.HitBoxPosition.Y,
                x1 = position.X,
                y1 = position.Y;

            return !(x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1);
        }

        return false;
    }

}

