
namespace Descent.Model.Player.OverlordStuff
{
    /// <summary>
    /// The power card will give the overlord extra abilities and boosts, 
    /// but are more expensive than reguar cards.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class PowerCard : OverlordCard
    {
        public PowerCard(int id, string name, string description, int playPrice, int sellPrice)
            : base(id, name, description, playPrice, sellPrice, OverlordCardType.Power)
        {
            
        }

        public override void PlayCard()
        {
            // TODO: Play card
        }
    }
}
