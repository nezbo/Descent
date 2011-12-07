using System.Diagnostics.Contracts;
using Descent.Model;
using Descent.Model.Player.Figure;
using Descent.Model.Player.Figure.HeroStuff;
using Descent.Model.Player.Overlord;

namespace Descent.State
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Simon Henriksen & Martin Marcher
    /// </author>
    public class GameState
    {
        private List<Equipment> currentEquipment;
        private List<OverlordCard> overlordCards;
        private List<Hero> heroes;
        //TODO private List<Treasure> treasures;

        public GameState()
        {
            currentEquipment.AddRange(FullModel.AllEquipment);
            overlordCards.AddRange(FullModel.AllOverlordCards);
            heroes.AddRange(FullModel.AllHeroes);
            //TODO treasures.AddRange(FullModel.AllTreasures);
        }

        public Equipment[] CurrentEquipment
        {
            get { return currentEquipment.ToArray(); }
        }

        public bool CanBuyEquipment(int equipmentId)
        {
            Contract.Requires(FullModel.GetEquipment(equipmentId) != null);
            return CurrentEquipment.Contains(FullModel.GetEquipment(equipmentId));
        }

        public OverlordCard[] GetOverlordCards(int count)
        {
            return overlordCards.OrderBy(x => System.Guid.NewGuid()).Take(count).ToArray();
        }

        public Hero getHero()
        {
            return heroes.OrderBy(x => System.Guid.NewGuid()).First();
        }

        /// <summary>
        /// Gets the contents of a chest.
        /// </summary>
        /// <param name="chestId">Id of the chest.</param>
        /// <returns>{conquest tokens, coins, curses, treasures}</returns>
        public int[] getChestContents(int chestId)
        {
            //TODO
            return null;
        }

        public Treasure getTreasure(int treasureId)
        {
            //TODO
            return null;
        }

        public void RemoveEquipment(int equipmentId)
        {
            Contract.Requires(currentEquipment.Contains(FullModel.GetEquipment(equipmentId)));
            Contract.Ensures(!currentEquipment.Contains(FullModel.GetEquipment(equipmentId)));

            currentEquipment.Remove(FullModel.GetEquipment(equipmentId));
        }

        public void RemoveOverlordCards(int[] overlordCardIds)
        {
            Contract.Requires(overlordCardIds.Length > 0);
            overlordCards.RemoveAll(card => overlordCardIds.Contains(card.Id));
        }

        public void RemoveHero(int heroId)
        {
            Contract.Requires(FullModel.GetHero(heroId) != null);
            heroes.Remove(FullModel.GetHero(heroId));
        }

        /* TODO
        public void RemoveTreasure(int treasureId)
        {
            Contract.Requires(FullModel.GetTreasure(treasureId) != null);
            treasures.Remove(FullModel.GetTreasure(treasureId));
        }
        */
    }
}
