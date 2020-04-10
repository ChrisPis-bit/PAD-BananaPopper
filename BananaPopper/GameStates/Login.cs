using Microsoft.Xna.Framework;
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
        TextGameObject test;
        public Login() : base()
        {
            Add(test = new TextGameObject("", Color.White, "GameFont", new Vector2(0)));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Username taken, or no internet connection");
            }
            GameEnvironment.DatabaseHelper.con.Close();
        }
    }
}
