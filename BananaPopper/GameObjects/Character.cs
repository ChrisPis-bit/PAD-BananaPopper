using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Character : TextGameObject
    {
        public string[] availableCharacters;
        public int selectedChar;

        public Character(Vector2 position) : base(" ", Color.White, "GameFont", position)
        {
            selectedChar = 0;
            this.position = position;
            availableCharacters = new string[] { "-", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
                "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            text = availableCharacters[selectedChar];
        }
    }
}
