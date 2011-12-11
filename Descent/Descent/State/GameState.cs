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

    using Descent.Model.Board.Marker;
    using Descent.Model.Event;

    public delegate T Bonus<T>();

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
        private List<Monster> monstersLeftToAct = new List<Monster>();
        private Dictionary<int, List<Equipment>> unequippedEquipment;

        private List<Chest> chestsLeft = new List<Chest>();
        public List<Monster> LegendaryMonsters { get; set; } 

        private List<Treasure> treasures;

        public GameState()
        {
            currentEquipment = new List<Equipment>();
            overlordCards = new List<OverlordCard>();
            heroes = new List<Hero>();
            unequippedEquipment = new Dictionary<int, List<Equipment>>();
            treasures = new List<Treasure>();

            currentEquipment.AddRange(FullModel.AllEquipment);
            overlordCards.AddRange(FullModel.AllOverlordCards);
            heroes.AddRange(FullModel.AllHeroes);
            treasures.AddRange(FullModel.AllTreasures);

            chestsLeft.AddRange(FullModel.AllChests);

            // Listen to events
            Player.Instance.EventManager.GiveOverlordCardsEvent += GiveOverlordCards;
            Player.Instance.EventManager.GiveEquipmentEvent += GiveEquipment;
        }

        public int CurrentPlayer { get; set; }

        public Attack CurrentAttack { get; set; }

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
            Console.WriteLine("OoverlordCards.Count:" + overlordCards.Count);
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

        public int GetRandomChestID(EquipmentRarity rarity)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int n = chestsLeft.Count(c => c.Rarity == rarity);
            Chest chest = chestsLeft.Where(c1 => c1.Rarity == rarity).ToArray()[n];
            // TODO Make sure that the chest is removed from the list of chests left at all clients
            return chest.Id;
        }

        /// <summary>
        /// Gets the contents of a chest.
        /// This method will remove the 
        /// </summary>
        /// <param name="chestId">Id of the chest.</param>
        /// <returns>{conquest tokens, coins, curses, treasures}</returns>
        public int[] getChestContents(int chestId)
        {
            // TODO: This should just return the chest itself?
            Chest c = FullModel.AllChests.Single(i => i.Id == chestId);
            chestsLeft.Remove(c);
            return new int[]{c.ConquestTokens, c.Coin, c.Curses, c.Treasures};
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
            Contract.Ensures(UnequippedEquipment(playerId).Contains(equipment));

            if (!unequippedEquipment.ContainsKey(playerId))
            {
                unequippedEquipment[playerId] = new List<Equipment>();
            }
            unequippedEquipment[playerId].Add(equipment);
        }

        public void RemoveFromUnequippedEquipment(int playerId, Equipment equipment)
        {
            Contract.Requires(playerId > 0);

            unequippedEquipment[playerId].Remove(equipment);
        }

        public void RemoveAllUnequippedEquipment(int playerId)
        {
            Contract.Requires(playerId > 0);
            Contract.Ensures(UnequippedEquipment(playerId).Length == 0);

            if(unequippedEquipment.ContainsKey(playerId)) unequippedEquipment[playerId].Clear();
        }

        #region Event listeners

        private void GiveOverlordCards(object sender, GiveOverlordCardsEventArgs eventArgs)
        {
            RemoveOverlordCards(eventArgs.OverlordCardIds);
        }

        private void GiveEquipment(object sender, GiveEquipmentEventArgs eventArgs)
        {
            RemoveEquipment(eventArgs.EquipmentId);
        }

        #endregion
    }
}
