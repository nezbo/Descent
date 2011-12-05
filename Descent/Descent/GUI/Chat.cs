﻿namespace Descent.GUI
{
    using System.Collections.Generic;
    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Chat : GUIElement
    {
        private Text input;
        private LinkedList<string> messages;

        public Chat(Game game)
            : base(game, "chat", (int)(game.Window.ClientBounds.Width * (3 / 4.0)), game.Window.ClientBounds.Height / 2, game.Window.ClientBounds.Width / 4 - 10, game.Window.ClientBounds.Height / 2)
        {
            //AddText("chat", "", new Vector2(10, Bound.Height - 50));
            //input = texts[0];

            AddChild(new InputElement(game, "chatInput", Bound.X + 10, Bound.Y + Bound.Height - 50, Bound.Width - 10, 50));

            messages = new LinkedList<string>();

            manager.ChatMessageEvent += new ChatMessageHandler(GetMessage);

            this.SetDrawBackground(true);
        }

        private void GetMessage(object sender, ChatMessageEventArgs eventArgs)
        {
            FormatAndAdd(eventArgs.ToString());
        }

        private void SendMessage(string text)
        {
            string message = Player.Instance.Name + ": " + text;
            manager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs(message));
        }

        private void FormatAndAdd(string text)
        {
            string[] lines = WordWrap(text, new Vector2(10, 0)).Split('\n');
            foreach (string s in lines) messages.AddFirst(s);
        }

        public override void HandleKeyPress(Keys key)
        {
            base.HandleKeyPress(key);

            foreach (GUIElement e in children)
            {
                if (e.Name == "chatInput" && e.HasFocus() && key == Keys.Enter)
                {
                    SendMessage(GUIHolder.GetInputFrom("chatInput"));
                    GUIHolder.SetInput("chatInput", "");
                }
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            int textHeight = (int)GUIHolder.Font.MeasureString("A").Y;
            int yPos = Bound.Height * 2 - 80;

            LinkedListNode<string> currentNode = messages.First;
            while (yPos > Bound.Y && currentNode != null)
            {
                draw.DrawString(GUIHolder.Font, currentNode.Value, new Vector2(10 + Bound.X, yPos), Color.Black);
                currentNode = currentNode.Next;
                yPos -= textHeight;
            }
        }
    }
}