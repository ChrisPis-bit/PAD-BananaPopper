using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class BananaCounter : GameObjectList
    {
        const float SCALE = 1.5f;
        public BananaCounter() : base()
        {

        }

        //Resets the banana amount using the amount of bananas in the bullet gameobjectlist in playingstate
        public void ResetCounter(GameObjectList bananas)
        {
            Children.Clear();

            for (int i = bananas.Children.Count() - 1; i >= 0; i--)
            {
                if (bananas.Children[i] is ExplosiveBanana)
                {
                    Add(new SpriteGameObject("sprites/IngameSprites/ExplosiveBanana"));
                }
                else if (bananas.Children[i] is Banana)
                {
                    Add(new SpriteGameObject("sprites/IngameSprites/Banana"));
                }
                (Children[Children.Count() - 1] as SpriteGameObject).Scale = SCALE;
                Children[Children.Count() - 1].position = new Vector2(Children.Count() * (Children[0] as SpriteGameObject).HitBox.X - (Children[0] as SpriteGameObject).HitBox.X, 0);
            }
        }

        //Either removes or adds a banana
        //Adds if the value goes up, removes if it goes down
        public int Amount
        {
            get { return Children.Count(); }
            set
            {
                if (value < Children.Count())
                {
                    for (int i = 0; i < Children.Count() - value; i++)
                    {
                        removeAt(Children.Count() - 1);
                    }
                }
                else if (value > Children.Count())
                {
                    for (int i = 0; i < value - Children.Count(); i++)
                    {
                        Add(new SpriteGameObject("sprites/IngameSprites/Banana"));
                        (Children[Children.Count() - 1] as SpriteGameObject).Scale = SCALE;
                        Children[Children.Count() - 1].position = new Vector2(i * (Children[Children.Count() - 1] as SpriteGameObject).HitBox.X, 0);
                    }
                }
            }
        }
    }
}
