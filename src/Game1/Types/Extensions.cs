using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Types {
    public static class Extensions {
        public static bool RectangleContains(this Rectangle rect, Vector2 vect) {
            return (vect.X > rect.Left && vect.X < rect.Right
                && vect.Y > rect.Top && vect.Y < rect.Bottom);
        }
    }
}
