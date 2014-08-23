// C# XNA MADE EASY TUTORIAL 8 - 3D EFFECTS
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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static DateTime dateTimeNow = DateTime.Now;
        string date = dateTimeNow.ToLongDateString();

        Vector2 position, velocity;
        KeyboardState keyState;
        SpriteFont font;
        //GamePadState pad1;

        float moveSpeed = 500f;
        int depth = 1;

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
            position = Vector2.Zero;
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

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("fontName");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Right))
                velocity.X = moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyState.IsKeyDown(Keys.Left))
                velocity.X = moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyState.IsKeyDown(Keys.Up))
                velocity.Y = moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyState.IsKeyDown(Keys.Down))
                velocity.Y = moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(keyState.IsKeyDown(Keys.W))
                depth++;
            else if(keyState.IsKeyDown(Keys.S))
                depth--;

            if (depth < 1)
                depth = 1;

            if (velocity.X > 0)
                velocity.Y = 0;
            else if (velocity.Y > 0)
                velocity.X = 0;

            position += velocity;

            /*
             pad1 = GamePad.GetState(PlayerIndex.One);

            if (pad1.DPad.Right == ButtonState.Pressed)
                position.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (pad1.DPad.Left == ButtonState.Pressed)
                position.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (pad1.DPad.Up == ButtonState.Pressed)
                position.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (pad1.DPad.Down == ButtonState.Pressed)
                position.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
             */

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            for(int i = 0; i < depth; i++)
                spriteBatch.DrawString(font, date, new Vector2(position.X - i, position.Y - i), Color.Gray);
            spriteBatch.DrawString(font, date, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
