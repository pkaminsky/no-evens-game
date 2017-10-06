using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Threading.Tasks;
using Game1.Types;
using LilyPath;
using Game1.Pieces;

namespace Game1 {
    public class Card {
        public Vector2 DrawPosition { get; set; }
        public Size2D Sz { get; set; }

        public Rectangle GetRect() => Sz.ToRectangle(DrawPosition);

        public Texture2D Texture { get; }
        public string Value { get; set; }
        public Dealer Factory { get; }

        public string ValueTrait0 => _valueSplit[0];
        public string ValueTrait1 => _valueSplit[1];
        public string ValueTrait2 => _valueSplit[2];
        private string[] _valueSplit;

        public bool Selected { get; set; }

        public Card(Texture2D texture, Size2D sz, string value, Dealer factory) {
            Texture = texture;
            Value = value;
            _valueSplit = Value.Split('_');
            Factory = factory;
            Sz = sz;
        }

        public void Draw(SpriteBatch drw, DrawBatch drawBatch) {
            var rect = GetRect();
            drawBatch.DrawRectangle(Selected ? Factory.HighlightPen : Factory.NormalPen, rect);
            drw.Draw(Texture, rect, Color.White);
        }

        public void Update(GameTime timeOfGame) {

        }
    }

    public class FuglyBirdCard {
        public Vector2 DrawPosition { get; set; }
        public Size2D Sz { get; set; }

        public Rectangle GetRect() => Sz.ToRectangle(DrawPosition);

        public Texture2D Texture { get; }
        public string Value { get; set; }
        public Dealer Factory { get; }

        public char ValueTrait0 => Value[0];
        public char ValueTrait1 => Value[1];
        public char ValueTrait2 => Value[2];

        public bool Selected { get; set; }

        public FuglyBirdCard(Texture2D texture, Size2D sz, string value, Dealer factory) {
            Texture = texture;
            Value = value;
            Factory = factory;
            Sz = sz;
        }

        public void Draw(SpriteBatch drw, DrawBatch drawBatch) {
            var rect = GetRect();
            drawBatch.DrawRectangle(Selected ? Factory.HighlightPen : Factory.NormalPen, rect);
            drw.Draw(Texture, rect, Color.White);
        }

        public void Update(GameTime timeOfGame) {

        }
    }
}
