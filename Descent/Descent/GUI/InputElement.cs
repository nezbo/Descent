﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Descent.GUI
{
    public class InputElement : GUIElement
    {
        private Vector2 pos;

        public InputElement(Game game, string inputName, int x, int y, int width, int height)
            : base(game, inputName, x, y, width, height)
        {
            pos = new Vector2(Bound.X, Bound.Y);
        }

        public override void HandleKeyPress(Keys key)
        {
            string name = Name;
            if (HasFocus())
            {
                string soFar = GUIHolder.GetInputFrom(this.Name);

                bool isShift = Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift);
                switch (key)
                {
                    //case Keys.Enter: { if (soFar.Length > 0) { SendMessage(soFar); soFar = ""; } break; }
                    case Keys.Back: { if (soFar.Length > 0) { soFar = soFar.Substring(0, soFar.Length - 1); } break; }
                    case Keys.Space: { soFar += " "; break; }
                    case Keys.OemPeriod: { soFar += isShift ? ":" : "."; break; }
                    case Keys.OemComma: { soFar += isShift ? ";" : ","; break; }
                    case Keys.OemPlus: { soFar += isShift ? "?" : "+"; break; }
                    case Keys.OemOpenBrackets: { soFar += isShift ? "`" : "´"; break; }
                    case Keys.OemCloseBrackets: { soFar += isShift ? "Å" : "å"; break; }
                    case Keys.OemQuotes: { soFar += isShift ? "Ø" : "ø"; break; }
                    case Keys.OemTilde: { soFar += isShift ? "Æ" : "æ"; break; }
                    case Keys.OemQuestion: { soFar += isShift ? "*" : "'"; break; }
                    case Keys.OemSemicolon: { soFar += isShift ? "^" : "¨"; break; }
                    case Keys.OemBackslash: { soFar += isShift ? ">" : "<"; break; }
                    case Keys.OemMinus: { soFar += isShift ? "_" : "-"; break; }
                    case Keys.D1: { soFar += isShift ? "!" : "1"; break; }
                    case Keys.D2: { soFar += isShift ? "\"" : "2"; break; }
                    case Keys.D3: { soFar += isShift ? "#" : "3"; break; }
                    case Keys.D4: { soFar += isShift ? "¤" : "4"; break; }
                    case Keys.D5: { soFar += isShift ? "%" : "5"; break; }
                    case Keys.D6: { soFar += isShift ? "&" : "6"; break; }
                    case Keys.D7: { soFar += isShift ? "/" : "7"; break; }
                    case Keys.D8: { soFar += isShift ? "(" : "8"; break; }
                    case Keys.D9: { soFar += isShift ? ")" : "9"; break; }
                    case Keys.D0: { soFar += isShift ? "=" : "0"; break; }
                    default: { if (key.ToString().Length == 1) { soFar += ((isShift == true) ? key.ToString() : key.ToString().ToLower()); } break; }
                }

                GUIHolder.SetInput(this.Name, soFar);
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUIHolder.Font, GUIHolder.GetInputFrom(Name) + (HasFocus() ? "|" : ""), pos, Color.Black);
        }
    }
}