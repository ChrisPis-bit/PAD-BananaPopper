using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace BananaPopper
{
   class TextBubble : GameObjectList
    {
        Texture2D blockColour;
        private Button textBlock;
        //veranderen naar een gewoon vierkant
        private TextGameObject gameText;
        

        public TextBubble(Vector2 position, string text)
        { 
            blockColour = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 700, 300);
            GameEnvironment.ChangeColor(blockColour, new Color(75,75,75,200));
            this.position = position;
            Add(textBlock = new Button(blockColour, Vector2.Zero));
            
            textBlock.Origin = textBlock.HitBox / 2;
            //waarom .Zero? Is dit zodat hij nog geen plaats heeft?
            //button.origin + button.HitBox, wat doen deze dingen?
            Add(gameText = new TextGameObject(Color.White, new Vector2(textBlock.HitBox.X/8-50, textBlock.HitBox.Y/4)-textBlock.HitBox/2, text));
            //Waarom kan ik hier geen HitBox gebruiken?

        }
    }
            

        /* if(eerste level gestart){
         * laat de tutorial zien (if level 1 is played for the first time) show tutorial?
        }
        
         if(nieuwe feature wordt laten zien){
        start nieuw stukje tutorial  (doormiddel van booleans op true en false zetten?)
        }

        creeër een compleet nieuw level die alle stukjes tutorial in een keer laten zien
         */


    }

   
