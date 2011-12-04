namespace Descent.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Descent.Messaging.Events;
    using Microsoft.Xna.Framework.Graphics;
    using Descent.Model.Player;

    public class Chat : GUIElement
    {
        private Text input;
        private LinkedList<string> messages;

        public Chat(Game game)
            : base(game, "chat", (int) (game.Window.ClientBounds.Width*(3/4.0)), game.Window.ClientBounds.Height/2, game.Window.ClientBounds.Width/4 - 10,game.Window.ClientBounds.Height/2)
        {
            AddText("chat", "", new Vector2(10, Bound.Height - 50));
            input = texts[0];
            messages = new LinkedList<string>();

            manager.ChatMessageEvent += new ChatMessageHandler(GetMessage);

            this.SetDrawBackground(true);
        }

        private void GetMessage(object sender, ChatMessageEventArgs eventArgs)
        {
            FormatAndAdd(eventArgs.ToString());
        }

        private void FormatAndAdd(string text)
        {
            string[] lines = WordWrap(Player.Instance.Name+": "+ text, new Vector2(10, 0)).Split('\n');
            foreach (string s in lines) messages.AddFirst(s);
        }

        public override void HandleKeyPress(Keys key)
        {
            if (HasFocus())
            {
                bool isShift = Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift);
                switch (key)
                {
                    case Keys.Enter: { if (input.Line.Length > 0) { FormatAndAdd(input.Line); input.Line = ""; } break; }
                    case Keys.Back: { if (input.Line.Length > 0) { input.Line = input.Line.Substring(0, input.Line.Length - 1); } break; }
                    case Keys.Space: { input.Line += " "; break; }
                    case Keys.OemPeriod: { input.Line += (isShift == true) ? ":" : "."; break; }
                    case Keys.OemComma: { input.Line += (isShift == true) ? ";" : ","; break; }
                    case Keys.OemPlus: { input.Line += (isShift == true) ? "?" : "+"; break; }
                    case Keys.OemOpenBrackets: { input.Line += (isShift == true) ? "`" : "´"; break; }
                    case Keys.OemCloseBrackets: { input.Line += (isShift == true) ? "Å" : "å"; break; }
                    case Keys.OemQuotes: { input.Line += (isShift == true) ? "Ø" : "ø"; break; }
                    case Keys.OemTilde: { input.Line += (isShift == true) ? "Æ" : "æ"; break; }
                    case Keys.OemQuestion: { input.Line += (isShift == true) ? "*" : "'"; break; }
                    case Keys.OemSemicolon: { input.Line += (isShift == true) ? "^" : "¨"; break; }
                    case Keys.OemBackslash: { input.Line += (isShift == true) ? ">" : "<"; break; }
                    case Keys.OemMinus: { input.Line += (isShift == true) ? "_" : "-"; break; }
                    case Keys.D1: { input.Line += (isShift == true) ? "!" : "1"; break; }
                    case Keys.D2: { input.Line += (isShift == true) ? "\"" : "2"; break; }
                    case Keys.D3: { input.Line += (isShift == true) ? "#" : "3"; break; }
                    case Keys.D4: { input.Line += (isShift == true) ? "¤" : "4"; break; }
                    case Keys.D5: { input.Line += (isShift == true) ? "%" : "5"; break; }
                    case Keys.D6: { input.Line += (isShift == true) ? "&" : "6"; break; }
                    case Keys.D7: { input.Line += (isShift == true) ? "/" : "7"; break; }
                    case Keys.D8: { input.Line += (isShift == true) ? "(" : "8"; break; }
                    case Keys.D9: { input.Line += (isShift == true) ? ")" : "9"; break; }
                    case Keys.D0: { input.Line += (isShift == true) ? "=" : "0"; break; }
                    default: { if (key.ToString().Length == 1) { input.Line += ((isShift == true) ? key.ToString() : key.ToString().ToLower()); } break; }
                }
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            int textHeight = (int) FontHolder.Font.MeasureString("A").Y;
            int yPos = Bound.Height*2 - 80 ;

            LinkedListNode<string> currentNode = messages.First;
            while(yPos > Bound.Y && currentNode != null)
            {
                draw.DrawString(FontHolder.Font, currentNode.Value, new Vector2(10 + Bound.X, yPos), Color.Black);
                currentNode = currentNode.Next;
                yPos -= textHeight;
            }
        }
    }
}
