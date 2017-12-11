using Game1.Pieces;
using Game1.Types;
using LilyPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Stage1 {
    public class SimpleChoiceGameBoard : IGameBoard<Card> {

        int ydim = 1;
        int xdim = 4;

        Size2D Sz { get; }
        protected int Capacity => ydim * xdim;
        protected int PopulationCount => Cards.Count;
        public int Vacancies => Capacity - PopulationCount;

        ICollection<Card> Cards { get; set; } = new List<Card>();
        public bool Ready { get; private set; } = true;

        Card[,] chart;

        public SimpleChoiceGameBoard(Viewport gd) {
            Sz = new Size2D(gd.Width, gd.Height);
            chart = new Card[ydim, xdim];
        }

        public Card CheckClicksOrNull(Vector2 clickLoc) {
            foreach (var card in Cards) {
                var hitBox = card.Sz.ToRectangle(card.DrawPosition);
                if (hitBox.RectangleContains(clickLoc))
                    return card;
            }
            return null;
        }

        public void Update(GameTime timeOfGame) {
            foreach (var c in Cards) {
                c.Update(timeOfGame);
            }

            //animate a card being placed, when done, do this
            this.Ready = true;
        }

        /// <summary>Also sets the position in the card</summary>
        public bool PlaceCard(Card card) {

            var t = FindEmptySlotOrNull();

            if (t != null) {
                chart[t.Item1, t.Item2] = card;
                Cards.Add(card);
                SetCardScreenPosition(card, t.Item1, t.Item2);

                //don't let new cards be placed
                Ready = false;

                return true;
            }

            return false;
        }

        void SetCardScreenPosition(Card card, int y, int x) {
            var ypos = Sz.H / ydim * y;
            var xpos = Sz.W / xdim * x;

            //this could be computed somehow but what the hey
            xpos += 50;

            //my logic behind this was messed up so i just flipped the fractions again and again until it works
            var cardsPerScreen = Sz.H / (double)(card.Texture.Height + 30);
            var scalar = cardsPerScreen / 4;

            card.DrawPosition = new Vector2(xpos, ypos);
            card.Sz = new Size2D((int)(card.Texture.Width * scalar), (int)(card.Texture.Height * scalar));
        }

        Tuple<int, int> FindEmptySlotOrNull() {
            for (int y = 0; y < ydim; y++) {
                for (int x = 0; x < xdim; x++) {
                    if (chart[y, x] == null) {
                        return new Tuple<int, int>(y, x);
                    }
                }
            }
            return null;
        }

        public void DrawEm(SpriteBatch spriteBatch, DrawBatch drawBatch) {
            foreach (Card card in Cards) {
                card.Draw(spriteBatch, drawBatch);
            }
        }
    }
}
