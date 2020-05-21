using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using BananaPopper.GameObjects;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace BananaPopper
{

    class TutorialState : PlayingState
    {
        const int TEXTBOX_WIDTH = 700, TEXTBOX_HEIGHT = 300, HUD_WIDTH = 360;
        TextBubble StartLevel, Shoot, BananaCount, Table, Aim, move, Flip, Restart, StrongBalloon;
        Texture2D textBox;
        Vector2 StandardPosition = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y /2);
        Vector2 BananaCountPosition = new Vector2(GameEnvironment.Screen.X - TEXTBOX_WIDTH/2 - HUD_WIDTH, TEXTBOX_HEIGHT/2);
        Vector2 TablePostition = new Vector2(GameEnvironment.Screen.X - TEXTBOX_WIDTH / 2 - HUD_WIDTH, 500);
        Vector2 FlipPosition = new Vector2(GameEnvironment.Screen.X - TEXTBOX_WIDTH / 2 - HUD_WIDTH, 750);
        Vector2 Restartposition = new Vector2(GameEnvironment.Screen.X - TEXTBOX_WIDTH / 2 - HUD_WIDTH, 600);
        Vector2 StrongBalloonPosition = new Vector2(GameEnvironment.Screen.X / 2 + 100, GameEnvironment.Screen.Y -TEXTBOX_HEIGHT/2);
        Vector2 AimPosition = new Vector2(GameEnvironment.Screen.X - TEXTBOX_WIDTH / 2 - HUD_WIDTH, GameEnvironment.Screen.Y - TEXTBOX_HEIGHT/2);
        GameObjectList tutorialText;

        public int i = 0;
        public TutorialState() : base()

        {
            tutorialText = new GameObjectList();
            tutorialText.Add(StartLevel = new TextBubble(StandardPosition, @"Welkom bij het spel bananapopper! 
In dit spel is het doel om alle ballonnen weg
te schieten met de bananen die je hebt.
Klik om verder te gaan."));
            tutorialText.Add(Shoot = new TextBubble(StandardPosition, @"Om een bannaan te schieten druk je op
de spatiebalk van je toetsenbord"));
            tutorialText.Add(BananaCount = new TextBubble(BananaCountPosition, @"Hier kan je zien hoeveel keer je nog kan schieten
voordat je geen bananen meer hebt"));
            tutorialText.Add(Table = new TextBubble(TablePostition, @"Soms lijken alle ballonnen gepopt te zijn maar is
het level nog niet gewonnen...
Dat betekent dat er ontzichtbare ballonnen zijn!
Vind de ballonnen door dit tabel te gebruiken."));
            tutorialText.Add(Aim = new TextBubble(AimPosition, @"Om te richten moet je de formule veranderen
met deze twee pijlen"));
            tutorialText.Add(move = new TextBubble(StandardPosition, @"Je kan de aap bewegen door deze
naar boven of naar beneden te slepen"));
            tutorialText.Add(Flip = new TextBubble(FlipPosition, @"Staat er een ballon aan de andere kant?
Druk op deze knop om van schietrichting te veranderen!"));
            tutorialText.Add(Restart = new TextBubble(Restartposition, @"Heb je een banaan misgeschoten?
Druk op deze knop om het spel te herstarten!"));
            tutorialText.Add(StrongBalloon = new TextBubble(StrongBalloonPosition, @"Deze ballon gaat niet in een keer kapot!
Om deze te poppen moet je hem twee keer raken"));
            Add(tutorialText);
            foreach (GameObject text in tutorialText.Children)
            {
                text.Visible = false;
            }

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);


            if (i < tutorialText.Children.Count())
            {

                tutorialText.Children[i].Visible = true;
                if (inputHelper.MouseLeftButtonPressed())
                {
                    tutorialText.Children[i].Visible = false;
                    i++;

                }


            }
        }
    }
}
