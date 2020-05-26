using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MySql.Data.MySqlClient;

namespace BananaPopper
{
    class LevelSelector : MenuState
    {
        Texture2D tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
        levelTexture = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 100, 100);
        LevelButton TutorialButton;

        GameObjectList levelButtons;
        TextGameObject personalScore;
        public int levelCounter;
        int horizontalCounter, verticalCounter;
        // buttonoffset = distance between side and first button.
        // buttondistance = distance between each button.
        const int BUTTONOFFSET = 100, BUTTONDISTANCE = 200, XBUTTONOFFSET = 150, YBUTTONOFFSET = 200;

        public List<int> scoreList = new List<int>();

        public LevelSelector() : base()
        {

            levelCounter = System.IO.Directory.GetFiles("Content/Maps").Length;
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(levelTexture, new Color(179, 107, 0));
            TutorialButton = new LevelButton(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 5 - 100), "Tutorial");
            Add(personalScore = new TextGameObject(Color.Black, new Vector2(GameEnvironment.Screen.X / 2 - 100, GameEnvironment.Screen.Y - 100)));



            Add(levelButtons = new GameObjectList());
            for (horizontalCounter = 0; horizontalCounter < levelCounter; horizontalCounter++)
            {
                levelButtons.Add(new LevelButton(new Vector2(GameEnvironment.Screen.X/2 - 2 * XBUTTONOFFSET + ((horizontalCounter % 5) * XBUTTONOFFSET), 300 + (verticalCounter * YBUTTONOFFSET)), (horizontalCounter + 1).ToString()));
                if (horizontalCounter % 5 == 4)
                {
                    verticalCounter++;
                }
            }

            Add(TutorialButton);
            TutorialButton.levelAvailable = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            for (int i = 0; i < levelButtons.Children.Count(); i++)
            {
                if (i == 0)
                {
                    (levelButtons.Children[i] as LevelButton).levelAvailable = true;
                }
                else if (scoreList[i - 1] > 0)
                {
                    (levelButtons.Children[i] as LevelButton).levelAvailable = true;
                }

                if ((levelButtons.Children[i] as MenuButton).isPressed && (levelButtons.Children[i] as LevelButton).levelAvailable)
                {
                    Console.WriteLine("Pressed");
                    (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).StartLevel(i + 1);
                    GameEnvironment.GameStateManager.SwitchTo("PlayingState");
                }

                if ((levelButtons.Children[i] as MenuButton).isHovered && i < scoreList.Count())
                {
                    personalScore.text = "Personal score : " + scoreList[i];
                }


            }
            if (TutorialButton.isPressed)
            {
                (GameEnvironment.GameStateManager.GetGameState("TutorialState") as PlayingState).StartLevel(0);
                GameEnvironment.GameStateManager.SwitchTo("TutorialState");
                (GameEnvironment.GameStateManager.GetGameState("TutorialState") as TutorialState).i = 0;

            }
            if (backButton.isPressed)
                GameEnvironment.GameStateManager.SwitchTo("HomeMenu");
        }

        public void UpdateScores(int playerIndex)
        {
            scoreList.Clear();


            //Query gets all scores ascending from the level number
            MySqlCommand cmd = new MySqlCommand("SELECT Score FROM zmult.Speler_has_Level WHERE Speler_idSpeler = " + playerIndex + " order by Level_LevelNr asc;", GameEnvironment.DatabaseHelper.con);
            MySqlDataReader cmdData = cmd.ExecuteReader();

            for (int i = 0; i < levelCounter; i++)
            {
                //Adds a score to the list if the level has a score
                if (cmdData.Read())
                {
                    scoreList.Add((int)cmdData[0]);
                }
                //If it doesnt have a score, the score will be 0
                else
                {
                    scoreList.Add(0);
                }
            }
            cmdData.Close();

            for (int i = 0; i < scoreList.Count(); i++)
            {
                Console.WriteLine(scoreList[i]);
            }
        }

        public void OfflineScore()
        {
            for (int i = 0; i < levelCounter; i++)
            {
                scoreList.Add(0);
            }
        }
    }
}
