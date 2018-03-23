using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AnimatedSprite
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static int WinHeight { private set; get; }
        public static int WinWidth { private set; get; }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState lastKeyState;

        private AnimatedSprite mrSmiley;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            WinHeight = 480;
            WinWidth = 800;
            graphics.PreferredBackBufferHeight = WinHeight;
            graphics.PreferredBackBufferWidth = WinWidth;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D texture = Content.Load<Texture2D>("img/SmileyWalk");
            mrSmiley = new AnimatedSprite(texture, 4, 4);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyState = Keyboard.GetState();
            var deltaTime = gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Escape))
                Exit();
            if (keyState.IsKeyDown(Keys.Enter))
            {
                Console.WriteLine(deltaTime);                
            }

            mrSmiley.Update();

            lastKeyState = keyState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            mrSmiley.Draw(spriteBatch, new Vector2(
                WinWidth / 2.2f,
                WinHeight / 2.2f));

            base.Draw(gameTime);
        }
    }
}
