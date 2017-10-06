using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Types;
using LilyPath;

namespace Game1.Pieces {

    public class Dealer : IDisposable {

        Size2D Size { get; set; }
        Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public Pen NormalPen = new Pen(new SolidColorBrush(Color.Navy), 3f, true);
        public Pen HighlightPen = new Pen(new SolidColorBrush(Color.Yellow), 3f, true);

        public Dealer(ContentManager content) {
            short keyIndex = 0;
            for (short i = 0; i < 3; i ++ ) {
                for (short j = 0; j < 3; j++) {
                    for (short k = 0; k < 3; k++) {
                        string key = $"{colors[i]}_{fills[j]}_{shapes[k]}";
                        keys[keyIndex++] = key;
                        textures[key] = content.Load<Texture2D>($"Graphics\\Shapes\\{key}");
                    }
                }
            }
        }

        string[] colors = new string[] { "purple", "red", "green" };
        string[] fills = new string[] { "solid", "striped", "outline" };
        string[] shapes = new string[] { "diamond", "squig", "oval" };

        string[] keys = new string[27];
        
        Random random = new Random();

        public Card GetCard() {
            string key = keys[random.Next(0, 27)];
            var cardTexture1 = textures[key];

            Card card = new Card(cardTexture1, Size, key, this);
            return card;
        }

        public void Dispose() {
            foreach (var guy in textures.ToArray()) {
                textures.Remove(guy.Key);
                guy.Value?.Dispose();
                NormalPen?.Dispose();
                HighlightPen?.Dispose();
            }
        }
    }
}
