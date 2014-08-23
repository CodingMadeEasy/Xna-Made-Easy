// C# XNA MADE EASY TUTORIAL 26 - DISTANCE COLLISION
// CODINGMADEEASY [XNA 4.0]

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Xna_Made_Easy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D sprite1, sprite2;
        Vector2 position;
        KeyboardState keyState;
        Color playerColor = Color.White;
        float moveSpeed = 500f;
        double distance;

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
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
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
            sprite1 = sprite2 = Content.Load<Texture2D>("Sprite1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Right))
                position.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyState.IsKeyDown(Keys.Left))
                position.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyState.IsKeyDown(Keys.Up))
                position.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyState.IsKeyDown(Keys.Down))
                position.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            distance = Math.Sqrt(Math.Pow(position.X - 100, 2) + Math.Pow(position.Y - 100, 2));
            //distance = Math.Abs(position.X - 100) + Math.Abs(position.Y - 100)

            if (distance < sprite1.Width / 2 + sprite2.Width / 2)
                playerColor = Color.Turquoise;
            else
                playerColor = Color.White;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(sprite2, new Vector2(100, 100), Color.Black);
            spriteBatch.Draw(sprite1, position, playerColor);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
