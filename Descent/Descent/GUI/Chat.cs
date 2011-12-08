using Descent.Model;

namespace Descent.GUI
{
    using System.Collections.Generic;
    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Chat : GUIElement
    {
        private LinkedList<string> messages;

        public Chat(Game game)
            : base(game, "chat", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height / 2, game.GraphicsDevice.Viewport.Width / 4, game.GraphicsDevice.Viewport.Height / 2)
        {
            InputElement input = new InputElement(game, "chatInput", Bound.X + 10, Bound.Y + Bound.Height - 40, Bound.Width - 18, 30);
            //input.SetDrawBackground(false);
            AddChild(input);

            messages = new LinkedList<string>();

            // external events
            manager.ChatMessageEvent += new ChatMessageHandler(GetMessage);
            manager.RequestBuyEquipmentEvent += new RequestBuyEquipmentHandler(ItemBought);

            this.SetDrawBackground(true);
            this.SetBackground("chatbg");
        }

        private void SendMessage(string text)
        {
            string message = Player.Instance.Nickname + ": " + text;
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
                if (e.Name == "chatInput" && e.HasFocus() && key == Keys.Enter && InputElement.GetInputFrom("chatInput").Length > 0)
                {
                    SendMessage(InputElement.GetInputFrom("chatInput"));
                    InputElement.SetInput("chatInput", "");
                }
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            int textHeight = (int)GUI.Font.MeasureString("A").Y;
            int yPos = Bound.Height * 2 - 80;

            LinkedListNode<string> currentNode = messages.First;
            while (yPos > Bound.Y && currentNode != null)
            {
                draw.DrawString(GUI.Font, currentNode.Value, new Vector2(10 + Bound.X, yPos), Color.Black);
                currentNode = currentNode.Next;
                yPos -= textHeight;
            }
        }

        // events from outside to chat
        private void GetMessage(object sender, ChatMessageEventArgs eventArgs)
        {
            FormatAndAdd(eventArgs.ToString());
        }

        private void ItemBought(object sender, RequestBuyEquipmentEventArgs eventArgs)
        {
            string playerName = Player.Instance.GetPlayerNick(eventArgs.SenderId);
            string equipmentName = FullModel.GetEquipment(eventArgs.EquipmentId).Name;
            FormatAndAdd(playerName + " bought " + equipmentName + ".");
        }
    }
}
