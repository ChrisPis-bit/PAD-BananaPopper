using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper
{
    class Login : GameObjectList
    {
        const int MAX_CHARACTERS = 10;

        public bool createAccount;

        Vector2 loginInfoOffset = new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 3);

        CharacterSelector userName, passWord;
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X, GameEnvironment.Screen.Y);

        public Login() : base()
        {
            //Bool defines if player is login in or creating an account
            createAccount = false;

            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));

            Add(new SpriteGameObject(bg));
            Add(userName = new CharacterSelector(MAX_CHARACTERS, loginInfoOffset));
            Add(passWord = new CharacterSelector(MAX_CHARACTERS, new Vector2(loginInfoOffset.X, loginInfoOffset.Y * 2), false));

            Add(new TextGameObject("Username", Color.White, "GameFont", new Vector2(userName.position.X, userName.position.Y - 80)));
            Add(new TextGameObject("Password", Color.White, "GameFont", new Vector2(passWord.position.X, passWord.position.Y - 80)));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Enter))
            {
                // Creates/Logs into account if all info is filled in
                if (passWord.selected)
                {
                    if (createAccount)
                    {
                        CreateAccount(userName.Text, passWord.Text);
                    }
                    else
                        LoginPlayer(userName.Text, passWord.Text);
                }

                //Toggles to password  if username was previously selected
                else
                {
                    passWord.selected = true;
                    userName.selected = false;
                }
            }

            //Toggles back to username selector if backspace is pressed
            if (inputHelper.KeyPressed(Keys.Back) && !userName.selected)
            {
                userName.selected = true;
                passWord.selected = false;
            }
        }

        //Used to log into an account
        void LoginPlayer(string userName, string passWord)
        {
            try
            {
                GameEnvironment.DatabaseHelper.con.Open();

                //Query selects info from the player table in the database
                string sql = "SELECT id, TotalScore, Money FROM Players WHERE UserName = '" + userName + "' AND Password = '" + passWord + "';";

                MySqlCommand cmd = new MySqlCommand(sql, GameEnvironment.DatabaseHelper.con);

                //Executes select statement
                MySqlDataReader cmdData = cmd.ExecuteReader();

                //Reads the results
                if (cmdData.Read())
                {
                    Console.WriteLine(cmdData[0] + " -- " + cmdData[1] + " -- " + cmdData[2]);

                    //Switches to playingstate for now
                    GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
                }
                //If the account doesnt exist, it can't execute the Read() function
                else
                    Console.WriteLine("Couldn't find account with this info");

                cmdData.Close();
            }
            //For if the player doesn't have internet connection
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            GameEnvironment.DatabaseHelper.con.Close();
        }

        public void CreateAccount(string userName, string passWord)
        {
            try
            {
                GameEnvironment.DatabaseHelper.con.Open();

                string sql = "INSERT INTO Players(UserName, Password) VALUES('" + userName + "', '" + passWord + "');";

                MySqlScript script = new MySqlScript(GameEnvironment.DatabaseHelper.con, sql);
                script.Execute();
                Console.WriteLine("Account created succesfully");

                //Switches to playingstate for now
                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Username taken, or no internet connection");
            }
            GameEnvironment.DatabaseHelper.con.Close();
        }
    }
}
