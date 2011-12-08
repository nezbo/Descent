namespace Descent.Model.Player.Overlord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Figure;

    /// <summary>
    /// TODO: Update summary.
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
            : base(id, name, description, playPrice, sellPrice)
        {
            monstersToSpawn = spawnMonsters;
        }

        public override void PlayCard()
        {
            // TODO: Monster spawn event
        }
    }
}
