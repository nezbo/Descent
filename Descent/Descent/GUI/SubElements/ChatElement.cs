namespace Descent.GUI.SubElements
{
    using System.Collections.Generic;
    using Descent.Messaging.Events;
    using Descent.Model;
    using Descent.Model.Player;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The chat displays chat messages and has an input element as a child that is used to write
    /// chatmessages to the chat.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class ChatElement : GUIElement
    {
        private LinkedList<string> messages;

        /// <summary>
        /// Creates a new Chat for the given Game.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        public ChatElement(Game game)
            : base(game, "chat", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), (Player.Instance.NumberOfPlayers - 1) * 100, game.GraphicsDevice.Viewport.Width / 4, game.GraphicsDevice.Viewport.Height - (Player.Instance.NumberOfPlayers - 1) * 100)
        {
            InputElement input = new InputElement(game, "chatInput", Bound.X + 10, Bound.Y + Bound.Height - 40, Bound.Width - 18, 30);
            AddChild(input);

            messages = new LinkedList<string>();

            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("chatbg")),
                        new Rectangle(Bound.X, Bound.Y + Bound.Height - 50, Bound.Width, 50));

            // external events
            manager.ChatMessageEvent += new ChatMessageHandler(GetMessage);
            manager.GiveEquipmentEvent += new GiveEquipmentHandler(GiveEquipment);

            this.SetDrawBackground(true);
            this.SetBackground("chatbg");
        }

        private void SendMessage(string text)
        {

#if DEBUG
            // Allow for sending events directly through the chat if we're in debug.
            if (text.IndexOf("evt: ") == 0)
            {
                manager.QueueStringEvent(text.Substring(5));
                return;
            }
#endif

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
            int yPos = Bound.Y + Bound.Height - 80;

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

        private void GiveEquipment(object sender, GiveEquipmentEventArgs eventArgs)
        {
            string playerName = Player.Instance.GetPlayerNick(eventArgs.PlayerId);
            string equipmentName = FullModel.GetEquipment(eventArgs.EquipmentId).Name;

            if (eventArgs.Free)
            {
                FormatAndAdd(playerName + " received " + equipmentName + ".");
            }
            else
            {
                FormatAndAdd(playerName + " bought " + equipmentName + ".");
            }
        }
    }
}
