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

        Song BGM;
        SpriteFont font;
        TimeSpan playTime, endTime;
        string songName;

        string[] button = { "Play", "Pause", "Stop" };
        Color[] buttonColor = { Color.White, Color.White, Color.White };

        MouseState mouse;

        private string DisplayTime(TimeSpan timeSpan)
        {
            string minutes = timeSpan.Minutes.ToString();
            string seconds = timeSpan.Seconds.ToString();

            if (int.Parse(seconds) < 10)
                return minutes + ":0" + seconds;
            else
                return minutes + ":" + seconds;
        }

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

            // TODO: use this.Content to load your game content here
            BGM = Content.Load<Song>("title");
            font = Content.Load<SpriteFont>("SpriteFont1");
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

            mouse = Mouse.GetState();
            for(int i = 0; i < 3; i ++)
            {
                if (mouse.X >= i * 100 + 100 && mouse.X <= i * 100 + 100 + font.MeasureString(button[i]).X
                    && mouse.Y >= 100 && mouse.Y <= 100 + font.MeasureString(button[i]).Y)
                {
                    buttonColor[i] = Color.Orange;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        if (i == 0)
                        {
                            if (MediaPlayer.State != MediaState.Playing && MediaPlayer.State != MediaState.Paused)
                                MediaPlayer.Play(BGM);
                            else if (MediaPlayer.State == MediaState.Paused)
                                MediaPlayer.Resume();
                        }
                        else if (i == 1)
                        {
                            MediaPlayer.Pause();
                        }
                        else if (i == 2)
                        {
                            MediaPlayer.Stop();
                        }
                    }
                }
                else
                    buttonColor[i] = Color.White;
            }

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

            songName = BGM.Name;
            endTime = BGM.Duration;
            playTime = MediaPlayer.PlayPosition;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, songName, Vector2.Zero, Color.Red);
            spriteBatch.DrawString(font, DisplayTime(playTime) + " / " + DisplayTime(endTime), new Vector2(100, 300), 
                                Color.White);
            for (int i = 0; i < 3; i++)
                spriteBatch.DrawString(font, button[i], new Vector2(i * 100 + 100, 100), buttonColor[i]);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
