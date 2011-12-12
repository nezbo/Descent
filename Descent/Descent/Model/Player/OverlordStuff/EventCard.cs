namespace Descent.Model.Player.OverlordStuff
{
    /// <summary>
    /// A type of overlord card that lets the overlord play one time abilities
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class EventCard : OverlordCard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventCard"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the card
        /// </param>
        /// <param name="name">
        /// The name of the card
        /// </param>
        /// <param name="description">
        /// The description of the card
        /// </param>
        /// <param name="playPrice">
        /// The play price to play the card
        /// </param>
        /// <param name="sellPrice">
        /// The sell price of the card
        /// </param>
        public EventCard(int id, string name, string description, int playPrice, int sellPrice)
            : base(id, name, description, playPrice, sellPrice, OverlordCardType.Event)
        {
            
        }

        public override void PlayCard()
        {
            // TODO: Play card
        }
    }
}
