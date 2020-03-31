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

namespace BananaPopper
{
    class PlayingState : GameObjectList
    {
        string connectionString = "server=oege.ie.hva.nl;user=lokhorc;database=zlokhorc;port=3306;password=dw5dZKtaln1AHIK2";
        MySqlConnection test;


        //All temporary textures for prototype
        Texture2D lineTest = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 5, 5);
        Texture2D bg = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);
        Texture2D mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10);

        GameObjectList theObstacles = new GameObjectList();
        GameObjectList theBullets = new GameObjectList();
        GameObjectList theEBullets = new GameObjectList();
        GameObjectList theBalloons = new GameObjectList();
        GameObjectList thePlusBanana = new GameObjectList();

        Texture2D grid = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 1, 1);
        HUD hud = new HUD();
        Formula theFormula;
        Table theTable;
        SpriteGameObject theMouse;
        Player thePlayer;
        Timer theTimer;
        PopAnimation thePopAnimation;
        XYAxes theXYaxes;

        int iRc = 0;
        float[] rc = new float[] { 1, -0.5f, 3 }; //Defines the a in y=ax+b



        public PlayingState() : base()
        {
            //Put which level you wanna start in the brackets
            StartLevel(5);

            //code for database
            /*test = new MySqlConnection(connectionString);
            test.Open();

            string sql = "SELECT * FROM zlokhorc.Highscores";

            MySqlCommand cmd = new MySqlCommand(sql, test);
            MySqlDataReader cmdData = cmd.ExecuteReader();

            while (cmdData.Read()) {
                Console.WriteLine(cmdData[0] +" -- "+ cmdData[1] + " -- " + cmdData[2]);
            }
            cmdData.Close();

            test.Close();*/

            //Sets color for test textures
            GameEnvironment.ChangeColor(lineTest, Color.Blue);
            GameEnvironment.ChangeColor(bg, Color.Black);
            GameEnvironment.ChangeColor(mouse, Color.White);

            GameEnvironment.ChangeColor(grid, new Color(Color.ForestGreen, 200));

            theMouse = new SpriteGameObject(mouse);

            //theBalloons.Add(new InvisibleBalloon(new Vector2(GameEnvironment.GlobalScale * 2, GameEnvironment.GlobalScale * 4)));
            //theBalloons.Add(new InvisibleBalloon(new Vector2(GameEnvironment.GlobalScale * 1, GameEnvironment.GlobalScale * 5)));
            //theBalloons.Add(new StrongBalloon(new Vector2(GameEnvironment.GlobalScale * 3, GameEnvironment.GlobalScale * 2)));

            //Detects how much invisible balloons there are in the game
            List<Vector2> invPoints = new List<Vector2>();
            foreach (Balloon balloon in theBalloons.Children)
            {
                if (balloon is InvisibleBalloon)
                {
                    invPoints.Add(balloon.position);
                }
            }

            theFormula = new Formula(new Vector2(GameEnvironment.Screen.X / 10, GameEnvironment.Screen.Y - GameEnvironment.Screen.Y / 10));
            theTable = new Table(invPoints.Count(), invPoints, thePlayer.Oorsprong,
                    new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y - GameEnvironment.Screen.Y / 10));

            //thePlusBanana.Add(new plusBanana(new Vector2(GameEnvironment.GlobalScale * 3, GameEnvironment.GlobalScale * 3)));

            //Add GameObjects here
            Add(theXYaxes = new XYAxes(thePlayer.Oorsprong));
            Add(theMouse);
            Add(theObstacles);
            Add(theBalloons);
            Add(thePlusBanana);
            Add(hud);
            Add(theTable);
            Add(theFormula);
            Add(thePlayer);
            Add(theTimer = new Timer());
            Add(theBullets);
            Add(theEBullets);
            Add(thePopAnimation = new PopAnimation());
            for (int iButton = 0; iButton < 2; iButton++)
                Add(new Button("arrowKey", (float)Math.PI * (float)iButton,
                    new Vector2(theFormula.position.X + BananaPopper.GlobalScale / 2.5f, theFormula.position.Y - 10 + 30 * iButton)));
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (SpriteGameObject banana in theBullets.Children)
            {

                if (banana.position.X < 0 || banana.position.X > GameEnvironment.Screen.X ||
                    banana.position.Y < 0 || banana.position.Y > GameEnvironment.Screen.Y)
                {
                    banana.Visible = false;
                }

                foreach (Obstacle obstacle in theObstacles.Children)
                {
                    if (obstacle.Overlaps(banana))
                    {
                        banana.Visible = false;
                    }
                }
            }

            foreach (SpriteGameObject eBanana in theEBullets.Children)
            {

                if (eBanana.position.X < 0 || eBanana.position.X > GameEnvironment.Screen.X ||
                    eBanana.position.Y < 0 || eBanana.position.Y > GameEnvironment.Screen.Y)
                {
                    eBanana.Visible = false;
                }

                foreach (Obstacle obstacle in theObstacles.Children)
                {
                    if (obstacle.Overlaps(eBanana))
                    {
                        (obstacle as Obstacle).ObstacleHP--;
                        if (obstacle is InvisibleBalloon)
                        {
                            thePopAnimation.position = obstacle.position;
                            thePopAnimation.Visible = true;
                        }

                        if ((obstacle as Obstacle).ObstacleHP == 0)
                        {
                            obstacle.Visible = false;
                            eBanana.Visible = false;
                        }

                    }
                }
            }
            

                foreach (SpriteGameObject banana in theBullets.Children)
                {



                    foreach (SpriteGameObject balloons in theBalloons.Children)
                    {
                        if (balloons.Overlaps(banana))
                        {
                            (balloons as Balloon).hp--;
                            if (balloons is InvisibleBalloon)
                            {
                                thePopAnimation.position = balloons.position;
                                thePopAnimation.Visible = true;
                            }

                            if ((balloons as Balloon).hp == 0)
                            {
                                balloons.Visible = false;
                            }
                            else { banana.Visible = false; }


                        }
                    }
                }

                foreach (SpriteGameObject eBanana in theEBullets.Children)
                {



                    foreach (SpriteGameObject balloons in theBalloons.Children)
                    {
                        if (balloons.Overlaps(eBanana))
                        {
                            (balloons as Balloon).hp--;
                            if (balloons is InvisibleBalloon)
                            {
                                thePopAnimation.position = balloons.position;
                                thePopAnimation.Visible = true;
                            }

                            if ((balloons as Balloon).hp == 0)
                            {
                                balloons.Visible = false;
                            }
                            else { eBanana.Visible = false; }


                        }
                    }
                }


                foreach (SpriteGameObject banana in theBullets.Children)
                {



                    foreach (SpriteGameObject plusBanana in thePlusBanana.Children)
                    {
                        if (plusBanana.Overlaps(banana))
                        {

                            plusBanana.Visible = false;
                            banana.Visible = false;
                            hud.numBananas++;
                        }
                    }
                }

                foreach (SpriteGameObject eBanana in theEBullets.Children)
                {



                    foreach (SpriteGameObject plusBanana in thePlusBanana.Children)
                    {
                        if (plusBanana.Overlaps(eBanana))
                        {

                            plusBanana.Visible = false;
                            eBanana.Visible = false;
                            hud.numBananas++;
                        }
                    }
                }

                if (iRc >= rc.Length)
                {
                    iRc = 0;
                }
                else if (iRc < 0)
                {
                    iRc = rc.Length - 1;
                }

                for (int i = 0; i < theBullets.Children.Count(); i++)
                {
                    if (!theBullets.Children[i].Visible)
                    {
                        theBullets.remove(theBullets.Children[i]);
                    }
                }

                for (int i = 0; i < theEBullets.Children.Count(); i++)
                {
                    if (!theEBullets.Children[i].Visible)
                    {
                        theEBullets.remove(theEBullets.Children[i]);
                    }
                }

                //Updates the formula on screen
                theFormula.UpdateFormula(rc[iRc], thePlayer.centerPos, thePlayer.Oorsprong);
            }
        
        


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //For testing, changes line direction
            if (inputHelper.KeyPressed(Keys.Up)) iRc += 1;
            if (inputHelper.KeyPressed(Keys.Down)) iRc -= 1;

            //For testing, flips line
            if (inputHelper.KeyPressed(Keys.F))
            {
                theFormula.flipLine = !theFormula.flipLine;

            }



            theMouse.position = inputHelper.MousePosition;

            if (inputHelper.KeyPressed(Keys.Space))
            {
                if (hud.numBananas != 0)
                {
                    theBullets.Add(new Banana(thePlayer.position, rc[iRc], theFormula.flipLine));
                    hud.numBananas--;
                }
            }

            if (inputHelper.KeyPressed(Keys.E))
            {
                if (hud.numEBananas != 0)
                {
                    theEBullets.Add(new ExplosiveBanana(thePlayer.position, rc[iRc], theFormula.flipLine));
                    hud.numEBananas--;
                }
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draws the bg across the screen
            spriteBatch.Draw(bg,
               new Rectangle(0, 0, GameEnvironment.Screen.X, GameEnvironment.Screen.Y),
               new Rectangle(0, 0, bg.Width, bg.Height),
               Color.White);

            for (int i = 0; i < 30; i++)
            {
                LineRenderer.DrawLine(spriteBatch, grid, new Vector2((GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale), 0), new Vector2(GameEnvironment.GlobalScale + i * GameEnvironment.GlobalScale, GameEnvironment.Screen.Y));
            }

            for (int j = 0; j < 15; j++)
            {
                LineRenderer.DrawLine(spriteBatch, grid, new Vector2(GameEnvironment.Screen.X, GameEnvironment.GlobalScale + j * GameEnvironment.GlobalScale), new Vector2(0, GameEnvironment.GlobalScale + j * GameEnvironment.GlobalScale));
            }

            //Draws a test line, startPosLine must be player coords
            // LineRenderer.DrawLine(spriteBatch, lineTest, thePlayer.centerPos, theFormula.end);

            base.Draw(spriteBatch);
        }



        public void StartLevel(int levelIndex)
        {
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

            for (int i = 0; i < mapData.Length; i++)
            {
                Console.WriteLine(mapData[i]);
            }

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
                        Add(new plusBanana(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(strongBalloon))
                    {
                        theBalloons.Add(new StrongBalloon(position));
                    }
                    else if (mapData[i + j * map.Width].Equals(point0))
                    {
                        thePlayer = new Player(position);
                    }
                }
            }
        }
    }
}
