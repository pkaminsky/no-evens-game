using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Types {
    public struct Size2D {
        public int W { get; }
        public int H { get; }

        public Size2D(int w, int h) {
            W = w;
            H = h;
        }

        public Size2D(Tuple<int, int> t) {
            W = t.Item1;
            H = t.Item2;
        }

        public Rectangle ToRectangle(int startX, int startY) {
            return new Rectangle(startX, startY, W, H);
        }

        public Rectangle ToRectangle(Vector2 vect) => ToRectangle((int)vect.X, (int)vect.Y);

        public static implicit operator Size2D(Tuple<int, int> t) => new Size2D(t.Item1, t.Item2);
    }
}
