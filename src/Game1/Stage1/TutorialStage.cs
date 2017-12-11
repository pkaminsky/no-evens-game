using Game1.Pieces;
using Game1.Stage1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Scene1 {
    public class TutorialStage {
        public AppResources Rsc { get; }

        public Dealer Dealer { get; private set; }
        SelectionCollection selections = new SelectionCollection();

        SpriteFont Font { get; set; }

        private IPhase<SimpleChoicePhase.State> _phase;

        public TutorialStage(AppResources resources) {
            Rsc = resources;
        }

        public void LoadContent() {
            Dealer = new Dealer(Rsc.Pipeline); //dealer generates cards
            Font = Rsc.Pipeline.Load<SpriteFont>("Fonts\\Font1");
            _phase = new SimpleChoicePhase(Rsc.GraphicsDevice.Viewport, Dealer, Font);
        }

        public void UnloadContent() {
            Dealer?.Dispose();
        }

        public void Update(GameTime gameTime) {

            UpdateMouseState();

            //while (GameBoard.Vacancies > 0) {
            //    var newCard = Dealer.GetCard();
            //    GameBoard.PlaceCard(newCard);
            //}
            //GameBoard.Update(gameTime);

            _phase.Update(gameTime);

            if (_phase.MyState == SimpleChoicePhase.State.Done) {
                Debugger.Break();
            }
        }

        private void UpdateMouseState() {
            
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            currentMouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            var currentState = currentMouseState.LeftButton;
            if (_lastState == ButtonState.Pressed && currentState == ButtonState.Released) {
                //var card = Board.CheckClicksOrNull(mousePosition);
                //if (card != null)
                //    OnClick(card);
            }
            _lastState = currentState;
        }
        ButtonState _lastState = ButtonState.Released;
        GamePadState currentGamePadState;
        MouseState currentMouseState;

        private void OnClick(Card hit) {
            if (hit.Selected) {
                hit.Selected = false;
                selections.Remove(hit);
                return;
            }

            if (selections.IsFull) return;
            Debug.Write(hit.Value + "\t");

            selections.AddCardo(hit);
            hit.Selected = true;

            if (selections.IsFull) {
                bool match = selections.IsMatch();
                if (match) {
                    HandleMatch();
                }
                else {
                    Debug.WriteLine("NOOO");
                    selections.Clear();
                }
            }
        }

        private void HandleMatch() {
            Debug.WriteLine("WOWW");
            selections.Clear();
        }

        public void Draw(GameTime gameTime) {
            _phase.DrawEm(Rsc.SpriteBatch, Rsc.DrawBatch);
        }
    }
}
