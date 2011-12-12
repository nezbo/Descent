namespace Descent.GUI
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Takes input from the user and displays everything entered so far.
    /// The content can be deleted (character by character) by the backspace
    /// key and the value of a specific instance can be read (or set) statically by
    /// knowing the instance's key.
    /// </summary>
    public class InputElement : GUIElement
    {
        // static

        private static Dictionary<string, string> inputs = new Dictionary<string, string>();

        /// <summary>
        /// Gets the current input from a specific input element through it's key.
        /// If two input elements share the same key, they will display the same
        /// text and always change together.
        /// </summary>
        /// <param name="key">The the key for the input element whose input is wanted.</param>
        /// <returns>The text associated with the given key, if nothing entered so far 
        /// it will return an empty string if nothing found for the given key.</returns>
        public static string GetInputFrom(string key)
        {
            if (inputs.ContainsKey(key))
            {
                return inputs[key];
            }
            return "";
        }

        /// <summary>
        /// Sets the value for a given key.
        /// </summary>
        /// <param name="key">The key for the value to set.</param>
        /// <param name="input">The new input for the given key.</param>
        public static void SetInput(string key, string input)
        {
            inputs[key] = input;
        }

        // dynamic
        private Vector2 pos;

        /// <summary>
        /// Create a new input element at the given position and saves the input to its
        /// name (key).
        /// </summary>
        /// <param name="game">The current game object.</param>
        /// <param name="inputName">The name is used to (internally) save the input and
        /// to retrieve it externally.</param>
        /// <param name="x">The top-left x-coordinate.</param>
        /// <param name="y">The top-left x-coordinate.</param>
        /// <param name="width">The width of the input element.</param>
        /// <param name="height">The height of the input element.</param>
        public InputElement(Game game, string inputName, int x, int y, int width, int height)
            : base(game, inputName, x, y, width, height)
        {
            pos = new Vector2(Bound.X, Bound.Y);
        }

        public override void HandleKeyPress(Keys key)
        {
            if (HasFocus())
            {
                string soFar = GetInputFrom(this.Name);

                bool isShift = Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift);
                switch (key)
                {
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

                SetInput(this.Name, soFar);
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUI.Font, GetInputFrom(Name) + (HasFocus() ? "|" : ""), pos, Color.Black);
        }
    }
}
