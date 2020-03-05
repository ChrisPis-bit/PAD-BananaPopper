using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GameEnvironment : Game
{
    protected static GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    static protected ContentManager content;
    protected static Point screen;
    protected static float globalScale;
    protected static Random random;
    protected InputHelper inputHelper;
    static protected List<GameObject> gameStateList;
    static protected GameObject currentGameState;

    public static Point Screen
    {
        get { return screen; }
    }

    //GlobalScale is used to make objects change scale with the screen
    public static float GlobalScale
    {
        get { return globalScale; }
    }

    public static GraphicsDeviceManager Graphics
    {
        get { return graphics; }
    }

    public static Random Random
    {
        get { return random; }
    }

    public static ContentManager ContentManager
    {
        get { return content; }
    }

    static public void ChangeColor(Texture2D texture, Color color)
    {
        Color[] data = new Color[texture.Width * texture.Height];
        for (int i = 0; i < data.Length; ++i) data[i] = color;
        texture.SetData(data);
    }

    static public void SwitchTo(int gameStateIndex)
    {
        if (gameStateIndex >= 0 && gameStateIndex < gameStateList.Count)
            currentGameState = gameStateList[gameStateIndex];
    }

    public GameEnvironment()
    {
        graphics = new GraphicsDeviceManager(this);
        inputHelper = new InputHelper();
        Content.RootDirectory = "Content";
        content = Content;
        gameStateList = new List<GameObject>();
        random = new Random();
    }

    public void ApplyResolutionSettings()
    {
        graphics.PreferredBackBufferWidth = screen.X;
        graphics.PreferredBackBufferHeight = screen.Y;
        graphics.ApplyChanges();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected void HandleInput()
    {
        inputHelper.Update();
        if (inputHelper.KeyPressed(Keys.Escape))
        {
            Exit();
        }

        if (currentGameState != null)
            currentGameState.HandleInput(inputHelper);
    }

    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();

        if (currentGameState != null)
            currentGameState.Draw(spriteBatch);

        spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void Update(GameTime gameTime)
    {
        HandleInput();

        if (currentGameState != null)
            currentGameState.Update(gameTime);

        base.Update(gameTime);
    }
}

