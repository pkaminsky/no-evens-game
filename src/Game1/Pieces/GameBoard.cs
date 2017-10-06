using Game1.Types;
using LilyPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Pieces {
    public class GameBoard<C> where C : Card {

        int ydim = 4;
        int xdim = 4;

        Size2D Sz { get; }
        protected int Capacity => ydim * xdim;
        protected int PopulationCount => Cards.Count;
        public int Vacancies => Capacity - PopulationCount;

        ICollection<C> Cards { get; set; } = new List<C>();
        C[,] chart;

        public GameBoard(GraphicsDevice gd) {
            Sz = new Size2D(gd.Viewport.Width, gd.Viewport.Height);
            chart = new C[ydim, xdim];
        }

        public C CheckClicksOrNull(Vector2 clickLoc) {
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
        }

        /// <summary>Also sets the position in the card</summary>
        public bool PlaceCard(C card) {

            var t = FindEmptySlotOrNull();

            if (t != null) {
                chart[t.Item1, t.Item2] = card;
                Cards.Add(card);
                SetCardScreenPosition(card, t.Item1, t.Item2);
                return true;
            }

            return false;
        }

        void SetCardScreenPosition(C card, int y, int x) {
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
            foreach (C card in Cards) {
                card.Draw(spriteBatch, drawBatch);
            }
        }
    }
}
