using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACKS_Toolkit
{
    public partial class Wilderness
    {
        static Random rand;
        static int roll;
        static bool lair;
        static string monster;
        static int numAppearing;
        static int xp;
        ArrayList treasures;

        public Wilderness()
        {
            rand = new Random(Guid.NewGuid().GetHashCode());
            roll = 0;
            lair = false;
            monster = "";
            numAppearing = 0;
            xp = 0;
            treasures = new ArrayList();

        }

        public bool getLairTag()
        {
            return lair;
        }

        public string getMonster()
        {
            return monster;
        }

        public int getXP()
        {
            return xp;
        }

        public ArrayList getTreasures()
        {
            return treasures;
        }

        public void generateEncounter(string terrain)
        {
            string monsterType = GenerateEncounterType(terrain);
            if (monsterType != "")
            {
                //No error
                //I know the monster type and terrain.  That means I need to look up the specific encounter table.
                string path = Application.StartupPath + "/Resources/Wilderness/Encounters/" + terrain + monsterType + ".txt";
                System.IO.StreamReader reader = new System.IO.StreamReader(path);
                string monster = "";
                int distance = 0;
                if (Form1.encounterDistance != "")
                {
                    distance = generateEncounterDistance(Form1.encounterDistance);
                    Form1.WriteToFile("Your encounter distance is: " + distance + " yards.  Modify by the size of monster relative to man.");
                }

                ArrayList monsters = new ArrayList();

                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    monsters.Add(reader.ReadLine());
                }

                roll = rand.Next(0, monsters.Count);
                monster = (string)monsters[roll];

                if ((monster != "") && (monsterType != ""))
                    identifyEncounterFunction(monster);
                else
                {
                    Form1.WriteToFile("ERROR: Could not find a monster in your encounter file!");
                    return; //Error
                }
                Form1.WriteToFile("Your encounter has completed!");
                Form1.WriteToFile("");
                Form1.WriteToFile("");
            }
            else
            {
                //Error
                Form1.WriteToFile("ERROR: Could not find a monster type in your terrain file!");
                return;
            }
        }

        //TYPE FUNCTIONS
        //Generate the type of encounter by terrain.
        //Are passed the specific type; some type functions are used for more than one terrain type.

        public string GenerateEncounterType(string terrain)
        {
            string path = "";
            if (terrain != "")
            {
                path = Application.StartupPath + "/Resources/Wilderness/" + terrain + ".txt";
            }
            else
            {
                //Error
                return "-1";
            }
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            string type = "";
            ArrayList types = new ArrayList();
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                types.Add(reader.ReadLine());
            }
            roll = rand.Next(0, types.Count);
            type = (string)types[roll];
            /*for (int i = 0; i < types.Count ; i++)
            {
                if (i+1 == roll)
                {
                    //You've found your encounter type!
                    type = (string)types[i];
                }
            }*/
            return type;
        }

        public static string sanitizeMonster(string monster)
        {
            string returner = monster;
            while (returner.Contains(' '))
            {
                returner = returner.Remove(returner.IndexOf(' '), 1);
            }
            while (returner.Contains(',')){
                returner = returner.Remove(returner.IndexOf(','), 1);
            }
            returner = returner + "Encounter";
            return returner;
        }

        public void identifyEncounterFunction(string monster)
        {
            Type type = typeof(Wilderness);
            string temp = sanitizeMonster(monster);
            System.Reflection.MethodInfo methodinfo = type.GetMethod(temp);
            if (methodinfo != null)
            methodinfo.Invoke(this, null);
            else {
                if (monster == "Demon Boar") BoarDemonEncounter();
                else if (monster == "Sea Dragon") DragonSeaEncounter();
                else if (monster == "Sea Hydra") HydraSeaEncounter();
                else if (monster == "Tyrannosaurus Rex") TRexEncounter();
                else customEncounter(monster);
            }
        }
        

        //CUSTOM ENCOUNTER
        private void customEncounter(string name)
        {
            if (name == null)
            {
                Form1.WriteToFile("ERROR:  customEncounter called with null monster name");
                return;
            }
            //Importer: Import Monster
            importer import = new importer();
            import.importMonster(name);
            xp = import.getXP();
            //Check if is in lair
            roll = rand.Next(1, 101);
            string parser = "";
            if (roll < import.getLair())
            {
                parser = import.getNumLair();
                //Generate lair numbar appearing if in lair
                //This first line is in the format XdY+Z
                //Might be in the format XdY
                //Might be XdY+Z
                //Might be XdY*AdB
                numAppearing = GenerateNumberInt(parser);
                Form1.WriteToFile("You have found a lair of " + numAppearing + " " + name + "s!");
                //Generate random lair if in lair and random lair box is checked
                if (Form1.lairGen)
                {
                    Form1.GenerateLair(this);
                }
                else
                {
                    //Roll treasure if in lair
                    Form1.WriteToFile("Its lair contains: ");
                    for (int j = 0; j < import.getTreasure().Length; j++)
                    {
                        treasure.RollTreasure(import.getTreasure().Substring(j, 1));
                        Form1.WriteToFile("");
                    }
                }
            }
            else
            {
                //Generate number appearing outside of lair if not in lair
                parser = import.getNumWilderness();
                //Might be in the format XdY
                //Might be XdY+Z
                //Might be XdY*AdB
                numAppearing = GenerateNumberInt(parser);
                Form1.WriteToFile("You have found a wilderness encounter of " + numAppearing + " " + name + "s!");
            }
        }


        /*private void generateNumber(string parser)
        {
            int counter = 0;
            rand = new Random(Guid.NewGuid().GetHashCode());
            if (parser.Contains('*'))
            {
                //Check whether it's XdY*AdB or XdY*Z
                if (parser.Substring(parser.IndexOf('*') + 1).Contains('d'))
                {

                    //XdY * AdB means roll XdY, then roll AdB a number of times equal to the result
                    //Counter now has the result of XdY
                    counter = dieRoller(parser.Substring(0, parser.IndexOf('*')));
                    for (int i = 0; i < counter; i++)
                    {
                        //Rolls the second set of dice each time through the for loop
                        numAppearing += dieRoller(parser.Substring(parser.IndexOf('*') + 1));
                    }
                }
                else
                {
                    //XdY*Z case
                    numAppearing += dieRoller(parser.Substring(0, parser.IndexOf('*')));
                    //After rolling dice, multiply by the value
                    numAppearing = numAppearing * System.Convert.ToInt32(parser.Substring(parser.IndexOf('*') + 1));
                }
            }
            else if (parser.Contains('+'))
            {
                //Does not contain a multiplier; this code covers XdY+Z
                numAppearing += dieRoller(parser.Substring(0, parser.IndexOf('+')));
                numAppearing += System.Convert.ToInt32(parser.Substring(parser.IndexOf('+') + 1));

            }
            else
            //This code covers XdY
            {
                numAppearing += dieRoller(parser);
            }
        }*/


        public static double generateNumberDouble(string parser)
        {
            //rand = new Random(Guid.NewGuid().GetHashCode());
            int counter = 0;
            int returner = 0;
            if (parser.Contains('*'))
            {
                //Check whether it's XdY*AdB or XdY*Z
                if (parser.Substring(parser.IndexOf('*') + 1).Contains('d'))
                {

                    //XdY * AdB means roll XdY, then roll AdB a number of times equal to the result
                    //Counter now has the result of XdY
                    counter = dieRoller(parser.Substring(0, parser.IndexOf('*')));
                    for (int i = 0; i < counter; i++)
                    {
                        //Rolls the second set of dice each time through the for loop
                        returner += dieRoller(parser.Substring(parser.IndexOf('*') + 1));
                    }
                }
                else
                {
                    //XdY*Z case
                    returner += dieRoller(parser.Substring(0, parser.IndexOf('*')));
                    //After rolling dice, multiply by the value
                    returner = returner * System.Convert.ToInt32(parser.Substring(parser.IndexOf('*') + 1));
                }
            }
            else if (parser.Contains('+'))
            {
                //Does not contain a multiplier; this code covers XdY+Z
                returner += dieRoller(parser.Substring(0, parser.IndexOf('+')));
                returner += System.Convert.ToInt32(parser.Substring(parser.IndexOf('+') + 1));

            }
            else if (parser.Contains('-'))
            {
                //Does not contain a multiplier; this code covers XdY-Z
                returner += dieRoller(parser.Substring(0, parser.IndexOf('-')));
                returner -= System.Convert.ToInt32(parser.Substring(parser.IndexOf('-') + 1));
            }
            else
            //This code covers XdY
            {
                returner += dieRoller(parser);
            }
            return (double)returner;
        }


        public static int GenerateNumberInt(string parser)
        {
            return (int)generateNumberDouble(parser);
        }

        private void GeneratePirateFleet()
        {
            //Number of guys appearing is the same whether in lair or not
            //Generate ship type
            roll = rand.Next(1, 101);
            int numBoats = 0, numSailors = 0, numMarines = 0, numSlaves = 0;
            bool king = false;
            int fourth = 0, fifth = 0;
            string pirateTreasure = "";
            int hostages = 0;
            string shipType = "";
            //Generate number of ships
            //Multiply number of ships by the complement for that ship for each type
            if (roll < 31)
            {
                //Boat, river
                shipType = "riverboats";
                numBoats = rand.Next(1, 5) + rand.Next(1, 5);
                numSailors = numBoats * 4;
                pirateTreasure = "L";
            }
            else if (roll < 51)
            {
                //Galley, small
                shipType = "small galleys";
                numBoats = rand.Next(1, 7);
                numSailors = numBoats * 10;
                numMarines = numBoats * 20;
                numSlaves = numBoats * 60;
                pirateTreasure = "L";
            }
            else if (roll < 71)
            {
                //Longship
                shipType = "longships";
                numBoats = rand.Next(1, 5);
                numSailors = numBoats * 75;
                pirateTreasure = "O";
            }
            else if (roll < 86)
            {
                //Troop transport, small
                shipType = "small troop transports";
                numBoats = rand.Next(1, 7);
                numSailors = numBoats * 12;
                numMarines = numBoats * 25;
                pirateTreasure = "O";
            }
            else if (roll < 91)
            {
                //Troop transport, large
                shipType = "large troop transports";
                numBoats = rand.Next(1, 5);
                numSailors = numBoats * 20;
                numMarines = numBoats * 50;
                pirateTreasure = "O";
            }
            else if (roll < 96)
            {
                //Galley, large
                shipType = "large galleys";
                numBoats = rand.Next(1, 4);
                numSailors = numBoats * 20;
                numMarines = numBoats * 50;
                numSlaves = numBoats * 180;
                pirateTreasure = "O";
            }
            else
            {
                //Galley, war
                shipType = "war galleys";
                numBoats = rand.Next(1, 4);
                numSailors = numBoats * 30;
                numMarines = numBoats * 75;
                numSlaves = numBoats * 300;
                pirateTreasure = "OL";
            }
            //There is a 4th level fighter for every 30 pirates
            //There is a 5th level fighter for every 50 pirates
            //There are 1d4 hostages for every 50 pirates
            //Fleets of less than 200 are led by a pirate captain of 8th level
            //Fleets of 200 or greater are led by a pirate king of 11th level, with a first mate of 8th level and a 75% chance of a mage of level 8 + 1d2
            //When out of lair, the pirate leader has a map to their lair
            king = ((numSailors + numMarines) > 200);
            fourth = (numSailors + numMarines) / 30;
            fifth = (numSailors + numMarines) / 50;
            for (int i = 0; i < ((numSailors + numMarines) / 50); i++)
            {
                hostages += rand.Next(1, 5);
            }
            Form1.WriteToFile("They have a fleet of " + numBoats + " " + shipType + "!");
            Form1.WriteToFile("Their fleet has a total of " + numSailors + " pirate sailors and " + numMarines + " pirate marines.");
            if (numSlaves != 0) Form1.WriteToFile("Their fleet has a total of " + numSlaves + " galley slaves.");
            if (hostages != 0) Form1.WriteToFile("Their fleet is carrying " + hostages + " hostages.");
            if (king)
            {
                Form1.WriteToFile("They are led by a pirate king, an 11th level fighter!  He has the following loot: ");
                magicTreasure.leaderTreasure(11);
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    roll = rand.Next(1, 3) + 8;
                    Form1.WriteToFile("He is advised by a mage of level " + roll + " with the following loot: ");
                    magicTreasure.leaderTreasure(roll);
                }
                Form1.WriteToFile("He has a first mate, an 8th level fighter, with the following loot: ");
                magicTreasure.leaderTreasure(8);
            }
            else
            {
                Form1.WriteToFile("They are led by a pirate captain, an 8th level fighter!  He has the following loot: ");
                magicTreasure.leaderTreasure(8);
            }
            for (int i = 0; i < fourth; i++)
            {
                Form1.WriteToFile("They have a fourth level fighter with the following loot: ");
                magicTreasure.leaderTreasure(4);
            }
            for (int i = 0; i < fifth; i++)
            {
                Form1.WriteToFile("They have a fifth level fighter with the following loot: ");
                magicTreasure.leaderTreasure(5);
            }
            roll = rand.Next(1, 101);
            if (roll < 11)
            {
                //In lair
                Form1.WriteToFile("They are at or near harbor in their secret island lair.");
                Form1.WriteToFile("Their lair contains the following loot: ");
                for (int i = 0; i < pirateTreasure.Length; i++)
                {
                    treasure.RollTreasure(pirateTreasure.Substring(i, 1));
                }
            }
            else
            {
                //Outside lair
                Form1.WriteToFile("They are out in the watery wilderness.");
                Form1.WriteToFile("Their leader has a treasure map to their lair.");
            }

        }

        private int generateEncounterDistance(string terrain)
        {
            //Encounter distance is determined by terrain features
            //Make another dropdown box to select it
            //We can then get the distance string and parse it
            int distance = 0;
            distance = parseDistanceString(terrain);
            return distance;
        }


        public static int parseDistanceString(string parser)
        {
            rand = new Random(Guid.NewGuid().GetHashCode());
            int distance = 0;
            //legal formats:
            //XdY
            //XdY*Z
            //XdY+Z
            if (parser.Contains('*'))
            {
                //XdY*Z case
                distance += dieRoller(parser.Substring(0, parser.IndexOf('*')));
                //After rolling dice, multiply by the value
                distance = distance * System.Convert.ToInt32(parser.Substring(parser.IndexOf('*') + 1));

            }
            else if (parser.Contains('+'))
            {
                //XdY+Z case
                distance += dieRoller(parser.Substring(0, parser.IndexOf('+')));
                //After rolling dice, add the value
                distance = distance + System.Convert.ToInt32(parser.Substring(parser.IndexOf('+') + 1));
            }
            else
            {
                //XdY case
                distance += dieRoller(parser);
            }
            return distance;
        }

        //Rolls XdY.  String must be in the format XdY; no plus signs or times signs or anything.
        public static int dieRoller(string parser)
        {
            if (parser == "")
            {
                return -1;
            }
            int returner = 0;
            int temp = 0;
            for (int i = 0; i < System.Convert.ToInt32(parser.Substring(0, parser.IndexOf('d'))); i++)
            {
                //Roll this many dice
                temp = System.Convert.ToInt32(parser.Substring(parser.IndexOf('d') + 1));
                returner += rand.Next(1, (temp + 1));
                //Die from one to x
            }
            return returner;
        }

        private void generateAdventurer(string NPCClass, int NPCLevel)
        {
            Form1.WriteToFile(NPCClass + ": Level " + NPCLevel + ".");
            if (Form1.dungeonNPCLevel)
                generateNPCTreasure((System.Convert.ToInt32(NPCLevel)));
            else
            {
                Form1.WriteToFile("You need to generate treasure yourself when an exact level is not known by me!");
                Form1.WriteToFile("");
            }
        }

        //This is the NPC encounter with known leader
        //It's just like any other NPC encounter, except the leader's class is not randomly generated
        public void NPCEncounter(string type)
        {
            ArrayList NPCClasses = new ArrayList(), NPCLevels = new ArrayList();
            numAppearing = GenerateNumberInt("1d4+2");
            NPCClasses.Add(type);
            NPCLevels.Add(generateNPCLevel());
            for (int i = 0; i < numAppearing-1; i++)
            {
                NPCClasses.Add(generateNPCclass());
                NPCLevels.Add(generateNPCLevel());
            }
            string alignment = generateNPCAlignment();
            Form1.WriteToFile("You have encountered an NPC adventuring party of " + numAppearing + " adventurers!");
            Form1.WriteToFile("The party alignment is: " + alignment);
            Form1.WriteToFile("All members of this party are of the party alignment or within one step of it.");
            Form1.WriteToFile("The specific NPC adventurers and their gear follow.");
            Form1.WriteToFile("");
            Form1.WriteToFile("The party leader is: ");
            for (int i = 0; i < numAppearing; i++)
            {
                generateAdventurer((string)NPCClasses[i], System.Convert.ToInt32(NPCLevels[i]));
            }
        }

        //NPC ENCOUNTER RULES
        //Number encountered: d4+2
        //NPCs are never in lair, so their XP values are irrelevant.
        //This is the full-on NPC Party encounter
        public void NPCPartyEncounter()
        {
            ArrayList NPCClasses = new ArrayList(), NPCLevels = new ArrayList();
            numAppearing = GenerateNumberInt("1d4+2");
            for (int i = 0; i < numAppearing; i++)
            {
                NPCClasses.Add(generateNPCclass());
                NPCLevels.Add(generateNPCLevel());
            }
            NPCLevels = sanitizeNPCLevels(NPCClasses, NPCLevels);
            string alignment = generateNPCAlignment();
            Form1.WriteToFile("You have encountered an NPC adventuring party of " + numAppearing + " adventurers!");
            Form1.WriteToFile("The party alignment is: " + alignment);
            Form1.WriteToFile("All members of this party are of the party alignment or within one step of it.");
            Form1.WriteToFile("The specific NPC adventurers and their gear follow.");
            Form1.WriteToFile("");
            Form1.WriteToFile("The party leader is: ");
            for (int i = 0; i < numAppearing; i++)
            {
                generateAdventurer((string)NPCClasses[i], System.Convert.ToInt32(NPCLevels[i]));
            }
        }

        private string generateNPCclass()
        {
            int NPCclass = GenerateNumberInt("3d6");
            string returner = "";
            if (NPCclass < 5) returner = "Elven nightblade";
            else if (NPCclass == 5) returner = "Elven spellsword";
            else if (NPCclass == 6) returner = "Explorer";
            else if (NPCclass == 7) returner = "Bladedancer";
            else if (NPCclass == 8) returner = "Cleric";
            else if (NPCclass < 12) returner = "Fighter";
            else if (NPCclass == 12) returner = "Thief";
            else if (NPCclass == 13) returner = "Mage";
            else if (NPCclass == 14) returner = "Assassin";
            else if (NPCclass == 15) returner = "Bard";
            else if (NPCclass == 16) returner = "Dwarven vaultguard";
            else returner = "Dwarven craftpriest";

            return returner;
        }

        //Group alignment: 1-2 Lawful, 3-5 Neutral, 6 Chaotic
        private string generateNPCAlignment()
        {
            string returner = "";
            int alignment = GenerateNumberInt("1d6");
            if (alignment < 3) returner = "Lawful";
            else if (alignment < 6) returner = "Neutral";
            else returner = "Chaotic";
            return returner;
        }

        //Level: 1 Base level -2, 2 Base level -1, 3-4 Base level, 5 Base level +1, 6 Base level +2 (Roll per NPC)
        private string generateNPCLevel()
        {
            string returner = "";
            if (Form1.dungeonNPCLevel)
            {
                int level = 0;
                switch (Form1.levels)
                {
                    case 1: level = 1; break;
                    case 2: level = 2; break;
                    case 3: level = 4; break;
                    case 4: level = 5; break;
                    case 5: level = 8; break;
                    case 6: level = 14; break;
                }
                roll = GenerateNumberInt("1d6");
                if (roll == 1) level = level - 2;
                else if (roll == 2) level = level - 1;
                else if (roll < 5) ;
                else if (roll == 5) level++;
                else level += 2;
                if (level < 1) level = 1;
                else if (level > 14) level = 14;
                returner = "" + level;
            }
            else
            {
                string level = "";
                string temp = "N";
                roll = GenerateNumberInt("1d6");
                if (roll == 1) level = temp + "-2";
                else if (roll == 2) level = temp + "-1";
                else if (roll < 5) level = temp;
                else if (roll == 5) level = temp + "+1";
                else level = temp + "+2";
                returner = level;
            }

            return returner;
        }

        private ArrayList sanitizeNPCLevels(ArrayList classes, ArrayList levels)
        {
            ArrayList returner = new ArrayList();
            for (int i = 0; i < classes.Count; i++)
            {
                //max level 11
                if ((string)classes[i] == "Elven nightblade")
                {
                    if (System.Convert.ToInt32(levels[i]) > 11)
                    {
                        returner.Add(11);
                    }
                    else returner.Add(levels[i]);
                }
                //max level 10
                else if ((string)classes[i] == "Elven spellsword")
                {
                    if (System.Convert.ToInt32(levels[i]) > 10)
                    {
                        returner.Add(10);
                    }
                    else returner.Add(levels[i]);
                }
                //max level 13
                else if ((string)classes[i] == "Dwarven vaultguard")
                {
                    if (System.Convert.ToInt32(levels[i]) > 13)
                    {
                        returner.Add(13);
                    }
                    else returner.Add(levels[i]);
                }
                //max level 10
                else if ((string)classes[i] == "Dwarven craftpriest")
                {
                    if (System.Convert.ToInt32(levels[i]) > 10)
                    {
                        returner.Add(10);
                    }
                    else returner.Add(levels[i]);
                }
                else
                {
                    returner.Add(levels[i]);
                }
            }
            return returner;
        }

        private void generateNPCTreasure(int level)
        {
            magicTreasure.leaderTreasure(level);
            switch (level)
            {
                case 1: treasure.NPCTreasureBQuarter(); break;
                case 2: treasure.NPCTreasureBHalf(); break;
                case 3: treasure.NPCTreasureBHalf(); break;
                case 4: treasure.NPCTreasureB(); break;
                case 5: treasure.NPCTreasureDHalf(); break;
                case 6: treasure.NPCTreasureD(); break;
                case 7: treasure.NPCTreasureH(); break;
                case 8: treasure.NPCTreasureJ(); break;
                case 9: treasure.NPCTreasureJ(); treasure.NPCTreasureJ(); break;
                case 10: treasure.NPCTreasureN(); break;
                case 11: treasure.NPCTreasureO(); break;
                case 12: treasure.NPCTreasureN(); treasure.NPCTreasureN(); break;
                case 13: treasure.NPCTreasureQ(); break;
                case 14: treasure.NPCTreasureR(); break;
            }
            Form1.WriteToFile("");
        }
    }
}
