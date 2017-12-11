using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1 {
    public interface IUpdate {
        void Update(GameTime gameTime);
    }

    public delegate void UpdateFunc(GameTime gameTime);
}
