using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Types;

namespace Game1 {
    public class CycleAnimation {
        Texture2D spriteStrip;
        float scale;
        int elapsedTime;
        int frameTime;
        int frameCount;
        int currentFrame;
        Color color;
        Rectangle sourceRect = new Rectangle();
        Rectangle destinationRect = new Rectangle();
        public Size2D size;
        public bool Active;
        public bool Looping;
        public Vector2 Position;

        public void Initialize(Texture2D texture, Vector2 position, Size2D sz, int frameCount, 
                int frametime, Color c, float scale, bool looping) {
            // Keep a local copy of the values passed in
            this.color = c;

            size = sz;

            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            Looping = looping;
            Position = position;
            spriteStrip = texture;

            // Set the time to zero
            elapsedTime = 0;

            Active = true;
        }

        public void Update(GameTime gameTime) {
            if (Active == false)
                return;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frameTime) {
                currentFrame++;                
                if (currentFrame == frameCount) {
                    currentFrame = 0;
                    if (Looping == false)
                        Active = false;
                }

                elapsedTime = 0;
            }

            sourceRect = size.ToRectangle(currentFrame * size.W, 0);
            destinationRect = new Rectangle((int)Position.X - (int)(size.W * scale) / 2,
                (int)Position.Y - (int)(size.H * scale) / 2,
                (int)(size.W * scale),
                (int)(size.H * scale)
                );
        }

        public void Draw(SpriteBatch drw) {
            if (Active)
                drw.Draw(spriteStrip, destinationRect, sourceRect, color);
        }
    }
}
