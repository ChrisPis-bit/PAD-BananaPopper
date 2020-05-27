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
        private const int DISPLAYED_HIGHSCORES = 10,
            HIGHSCORE_UPDATE_TIME = 300;

        // buttonoffset = distance between side and first button.
        // buttondistance = distance between each button.
        const int BUTTONOFFSET = 100, BUTTONDISTANCE = 200;

        Texture2D tempButton = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 10),
        levelTexture = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 100, 100);
        LevelButton TutorialButton;

        GameObjectList levelButtons;
        GameObjectList allHighScores;
        TextGameObject personalScore, highScoreText;
        TextBubble First, Second;
        public int levelCounter;
        bool offlineMode = true;
        int horizontalCounter, verticalCounter, updateCounter = HIGHSCORE_UPDATE_TIME;


        public List<int> scoreList = new List<int>();

        private int[,] highScores;
        private string[,] names;

        public LevelSelector() : base()
        {
  

            levelCounter = System.IO.Directory.GetFiles("Content/Maps").Length;
            GameEnvironment.ChangeColor(tempButton, Color.Green);
            GameEnvironment.ChangeColor(levelTexture, new Color(179, 107, 0));
            TutorialButton = new LevelButton(new Vector2(BUTTONOFFSET, GameEnvironment.Screen.Y / 10), "T");
            Add(personalScore = new TextGameObject(Color.Black, new Vector2(1300, 50)));
            Add(highScoreText = new TextGameObject(Color.Black, new Vector2(1600, 50)));
            Add(allHighScores = new GameObjectList());
            for (int i = 0; i < DISPLAYED_HIGHSCORES; i++)
            {
                allHighScores.Add(new TextGameObject(Color.Black, new Vector2(1600, i * 20 + 100)));
            }


            highScores = new int[levelCounter, DISPLAYED_HIGHSCORES];
            names = new string[levelCounter, DISPLAYED_HIGHSCORES];

            Add(levelButtons = new GameObjectList());
            for (horizontalCounter = 0; horizontalCounter < levelCounter; horizontalCounter++)
            {
                levelButtons.Add(new LevelButton(new Vector2(100 + ((horizontalCounter % 5) * 150), 300 + (verticalCounter * 200)), (horizontalCounter + 1).ToString()));
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


            updateCounter++;
            if (updateCounter >= HIGHSCORE_UPDATE_TIME)
            {
                updateCounter = 0;
                GetHighScores();
            }

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

                if ((levelButtons.Children[i] as MenuButton).isHovered)
                    for (int j = 0; j < DISPLAYED_HIGHSCORES; j++)
                        Console.WriteLine(names[i, j]);

                if ((levelButtons.Children[i] as MenuButton).isPressed && (levelButtons.Children[i] as LevelButton).levelAvailable)
                {
                    Console.WriteLine("Pressed");
                    (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).StartLevel(i + 1);
                    GameEnvironment.GameStateManager.SwitchTo("PlayingState");
                }

                if ((levelButtons.Children[i] as MenuButton).isHovered && i < scoreList.Count())
                {
                    personalScore.text = "Personal score : " + scoreList[i];
                    highScoreText.text = "HighScores";
                    for (int iText = 0; iText < allHighScores.Children.Count(); iText++)
                    {

                        (allHighScores.Children[iText] as TextGameObject).text = highScores[i, iText] + " - " + names[i, iText];
                    }
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

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.OemOpenBrackets))
            {
                foreach(LevelButton level in levelButtons.Children)
                {
                    level.levelAvailable = true;
                }
            }
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
        }

        public void GetHighScores()
        {
            try
            {
                GameEnvironment.DatabaseHelper.con.Open();

                //Gets the score for each level
                for (int levelIndex = 0; levelIndex < levelCounter; levelIndex++)
                {
                    //Query selects the top scores from top to bottom
                    MySqlCommand cmd = new MySqlCommand("SELECT p.UserName, s.score FROM zmult.Speler_has_Level s INNER JOIN zmult.Players p ON s.Speler_idSpeler = p.id WHERE s.Level_LevelNr = " + (levelIndex + 1) + " ORDER BY s.Score DESC;", GameEnvironment.DatabaseHelper.con);
                    MySqlDataReader cmdData = cmd.ExecuteReader();

                    //Only gets the top 10 scores
                    for (int i = 0; i < DISPLAYED_HIGHSCORES; i++)
                    {
                        if (cmdData.Read())
                        {
                            names[levelIndex, i] = (string)cmdData[0];
                            highScores[levelIndex, i] = (int)cmdData[1];
                        }
                        else
                        {
                            names[levelIndex, i] = "";
                            highScores[levelIndex, i] = 0;
                        }
                    }
                    cmdData.Close();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            GameEnvironment.DatabaseHelper.con.Close();
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
