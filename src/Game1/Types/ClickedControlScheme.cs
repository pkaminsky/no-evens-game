using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Types {
    public class ClickedControlScheme {
        public MouseState CurrentMouseState { get; private set; }
        public MouseState Previous { get; private set; }

        public ClickedControlScheme(MouseState initialState, MouseState? previous = null) {
            CurrentMouseState = initialState;
            Previous = previous ?? initialState;
        }

        //dis is dumb, should make a clicks queue to preserve the coordinates of clicks or whatever
        public bool IfClicked(Action<MouseState> doAction) {
            Previous = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
            if (Previous.LeftButton == ButtonState.Pressed
                && CurrentMouseState.LeftButton == ButtonState.Released) {
                doAction?.Invoke(CurrentMouseState);
                return true;
            }
            return false;
        }

    }
}
