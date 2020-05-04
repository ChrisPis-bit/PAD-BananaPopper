using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using BananaPopper.GameObjects;

namespace BananaPopper
{
    class PlayingState : GameObjectList
    {
        //All temporary textures for prototype
        Texture2D lineTest = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 5, 5);
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Texture2D mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);

        GameObjectList theObstacles = new GameObjectList(),
         theBullets = new GameObjectList(),
         theBalloons = new GameObjectList(),
         thePlusBanana = new GameObjectList();

        HUD hud;
        SpriteGameObject theMouse;
        Player thePlayer;
        PopAnimation thePopAnimation;
        XYAxes theXYaxes;
        DirectionBox theDirectionBox;

        public int levelIndex = 3;



        public PlayingState() : base()
        {
            //StreamReader test = new StreamReader("Content/MapStats.txt");
            Console.WriteLine(string.Join("", readRecord("1", "Content/MapStats.txt")));
            Console.ReadLine();

            //code for database
            /*test = new MySqlConnection(connectionString);
            test.Open();

            string sql = "update Highscores set time = 10 where Users_id = 100;";

            MySqlCommand cmd = new MySqlCommand(sql, test);

            MySqlDataReader cmdData = cmd.ExecuteReader();

            while (cmdData.Read()) {
                Console.WriteLine(cmdData[0] +" -- "+ cmdData[1] + " -- " + cmdData[2]);
            }
            cmdData.Close();

            test.Close();*/

            //Sets color for test textures
            GameEnvironment.ChangeColor(lineTest, Color.Blue);
            GameEnvironment.ChangeColor(bg, new Color(40, 40, 40));
            GameEnvironment.ChangeColor(mouse, Color.White);

            theMouse = new SpriteGameObject(mouse);
            hud = new HUD();
            theXYaxes = new XYAxes();
            thePlayer = new Player();

            //Put which level you want to start in the brackets
            Reset();

            //Add GameObjects here
            Add(new Background());
            Add(theObstacles);
            Add(theBalloons);
            Add(thePlusBanana);
            Add(thePopAnimation = new PopAnimation());
            Add(theBullets);
            Add(theDirectionBox = new DirectionBox());
            Add(theXYaxes);
            Add(thePlayer);
            Add(hud);
            Add(theMouse);
        }


        //Restarts the level for when you want to re-do it
        public override void Reset()
        {
            base.Reset();

            StartLevel(levelIndex);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Obstacle obstacles in theObstacles.Children)
            {
                thePlayer.CollideWithObject(obstacles);
            }

            //////////////////////////////
            //Collisions with the banana//
            //////////////////////////////
            foreach (SpriteGameObject banana in theBullets.Children)
            {
                //Collision with screen border
                if (banana.position.X + banana.HitBox.X < 0 || banana.position.X > GameEnvironment.Screen.X ||
                    banana.position.Y + banana.HitBox.Y < 0 || banana.position.Y > GameEnvironment.Screen.Y)
                {
                    banana.Visible = false;
                }

                //Collision with obstacles
                foreach (Obstacle obstacle in theObstacles.Children)
                {
                    if (obstacle.Overlaps(banana))
                    {
                        if (banana is ExplosiveBanana)
                        {
                            banana.Visible = false;
                            obstacle.Visible = false;
                        }
                        banana.Visible = false;
                    }
                }

                //Collision with balloons
                foreach (SpriteGameObject balloons in theBalloons.Children)
                {
                    if (balloons.Overlaps(banana))
                    {
                        (balloons as Balloon).hp--;

                        //Invisible balloon collision
                        if (balloons is InvisibleBalloon)
                        {
                            thePopAnimation.position = balloons.position;
                            thePopAnimation.Visible = true;

                        }

                        if ((balloons as Balloon).hp == 0)
                        {
                            balloons.Visible = false;
                            hud.theScore.GetScore += (balloons as Balloon).score * (banana as Banana).ScoreMultiplier;
                            (banana as Banana).hitBalloonsAmount++;
                        }
                        else { banana.Visible = false; }

                        if (banana is ExplosiveBanana)
                        {
                            banana.Visible = false;
                            balloons.Visible = false;
                        }
                    }
                }
            }






            for (int i = 0; i < theBullets.Children.Count(); i++)
            {
                //Collision with plus banana power up
                foreach (SpriteGameObject plusBanana in thePlusBanana.Children)
                {
                    if (plusBanana.Overlaps(theBullets.Children[i] as SpriteGameObject))
                    {
                        plusBanana.Visible = false;
                        theBullets.Add(new Banana());
                        hud.theBananaCounter.Amount++;
                    }
                }

                //Deletes used bananas
                if (!theBullets.Children[i].Visible && (theBullets.Children[i] as Banana).shot)
                {
                    theBullets.remove(theBullets.Children[i]);
                    i--;
                }
            }

            for(int i = 0; i < theBalloons.Children.Count(); i++)
            {
                //Deletes popped balloons
                if (!theBalloons.Children[i].Visible)
                {
                    theBalloons.remove(theBalloons.Children[i]);
                    i--;
                }
            }


            //Switches game state if the player wins (pops all balloons)
            //or loses (runs out of bananas)
            if (theBalloons.Children.Count() == 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("LevelCleared");
            }
            else if (theBullets.Children.Count() == 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("LevelFailed");
            }


            //Updates the formula on screen
            hud.theFormula.UpdateFormula(thePlayer.centerPos, thePlayer.Oorsprong, hud.flipLine);

            theDirectionBox.UpdateDirection(hud.flipLine, thePlayer.centerPos);

            thePlayer.Flip(hud.flipLine);
        }




        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);



            //For testing, flips line
            if (inputHelper.KeyPressed(Keys.F))
            {
                hud.flipLine = !hud.flipLine;
            }

            if (inputHelper.KeyPressed(Keys.L))
            {
                StartLevel(3);
            }

            if (inputHelper.KeyPressed(Keys.K))
            {
                StartLevel(5);
            }

            theMouse.position = inputHelper.MousePosition;

            if (inputHelper.KeyPressed(Keys.Space))
            {
                if (hud.theBananaCounter.Amount != 0)
                {
                    foreach (Banana banana in theBullets.Children)
                    {
                        if (!banana.shot)
                        {
                            banana.Shoot(thePlayer.centerPos, hud.theFormula.RC, hud.flipLine);
                            hud.theBananaCounter.Amount--;
                            break;
                        }
                    }
                }
            }
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Draws the bg across the screen
            spriteBatch.Draw(bg,
               new Rectangle(0, 0, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
               new Rectangle(0, 0, bg.Width, bg.Height),
               Color.White);



            //Draws a test line, startPosLine must be player coords
            // LineRenderer.DrawLine(spriteBatch, lineTest, thePlayer.centerPos, theFormula.end);

            base.Draw(gameTime, spriteBatch);
        }



        public void StartLevel(int levelIndex)
        {
            //Clears all lists for reset
            theBalloons.Children.Clear();
            theObstacles.Children.Clear();
            thePlusBanana.Children.Clear();
            theBullets.Children.Clear();

            //Colors for game objects, use these colors for maps
            Color balloon = new Color(255, 0, 0),
                obstacle = new Color(0, 0, 255),
                invBalloon = new Color(255, 255, 0),
                point0 = new Color(0, 255, 0),
            extraBanana = new Color(150, 255, 150),
            strongBalloon = new Color(200, 100, 100);


            Texture2D map = GameEnvironment.ContentManager.Load<Texture2D>("Maps/Map" + levelIndex);

            //Changes GlobalScale according to the maps width or height, so that the map always fits on the screen
            if (GameEnvironment.Screen.X / map.Width / 16 > GameEnvironment.Screen.Y / map.Height / 9)
            {
                GameEnvironment.GlobalScale = GameEnvironment.Screen.X / map.Width;
            }
            else
                GameEnvironment.GlobalScale = GameEnvironment.Screen.Y / map.Height;



            Color[] mapData = new Color[map.Width * map.Height];
            map.GetData(mapData);


            //Loops through the data of the map texture and checks every pixel for its color
            //If it's a color from the given object colors, it will place down that object on the right position on screen
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    Vector2 position = new Vector2(GameEnvironment.GlobalScale * i, GameEnvironment.GlobalScale * j);

                    if (mapData[i + j * map.Width].Equals(balloon))
                    {
                        theBalloons.Add(new Balloon(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(obstacle))
                    {
                        theObstacles.Add(new Obstacle(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(invBalloon))
                    {
                        theBalloons.Add(new InvisibleBalloon(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(extraBanana))
                    {
                        thePlusBanana.Add(new plusBanana(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(strongBalloon))
                    {
                        theBalloons.Add(new StrongBalloon(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(point0))
                    {
                        thePlayer.ResetPlayer(position);
                    }
                }
            }

            //Gets all the invisible balloon points for the table
            List<Vector2> invPoints = new List<Vector2>();
            foreach (Balloon balloons in theBalloons.Children)
            {
                if (balloons is InvisibleBalloon)
                {
                    invPoints.Add(balloons.position);
                }
            }

            hud.theTable.ResetTable(invPoints, thePlayer.Oorsprong);
            hud.Reset();
            theXYaxes.ResetAxes(thePlayer.Oorsprong);

            //Adds banana's to the list
            ///for (int iBanana = 0; iBanana < hud.numBananas; iBanana++)
            //{
            //    theBullets.Add(new Banana());
            //}

            for (int i = 0; i < readRecord(levelIndex.ToString(), "Content/MapStats.txt").Count(); i++)
            {
                if (readRecord(levelIndex.ToString(), "Content/MapStats.txt")[i] == "e")
                {
                    theBullets.Add(new ExplosiveBanana());
                    Console.WriteLine('e');
                }

                if (readRecord(levelIndex.ToString(), "Content/MapStats.txt")[i] == "b")
                {
                    theBullets.Add(new Banana());
                    Console.WriteLine('b');
                }
            }

            hud.theBananaCounter.ResetCounter(theBullets);
        }



        public static void addRecord(string level, string bullet, string eBullet, string filePath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath, true))
                {
                    file.WriteLine(level + "," + bullet + "," + eBullet);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program is doing something wrong :", ex);
            }
        }

        public static string[] readRecord(string searchTerm, string filePath)
        {
            string[] recordNotFound = { "Record not found" };

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (recordMatches(searchTerm, fields))
                    {
                        Console.WriteLine("Record found");
                        return fields;
                    }
                }
                return recordNotFound;
            }
            catch (Exception ex)
            {
                Console.WriteLine("This program is doing something wrong");
                return recordNotFound;
                throw new ApplicationException("This program is doing something wrong :", ex);
            }
        }

        public static bool recordMatches(string searchTerm, string[] record)
        {
            if (record[0].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }








    }
}
