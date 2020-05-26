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
    public Texture2D hitBoxTest;

    public SpriteEffects spriteEffect;
    protected Vector2 origin, hitbox, visualScale;
    public float angle;
    private float scale, hitboxScale;

    public SpriteGameObject(String assetName, float angle = 0)
    {
        if (assetName.Length > 0)
            texture = GameEnvironment.ContentManager.Load<Texture2D>(assetName);

        this.angle = angle;
        Origin = Vector2.Zero;
        Scale = 1;
        spriteEffect = SpriteEffects.None;
        visualScale = new Vector2(Scale);
    }

    public SpriteGameObject(Texture2D texture, float angle = 0)
    {
        this.texture = texture;

        this.angle = angle;

        Origin = Vector2.Zero;
        Scale = 1;
        spriteEffect = SpriteEffects.None;
        visualScale = new Vector2(Scale);
    }

    public Vector2 HitBox
    {
        get { return hitbox; }
    }

    public Vector2 HitBoxPosition
    {
        get { return GlobalPosition - Origin * Scale + (new Vector2(texture.Width * Scale, texture.Height * Scale) / 2 - HitBox / 2); }
    }

    public Vector2 Origin
    {
        get { return origin; }
        set
        {
            origin = value;
        }
    }

    public float Scale
    {
        get { return scale; }
        set
        {
            scale = value;
            hitbox = new Vector2(texture.Width * scale, texture.Height * scale);
            VisualScale = new Vector2(scale);
        }
    }

    public Vector2 VisualScale
    {
        get { return visualScale; }
        set { visualScale = value; }
    }

    public float HitBoxScale
    {
        get { return hitboxScale; }
        set
        {
            hitbox *= value;
            hitboxScale = value;
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        /*GameEnvironment.ChangeColor(hitBoxTest, Color.Red);
        spriteBatch.Draw(hitBoxTest, HitBoxPosition, Color.White);*/

        if (visible)
            spriteBatch.Draw(texture, GlobalPosition, null, Color.White,
             angle,
             Origin,
             VisualScale,
             spriteEffect, 0f);
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

