using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Login : GameObjectList
    {
        TextGameObject test;
        public Login() : base()
        {
            GameEnvironment.DatabaseHelper.ExecuteQuery("update Highscores set time = 30 where Users_id = 102;");

            Add(test = new TextGameObject("", Color.White, "GameFont", new Vector2(0)));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            
            
        }
    }
}
