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
    class Login : MenuState
    {
        const int MAX_CHARACTERS = 10;

        public bool createAccount;

        Vector2 loginInfoOffset = new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 3);

        CharacterSelector userName, passWord;

        TextGameObject errorMessage, explain;

        const string LOGIN_ERROR = "Verkeerde password/username of geen verbinding",
            CREATE_ACCOUNT_ERROR = "De username wordt all gebruikt of geen verbinding",
            EXPLAIN_TEXT = @"Use arrow keys to change characters
Press enter to confirm";


        public Login() : base()
        {
            //Bool defines if player is login in or creating an account
            createAccount = false;

            Add(userName = new CharacterSelector(MAX_CHARACTERS, loginInfoOffset));
            Add(passWord = new CharacterSelector(MAX_CHARACTERS, new Vector2(loginInfoOffset.X, loginInfoOffset.Y * 2), false));

            Add(new TextGameObject(Color.White, new Vector2(userName.position.X, userName.position.Y - 80), "Username"));
            Add(new TextGameObject(Color.White, new Vector2(passWord.position.X, passWord.position.Y - 80), "Password"));
            Add(errorMessage = new TextGameObject(Color.Red, new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 10)));
            Add(explain = new TextGameObject(Color.Wheat, new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 10 * 9), EXPLAIN_TEXT));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (backButton.isPressed)
                GameEnvironment.GameStateManager.SwitchTo("Startup");

            if (userName.isPressed)
            {
                userName.selected = true;
                passWord.selected = false;
                Console.WriteLine("yes");
            }

            if (passWord.isPressed)
            {
                passWord.selected = true;
                userName.selected = false;
                Console.WriteLine("yes");

            }

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
                else
                {
                    passWord.selected = true;
                    userName.selected = false;
                }
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
                    GameEnvironment.DatabaseHelper.playerIndex = (int)cmdData[0];
                    cmdData.Close();

                    (GameEnvironment.GameStateManager.GetGameState("LevelSelector") as LevelSelector).UpdateScores(GameEnvironment.DatabaseHelper.playerIndex);

                    //Switches to playingstate for now
                    GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
                }
                //If the account doesnt exist, it can't execute the Read() function
                else
                {
                    Console.WriteLine("Couldn't find account with this info");
                    errorMessage.text = LOGIN_ERROR;
                    cmdData.Close();
                }
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
                GameEnvironment.DatabaseHelper.con.Close();

                LoginPlayer(userName, passWord);

                //Switches to playingstate for now
                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Username taken, or no internet connection");
                errorMessage.text = CREATE_ACCOUNT_ERROR;

                GameEnvironment.DatabaseHelper.con.Close();
            }
        }
    }
}
