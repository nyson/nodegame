using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Nodegame
{
    public abstract class Drawable
    {
        protected string texturePath;
        Texture2D getTexture(ContentManager cm)
        {
            return cm.Load<Texture2D>(texturePath);
        }
    }
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Nodegame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Network network;
        private SpriteFont font;


        public Nodegame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            network = new Network();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
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
            Vector2 playerPosition = new Vector2(
                GraphicsDevice.Viewport.TitleSafeArea.X,
                GraphicsDevice.Viewport.TitleSafeArea.Y +
                GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            var pgraphics = Content.Load<Texture2D>("Graphics\\Hexa");
            font = Content.Load<SpriteFont>("Fonts\\Amosis");

            network.initializeGraphics(graphics, Content);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector2 mv = Vector2.Zero;
            var step = gameTime.ElapsedGameTime.Milliseconds / 2;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                mv.X += step;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                mv.Y -= step;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                mv.X -= step;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                mv.Y += step;
            //player.Move(mv);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();


            network.draw(spriteBatch);
            GraphicsDevice.Clear(Color.Black);
                        
            // TODO: Add your drawing code here
            //player.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.DrawString(font, "Tjo knas", new Vector2(20, 200), Color.Red);
            spriteBatch.End();
        }
    }
}
