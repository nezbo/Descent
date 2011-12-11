
using Descent.Model.Player.Overlord;

namespace Descent.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;

    using Descent.Model.Board;
    using Descent.Model.Board.Marker;
    using Descent.Model.Event;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Full Model has access to the entire model of the program,
    /// and the responsebility of loading/creating the model entities.
    /// When the game needs instances of monsters, dice or heroes,
    /// they call the FullModel which then returns a 
    /// Holds references to all model related classes
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class FullModel
    {
        #region Fields

        private static Game game;

        private static List<Monster> monsters;

        private static List<Monster> legendaryMonsters = new List<Monster>();

        private static int monstersInPlay;

        private static int markersOnBoard = 0;

        private static List<Hero> heroes;

        private static List<OverlordCard> overlordCards;

        private static Dictionary<EDice, Dice> diceDictionary;

        private static List<Equipment> townEquipment;

        private static Dictionary<EquipmentRarity, List<Treasure>> treasures = new Dictionary<EquipmentRarity, List<Treasure>>();

        private static List<Marker> markers;

        private static List<Chest> chests;

        private static List<Skill> skills;

        private static Board.Board board;

        private static HeroParty heroParty;

        /// <summary>
        /// Gets the instance of the board
        /// Can I have the board?
        /// </summary>
        public static Board.Board Board
        {
            get
            {
                return board;
            }
        }

        #endregion

        #region Load Content

        /// <summary>
        /// Load all content!
        /// This includes monsters, heroes, cards, equipment, dice and the map.
        /// </summary>
        /// <param name="game">
        /// The game object
        /// </param>
        public static void LoadContent(Game game)
        {
            Contract.Requires(game != null);

            if (FullModel.game != null)
            {
                Debug.Assert(false, "Content was loaded more than one time");
            }

            FullModel.game = game;
            heroParty = new HeroParty();
            overlordCards = new List<OverlordCard>();

            LoadDice(game);
            LoadMonsters(game);
            LoadEquipment(game);
            LoadMap(game);
            LoadHeroes(game);
            LoadOverlordCards(game);
            LoadSkillCards(game);
        }

        #region Load Monsters
        /// <summary>
        /// Loads the monsters from the file monsters.txt
        /// </summary>
        /// <param name="game">
        /// The game object
        /// </param>
        private static void LoadMonsters(Game game)
        {
            if (FullModel.monsters != null) return;
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("monsters.txt"));

            int n = int.Parse(reader.ReadLine());
            string line;

            List<Monster> monsters = new List<Monster>();
            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();

                if (line.StartsWith("//")) continue;

                string[] data = line.Split(',');
                System.Diagnostics.Debug.Assert(data.Length == 11, "Error when parsing monsters, at line " + (i + 2));

                int id = int.Parse(data[0]);
                string name = data[1].Substring(1, data[1].Length - 2);
                bool master = bool.Parse(data[2]);
                int speed = int.Parse(data[3]);
                int health = int.Parse(data[4].Split('/')[2]); // TODO: How many players are playing?
                int armor = int.Parse(data[5]);
                EAttackType type = data[6].Equals("MELEE")
                                       ? EAttackType.MELEE
                                       : (data[5].Equals("MAGIC") ? EAttackType.MAGIC : EAttackType.RANGED);

                List<Dice> attackDice = (
                    from string dice
                        in data[7].Split(' ')
                    select GetDice(dice)).ToList<Dice>();

                List<Ability> abilities = data[8].Split('/').Select(Ability.GetAbility).ToList();


                Rectangle size = new Rectangle(0, 0, int.Parse(data[9]), int.Parse(data[10]));

                Texture2D texture = game.Content.Load<Texture2D>("Images/Monsters/" + id);

                Monster m = new Monster(id, name, master, speed, health, armor, type, attackDice, size, texture);
                foreach (Ability ability in abilities)
                {
                    ability.Apply(m);
                }

                m.Initialize();
                monsters.Add(m);
            }

            FullModel.monsters = monsters;
            System.Diagnostics.Debug.WriteLine("Monsters loaded successfully!");
        }
        #endregion

        #region Load Dice
        /// <summary>
        /// Loads all dice from 
        /// </summary>
        /// <param name="game">
        /// The game.
        /// </param>
        private static void LoadDice(Game game)
        {
            if (diceDictionary != null) return;

            StreamReader reader = new StreamReader(TitleContainer.OpenStream("dice.txt"));

            int n = int.Parse(reader.ReadLine());
            string line;

            Dictionary<EDice, Dice> dice = new Dictionary<EDice, Dice>();
            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();
                string[] data = line.Split(',');
                System.Diagnostics.Debug.Assert(data.Length == 7, "Error in dice file, at line " + (i + 1));

                EDice eDice;
                Enum.TryParse(data[0], false, out eDice);

                Texture2D[] textures = new Texture2D[8];
                int[][] sides = new int[8][];
                for (int side = 0; side < 6; side++)
                {
                    sides[side] = new int[4];

                    char[] sideArray = data[side + 1].ToCharArray();
                    textures[side] = game.Content.Load<Texture2D>("Images/Dice/" + data[0] + data[side + 1]);

                    for (int value = 0; value < 4; value++)
                    {
                        sides[side][value] = int.Parse(sideArray[value] + string.Empty);
                    }
                }

                if (eDice == EDice.B)
                {
                    textures[6] = game.Content.Load<Texture2D>("Images/Dice/B1000");
                    textures[7] = game.Content.Load<Texture2D>("Images/Dice/B0100");
                    sides[6] = new int[4] { 1, 0, 0, 0 };
                    sides[7] = new int[4] { 0, 1, 0, 0 };
                }

                dice[eDice] = new Dice(eDice, sides, textures);
            }

            diceDictionary = dice;
            System.Diagnostics.Debug.WriteLine("Dice loaded successfully!");
        }

        #endregion

        #region Load Equipement

        private static void LoadEquipment(Game game)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("equipmentWithTreasure.txt"));

            int n = int.Parse(reader.ReadLine());
            string line;

            List<Equipment> equipmentList = new List<Equipment>();

            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();
                if (line.StartsWith("//")) continue;

                string[] data = line.Split(',');
                System.Diagnostics.Debug.Assert(data.Length == 12, "Error when loading equipment, at line " + (i + 2));

                Equipment eq = LoadEquipment(data);

                for (int j = 0; j < int.Parse(data[8]); j++)
                {
                    equipmentList.Add(eq);
                }
            }

            townEquipment = equipmentList;
            System.Diagnostics.Debug.WriteLine("Common equipment loaded successfully!");

            LoadTreasures(game, reader);

            System.Diagnostics.Debug.WriteLine("Equipment loaded successfully!");
        }

        private static void LoadTreasures(Game game, StreamReader reader)
        {
            int n = int.Parse(reader.ReadLine());

            // Instantiating all lists
            treasures = new Dictionary<EquipmentRarity, List<Treasure>>();
            foreach (EquipmentRarity rarity in Enum.GetValues(typeof(EquipmentRarity)))
            {
                treasures[rarity] = new List<Treasure>();
            }

            // running over all treasures
            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                if (line.StartsWith("//")) continue;

                string[] data = line.Split(',');

                EquipmentRarity rarity;
                EquipmentRarity.TryParse(data[2], out rarity);

                if (data[1].Equals("Treasure Cache"))
                {
                    treasures[rarity].Add(
                        new Treasure(
                            int.Parse(data[0]), 
                            data[1], 
                            rarity, 
                            data[10].Contains("Potion Vitality") ? 
                                GetEquipment(12) : 
                                data[10].Contains("Potion Healing") ? 
                                    GetEquipment(11) : 
                                    null, 
                            data[10].Contains("Coins") ? int.Parse(data[10].Split(' ').Last()) : 0));
                }
                else
                {
                    treasures[rarity].Add(new Treasure(int.Parse(data[0]), data[1] , rarity, LoadEquipment(data), 0));
                }
            }

            System.Diagnostics.Debug.WriteLine("Treasures loaded successfully!");
        }

        private static Equipment LoadEquipment(string[] data)
        {
            Contract.Requires(data.Length == 12);

            int id = int.Parse(data[0]);
            string name = data[1];

            EquipmentRarity rarity;
            EquipmentRarity.TryParse(data[2], out rarity);

            EquipmentType type;
            EquipmentType.TryParse(data[3], out type);

            string other = data[4];

            EAttackType attackType;
            EAttackType.TryParse(data[5], out attackType);
            attackType = type == EquipmentType.Weapon ? attackType : EAttackType.NONE;

            int buyPrice = data[6].Equals(string.Empty) ? 0 : int.Parse(data[6]);
            int hands = data[7].Equals(string.Empty) ? 0 : int.Parse(data[7]);
            int amount = data[8].Equals(string.Empty) ? 0 : int.Parse(data[8]);
            List<Dice> dice = data[9].Split(' ').Select(GetDice).ToList();
            List<Ability> abilities = data[10].Split('/').Select(Ability.GetAbility).ToList();
            System.Diagnostics.Debug.WriteLine(name + " - " + data[11]);
            List<SurgeAbility> surgeAbilities = data[11].Equals(string.Empty) ? new List<SurgeAbility>() : data[11].Split('/').Select(SurgeAbility.GetSurgeAbility).ToList();

            return new Equipment(
                id: id,
                name: name,
                type: type,
                attackType: attackType,
                rarity: rarity,
                buyPrice: buyPrice,
                surgeAbilities: surgeAbilities,
                hands: hands,
                abilities: abilities,
                dice: dice);
        }

        #endregion

        #region Load Markers

        private void LoadMarkers(Game game)
        {

        }

        #endregion

        #region Load Map

        public static void LoadMap(Game game)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("quest1.map"));

            int height = int.Parse(reader.ReadLine());
            int width = int.Parse(reader.ReadLine());

            Board.Board board = new Board.Board(width, height, game.Content.Load<Texture2D>("Images/Board/floor"));

            for (int y = 0; y < height; y++)
            {
                char[] c = reader.ReadLine().ToCharArray();
                for (int x = 0; x < c.Length; x++)
                {
                    switch (c[x])
                    {
                        case ' ':
                            board[x, y] = null;
                            break;
                        default:
                            board[x, y] = new Square(int.Parse(c[x] + string.Empty));
                            break;
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine("Map loaded successfully!");

            LoadOther(game, reader, board);
        }

        private static void LoadOther(Game game, StreamReader reader, Board.Board board)
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                switch (data[0])
                {
                    case "monster":
                        int x = int.Parse(data[1]);
                        int y = int.Parse(data[2]);
                        Orientation o = Orientation.H;
                        Orientation.TryParse(data[4], true, out o);
                        Monster monster = GetMonster(int.Parse(data[3]));
                        monster.Orientation = o;
                        board.PlaceFigure(monster, new Point(x, y));
                        break;
                    case "door":
                        RuneKey color;
                        RuneKey.TryParse(data[12], out color);
                        Orientation orientation;
                        Orientation.TryParse(data[11], out orientation);
                        board.AddDoor(new Door(int.Parse(data[1]), new Point(int.Parse(data[2]), int.Parse(data[3])), new Point(int.Parse(data[4]), int.Parse(data[5])), int.Parse(data[6]), new Point(int.Parse(data[7]), int.Parse(data[8])), new Point(int.Parse(data[9]), int.Parse(data[10])), orientation, color, game.Content.Load<Texture2D>("Images/Board/door-" + color.ToString())));
                        break;
                    default:
                        board[int.Parse(data[1]), int.Parse(data[2])].Marker = GetMarker(data[0], data[3]);
                        break;
                }
            }

            System.Diagnostics.Debug.WriteLine("Markers loaded successfully!");

            LoadChests(game, reader);

            FullModel.board = board;
        }

        /// <summary>
        /// </summary>
        /// <param name="game">
        /// The game object
        /// </param>
        /// <param name="reader">
        /// The reader instance, loading the map file
        /// </param>
        private static void LoadChests(Game game, StreamReader reader)
        {
            chests = new List<Chest>();
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                //System.Diagnostics.Debug.Assert(data.Length == 5, "Error when loading chests at line: " + (i + 1));

                int id = int.Parse(data[0]);
                EquipmentRarity rarity;
                EquipmentRarity.TryParse(data[1], true, out rarity);
                int tokens = int.Parse(data[2]);
                int coins = int.Parse(data[3]);
                int curses = int.Parse(data[4]);
                int treasures = int.Parse(data[5]);

                chests.Add(new Chest(id, rarity, tokens, coins, curses, treasures));
            }

            System.Diagnostics.Debug.WriteLine("Chests loaded successfully!");
        }

        private static void LoadLegendaryMonsters(Game game, StreamReader reader)
        {
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                int id = int.Parse(data[0]);
                Monster m = GetMonster(int.Parse(data[1]));
                string name = data[2];

                int bonusSpeed = int.Parse(data[3]);
                int bonusHealth = int.Parse(data[4]);
                int bonusArmor = int.Parse(data[5]);

                List<Dice> attackDice = (
                    from string dice
                        in data[7].Split(' ')
                    select GetDice(dice)).ToList<Dice>();
                attackDice.AddRange(m.DiceForAttack);

                List<Ability> abilities = data[8].Split('/').Select(Ability.GetAbility).ToList();
                abilities.AddRange(m.Abilities);

                Monster Legendary = new Monster(
                    id, 
                    name, 
                    m.IsMaster, 
                    m.Speed + bonusSpeed, 
                    m.MaxHealth + bonusHealth, 
                    m.Armor + bonusArmor, 
                    m.AttackType, 
                    attackDice, 
                    m.Size, 
                    m.Texture);


            }
        }

        #endregion

        #region Load Heroes

        private static void LoadHeroes(Game game)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("heroes.txt"));

            List<Hero> heroes = new List<Hero>();
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(new char[] { ',' }, 11);

                int id = int.Parse(data[0]);
                string name = data[1];
                int cost = int.Parse(data[2]);
                int health = int.Parse(data[3]);
                int fatigue = int.Parse(data[4]);
                int armor = int.Parse(data[5]);
                int speed = int.Parse(data[6]);

                int[] dice = data[7].Split('/').Select(int.Parse).ToArray();
                Dictionary<EAttackType, int> diceDictionary = new Dictionary<EAttackType, int>();
                diceDictionary[EAttackType.MELEE] = dice[0];
                diceDictionary[EAttackType.RANGED] = dice[1];
                diceDictionary[EAttackType.MAGIC] = dice[2];

                int[] skills = data[8].Split('/').Select(int.Parse).ToArray();
                Dictionary<EAttackType, int> skillDictionary = new Dictionary<EAttackType, int>();
                skillDictionary[EAttackType.MELEE] = dice[0];
                skillDictionary[EAttackType.RANGED] = dice[1];
                skillDictionary[EAttackType.MAGIC] = dice[2];

                int hands = int.Parse(data[9]);

                string text = data[10];

                Texture2D texture = game.Content.Load<Texture2D>("Images/Heroes/" + id);
                Texture2D largeTexture;
                try
                {
                    largeTexture = game.Content.Load<Texture2D>("Images/Heroes/BIG-" + id);
                }
                catch (Exception e)
                {
                    largeTexture = game.Content.Load<Texture2D>("Images/Heroes/BIG-0");
                }

                heroes.Add(new Hero(id, name, cost, health, fatigue, armor, speed, diceDictionary, skillDictionary, hands, text, texture, largeTexture));
            }

            FullModel.heroes = heroes;
        }

        #endregion

        #region Load Overlord Cards

        private static void LoadOverlordCards(Game game)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("overlordcards.txt"));
            overlordCards = new List<OverlordCard>();

            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                if (line.StartsWith("//")) continue;
                OverlordCard card = null;

                string[] data = line.Split(new char[] { ',' }, 9);

                int id = int.Parse(data[0]);
                string type = data[1];
                string name = data[2];
                int amount = int.Parse(data[3]);
                int cost = int.Parse(data[4]);
                int sell = int.Parse(data[5]);
                string description = data[7];

                switch (type)
                {
                    case "Spawn":
                        List<Monster> monsters = new List<Monster>();
                        string[] creaturesToSpawn = data[6].Split('/');
                        for (int j = 0; j < creaturesToSpawn.Length; j++)
                        {
                            for (int k = 0; k < int.Parse(creaturesToSpawn[j].Split(' ')[1]); k++)
                            {
                                monsters.Add(GetMonster(int.Parse(creaturesToSpawn[j].Split(' ')[0])));
                            }
                        }
                        card = new SpawnCard(id, name, description, cost, sell, monsters.ToArray());
                        break;
                    case "Power":
                        card = new PowerCard(id, name, description, cost, sell);
                        break;
                    case "Trap":
                        card = new TrapCard(id, name, description, cost, sell);
                        break;
                    case "Event":
                        card = new EventCard(id, name, description, cost, sell);
                        break;
                }
                if (card != null)
                    overlordCards.Add(card);
            }
        }

        #endregion

        #region Load Skill Cards

        private static void LoadSkillCards(Game game)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("skills.txt"));

            skills = new List<Skill>();
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                if (line.StartsWith("//")) continue;
                string[] data = line.Split(new char[] { ',' }, 4);
                int id = int.Parse(data[0]);

                EAttackType attackType;
                EAttackType.TryParse(data[1], true, out attackType);

                string name = data[2];
                string description = data[3];

                skills.Add(new Skill(id, name, attackType, description, new List<Ability>()));
            }
        }

        #endregion

        #endregion

        #region Getters

        /// <summary>
        /// Gets the standard instance of 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// The standard id of the mosnter
        /// <returns>
        /// The monster, as a new monster
        /// </returns>
        [Pure]
        public static Monster GetMonster(int id)
        {
            Contract.Ensures(Contract.Result<Monster>().Id == Contract.OldValue(monstersInPlay));
            return monsters.Single(monster => monster.Id == id).Clone(monstersInPlay++);
        }

        /// <summary>
        /// Gets a piece of equipment with a specific ID
        /// This is only the common, town equipment, not treasure
        /// </summary>
        /// <param name="id">
        /// The id of the equipment
        /// </param>
        /// <returns>
        /// An equipment with the id equals to the input
        /// </returns>
        [Pure]
        public static Equipment GetEquipment(int id)
        {
            Contract.Ensures(Contract.Result<Equipment>().Id == id);
            return AllEquipment.First(equipment => equipment.Id == id).Clone();
        }

        public static Treasure GetTreasure(int id)
        {
            return AllTreasures.Single(t => t.ID == id);
        }

        /// <summary>
        /// Gets an overlord card by id
        /// </summary>
        /// <param name="id">
        /// The id of the card
        /// </param>
        /// <returns>
        /// The card with the given id
        /// </returns>
        [Pure]
        public static OverlordCard GetOverlordCard(int id)
        {
            Contract.Ensures(Contract.Result<OverlordCard>().Id == id);
            return overlordCards.First(overlordCard => overlordCard.Id == id);
        }

        /// <summary>
        /// Get an instance of the dice, of the given color
        /// </summary>
        /// <param name="dice">
        /// The dice.
        /// </param>
        /// <returns>
        /// A die of that color
        /// </returns>
        [Pure]
        public static Dice GetDice(EDice dice)
        {
            Contract.Ensures(Contract.Result<Dice>().Color == dice);
            return diceDictionary[dice].Clone();
        }

        /// <summary>
        /// Gets a dice from a text-string, 
        /// </summary>
        /// <param name="dice">
        /// A text-string, one of R, W, U, G, Y, B
        /// </param>
        /// <returns>
        /// The dice of the asked color
        /// </returns>
        [Pure]
        public static Dice GetDice(string dice)
        {
            EDice d;
            Enum.TryParse(dice, false, out d);
            return GetDice(d);
        }

        /// <summary>
        /// TODO: Should be changed.. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static Marker GetMarker(string name, string other)
        {
            switch (name)
            {
                case "glyph":
                    return new GlyphMarker(markersOnBoard++, name + "-" + other, game.Content.Load<Texture2D>("Images/Board/portal-closed"), 0, other.Equals("open"), game.Content.Load<Texture2D>("Images/Board/portal-open"));
                case "treasure":
                    EquipmentRarity rarity;
                    EquipmentRarity.TryParse(other, true, out rarity);
                    return new ChestMarker(markersOnBoard++, name + "-" + other, 2, rarity, game.Content.Load<Texture2D>("Images/Board/" + name + "-" + other));
                case "gold":
                    return new MoneyMarker(markersOnBoard++, name, game.Content.Load<Texture2D>("Images/Board/" + name), 0);
                case "rock":
                    return new OtherMarkers(markersOnBoard++, name, game.Content.Load<Texture2D>("Images/Board/rock1"), 0);
                case "pit":
                    return new OtherMarkers(markersOnBoard++, name, game.Content.Load<Texture2D>("Images/Board/pit1"), 0);
                case "potion":
                    return new PotionMarker(markersOnBoard++, name + "-" + other, game.Content.Load<Texture2D>("Images/Board/" + name + "-" + other), 0, other.Contains("health") ? GetEquipment(11) : GetEquipment(12));
                case "rune":
                    RuneKey color;
                    RuneKey.TryParse(other, true, out color);
                    return new RuneMarker(markersOnBoard++, name + "-" + other, game.Content.Load<Texture2D>("Images/Board/" + name + "-" + other), 0, color);
                default:
                    break;
            }
            System.Diagnostics.Debug.Assert(false);
            return null;
        }

        /// <summary>
        /// Gets a copy of a hero figure
        /// </summary>
        /// <param name="id">
        /// The id of the hero
        /// </param>
        /// <returns>
        /// Returns the hero with id equal to the parameter id
        /// </returns>
        [Pure]
        public static Hero GetHero(int id)
        {
            return heroes.First(hero => hero.Id == id);
        }

        /// <summary>
        /// Gets a list of all heroes
        /// </summary>
        [Pure]
        public static Hero[] AllHeroes
        {
            get { return heroes.ToArray(); }
        }

        [Pure]
        public static Monster[] AllLengendaryMonsters
        {
            get { return legendaryMonsters.ToArray(); }
        }

        /// <summary>
        /// Gets a list of all town equipment 
        /// </summary>
        [Pure]
        public static Equipment[] AllEquipment
        {
            get
            {
                return townEquipment.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all overlord cards
        /// </summary>
        [Pure]
        public static OverlordCard[] AllOverlordCards
        {
            get { return overlordCards.ToArray(); }
        }

        /// <summary>
        /// Gets a list of all chests
        /// </summary>
        [Pure]
        public static Chest[] AllChests
        {
            get
            {
                return chests.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all treasures
        /// </summary>
        [Pure]
        public static Treasure[] AllTreasures
        {
            get
            {
                List<Treasure> list = new List<Treasure>();
                foreach (EquipmentRarity r in Enum.GetValues(typeof(EquipmentRarity)))
                    list.AddRange(treasures[r]);
                return list.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all skills
        /// </summary>
        [Pure]
        public static Skill[] AllSkills
        {
            get
            {
                return skills.ToArray();
            }
        }

        #endregion
    }
}
