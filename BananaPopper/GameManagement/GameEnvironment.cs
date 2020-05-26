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
    protected static GameStateManager gameStateManager;
    protected SpriteBatch spriteBatch;
    static protected ContentManager content;
    protected static Point screen, screenRatio;
    protected static float globalScale,
        textureScale;
    protected static Random random;
    protected InputHelper inputHelper;
    /*static protected List<GameObject> gameStateList;
    static protected GameObject currentGameState;*/
    static protected DatabaseHelper databaseHelper;
    StringBuilder builder = new StringBuilder();

    public static Point Screen
    {
        get { return screen; }
    }

    public static Point ScreenRatio
    {
        get { return screenRatio; }
        set { screenRatio = value; }
    }

    //GlobalScale is used to make objects change scale with the screen
    public static float GlobalScale
    {
        get { return globalScale; }
        set { globalScale = value;
            textureScale = globalScale / 32;
        }
    }

    public static float TextureScale
    {
        get { return textureScale; }
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

    public static DatabaseHelper DatabaseHelper
    {
        get { return databaseHelper; }
    }

    public static GameStateManager GameStateManager
    {
        get { return gameStateManager; }
    }

    static public void ChangeColor(Texture2D texture, Color color)
    {
        Color[] data = new Color[texture.Width * texture.Height];
        for (int i = 0; i < data.Length; ++i) data[i] = color;
        texture.SetData(data);
    }

    public GameEnvironment()
    {
        Window.TextInput += TextInputHandler;

        graphics = new GraphicsDeviceManager(this);
        inputHelper = new InputHelper();
        Content.RootDirectory = "Content";
        content = Content;
        gameStateManager = new GameStateManager();
        random = new Random();
        databaseHelper = new DatabaseHelper();
    }

    private void TextInputHandler(object sender, TextInputEventArgs args)
    {
        if (args.Key == Keys.Back)
            if (builder.Length > 0)
                builder.Remove(builder.Length - 1, 1);
            else
                builder.Append(args.Character);
        this.Window.Title = builder.ToString();
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

        if (gameStateManager.CurrentGameState != null)
            gameStateManager.CurrentGameState.HandleInput(inputHelper);
    }

    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

        if (gameStateManager.CurrentGameState != null)
            gameStateManager.CurrentGameState.Draw(gameTime, spriteBatch);

        spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void Update(GameTime gameTime)
    {
        HandleInput();

        if (gameStateManager.CurrentGameState != null)
            gameStateManager.CurrentGameState.Update(gameTime);

        base.Update(gameTime);
    }
}

