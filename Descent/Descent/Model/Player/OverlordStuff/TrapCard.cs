
namespace Descent.Model.Player.OverlordStuff
{
    /// <summary>
    /// A type of Overlord_Card to make traps
    /// </summary>
    /// <author>
    /// Jonas Breindahl
    /// </author>
    public class TrapCard : OverlordCard
    {
        public TrapCard(int id, string name, string description, int playPrice, int sellPrice)
            : base(id, name, description, playPrice, sellPrice, OverlordCardType.Trap)
        {
            
        }

        public override void PlayCard()
        {
            // TODO: Play card
        }
    }
}
