using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACKS_Toolkit
{

    public partial class Form1 : Form
    {
        public static Random rand = new Random(Guid.NewGuid().GetHashCode());
        static int roll;
        public static int levels = 1;
        public static bool armorBox = false;
        static string dungeonPath = Application.StartupPath + "/Dungeon.txt";
        static string treasurePath = Application.StartupPath + "/Treasure.txt";
        static string wildernessPath = Application.StartupPath + "/Wilderness.txt";
        static string monsterPath = Application.StartupPath + "/Monster.txt";
        static string errorPath = Application.StartupPath + "/Error.txt";
        static string playerPath = Application.StartupPath + "/PlayerOutput.txt";
        static string scavengePath = Application.StartupPath + "/Scavenging.txt";
        static string warPath = Application.StartupPath + "/War.txt";
        static string demandPath = Application.StartupPath + "/Demand.txt";
        public static int generationType = 0;
        public static bool lairGen = true;
        public static bool forceLair = false;
        public static string encounterDistance = "";
        public static bool dungeonNPCLevel = false;
        public bool wordpad = false;
        public static bool playerBox = false;
        static string partsPath = "";
        static string terrain = "";
        static ArrayList randomTerrains;

        public Form1()
        {
            InitializeComponent();
            randomTerrains = new ArrayList();
            System.IO.StreamReader terrains = new System.IO.StreamReader(Application.StartupPath + "/Resources/Wilderness/terrain.txt");
            string terrain = "";
            while (!terrains.EndOfStream)
            {
                terrain = terrains.ReadLine();
                this.terrainBox.Items.Add(terrain);
                this.monsterTerrainBox.Items.Add(terrain);
            }
        }

        public static void WriteToFile(string text)
        {
            System.IO.StreamWriter file;
            if (generationType == 1) file = new System.IO.StreamWriter(dungeonPath, append: true);
            else if (generationType == 2) file = new System.IO.StreamWriter(treasurePath, append: true);
            else if (generationType == 3) file = new System.IO.StreamWriter(wildernessPath, append: true);
            else if (generationType == 4) file = new System.IO.StreamWriter(monsterPath, append: true);
            else if (generationType == 5) file = new System.IO.StreamWriter(scavengePath, append: true);
            else if (generationType == 6) file = new System.IO.StreamWriter(warPath, append: true);
            else if (generationType == 7) file = new System.IO.StreamWriter(demandPath, append: true);
            else file = new System.IO.StreamWriter(errorPath, append: true);
            file.WriteLine(text);
            file.Close();
            /*if (playerBox)
            {
                //write to two files
                write(text);
                if (!text.Contains("Null"))
                playerWrite(text);
            }
            else
            {
                //write to one file
                write(text);
            }*/
        }

        public static void writeToBoth(string text)
        {
            /*System.IO.StreamWriter file;
            if (generationType == 1) file = new System.IO.StreamWriter(dungeonPath, append: true);
            else if (generationType == 2) file = new System.IO.StreamWriter(treasurePath, append: true);
            else if (generationType == 3) file = new System.IO.StreamWriter(wildernessPath, append: true);
            else if (generationType == 4) file = new System.IO.StreamWriter(monsterPath, append: true);
            else if (generationType == 5) file = new System.IO.StreamWriter(scavengePath, append: true);
            else file = new System.IO.StreamWriter(errorPath, append: true);
            file.WriteLine(text);
            file.Close();*/
            if (playerBox)
            {   
                //write to two files   
                WriteToFile(text);  
                if (!text.Contains("Null"))   
                    playerWrite(text);
            }
            else
            {  
                //write to one file  
                WriteToFile(text);
            }
        }

        public static void playerWrite(string text)
        {
            System.IO.StreamWriter file;
            file = new System.IO.StreamWriter(playerPath, append:true);
            file.WriteLine(text);
            file.Close();
        }

        private static string GetLevelName(int i)
        {
            string levelName = "";
            switch (i)
            {
                case 1:
                    levelName = "first";
                    break;
                case 2:
                    levelName = "second";
                    break;
                case 3:
                    levelName = "third";
                    break;
                case 4:
                    levelName = "fourth";
                    break;
                case 5:
                    levelName = "fifth";
                    break;
                case 6:
                    levelName = "sixth";
                    break;
            }

            return levelName;
        }

        private int GetRooms(int i)
        {
            int rooms = 0;
            switch (i)
            {
                case 1:
                    rooms = System.Convert.ToInt32(roomBox.Text);
                    break;
                case 2:
                    rooms = System.Convert.ToInt32(rooms2.Text);
                    break;
                case 3:
                    rooms = System.Convert.ToInt32(rooms3.Text);
                    break;
                case 4:
                    rooms = System.Convert.ToInt32(rooms4.Text);
                    break;
                case 5:
                    rooms = System.Convert.ToInt32(rooms5.Text);
                    break;
                case 6:
                    rooms = System.Convert.ToInt32(rooms6.Text);
                    break;
            }
            return rooms;
        }

        //Generates a dungeon.
        //Generates dungeon type, then one level per level, then opens up the file.
        private void GenerateDungeon(object sender, EventArgs e)
        {
            generationType = 1;
            playerBox = playerBoxDungeon.Checked;
            System.IO.StreamWriter file = new System.IO.StreamWriter(dungeonPath);
            file.Write("");
            file.Close();
            if (playerBox)
            {
                file = new System.IO.StreamWriter(playerPath);
                file.Write("");
                file.Close();
            }
            int rooms;
            string levelName = "first";
            if (roomBox.Text == "") rooms = 0;
            else 
                rooms = System.Convert.ToInt32(roomBox.Text);
            armorBox = dungeonArmorBox.Checked;
            wordpad = wordpadDungeonBox.Checked;
            GenerateDungeonType();
            for (int i = 1; i <= levels; i++)
            {
                levelName = GetLevelName(i);
                rooms = GetRooms(i);
                WriteToFile("The following rooms are on the " + levelName + " level.\n");
                partsPath = Application.StartupPath + "/Resources/Dungeon/" + levelName + "Level.txt";
                GenerateLevel(i, rooms);
                WriteToFile("The " + levelName + " level rooms have completed.");
                WriteToFile("\n");
                WriteToFile("\n");
            }

            closeOldFile("Dungeon");
            if (playerBox) closeOldFile("PlayerOutput");
            openFile(dungeonPath);
            if (playerBox) openFile(playerPath);

        }

        private void GenerateTreasure(object sender, EventArgs e)
        {
            generationType = 2;
            playerBox = playerBoxTreasure.Checked;
            for (int i = 0; i < monsterTerrainBox.Items.Count; i++)
            {
                randomTerrains.Add(monsterTerrainBox.Items[i]);
            }
            if (!(appendCheck.Checked))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(treasurePath);
                file.Write("");
                file.Close();
                if (playerBox)
                {
                    file = new System.IO.StreamWriter(playerPath);
                    file.Write("");
                    file.Close();
                }
            }
            armorBox = armorCheck.Checked;
            wordpad = wordpadTreasureBox.Checked;

            int rolls = 0;

            if (treasureRolls.Text == "") rolls = 0;
            else
                rolls = System.Convert.ToInt32(treasureRolls.Text);

            for (int i = 0; i < rolls; i++)
            {
                treasure.RollTreasure(typeBox.Text);
                WriteToFile("\n");
                WriteToFile("\n");
            }

            closeOldFile("Treasure");
            if (playerBox) closeOldFile("PlayerOutput");
            openFile(treasurePath);
            if (playerBox) openFile(playerPath);
        }

        private void addLevel(object sender, EventArgs e)
        {
            if (levels < 6)
                levels++;
            switch (levels)
            {
                case 2:
                    this.level2.Size = new System.Drawing.Size(100, 22);
                    this.rooms2.Size = new System.Drawing.Size(100, 22);
                    this.level2.Enabled = true;
                    this.rooms2.Enabled = true;
                    break;
                case 3: 
                    this.level3.Size = new System.Drawing.Size(100, 22);
                    this.rooms3.Size = new System.Drawing.Size(100, 22);
                    this.level3.Enabled = true;
                    this.rooms3.Enabled = true;
                    break;
                case 4: 
                    this.level4.Size = new System.Drawing.Size(100, 22);
                    this.rooms4.Size = new System.Drawing.Size(100, 22);
                    this.level4.Enabled = true;
                    this.rooms4.Enabled = true;
                    break;
                case 5: 
                    this.level5.Size = new System.Drawing.Size(100, 22);
                    this.rooms5.Size = new System.Drawing.Size(100, 22);
                    this.level5.Enabled = true;
                    this.rooms5.Enabled = true;
                    break;
                case 6: 
                    this.level6.Size = new System.Drawing.Size(100, 22);
                    this.rooms6.Size = new System.Drawing.Size(100, 22);
                    this.level6.Enabled = true;
                    this.rooms6.Enabled = true;
                    break;

            }
        }

        public static void GenerateDungeonType()
        {
            int roll = rand.Next(1, 21);
            string text = "";
            switch (roll)
            {
                case 1: text = "Abandoned mine\n"; break;
                case 2: text = "Barrow mound\n"; break;
                case 3: text = "Catacombs\n"; break;
                case 4: text = "Cliff city\n"; break;
                case 5: text = "Crumbling castle\n"; break;
                case 6: text = "Giant burrow\n"; break;
                case 7: text = "Giant insect hive\n"; break;
                case 8: text = "Humanoid warren\n"; break;
                case 9: text = "Maze\n"; break;
                case 10: text = "Monster lair\n"; break;
                case 11: text = "Natural caverns\n"; break;
                case 12: text = "Prison\n"; break;
                case 13: text = "Ruined manor\n"; break;
                case 14: text = "Sewers\n"; break;
                case 15: text = "Sunken city\n"; break;
                case 16: text = "Temple\n"; break;
                case 17: text = "Tomb\n"; break;
                case 18: text = "Tower\n"; break;
                case 19: text = "Underground river\n"; break;
                case 20: text = "Wizard's dungeon\n"; break;

            }
            WriteToFile("Your dungeon type is: ");
            WriteToFile(text);
            WriteToFile("\n");
        }

        public static int GenerateRoomType(int roll)
        {
            if (roll < 31) return 1; //Empty room
            else if (roll < 61) return 2; //Monster room
            else if (roll < 76) return 3; //Trap room
            else return 4; //Unique room
        }

        //Generates a full level by generating the number of rooms.  Is passed the level depth and the number of rooms.
        public static void GenerateLevel(int level, int rooms)
        {
            int roomType = 0;
            for (int i = 0; i < rooms; i++)
            {
                roomType = GenerateRoomType(rand.Next(1, 101));
                switch (level)
                {
                    case 1: firstLevel.GenerateRoom(roomType);
                        break;
                    case 2: secondLevel.GenerateRoom(roomType);
                        break;
                    case 3: thirdLevel.GenerateRoom(roomType);
                        break;
                    case 4: fourthLevel.GenerateRoom(roomType);
                        break;
                    case 5: fourthLevel.GenerateRoom(roomType);
                        break;
                    case 6: sixthLevel.GenerateRoom(roomType);
                        break;
                }
            }
        }

        public static double getMultiplier(int level, int starter)
        {
            double multiplier = 0;
            if (level == (starter + 1)) multiplier = 1.5;
            else if (level == (starter + 2)) multiplier = 2;
            else if (level == starter) multiplier = 1;
            else if (level == (starter - 1)) multiplier = .5;
            else if (level == (starter - 2)) multiplier = .25;
            return multiplier;
        }



        public static void GenericMonsterGenerator(string path, double multiplier)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            ArrayList monsters = new ArrayList(), dice = new ArrayList();
            Wilderness wildlands = new Wilderness();
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                dice.Add(reader.ReadLine());
                monsters.Add(reader.ReadLine());
            }

            roll = rand.Next(1, monsters.Count+1);
            string parser = "";
            string monster = "";
            double numAppearing = 0;
            for (int i = 0; i < monsters.Count; i++)
            {
                if (i+1 == roll)
                {
                    //You've found your monster!
                    parser = (string)dice[i];
                    numAppearing = Wilderness.generateNumberDouble(parser);
                    numAppearing = Math.Truncate(numAppearing * multiplier);
                    if (numAppearing == 0) numAppearing = 1;

                    monster = (string)monsters[i];
                }
            }
            Form1.WriteToFile("The room contains " + numAppearing + " " + monster + ".");
        }

        private void GenerateWilderness(object sender, EventArgs e)
        {
            generationType = 3;
            playerBox = playerBoxWilderness.Checked;
            Wilderness wildlands = new Wilderness();
            if (!(wildernessAppendCheck.Checked))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(wildernessPath);
                file.Write("");
                file.Close();
                if (playerBox)
                {
                    file = new System.IO.StreamWriter(playerPath);
                    file.Write("");
                    file.Close();
                }
            }
            /*
             * All the actual generation calls go here.
             * Each terrain type:  Roll for type of encounter
             * Then roll for specific encounter
             * Then check if encounter is in lair
             * Then check if lairBox is checked; if it is, generate a random dungeon for the lair to be placed in.
             * Can't really use the normal dungeon generation for the random lair, since we need it to include some specific monsters and for them to be
             * the major monsters in the dungeon.
             * Then generate the number appearing (different numbers for lair and nonlair).
             * Then generate encounter distance.
             * A randomly generated lair is basically a dungeon, but every monster room of the appropriate depth is replaced with the specific monster type.
             * Levels above the appropriate depth are filled with random monsters.
             * Lairs have levels based on the type of lair; they are deep enough for the monster to be appropriate on the last level.  Thus, goblin lairs are
             * only one level, while dragon lairs are six levels.  A randomly generated dragon lair may seem to be merely a random dungeon, until you get down 
             * to the bottom and find a dragon.
             * This can be done by using the normal level generators for the above levels, and having a Lair.GenerateLairLevel function for each level.  Thus, 
             * only the level that is the actual lair needs to be different from a truly random dungeon.
             * Lair levels need to have a minimum number of monsters, and thus a minimum number of rooms.  Unfortunately, this number varies based on monster.
             * So there's some gruntwork defining to do there, I can't see any way around it.
             * */
            lairGen = lairBox.Checked;
            armorBox = wildernessArmorBox.Checked;
            forceLair = forceLairBox.Checked;
            dungeonNPCLevel = npcBox.Checked;
            wordpad = wordpadWildernessBox.Checked;
            if ((distanceBox.Text != "") && (distanceBox.Text != "Error"))
            encounterDistance = distanceBox.Text;
            terrain = terrainBox.Text;
            wildlands.generateEncounter(terrainBox.Text);

            //lairGen = wildlands.getLairTag();
            //if (lairGen)
           // {
          //      GenerateLair(wildlands.getMonster());
          //  }

            closeOldFile("Wilderness");
            if (playerBox) closeOldFile("PlayerOutput");
            openFile(wildernessPath);
            if (playerBox) openFile(playerPath);
        }


        public static void GenerateLair(Wilderness wildlands)
        {
            int xp = wildlands.getXP();
            int lairLevels = getLevel(xp);
            int temp = levels;
            levels = lairLevels;
            int rooms = 0;
            string levelName = "";

            for (int i = 1; i < lairLevels; i++)
            {
                //Generate the levels of the lair
                //Levels above the last one should be done normally
                //The last one needs to be a lair level
                //This for loop only generates levels above the lair level
                //Each level has a random number of rooms from 1 to 20.
                levelName = GetLevelName(i);
                WriteToFile("The following rooms are on the " + levelName + " level.\n");
                GenerateLevel(i, rooms);
                rooms = rand.Next(1, 21);
                GenerateLevel(i, rooms);
                WriteToFile("The " + levelName + " level rooms have completed.");
                WriteToFile("\n");
                WriteToFile("\n");
            }

            //Generate the lair level
            rooms = rand.Next(1, 21);
            GenerateLairLevel(wildlands);
            levels = temp;
        }



        //Is just a copy of generatelevel at the moment
        private static void GenerateLairLevel(Wilderness wildlands)
        {
            //LAIR LEVEL ROOM GENERATION:
            //Can be empty, trap, unique, or monster
            //In all cases of 'monster' on the lair level, it needs to be the specific monster
            //The lair level needs to have enough monster rooms to account for their number in lair
            //Remaining rooms can be generated randomly 
            //Currently:  Gives up and just says "Make the lair level yourself, I made the rest of the dungeon!"
            Form1.WriteToFile("Their lair is on level " + getLevel(wildlands.getXP()) + ".");
            ArrayList treasures = wildlands.getTreasures();
            string tempTreasure = "";
            if (treasures.Count > 0)
            {
                Form1.WriteToFile("Their lair contains: ");
                for (int i = 0; i < treasures.Count; i++)
                {
                    //treasure.RollTreasure((string)treasures[i]);
                    //Form1.WriteToFile("");
                    tempTreasure += (string)treasures[i];
                }
                treasure.RollTreasure(tempTreasure);
            }
        }

        public static int getLevel(int xp)
        {
            int levels = 0;
            if (xp < 16) levels = 1;
            else if (xp < 48) levels = 2;
            else if (xp < 151) levels = 3;
            else if (xp < 476) levels = 4;
            else if (xp < 1141) levels = 5;
            else levels = 6;
            return levels;
        }

        private void updateDistance(object sender, EventArgs e)
        {
            //Badlands 2d6*10
            //Desert 4d6*10
            //Fields, Fallow 4d6*10
            //Fields, Ripe 5d10
            //Fields, Wild 3d6*5
            //Forest, Heavy or Jungle 5d4
            //Forest, Light 5d8
            //Marsh 8d10
            //Mountains 4d6*10
            //Plains 5d20*10
            distanceBox.Enabled = false;
            if (distanceType.Text == "Badlands") distanceBox.Text = "2d6*10";
            else if (distanceType.Text == "Desert") distanceBox.Text = "4d6*10";
            else if (distanceType.Text == "Fields, Fallow") distanceBox.Text = "4d6*10";
            else if (distanceType.Text == "Fields, Ripe") distanceBox.Text = "5d10";
            else if (distanceType.Text == "Fields, Wild") distanceBox.Text = "3d6*5";
            else if (distanceType.Text == "Forest, Heavy") distanceBox.Text = "5d4";
            else if (distanceType.Text == "Jungle") distanceBox.Text = "5d4";
            else if (distanceType.Text == "Forest, Light") distanceBox.Text = "5d8";
            else if (distanceType.Text == "Marsh") distanceBox.Text = "8d10";
            else if (distanceType.Text == "Mountains") distanceBox.Text = "4d6*10";
            else if (distanceType.Text == "Plains") distanceBox.Text = "5d20*10";
            else if (distanceType.Text == "Custom") distanceBox.Enabled = true;
            else distanceBox.Text = "Error";
        }

        private void monsterTerrainBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill in the encounter dropdown list with the encounter types found on the selected terrain
            //File path:  Application.StartupPath + "/Resources/Wilderness/" + terrain + ".txt"
            string terrain = this.monsterTerrainBox.Text;
            string temp = "";
            System.IO.StreamReader table = new System.IO.StreamReader(Application.StartupPath + "/Resources/Wilderness/" + terrain + ".txt");
            int count = monsterEncounterBox.Items.Count;
            for (int i = 0; i < count; i++)
            {
                monsterEncounterBox.Items.RemoveAt(0);
            }
            count = monsterMonsterBox.Items.Count;
            for (int i = 0; i < count; i++)
            {
                monsterMonsterBox.Items.RemoveAt(0);
            }
            while (!table.EndOfStream)
            {
                table.ReadLine();
                temp = table.ReadLine();
                if (! monsterEncounterBox.Items.Contains(temp))
                monsterEncounterBox.Items.Add(temp);
            }

        }

        private void monsterEncounterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill in the monster list with the actual list of monsters available, then enable the generate button
            string terrain = this.monsterTerrainBox.Text;
            string type = this.monsterEncounterBox.Text;
            string temp = "";
            System.IO.StreamReader table = new System.IO.StreamReader(Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + type + ".txt");
            int count = monsterMonsterBox.Items.Count;
            for (int i = 0; i < count; i++)
            {
                monsterMonsterBox.Items.RemoveAt(0);
            }
            while (!table.EndOfStream)
            {
                table.ReadLine();
                temp = table.ReadLine();
                if (! monsterMonsterBox.Items.Contains(temp))
                monsterMonsterBox.Items.Add(temp);
            }
            
            this.monsterButton.Enabled = true;
        }

        private void generateMonsterEncounter(object sender, EventArgs e)
        {
            generationType = 4;
            playerBox = playerBoxMonster.Checked;
            forceLair = monsterLairBox.Checked;
            lairGen = monsterRandomLair.Checked;
            dungeonNPCLevel = monsterNPCBox.Checked;
            wordpad = wordpadMonsterBox.Checked;
            terrain = monsterTerrainBox.Text;
            if (!(monsterAppendCheck.Checked))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(monsterPath);
                file.Write("");
                file.Close();
                if (playerBox)
                {
                    file = new System.IO.StreamWriter(playerPath);
                    file.Write("");
                    file.Close();
                }
            }
            Wilderness wildlands = new Wilderness();
            string monster = "";
            if (monsterMonsterBox.Text != "")
                monster = monsterMonsterBox.Text;
            else
            {
                string type = monsterEncounterBox.Text;
                ArrayList monsters = new ArrayList();
                string path = Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + type + ".txt";
                System.IO.StreamReader reader = new System.IO.StreamReader(path);
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    monsters.Add(reader.ReadLine());
                }

                roll = rand.Next(1, monsters.Count + 1);
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (i + 1 == roll)
                    {
                        monster = (string)monsters[i];
                    }
                }
            }
            wildlands.identifyEncounterFunction(monster);

            closeOldFile("Monster");
            if (playerBox) closeOldFile("PlayerOutput");
            openFile(monsterPath);
            if (playerBox) openFile(playerPath);
        }

        private void openFile(string path)
        {
            if (!wordpad)
                System.Diagnostics.Process.Start(@"notepad.exe", path);
            else System.Diagnostics.Process.Start(@"wordpad.exe", "\"" + path + "\""); 
        }

        private void closeOldFile(string path)
        {
            System.Diagnostics.Process[] processes;
            path = path + ".txt";
            string procName = "";
            if (!wordpad)
            {
                procName = "Notepad";
            }
            else
            {
                procName = "WordPad";
            }

            path = path + " - " + procName;

            processes = System.Diagnostics.Process.GetProcessesByName(procName);
            int procID = 0;

            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].MainWindowTitle == path)
                {
                    procID = processes[i].Id;
                }
            }

            try
            {
                System.Diagnostics.Process tempProc = System.Diagnostics.Process.GetProcessById(procID);
                tempProc.CloseMainWindow();
                //tempProc.WaitForExit();
            }
            catch
            {
                MessageBox.Show("Failed to close old file!");
            }


        }

        private static string sanitizeMonsterReturn(string text)
        {
            string returner = "";
            //werewolves
            if (text.Contains("werewolves"))
            {
                returner = "werewolf";
            }
            //cyclops
            else if (text.Contains("cyclops"))
            {
                returner = text;
            }
            else if (text[text.Length - 1] == 's')
            {
                returner = text.Substring(0, text.Length - 1);
            }
            else returner = text;

            returner = returner.ToLower();
            return returner;
        }

        private static string getSpecificMonster(string monsterType)
        {
            System.IO.StreamReader reader;
            ArrayList monsters = new ArrayList();
            string returner = "";
            partsPath = Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + monsterType + ".txt";
            if (partsPath == "")
            {
                //error
            }
            else
            {
                reader = new System.IO.StreamReader(partsPath);
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    monsters.Add(reader.ReadLine());
                }
                roll = rand.Next(0, monsters.Count);
                returner = (string)monsters[roll];
                while ((returner.Contains("NPC")))
                {
                    roll = rand.Next(0, monsters.Count);
                    returner = (string)monsters[roll];
                }

                returner = sanitizeMonsterReturn(returner);
            }
            return returner;
        }

        public static string getMonsterType()
        {
            //TODO: Check to see if this was generated as treasure or as a wilderness or as a monster or as a dungeon
            //If generated as treasure, get a totally random monster
            //If generated as wilderness, monster, or dungeon, get a monster off the encounter table being used
            string returner = "";
            System.IO.StreamReader reader;
            ArrayList monsters = new ArrayList();
            Wilderness wildlands = new Wilderness();
            //DUNGEON CODE
            if (generationType == 1)
            {
                //generate a monster name
                if (partsPath == "")
                {
                    //error
                }
                else
                {
                    reader = new System.IO.StreamReader(partsPath);
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        reader.ReadLine();
                        monsters.Add(reader.ReadLine());
                    }
                    roll = rand.Next(0, monsters.Count);
                    returner = (string)monsters[roll];
                    while ((returner.Contains("NPC")))
                    {
                        roll = rand.Next(0, monsters.Count);
                        returner = (string)monsters[roll];
                    }
                    
                    returner = sanitizeMonsterReturn(returner);
                    return returner;
                }

            }
            //TREASURE CODE
            else if (generationType == 2)
            {
                string monsterType;
                roll = rand.Next(0, randomTerrains.Count);
                terrain = (string)randomTerrains[roll];
                monsterType = wildlands.GenerateEncounterType(terrain);
                while (monsterType == "Man")
                {
                    roll = rand.Next(0, randomTerrains.Count);
                    terrain = (string)randomTerrains[roll];
                    monsterType = wildlands.GenerateEncounterType(terrain);
                }
                /*partsPath = Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + monsterType + ".txt";
                if (partsPath == "")
                {
                    //error
                }
                else
                {
                    reader = new System.IO.StreamReader(partsPath);
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        monsters.Add(reader.ReadLine());
                    }
                    roll = rand.Next(0, monsters.Count);
                    returner = (string)monsters[roll];
                    while ((returner.Contains("NPC")))
                    {
                        roll = rand.Next(0, monsters.Count);
                        returner = (string)monsters[roll];
                    }

                    returner = sanitizeMonsterReturn(returner);
                    return returner;
                }*/
                returner = getSpecificMonster(monsterType);
                return returner;
 
            }
            //WILDERNESS CODE
            else if (generationType == 3)
            {
                string monsterType;
                monsterType = wildlands.GenerateEncounterType(terrain);
                while (monsterType == "Man")
                {
                    monsterType = wildlands.GenerateEncounterType(terrain);
                }

                partsPath = Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + monsterType + ".txt";
                if (partsPath == "")
                {
                    //error
                }
                else
                {
                    reader = new System.IO.StreamReader(partsPath);
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        monsters.Add(reader.ReadLine());
                    }
                    roll = rand.Next(0, monsters.Count);
                    returner = (string)monsters[roll];
                    while ((returner.Contains("NPC")))
                    {
                        roll = rand.Next(0, monsters.Count);
                        returner = (string)monsters[roll];
                    }

                    returner = sanitizeMonsterReturn(returner);
                    return returner;
                }
            }
            //MONSTER CODE
            else if (generationType == 4)
            {
                string monsterType;
                monsterType = wildlands.GenerateEncounterType(terrain);
                while (monsterType == "Man")
                {
                    monsterType = wildlands.GenerateEncounterType(terrain);
                }

                partsPath = Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + monsterType + ".txt";
                if (partsPath == "")
                {
                    //error
                }
                else
                {
                    reader = new System.IO.StreamReader(partsPath);
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        monsters.Add(reader.ReadLine());
                    }
                    roll = rand.Next(0, monsters.Count);
                    returner = (string)monsters[roll];
                    while ((returner.Contains("NPC")))
                    {
                        roll = rand.Next(0, monsters.Count);
                        returner = (string)monsters[roll];
                    }

                    returner = sanitizeMonsterReturn(returner);
                    return returner;
                }
            }
            return "";
        }

        public static string getMonsterFeathers()
        {
            System.IO.StreamReader reader;
            ArrayList monsters = new ArrayList();
            reader = new System.IO.StreamReader(Application.StartupPath + "/Resources/Treasure/Feathers.txt");
            while (!reader.EndOfStream)
            {
                monsters.Add(reader.ReadLine());
            }
            roll = rand.Next(0, monsters.Count);
            return (string)monsters[roll];
        }

        public static string getMonsterHorns()
        {
            System.IO.StreamReader reader;
            ArrayList monsters = new ArrayList();
            reader = new System.IO.StreamReader(Application.StartupPath + "/Resources/Treasure/Horns.txt");
            while (!reader.EndOfStream)
            {
                monsters.Add(reader.ReadLine());
            }
            roll = rand.Next(0, monsters.Count);
            return (string)monsters[roll];
        }

        private void generateScavenging(object sender, EventArgs e)
        {
            //TODO: Read number of armor and number of weapons out of text boxes
            //Roll on scavenging tables in scavenging class a number of times equal to the number in each box
            //This one isn't really super complicated
            wordpad = scavengeWordpadBox.Checked;
            playerBox = scavengePlayerBox.Checked;
            generationType = 5;
            System.IO.StreamWriter file = new System.IO.StreamWriter(scavengePath);
            file.Write("");
            file.Close();
            if (playerBox)
            {
                file = new System.IO.StreamWriter(playerPath);
                file.Write("");
                file.Close();
            }

            WriteToFile("Generating bladed weapons!");
            WriteToFile("");
            for (int i = 0; i < System.Convert.ToInt32(scavengeBladedWeaponsBox.Text); i++)
            {
                WriteToFile("Your bladed weapon has the following qualities: ");
                scavenging.scavengeBladedWeapon();
                WriteToFile("");
            }
            WriteToFile("Bladed weapons concluded!");
            WriteToFile("");

            WriteToFile("Generating blunt weapons!");
            for (int i = 0; i < System.Convert.ToInt32(scavengeBluntWeaponsBox.Text); i++)
            {
                WriteToFile("Your blunt weapon has the following qualities: ");
                scavenging.scavengeBluntWeapon();
                WriteToFile("");
            }
            WriteToFile("Blunt weapons concluded!");
            WriteToFile("");

            WriteToFile("Generating armor and/or equipment!");
            for (int i = 0; i < System.Convert.ToInt32(scavengeArmorBox.Text); i++)
            {
                WriteToFile("Your armor or equipment has the following qualities: ");
                scavenging.scavengeArmor();
                WriteToFile("");
            }
            WriteToFile("Armor and/or equipment concluded!");

            closeOldFile("Scavenging");
            if (playerBox) closeOldFile("PlayerOutput");
            openFile(scavengePath);
            if (playerBox) openFile(playerPath);
        }

        private void GenerateStandardStats(object sender, EventArgs e)
        {
            //Setup
            generationType = 6;
            wordpad = warWordpadBox.Checked;
            System.IO.StreamWriter file = new System.IO.StreamWriter(warPath);
            file.Write("");
            file.Close();

            //Actually do stuff in the middle here!

            //Unit Name: Entered by user
            string name = nameBox.Text;
            WriteToFile("Unit's Name: " + name);

            //Unit Movement Rate/Formation:  Determined by Base Movement and Weapons Carried
            string movement = warStats.getMovement(movementBox.Text, weaponsBox.Text);
            WriteToFile("Unit's Movement: " + movement);

            //Unit AC = Creature AC
            string AC = warStats.validateAC(acBox.Text);
            WriteToFile("Unit's AC: " + AC);
            warStats.setAC(acBox.Text);

            //Unit HD = Creature HD
            string HD = warStats.validateHD(hdBox.Text);
            WriteToFile("Unit's HD: " + hdBox.Text);

            //Unit HP = (Creature HD * number of creatures)/15
            //Number of creatures is determined by size
            string HP = warStats.getUnitHP(HD, sizeBox.Text);
            WriteToFile("Unit's HP: " + HP);

            //Unit Attack Throw = Creature's Attack Throw
            string attack = atkBox.Text;
            WriteToFile("Unit's Attack Throw: " + attack);

            //Unit's Number of Attacks = (Number of Creatures * (Number of Attacks + Cleave Factor) * Average Damage)/Size Factor * 4.5
            string attacks = warStats.getNumAttacks(HD, sizeBox.Text, numAttacksBox.Text, avgDamageBox.Text);
            WriteToFile("Unit's Number of Attacks: " + attacks);

            //Unit Morale = Creature Morale
            string morale = moraleBox.Text;
            WriteToFile("Unit's Morale: " + morale);

            //Unit Battle Rating = Complicated
            string br = warStats.getBattleRating();
            WriteToFile("Unit's Battle Rating: " + br);

            //Now I have all the stats!

            //Finishing
            closeOldFile("War");
            openFile(warPath);
        }

        private void revenueButton_Click(object sender, EventArgs e)
        {
            valueBox.Text = System.Convert.ToString((rand.Next(1, 4) + rand.Next(1, 4) + rand.Next(1, 4)));
        }

        private void GenerateDemandModifiers(object sender, EventArgs e)
        {
            //Setup
            generationType = 7;
            wordpad = demandWordpadBox.Checked;
            System.IO.StreamWriter file = new System.IO.StreamWriter(demandPath);
            file.Write("");
            file.Close();

            //I have all the data I need in various files in /Resources/Demand
            //PROGRAM PATH:  
            //Open the Merchandise file and fill an arraylist with the types of merchandise
            //I made a tiny merchandise class to pair name with value.
            //Now I can make a list of merchandise.

            //Read from the merchandise file
            System.IO.StreamReader reader = new System.IO.StreamReader(Application.StartupPath + "/Resources/Demand/Merchandise.txt");
            string read = "";
            int value = 0;
            ArrayList adder = new ArrayList();
            List<merchandise> items = new List<merchandise>();

            while (!reader.EndOfStream)
            {
                read = reader.ReadLine();
                items.Add(new merchandise(read, 0));
            }

            //I now have a list of merchandises with zero as their demand modifier value.

            //First step:  Roll 1d3 - 1d3 for each of them.
            for (int i = 0; i < items.Count; i++)
            {
                items[i].modifier += (rand.Next(1, 4) - rand.Next(1, 4));
            }

            //I now have the base value done.  Next I will apply land modifiers.
            try
            {
                value = System.Convert.ToInt32(valueBox.Text);
                ArrayList toAdd = new ArrayList(), toSubtract = new ArrayList();
                switch (value)
                {
                    case 3:
                        //+1 to 6, -1 to 1
                        toAdd = getLandModifiers(items.Count, 6);
                        toSubtract = getLandModifiers(items.Count, 1);
                        break;
                    case 4:
                        //+1 to 4, -1 to 1
                        toAdd = getLandModifiers(items.Count, 4);
                        toSubtract = getLandModifiers(items.Count, 1);
                        break;
                    case 5:
                        //+1 to 2, -1 to 1
                        toAdd = getLandModifiers(items.Count, 2);
                        toSubtract = getLandModifiers(items.Count, 1);
                        break;
                    case 6:
                        //+1 to 1, -1 to 1
                        toAdd = getLandModifiers(items.Count, 1);
                        toSubtract = getLandModifiers(items.Count, 1);
                        break;
                    case 7:
                        //-1 to 2, +1 to 1
                        toAdd = getLandModifiers(items.Count, 1);
                        toSubtract = getLandModifiers(items.Count, 2);
                        break;
                    case 8:
                        //-1 to 4, +1 to 1
                        toAdd = getLandModifiers(items.Count, 1);
                        toSubtract = getLandModifiers(items.Count, 4);
                        break;
                    case 9:
                        //-1 to 6, +1 to 1
                        toAdd = getLandModifiers(items.Count, 1);
                        toSubtract = getLandModifiers(items.Count, 6);
                        break;        
                }

                for (int i = 0; i < toAdd.Count; i++)
                {
                    items[(int)toAdd[i]].modifier++;
                }

                for (int i = 0; i < toSubtract.Count; i++)
                {
                    items[(int)toSubtract[i]].modifier--;
                }
            }
            catch (Exception a)
            {
                throw new Exception("You entered something that wasn't a number in the land value field!", a);
            }

            //Age modifiers requires me to find the age string in the Age.txt file.  After that, I want to loop until I read ****.

            reader.Close();


            /*reader = new System.IO.StreamReader(Application.StartupPath + "/Resources/Demand/Age.txt");
            read = reader.ReadLine();
            while (read != ageBox.Text)
            {
                read = reader.ReadLine();
            }
            //I only go until the ****, which may not be enough for all the items, to support custom items.
            while (!(read.Contains("****")))
            {
                read = reader.ReadLine();
                items[counter].modifier += System.Convert.ToDouble(read);
                counter++;
            }
            
            //Now I have to do the same thing for age, climate, elevation, and water.  Can I use reflection to get a variable name?  
            //It actually doesn't matter, I'm just an idiot.*/

            //Age
            adder = addDemandModifiers(ageBox.Text, "Age");

            for (int i = 0; i < adder.Count; i++)
            {
                items[i].modifier += (double)adder[i];
            }

            //Climate
            adder = addDemandModifiers(climateBox.Text, "Climate");

            for (int i = 0; i < adder.Count; i++)
            {
                items[i].modifier += (double)adder[i];
            }

            //Elevation
            adder = addDemandModifiers(elevationBox.Text, "Elevation");

            for (int i = 0; i < adder.Count; i++)
            {
                items[i].modifier += (double)adder[i];
            }

            //Water
            adder = addDemandModifiers(waterBox.Text, "Water");

            for (int i = 0; i < adder.Count; i++)
            {
                items[i].modifier += (double)adder[i];
            }

            //I now know all of the demand modifiers.  Time to fix them!
            for (int i = 0; i < items.Count; i++)
            {
                items[i].modifier = Math.Truncate(items[i].modifier);
            }

            //For output, I only care about demand modifiers that aren't 0.

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].modifier < 0)
                {
                    WriteToFile(items[i].name + ": " + (int)items[i].modifier);
                }
                else if (items[i].modifier > 0)
                {
                    WriteToFile(items[i].name + ": +" + (int)items[i].modifier);
                }
            }

            //Finishing
            closeOldFile("Demand");
            openFile(demandPath);
        }

        //This is not actually going to be a void.  I'm just not sure what I'm returning yet.
        private ArrayList addDemandModifiers(string tester, string path)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Application.StartupPath + "/Resources/Demand/" + path + ".txt");
            string read = reader.ReadLine();
            ArrayList returner = new ArrayList();
            while (read != tester)
            {
                read = reader.ReadLine();
            }
            read = reader.ReadLine();
            //I only go until the ****, which may not be enough for all the items, to support custom items.
            while (!(read.Contains("****")))
            {
                returner.Add(System.Convert.ToDouble(read));
                read = reader.ReadLine();
            }

            return returner;
        }

        //Returns num random unique numbers between 0 and max-1
        private ArrayList getLandModifiers(int max, int num)
        {
            ArrayList returner = new ArrayList();
            int adder = rand.Next(0, max);
            for (int i = 0; i < num; i++)
            {
                while (returner.Contains(adder))
                {
                    adder = rand.Next(0, max);
                }
                returner.Add(adder);
            }

            return returner;
        }


        private void armyAAddButton_Click(object sender, EventArgs e)
        {

        }

        private void armyBAddButton_Click(object sender, EventArgs e)
        {

        }

        private void armyAGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            armyAGridView.Rows.Add();
        }

        private void battleButton_Click(object sender, EventArgs e)
        {
            //Check if an army was surprised
            DialogResult surpriseResult = new DialogResult();
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            MessageBoxManager.Yes = "Army A";
            MessageBoxManager.No = "Army B";
            MessageBoxManager.Cancel = "Neither";
            MessageBoxButtons buttons2 = MessageBoxButtons.AbortRetryIgnore;
            MessageBoxManager.Abort = "Advantageous";
            MessageBoxManager.Retry = "Ext. advantag.";
            MessageBoxManager.Ignore = "No";
            MessageBoxButtons buttons3 = MessageBoxButtons.YesNo;
            MessageBoxManager.Register();
            surpriseResult = MessageBox.Show("Was either army surprised?", "Check for surprise!", buttons);
            //Check if an army occupies advantageous or extremely advantageous terrain
            DialogResult terrainResult = new DialogResult();
            terrainResult = MessageBox.Show("Does either army occupy especially advantageous terrain?", "Terrain", buttons2);
            DialogResult armyTerrainResult = new DialogResult();
            if ((terrainResult == DialogResult.Abort) || (terrainResult == DialogResult.Retry))
                armyTerrainResult = MessageBox.Show("Which army occupies the advantageous terrain?", "Army Terrain", buttons3);
            //Run through the rounds

            //If one army is surprised, the other army gains +2 on attack throws in the first round.
            //If one army occupies advantageous terrain, the other army takes -2 on attack throws.
            //If one army occupies extremely advantageous terrain, the other army takes -4 on attack throws.
            //If the unit attacking has a lieutenant attached to it, it gets a +2 bonus to attack throws.

            //After damage is resolved, morale phase happens.
        }

    }

}
