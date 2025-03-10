﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class CharacterSelector : GameObjectList
    {
        Vector2 charOffset = new Vector2(GameEnvironment.Screen.X / 40, GameEnvironment.Screen.Y / 30);
        GameObjectList characters;
        private int selectedChar;
        public bool selected;

        Texture2D selectedBg, unSelectedBg;
        Button charBg;

        public CharacterSelector(int characterAmount, Vector2 position, bool selected = true) : base()
        {
            this.selected = selected;
            this.position = position;

            characters = new GameObjectList();
            selectedChar = 0;

            for (int iChar = 0; iChar < characterAmount; iChar++)
            {
                characters.Add(new Character(new Vector2(0 + charOffset.X * iChar, 0)));
            }

            selectedBg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 0 + (int)charOffset.X * characters.Children.Count(), (int)charOffset.Y);
            unSelectedBg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 0 + (int)charOffset.X * characters.Children.Count(), (int)charOffset.Y);
            GameEnvironment.ChangeColor(selectedBg, new Color(80, 80, 80));
            GameEnvironment.ChangeColor(unSelectedBg, new Color(80, 80, 80, 50));

            Add(charBg = new Button(selectedBg, Vector2.Zero));
            Add(characters);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            for (int i = 0; i < characters.Children.Count(); i++)
            {
                if (characters.Children[i] == characters.Children[selectedChar])
                {
                    (characters.Children[i] as Character).color = Color.LightCoral;
                }
                else
                    (characters.Children[i] as Character).color = Color.LightGray;
            }

            if (selected)
            {
                charBg.texture = selectedBg;
            }
            else
            {
                charBg.texture = unSelectedBg;
            }
        }

        public string Text
        {
            get
            {
                string text = "";
                for (int i = 0; i < characters.Children.Count(); i++)
                {
                    if ((characters.Children[i] as Character).text == "-")
                    {
                        text += " ";
                    }
                    else
                    {
                        text += (characters.Children[i] as Character).text;
                    }
                }
                return text;
            }
        }

        public bool isPressed
        {
            get { return charBg.isPressed; }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (selected)
            {
                //Changes selected character on the list with arrow keys
                if (inputHelper.KeyPressed(Keys.Right))
                {
                    selectedChar++;
                    if (selectedChar >= characters.Children.Count())
                    {
                        selectedChar = 0;
                    }
                }
                else if (inputHelper.KeyPressed(Keys.Left))
                {
                    selectedChar--;
                    if (selectedChar < 0)
                    {
                        selectedChar = characters.Children.Count() - 1;
                    }
                }

                //Changes character of the selected character
                if (inputHelper.KeyPressed(Keys.Down))
                {
                    (characters.Children[selectedChar] as Character).selectedChar++;
                    if ((characters.Children[selectedChar] as Character).selectedChar >= (characters.Children[selectedChar] as Character).availableCharacters.Count())
                    {
                        (characters.Children[selectedChar] as Character).selectedChar = 0;
                    }
                }
                else if (inputHelper.KeyPressed(Keys.Up))
                {
                    (characters.Children[selectedChar] as Character).selectedChar--;
                    if ((characters.Children[selectedChar] as Character).selectedChar < 0)
                    {
                        (characters.Children[selectedChar] as Character).selectedChar = (characters.Children[selectedChar] as Character).availableCharacters.Count() - 1;
                    }
                }
            }
        }
    }
}
