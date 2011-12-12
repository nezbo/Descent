using Descent.Messaging.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    using Descent.Model.Player.OverlordStuff;

    class OverlordCardElement : GUIElement
    {
        private static SpriteFont Font { get; set; }
        private bool up = false;

        public OverlordCardElement(Game game, int x, int y, OverlordCard card)
            : base(game, "overlord card", x, y, 200, 300)
        {
            if (Font == null) Font = game.Content.Load<SpriteFont>("fontSmall");

            SetBackground("Images/Other/overlordcard");

            // header
            GUIElement header = new GUIElement(game, "overlord header", Bound.X + 48, Bound.Y + 15, 200 - 48 * 2, 100);
            header.AddText(header.Name, card.Name, new Vector2(0, 0));
            header.SetDrawBackground(false);
            header.SetFont(Font);
            AddChild(header);

            // description
            GUIElement description = new GUIElement(game, "overlord desc", Bound.X + 35, Bound.Y + 80, 150, 160);
            description.AddText(description.Name, card.Decription, new Vector2(0, 0));
            description.SetDrawBackground(false);
            description.SetFont(Font);
            AddChild(description);

            // use area
            GUIElement use = new GUIElement(game, "use overlord card", Bound.X + 10, Bound.Y + 250, 50, 40);
            use.SetDrawBackground(false);
            use.SetClickAction(use.Name, (n, g) =>
                                             {
                                                 n.EventManager.QueueEvent(EventType.UseOverlordCard, new OverlordCardEventArgs(card.Id));
                                             });

            string playPrice = "" + card.PlayPrice;
            Vector2 playDisp = GUI.Font.MeasureString(playPrice);
            use.AddText(use.Name, playPrice, new Vector2((use.Bound.Width - playDisp.X) / 2, (use.Bound.Height - playDisp.Y) / 2));
            AddChild(use);

            // sell area
            GUIElement sell = new GUIElement(game, "sell overlord card", Bound.X + 140, Bound.Y + 250, 50, 40);
            sell.SetDrawBackground(false);
            sell.SetClickAction(sell.Name, (n, g) =>
                                               {
                                                   n.EventManager.QueueEvent(EventType.RemoveOverlordCard, new OverlordCardEventArgs(card.Id));
                                               });

            string sellPrice = "" + card.SellPrice;
            Vector2 sellDisp = GUI.Font.MeasureString(sellPrice);
            sell.AddText(sell.Name, sellPrice, new Vector2((sell.Bound.Width - sellDisp.X) / 2, (sell.Bound.Height - sellDisp.Y) / 2));
            AddChild(sell);
        }

        protected override void ActOnDirectClick(int x, int y)
        {
            Move(0, up ? 275 : -275);
            up = !up;
        }
    }
}
