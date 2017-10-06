using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Game1.Pieces;
using System.Diagnostics;
using LilyPath;
using Game1.Scene1;

namespace Game1 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        DrawBatch drawBatch;

        AppResources appResources;

        TutorialStage stage = null;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            this.IsMouseVisible = true;
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
            
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            drawBatch = new DrawBatch(GraphicsDevice);

            this.appResources = new AppResources(GraphicsDevice, Content, spriteBatch, drawBatch);

            stage = new TutorialStage(appResources);
            stage.LoadContent();
        }

        protected override void UnloadContent() {
            stage.UnloadContent();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            stage.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.DarkSeaGreen);

            spriteBatch.Begin();
            drawBatch.Begin();

            //board.DrawEm(spriteBatch, drawBatch);
            //player.Draw(spriteBatch);
            stage.Draw(gameTime);

            drawBatch.End();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
