using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaPopper.GameStates
{
    class HomeState:GameObject
    {

       Texture2D mouse = new Texture2D(GameEnvironment.Graphics.GraphicsDevice, 10, 10); //temporary texture for mouse


    void HomeScreen()
        {
            SpriteGameObject theMouse = new SpriteGameObject(mouse);
            //Add GameObjects here
            Add(theMouse);


        }

    void StartButton()
        {

        }





        private void Add(SpriteGameObject theMouse)
        {
            throw new NotImplementedException();
        }
    }
}
