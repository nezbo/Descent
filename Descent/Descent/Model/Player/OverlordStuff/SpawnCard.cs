namespace Descent.Model.Player.OverlordStuff
{
    using Descent.Model.Player.Figure;

    /// <summary>
    /// A type of Overlord_Card that lets the overlord spawn more monsters
    /// </summary>
    /// <author>
    /// Martin Marcher
    /// </author>
    public class SpawnCard : OverlordCard
    {
        private readonly Monster[] monstersToSpawn;

        public Monster[] MonstersToSpawn
        {
            get { return monstersToSpawn; }
        }

        public SpawnCard(int id, string name, string description, int playPrice, int sellPrice, Monster[] spawnMonsters)
            : base(id, name, description, playPrice, sellPrice, OverlordCardType.Spawn)
        {
            monstersToSpawn = spawnMonsters;
        }

        public override void PlayCard()
        {
            // TODO: Monster spawn event
        }
    }
}
