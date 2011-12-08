using System.Diagnostics.Contracts;
using Descent.Messaging.Events;
using Descent.Model;
using Descent.Model.Player;
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
        private List<Equipment> currentEquipment = new List<Equipment>();
        private List<OverlordCard> overlordCards = new List<OverlordCard>();
        private List<Hero> heroes = new List<Hero>();
        private Dictionary<int, List<Equipment>> unequippedEquipment; 

        //TODO private List<Treasure> treasures;

        public GameState()
        {
            currentEquipment = new List<Equipment>();
            overlordCards = new List<OverlordCard>();
            heroes = new List<Hero>();
            unequippedEquipment = new Dictionary<int, List<Equipment>>();

            currentEquipment.AddRange(FullModel.AllEquipment);
            overlordCards.AddRange(FullModel.AllOverlordCards);
            heroes.AddRange(FullModel.AllHeroes);
            //TODO treasures.AddRange(FullModel.AllTreasures);

            // Listen to events
            Player.Instance.EventManager.GiveOverlordCardsEvent += GiveOverlordCards;
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

        public Equipment[] UnequippedEquipment(int playerId)
        {
            Contract.Requires(playerId > 0);
            if(!unequippedEquipment.Keys.Contains(playerId)) return new Equipment[0];
            return unequippedEquipment[playerId].ToArray();
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

        public void AddToUnequippedEquipment(int playerId, Equipment equipment)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(equipment != null);
            Contract.Ensures(UnequippedEquipment(playerId).Contains(equipment));

            if (unequippedEquipment[playerId] == null)
            {
                unequippedEquipment[playerId] = new List<Equipment>();
            }
            unequippedEquipment[playerId].Add(equipment);
        }

        public void RemoveFromUnequippedEquipment(int playerId, Equipment equipment)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(equipment != null);
            Contract.Ensures(!UnequippedEquipment(playerId).Contains(equipment));

            unequippedEquipment[playerId].Remove(equipment);
        }

        #region Event listeners

        private void GiveOverlordCards(object sender, GiveOverlordCardsEventArgs eventArgs)
        {
            RemoveOverlordCards(eventArgs.OverlordCardIds);
        }

        #endregion
    }
}
