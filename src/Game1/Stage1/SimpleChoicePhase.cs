using Game1.Pieces;
using Game1.Types;
using LilyPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Game1.Stage1 {
    public interface IPhase<T> where T : struct {
        T MyState { get; }
        void Update(GameTime gameTime);
        void DrawEm(SpriteBatch spriteBatch, DrawBatch drawBatch);
    }

    public class SimpleChoicePhase : IPhase<SimpleChoicePhase.State> {

        public enum State {
            Default = 0,
            Dealing,
            Choosing,
            WrongChoice,
            CorrectChoice,
            Done,
        }

        public State MyState { get; private set; } = State.Dealing;
        public SimpleChoiceGameBoard GameBoard { get; }
        public Dealer Dealer { get; }
        public SpriteFont Font { get; }
        public ClickedControlScheme Controls { get; }

        private string message = null;

        SelectionCollection selections = new SelectionCollection();

        public SimpleChoicePhase(Viewport viewPort, Dealer dealer, SpriteFont font, IEnumerable<Card> iv = null) {
            GameBoard = new SimpleChoiceGameBoard(viewPort);
            Dealer = dealer;
            Font = font;
            Controls = new ClickedControlScheme(Mouse.GetState(), Mouse.GetState());

            _deck = new Stack<Card>(iv ?? new Card[] {
                Dealer.GetCard(CardColor.green, CardFill.solid, CardShape.diamond),
                Dealer.GetCard(CardColor.green, CardFill.solid, CardShape.diamond),
                Dealer.GetCard(CardColor.green, CardFill.solid, CardShape.oval),
                Dealer.GetCard(CardColor.green, CardFill.solid, CardShape.diamond)
            });
        }

        public void Update(GameTime gameTime) {
            switch (MyState) {
                case State.Dealing:
                    Deal(gameTime);
                    break;
                case State.Choosing:
                    Choose(gameTime);
                    break;
                case State.WrongChoice:
                    ShowWrongChoice(gameTime);
                    break;
                case State.CorrectChoice:
                    ShowRightChoice(gameTime);
                    break;
                case State.Done:
                    DoComplete(gameTime);
                    break;
                default:
                    throw new InvalidOperationException("argh");
            }

            GameBoard.Update(gameTime);
        }

        public void DrawEm(SpriteBatch spriteBatch, DrawBatch drawBatch) {
            GameBoard.DrawEm(spriteBatch, drawBatch);
            spriteBatch.DrawString(Font, "aids galore", new Vector2(50, 50), Color.Black);
        }

        private void ShowRightChoice(GameTime gameTime) {
            throw new NotImplementedException();
        }

        private void DoComplete(GameTime gameTime) {
            throw new NotImplementedException();
        }

        private void ShowWrongChoice(GameTime gameTime) {
            throw new NotImplementedException();
        }

        private void Choose(GameTime gameTime) {
            Controls.IfClicked(OnClicked);
        }

        private void OnClicked(MouseState mouse) {
            var hit = GameBoard.CheckClicksOrNull(new Vector2(mouse.X, mouse.Y));
            if (hit != null) {
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
        }

        private void HandleMatch() {
            Debug.WriteLine("WOWW");
            selections.Clear();
        }

        private void Deal(GameTime gameTime) {
            if (GameBoard.Vacancies > 0) {
                if (GameBoard.Ready) {
                    var c = _deck.Peek();

                    if (GameBoard.PlaceCard(c)) {
                        _deck.Pop();
                    }
                }
            }
            else {
                MyState = State.Choosing;
            }
        }

        private Stack<Card> _deck;
    }
}
