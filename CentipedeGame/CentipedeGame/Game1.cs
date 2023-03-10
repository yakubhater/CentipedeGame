using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentipedeGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Texture2D[] text;
        public List<Mushroom> mushrooms;

        int points;

        Random ran = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 525;
            graphics.PreferredBackBufferHeight = 720;
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

            text = new Texture2D[4];
            mushrooms = new List<Mushroom>();

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
            for(int i = 0; i < text.Length; i++)
            {
                text[i] = this.Content.Load<Texture2D>(i + "");
            }
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

            // TODO: Add your update logic here

            if (mushrooms.Count == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    mushrooms.Add(new Mushroom(text[0], new Rectangle(ran.Next(0, 509), ran.Next(0, 700), 16, 20)));
                }
            }

            for(int i = 0; i < mushrooms.Count; i++)
            {
                //if(mousey.Intersects(mushrooms[i].rect) && !Oldmousey.Intersects(mushrooms[i].rect))//if the rect for the laser intersects the mushroom 
                //{
                //    mushrooms[i].health--;
                //}

                if(mushrooms[i].health == 0)
                {
                    mushrooms.RemoveAt(i);
                    points += 600;
                    i--;
                }
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
            spriteBatch.Begin();

            for(int i = 0; i < mushrooms.Count; i++)
            {
                spriteBatch.Draw(mushrooms[i].text, mushrooms[i].rect, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
