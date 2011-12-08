
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
    /// TODO: Update summary.
    /// </summary>
    public class FullModel
    {
        #region Fields

        private static Game game;

        private static List<Monster> monsters;

        private static int monstersInPlay;

        private static List<Hero> heroes;

        private static Dictionary<EDice, Dice> diceDictionary;

        private static Dictionary<EquipmentType, List<Equipment>> townEquipment;

        private static List<Marker> markers;

        private static Board.Board board;

        #endregion

        public static Board.Board Board
        {
            get
            {
                return board;
            }
        }

        #region Load Content

        /// <summary>
        /// Loads all content.
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

            LoadDice(game);
            LoadMonsters(game);
            LoadEquipment(game);
            LoadMap(game);
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
                System.Diagnostics.Debug.WriteLine(line);

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


                Rectangle size = new Rectangle(0,0,int.Parse(data[9]), int.Parse(data[10]));

                Texture2D texture = game.Content.Load<Texture2D>("Images/Monsters/" + id);

                monsters.Add(new Monster(id, name, master, speed, health, armor, type, attackDice, size, texture));
            }

            FullModel.monsters = monsters;
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

                Texture2D[] textures = new Texture2D[6];
                int[][] sides = new int[6][];
                for (int side = 0; side < 6; side++)
                {
                    sides[side] = new int[4];

                    char[] sideArray = data[side + 1].ToCharArray();
                    textures[side] = game.Content.Load<Texture2D>(data[0] + data[side + 1]);

                    for (int value = 0; value < 4; value++)
                    {
                        sides[side][value] = int.Parse(sideArray[value] + string.Empty);
                    }
                }

                dice[eDice] = new Dice(eDice, sides, null);
            }

            diceDictionary = dice;
        }

        /// <summary>
        /// Reads the sides of a dice
        /// </summary>
        /// <param name="data">
        /// The array of sides
        /// </param>
        /// <returns>
        /// A 6 by 4 array with 6 sides, each with 4 parts, range, damage, surges and 
        /// </returns>
        private static int[][] AddSides(string[] data)
        {
            

            return sides;
        }


        #endregion

        #region Load Equipement

        private static void LoadEquipment (Game game)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("equipmentWithTreasure.txt"));

            int n = int.Parse(reader.ReadLine());
            string line;

            Dictionary<EquipmentType, List<Equipment>> equipmentlists = new Dictionary<EquipmentType, List<Equipment>>();
            equipmentlists[EquipmentType.Weapon] = new List<Equipment>();
            equipmentlists[EquipmentType.Armor] = new List<Equipment>();
            equipmentlists[EquipmentType.Shield] = new List<Equipment>();
            equipmentlists[EquipmentType.Weapon] = new List<Equipment>();
            equipmentlists[EquipmentType.Other] = new List<Equipment>();
            equipmentlists[EquipmentType.Potion] = new List<Equipment>();

            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();
                if (line.StartsWith("//")) continue;

                string[] data = line.Split(',');
                System.Diagnostics.Debug.Assert(data.Length == 12, "Error when loading equipment, at line " + (i + 2));

                Equipment eq = LoadEquipment(data);
                

                equipmentlists[eq.Type].Add(eq);
            }

            townEquipment = equipmentlists;
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

            int buyPrice = data[6].Equals(string.Empty) ? 0 : int.Parse(data[6]);
            int hands = data[7].Equals(string.Empty) ? 0 : int.Parse(data[7]);
            int amount = data[8].Equals(string.Empty) ? 0 : int.Parse(data[8]);
            List<Dice> dice = data[9].Split(' ').Select(GetDice).ToList();
            List<Ability> abilities = data[10].Split('/').Select(s => Ability.GetAbility(s)).ToList();
            List<SurgeAbility> surgeAbilities =
                data[11].Split('/').Select(s => SurgeAbility.GetSurgeAbility(s)).ToList();

            return new Equipment(id, name, type, rarity, buyPrice, surgeAbilities, hands, abilities);
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
                for(int x = 0; x < c.Length; x++)
                {
                    switch(c[x])
                    {
                        case ' ':
                            board[x, y] = null;
                            break;
                        default:
                            board[x, y] = new Square();
                            break;
                    }
                }
            }

            LoadOther(game, reader, board);
        }

        private static void LoadOther(Game game, StreamReader reader, Board.Board board)
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();
                System.Diagnostics.Debug.WriteLine(line);
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
                        board[x, y].Figure = monster;
                        break;
                    case "door":
                        Door.RuneColor color;
                        Door.RuneColor.TryParse(data[3], out color);
                        board.AddDoor(new Door(int.Parse(data[1]), int.Parse(data[2]), color));
                        break;
                    default:
                        board[int.Parse(data[1]), int.Parse(data[2])].Marker = GetMarker(data[0], data[3]);
                        break;
                }
            }

            FullModel.board = board;
        }

        #endregion

        #region Load Heroes

        private void LoadHeroes(Game game)
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

                heroes.Add(new Hero(id, name, cost, health, fatigue, armor, speed, diceDictionary, skillDictionary, hands, text));
            }

            FullModel.heroes = heroes;
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
        public static Monster GetMonster(int id)
        {
            return monsters.Single(monster => monster.Id == id).Clone(monstersInPlay++);
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
        public static Dice GetDice(EDice dice)
        {
            Contract.Ensures(Contract.Result<Dice>().Color == dice);
            return diceDictionary[dice].Clone();
        }

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
        public static Marker GetMarker(string name, string other)
        {
            switch (name)
            {
                case "glyph":
                    return new Marker(name + "-" + other, game.Content.Load<Texture2D>("Images/Board/portal-" + other));
                case "treasure":
                    return new Marker(name + "-" + other, game.Content.Load<Texture2D>("Images/Board/" + name + "-" + other));
                case "gold":
                    return new Marker(name, game.Content.Load<Texture2D>("Images/Board/" + name));
                case "rock":
                    return new Marker(name, game.Content.Load<Texture2D>("Images/Board/rock1"));
                case "pit":
                    return new Marker(name, game.Content.Load<Texture2D>("Images/Board/pit1"));
                case "potion":
                    return new Marker(name + "-" + other, game.Content.Load<Texture2D>("Images/Board/" + name + "-" + other));
                case "rune":
                    return new Marker(name + "-" + other, game.Content.Load<Texture2D>("Images/Board/" + name + "-" + other));
                default:
                    break;                    
            }
            System.Diagnostics.Debug.Assert(false);
            return null;
        }

        public static Hero GetHero(int id)
        {
            return heroes[id];
        }

        #endregion
    }
}
