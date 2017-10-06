using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LilyPath;

namespace Game1 {
    public class AppResources {
        public GraphicsDevice GraphicsDevice { get; internal set; }
        public ContentManager Pipeline { get; }
        public SpriteBatch SpriteBatch { get; }
        public DrawBatch DrawBatch { get; }

        public AppResources(GraphicsDevice graphicsDevice, ContentManager pipeLine, SpriteBatch sprite, DrawBatch drawb) {
            GraphicsDevice = graphicsDevice;
            Pipeline = pipeLine;
            SpriteBatch = sprite;
            DrawBatch = drawb;
        }
    }
}
