using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{

    //ENCOUNTER FUNCTION TASKS
    //SET XP
    //CHECK IF IS IN LAIR
    //IF IT IS IN LAIR, ROLL LAIR NUMBER APPEARING
    //GENERATE LAIR IF THE BOX IS CHECKED
    //OTHERWISE ROLL TREASURE
    //IF NOT IN LAIR, ROLL WILDERNESS NUMBER APPEARING
    //DO ANY MONSTER-SPECIFIC THINGS NECESSARY
    public partial class Wilderness
    {
        public void GenericEncounter(int monsterXP, int lair, string treasureType, string lairNum, string wildNum, string monsterName, string lairName, string wildName)
        {
            xp = monsterXP;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) lair = 100;
            if (roll <= lair)
            {
                //IN LAIR
                numAppearing = GenerateNumberInt(lairNum);
                if (numAppearing == 1)
                {
                    monsterName = monsterName.Substring(0, monsterName.Length);
                    Form1.WriteToFile("You have encountered a single " + monsterName + "!");
                    Form1.WriteToFile("It is in its lair.");
                }
                else
                {
                    Form1.WriteToFile("You have encountered a " + lairName + " of " + numAppearing + " " + monsterName + "!");
                    Form1.WriteToFile("They are in their lair.");
                }
                if (Form1.lairGen)
                {
                    //for (int i = 0; i < treasureType.Length; i++)
                    //{
                    //    treasures.Add(treasureType.Substring(i, 1));
                    //}
                    treasures.Add(treasureType);
                    Form1.GenerateLair(this);
                }
                else if (treasureType != "")
                {
                    Form1.WriteToFile("The lair contains: ");
                    /*for (int i = 0; i < treasureType.Length; i++)
                    {
                        treasure.RollTreasure(treasureType.Substring(i, 1));
                    }*/
                    treasure.RollTreasure(treasureType);
                }
                else
                {
                    Form1.WriteToFile("The lair contains no meaningful treasure.");
                }
            }
            else
            {
                //OUT OF LAIR
                numAppearing = GenerateNumberInt(wildNum);
                if (numAppearing == 1)
                {
                    monsterName = monsterName.Substring(0, monsterName.Length);
                    Form1.WriteToFile("You have encountered a single " + monsterName + "!");
                    Form1.WriteToFile("It is out in the wilderness.");
                }
                else
                {
                    Form1.WriteToFile("You have encountered a " + wildName + " of " + numAppearing + " " + monsterName + "!");
                    Form1.WriteToFile("They are out on the wilderness.");
                }
            }
        }

        public void AntGiantEncounter()
        {
            xp = 80;
            roll = rand.Next(1, 101);
            //Since giant ants have the same number in or out of nest, just roll it before checking
            //numAppearing = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            numAppearing = GenerateNumberInt("4d6");
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //IN LAIR
                Form1.WriteToFile("You have encountered a nest of " + numAppearing + " giant ants!");
                Form1.WriteToFile("They are in their lair.");
                if (Form1.lairGen)
                {
                    treasures.Add("I");
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("This nest contains the following treasure: ");
                    treasure.RollTreasure("I");
                }
                roll = rand.Next(1, 101);
                if (roll < 31)
                {
                    Form1.WriteToFile("This ant nest contains " + (rand.Next(1, 11) * 1000) + " gold pieces worth of raw gold nuggets.");
                }
            }
            else
            {
                //NOT IN LAIR
                Form1.WriteToFile("You have encountered a swarm of " + numAppearing + " giant ants!");
                Form1.WriteToFile("They are out in the wilderness.");
            }
        }

        public void ApeWhiteEncounter()
        {
            GenericEncounter(80, 10, "", "2d4", "2d4", "white apes", "den", "band");
        }

        public void BaboonRockEncounter()
        {
            GenericEncounter(20, 10, "", "5d6", "5d6", "rock baboons", "den", "band");
        }

        //Is an NPC encounter
        public void BarbarianEncounter()
        {
            NPCEncounter("Barbarian");
        }

        public void BasiliskEncounter()
        {
            xp = 980;
            numAppearing = rand.Next(1, 7);
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //IN LAIR
                Form1.WriteToFile("You have encountered a nest of " + numAppearing + " basilisks!");
                if (Form1.lairGen)
                {
                    treasures.Add("K");
                    Form1.GenerateLair(this);
                    Form1.WriteToFile("Any treasure in the basilisk's lair is on petrified victims and is only accessible if they are returned to flesh.");
                }
                else
                {
                    Form1.WriteToFile("The basilisk nest contains the following treasure, on petrified victims, only accessible if the victims are returned to flesh: ");
                    treasure.RollTreasure("K");
                }
            }
            else
            {
                //NOT IN LAIR
                Form1.WriteToFile("You have encountered a bask of " + numAppearing + " basilisks!");
            }
        }

        public void BatEncounter()
        {
            //1-4 normal or swarm, 5-6 giant
            roll = rand.Next(1, 7);
            if (roll < 5)
            {
                //normal or swarm
                roll = rand.Next(1, 101);
                if (roll < 36)
                {
                    //swarm, in lair
                    GenericEncounter(5, 100, "", "1d1", "1d1", "bat swarms", "nest", "flock");
                }
                else
                {
                    //normal, out of lair
                    GenericEncounter(5, 0, "", "1d10", "1d10", "ordinary bats", "nest", "flock");
                }
            }
            else
            {
                //giant
                BatGiantEncounter();
            }
        }

        public void BatGiantEncounter()
        {
            roll = rand.Next(1, 101);
            string name = "";
            if (roll < 96)
            {
                //Normal giant bat
                name = "giant bats";
            }
            else
            {
                //Giant vampire bat
                name = "giant vampire bats";
            }
            GenericEncounter(20, 35, "", "1d10", "1d10", name, "nest", "flock");
        }

        public void BearBlackEncounter()
        {
            GenericEncounter(80, 25, "", "1d4", "1d4", "black bears", "den", "sloth");
        }

        public void BearCaveEncounter()
        {
            GenericEncounter(320, 25, "", "1d2", "1d2", "cave bears", "den", "sloth");
        }

        public void BearGrizzlyEncounter()
        {
            GenericEncounter(200, 25, "", "1d4", "1d4", "grizzly bears", "den", "sloth");
        }

        public void BearPolarEncounter()
        {
            GenericEncounter(440, 35, "", "1d2", "1d2", "polar bears", "den", "sloth");
        }

        public void BeeKillerGiantEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 36)
            {
                //in lair
                numAppearing = GenerateNumberInt("5d6");
                Form1.WriteToFile("You have encountered a hive of " + numAppearing + " giant killer bees!");
                Form1.WriteToFile("They are led by a queen of 2 Hit Dice, guarded by 10 large giant killer bees with 1 HD each.");
                Form1.WriteToFile("Their hive contains " + rand.Next(1, 5) + " doses of giant killer bee honey (each dose acts as a half-strength potion of healing, healing 1d4 hit points.");
            }
            else
            {
                //out of lair
                GenericEncounter(6, 0, "", "5d6", "5d6", "giant killer bees", "hive", "swarm");
            }
        }

        public void BeetleFireEncounter()
        {
            GenericEncounter(15, 40, "", "2d6", "2d6", "giant fire beetles", "nest", "scourge");
        }

        public void BeetleGiantBombardierEncounter()
        {
            GenericEncounter(20, 40, "", "2d6", "2d6", "giant bombardier beetles", "nest", "scourge");
        }

        public void BeetleTigerEncounter()
        {
            GenericEncounter(65, 40, "", "2d4", "2d4", "giant tiger beetles", "nest", "scourge");
        }

        public void BerserkerEncounter()
        {
            xp = 21;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //Lair encounter
                //Generate the encounter
                roll = rand.Next(1, 9);
                for (int i = 0; i < roll; i++)
                {
                    numAppearing += rand.Next(1, 7);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " berserkers!");
                Form1.WriteToFile("They are led by a 4th level fighter with the Berserkergang proficiency and the following loot.");
                magicTreasure.leaderTreasure(4);
                Form1.WriteToFile("They are in their lair.");
                //Check if a random lair should be generated
                if (Form1.lairGen)
                {
                    //Generate a random lair
                    treasures.Add("J");
                    Form1.GenerateLair(this);
                }
                else
                {
                    //At least roll their treasure, since they're in lair and have it.
                    Form1.WriteToFile("Their lair contains: ");
                    treasure.RollTreasure("J");
                }
            }
            else
            {
                //Wilderness encounter
                roll = rand.Next(1, 9);
                for (int i = 0; i < roll; i++)
                {
                    numAppearing += rand.Next(1, 7);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " berserkers!");
                Form1.WriteToFile("They are led by a 4th level fighter with the Berserkergang proficiency.");
                magicTreasure.leaderTreasure(4);
                Form1.WriteToFile("They are out in the wilderness.");
            }
            Form1.WriteToFile("");
        }

        public void BlackPuddingEncounter()
        {
            GenericEncounter(1550, 0, "", "1d1", "1d1", "black puddings", "ooze", "ooze");
        }

        public void BlinkDogEncounter()
        {
            GenericEncounter(135, 20, "I", "2d6", "2d6", "blink dogs", "den", "route");
        }

        public void BoarEncounter()
        {
            //1-4 normal, 5-6 giant
            roll = rand.Next(1, 7);
            if (roll < 5) BoarNormalEncounter();
            else BoarGiantEncounter();
        }

        public void BoarNormalEncounter()
        {
            GenericEncounter(50, 0, "", "1d6", "1d6", "ordinary boars", "sounder", "sounder");
        }

        public void BoarGiantEncounter()
        {
            GenericEncounter(200, 0, "", "1d4+1", "1d4+1", "giant boars", "sounder", "sounder");
        }

        public void BrigandEncounter()
        {
            xp = 10;
            roll = rand.Next(1, 101);
            bool cleric = false, mage = false;
            int mageLevel = 0;
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                int bands;
                //Lair encounter
                //Generate the encounter
                bands = rand.Next(1, 7) + rand.Next(1, 7);
                //Camp has 2d6 bands
                //A band is 1d10 gangs
                //A gang is 2d4 brigands
                //FOR EACH BAND
                for (int i = 0; i < bands; i++)
                {
                    roll = rand.Next(1, 11);
                    //FOR EACH GANG
                    for (int j = 0; j < roll; j++)
                    {
                        numAppearing += rand.Next(1, 5) + rand.Next(1, 5);
                    }
                }
                roll = rand.Next(1, 101);
                if (roll < 31)
                {
                    //cleric
                    cleric = true;
                }
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    //mage
                    mage = true;
                    mageLevel = rand.Next(1, 3) + 8;
                }

                Form1.WriteToFile("You have encountered a camp of " + numAppearing + " brigands!");
                Form1.WriteToFile("This camp contains " + bands + " bands.");
                Form1.WriteToFile("Every band is led by a 4th level fighter and two 2nd level fighters.");
                for (int j = 0; j < bands; j++)
                {
                    magicTreasure.leaderTreasure(4);
                    magicTreasure.leaderTreasure(2);
                    magicTreasure.leaderTreasure(2);
                }
                Form1.WriteToFile("For every two bands, there is a single 5th level lieutenant.");
                for (int j = 0; j < (bands / 2); j++)
                {
                    magicTreasure.leaderTreasure(5);
                }
                Form1.WriteToFile("The camp overall is led by a 9th level brigand captain.");
                magicTreasure.leaderTreasure(9);
                if (cleric)
                {
                    Form1.WriteToFile("There is an 8th level cleric in the camp.");
                    magicTreasure.leaderTreasure(8);
                }
                if (mage)
                {
                    Form1.WriteToFile("There is a level " + mageLevel + " mage in the camp.");
                    magicTreasure.leaderTreasure(mageLevel);
                }
                Form1.WriteToFile("They are in their lair.");
                //Check if a random lair should be generated
                if (Form1.lairGen)
                {
                    //Generate a random lair
                    for (int i = 0; i < bands; i++)
                    {
                        treasures.Add("H");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    //At least roll their treasure, since they're in lair and have it.
                    Form1.WriteToFile("Their lair contains: ");
                    string temp = "";
                    for (int i = 0; i < bands; i++)
                    {
                        temp += "H";
                        //treasure.RollTreasure("H");
                    }
                    treasure.RollTreasure(temp);
                }
            }
            else
            {
                //Wilderness encounter
                //One band: 1d10 gangs, each gang is 2d4 brigands
                roll = rand.Next(1, 11);
                for (int i = 0; i < roll; i++)
                {
                    numAppearing += rand.Next(1, 5) + rand.Next(1, 5);
                }
                Form1.WriteToFile("You have encountered a band of " + numAppearing + " brigands!");
                Form1.WriteToFile("The band is led by a 4th level fighter and two 2nd level fighters.");
                Form1.WriteToFile("They are out in the wilderness.");
            }
            Form1.WriteToFile("");
        }


        public void BuccaneerEncounter()
        {
            xp = 10;
            Form1.WriteToFile("You have encountered buccaneers!");
            GeneratePirateFleet();
        }

        public void BugbearEncounter()
        {
            xp = 65;
            int warbands = 0, gangs = 0, temp = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 26)
            {
                //Lair encounter
                //Village: 1d10 warbands
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    //each warband is 1d4 gangs
                    temp = rand.Next(1, 5);
                    for (int j = 0; j < temp; j++)
                    {
                        //each gang is 2d4 bugbears
                        numAppearing += (rand.Next(1, 5) + rand.Next(1, 5));
                        gangs++;
                    }
                }
                //Number of bugbears is now known!
                //Each gang has a champion - increased stats but no class levels
                //Each warband has a sub-chieftain - no class levels, increased stats
                //A lair or village has a chieftain; again, more stats, no class levels
                //Lairs/villages have females and young each equal to 50% of the number of adult males
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " bugbears.");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village is made up of a total of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each warband has a sub-chieftain with increased stats.");
                Form1.WriteToFile("Each gang has a champion with increased stats.");
                Form1.WriteToFile("The village has " + Math.Truncate((double)(numAppearing / 2)) + " of each young and females.");
                //75% chance of shaman; sub-chieftain stats plus 1d6 levels of cleric
                //50% chance of witch doctor; champion stats plus 1d4 levels of mage
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    //shaman
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("The village has a shaman of level " + level + ".");
                    Form1.WriteToFile("He has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                    
                }
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    //witch doctor
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village has a witch doctor of level " + level + ".");
                    Form1.WriteToFile("He has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }
                //Check if a random lair should be generated
                if (Form1.lairGen)
                {
                    //Generate a random lair
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("L");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    //At least roll their treasure, since they're in lair and have it.
                    Form1.WriteToFile("Their lair contains: ");
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("L");
                        tempTreasure += "L";
                    }
                    treasure.RollTreasure(tempTreasure);
                }

            }
            else
            {
                //Wilderness encounter
                //Warband: 1d4 gangs
                //Each gang has a champion - increased stats but no class levels
                //Each warband has a sub-chieftain - no class levels, increased stats
                gangs = rand.Next(1, 5);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += (rand.Next(1, 5) + rand.Next(1, 5));
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " bugbears!");
                Form1.WriteToFile("The warband is made up of " + gangs + " gangs.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("They are out in the wilderness.");
            }

        }

        public void CaecilianEncounter()
        {
            GenericEncounter(570, 25, "K", "1d3", "1d3", "caecilians", "nest", "clew");
        }

        public void CamelEncounter()
        {
            GenericEncounter(20, 0, "", "2d4", "2d4", "camels", "caravan", "caravan");
        }

        public void CarcassScavengerEncounter()
        {
            GenericEncounter(135, 0, "", "1d3", "1d3", "carcass scavengers", "clew", "clew");
        }

        public void CatLionEncounter()
        {
            GenericEncounter(200, 25, "", "1d8", "1d4", "lions", "den", "pride");
        }

        public void CatMountainLionEncounter()
        {
            GenericEncounter(65, 10, "", "1d4", "1d4", "mountain lions", "den", "litter");
        }

        public void CatPantherEncounter()
        {
            GenericEncounter(80, 10, "", "1d6", "1d6", "panthers", "den", "pride");
        }

        public void CatTigerEncounter()
        {
            GenericEncounter(320, 5, "", "1d3", "1d1", "tigers", "den", "solitary");
        }

        public void CatSabretoothTigerEncounter()
        {
            GenericEncounter(600, 10, "", "1d4", "1d4", "sabre-tooth tigers", "den", "troop");
        }

        public void CentaurEncounter()
        {
            xp = 80;
            //Number appearing are the same whether it's lair or not.
            numAppearing += (rand.Next(1, 11) + rand.Next(1, 11));
            int young = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 6)
            {
                //Lair encounter
                Form1.WriteToFile("You have encountered a troop of " + numAppearing + " centuars!");
                Form1.WriteToFile("They are in their lair.");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    //Chieftain has clerical abilities
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("They are led by a chieftain with clerical abilities at level " + level + ".");
                    Form1.WriteToFile("He has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }
                else
                {
                    //Chieftain does not have clerical abilities
                    Form1.WriteToFile("They are led by a chieftain with increased stats but no clerical abilities.");
                }
                young = (numAppearing * 2) + GenerateNumberInt("5d6");
                Form1.WriteToFile("The lair also has " + numAppearing * 2 + " females and " + young + " young.");

                //Check if a random lair should be generated
                if (Form1.lairGen)
                {
                    treasures.Add("L");
                    Form1.GenerateLair(this);
                }
                else
                {
                    //At least roll their treasure, since they're in lair and have it.
                    Form1.WriteToFile("Their lair contains: ");
                    treasure.RollTreasure("L");
                }

            }
            else
            {
                //Wilderness encounter
                Form1.WriteToFile("You have encountered a troop of " + numAppearing + " centuars!");
                Form1.WriteToFile("They are out in the wilderness.");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    //Chieftain has clerical abilities
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("They are led by a chieftain with clerical abilities at level " + level + ".");
                    Form1.WriteToFile("He has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }
                else
                {
                    //Chieftain does not have clerical abilities
                    Form1.WriteToFile("They are led by a chieftain with increased stats but no clerical abilities.");
                }
            }
        }

        public void CentipedeGiantEncounter()
        {
            GenericEncounter(6, 10, "", "2d12", "2d12", "giant centipedes", "nest", "swarm");
        }

        public void ChimeraEncounter()
        {
            GenericEncounter(1300, 40, "KK", "1d4", "1d4", "chimeras", "den", "flock");
        }

        public void ClericEncounter()
        {
            NPCEncounter("Cleric");
        }

        public void CockatriceEncounter()
        {
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                //LAIR ENCOUNTER
                GenericEncounter(350, 100, "I", "1d8", "1d8", "cockatrices", "nest", "flock");
                Form1.WriteToFile("Any treasure in their lair is on petrified victims and can only be accessed by returning them to flesh.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(350, 0, "I", "1d8", "1d8", "cockatrices", "nest", "flock");
            }
        }

        public void CrabGiantEncounter()
        {
            GenericEncounter(50, 90, "", "2d6", "1d6", "giant crabs", "colony", "cluster");
        }

        public void CrocodileEncounter()
        {
            //1-4 normal or swarm, 5-6 giant
            roll = rand.Next(1, 5);
            if (roll < 5) CrocodileNormalEncounter();
            else CrocodileGiantEncounter();
        }

        public void CrocodileGiantEncounter()
        {
            GenericEncounter(1800, 0, "", "1d3", "1d3", "giant crocodiles", "bask", "bask");
        }

        public void CrocodileLargeEncounter()
        {
            GenericEncounter(320, 0, "", "1d4", "1d4", "large crocodile", "bask", "bask");
        }

        public void CrocodileNormalEncounter()
        {
            GenericEncounter(20, 0, "", "1d8", "1d8", "ordinary crocodile", "bask", "bask");
        }

        public void CyclopsEncounter()
        {
            GenericEncounter(1400, 20, "N", "1d4", "1d4", "cyclops ", "lair", "gang");
        }

        public void BoarDemonEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //LAIR ENCOUNTER
                GenericEncounter(2000, 100, "OL", "1d4", "1d4", "demon boars", "lair", "sounder");
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    int numThralls = rand.Next(1, 4);
                    Form1.WriteToFile("The demon boars have " + numThralls + " charmed thralls in their lair.");
                    Form1.WriteToFile("The thralls cannot cast spells or use magic items due to being under mental domination.");
                    Form1.WriteToFile("The thralls' classes, levels, and gear follow.");
                    System.Collections.ArrayList NPCClasses = new System.Collections.ArrayList(), NPCLevels = new System.Collections.ArrayList();
                    for (int i = 0; i < numThralls; i++)
                    {
                        NPCClasses.Add(generateNPCclass());
                        NPCLevels.Add(generateNPCLevel());
                    }
                    for (int i = 0; i < numThralls; i++)
                    {
                        generateAdventurer((string)NPCClasses[i], System.Convert.ToInt32(NPCLevels[i]));
                    }
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(2000, 0, "OL", "1d4", "1d4", "demon boars", "lair", "sounder");
            }
        }

        public void DjinniEncounter()
        {
            GenericEncounter(1300, 0, "", "1d1", "1d1", "djinnis", "solitary", "solitary");
        }

        public void DogEncounter()
        {
            //1-4 hunting, 5 or 6 war
            roll = rand.Next(1, 7);
            if (roll < 5) DogHuntingEncounter();
            else DogWarEncounter();
        }

        public void DogHuntingEncounter()
        {
            GenericEncounter(15, 10, "", "3d6", "3d6", "hunting dogs", "den", "route");
        }

        public void DogWarEncounter()
        {
            GenericEncounter(35, 10, "", "2d4", "2d4", "war dogs", "den", "route");
        }

        public void DoppelgangerEncounter()
        {
            GenericEncounter(135, 20, "I", "1d6", "1d6", "doppelgangers", "lair", "throng");
        }

        //Dragon flow:
        //Generate color if it is not already known
        //Generate age
        //Output abilities and such based on age
        public void DragonEncounter()
        {
            DragonColor();
        }

        public void DragonColorEncounter()
        {
            DragonAge();
        }
        /*
         * 2 - Spawn
         * 3 - V. Young
         * 4 - Young
         * 5 - Juvenile
         * 6 - Adult
         * 7 - Mature Adult
         * 8 - Old
         * If you roll an 8, roll 1d6-3. On a 1, the dragon is Very Old, on a 2 Ancient, and on a 3 Venerable.
         * */
        public void DragonAge()
        {
            roll = rand.Next(1, 5) + rand.Next(1, 5);
            if (roll == 2) DragonSpawnEncounter();
            else if (roll == 3) DragonVeryYoungEncounter();
            else if (roll == 4) DragonYoungEncounter();
            else if (roll == 5) DragonJuvenileEncounter();
            else if (roll == 6) DragonAdultEncounter();
            else if (roll == 7) DragonMatureAdultEncounter();
            else
            {
                roll = (rand.Next(1, 7) - 3);
                if (roll < 1) DragonOldEncounter();
                else if (roll == 1) DragonVeryOldEncounter();
                else if (roll == 2) DragonAncientEncounter();
                else DragonVenerableEncounter();
            }
          
        }

        //Generate the dragon's color if it is not already known
        //1 black
        //2 blue
        //3 brown
        //4 green
        //5 metallic
        //6 red
        //7 sea
        //8 white
        //9 wyrm
        //10 judge's choice
        public void DragonColor()
        {
            roll = rand.Next(1, 11);
            switch (roll)
            {
                case 1: DragonBlackEncounter(); break;
                case 2: DragonBlueEncounter(); break;
                case 3: DragonBrownEncounter(); break;
                case 4: DragonGreenEncounter(); break;
                case 5: DragonMetallicEncounter(); break;
                case 6: DragonRedEncounter(); break;
                case 7: DragonSeaEncounter(); break;
                case 8: DragonWhiteEncounter(); break;
                case 9: DragonWyrmEncounter(); break;
                case 10:
                    {
                        Form1.WriteToFile("You have encountered a dragon!  Color is Judge's choice.");
                        DragonColorEncounter();
                        break;
                    }
            }
        }

        //Dragon encounters:  Things I need to do
        //-Are they in lair?
        //-If in lair, are they asleep?
        //-If in lair, they need a treasure type.
        //-If old enough, they need special abilities.
        //-Always check for chance of speech; chance of speech means spellcasting.  XPV increases by one  * if they can cast spells.
        public void DragonGenericEncounter(int monsterXP, int spellXP, int lair, string treasureType, string lairNum, string wildNum, string monsterName, int speech, int sleep, int specials)
        {
            if (Form1.forceLair)
                lair = 101;
            Form1.WriteToFile("You have encountered a "+ monsterName + " encounter!.");
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < lair)
            {
                //lair encounter
                numAppearing = GenerateNumberInt(lairNum);
                if (numAppearing > 1)
                    Form1.WriteToFile("You have encountered a " + monsterName + " encounter of " + numAppearing + " " + monsterName + "s!");
                else Form1.WriteToFile("You have encountered a " + monsterName + " encounter of " + numAppearing + " " + monsterName + "!");
                Form1.WriteToFile("They are in their lair.");

                roll = rand.Next(1, 101);
                if (roll <= speech)
                {
                    //speech and spellcasting
                    Form1.WriteToFile("The dragon(s) are capable of speech and spellcasting.");
                    xp = spellXP;
                }
                else
                {
                    //no speech, no spellcasting
                    Form1.WriteToFile("The dragon(s) are incapable of speech and spellcasting.");
                    xp = monsterXP;
                }
                roll = rand.Next(1, 101);
                if (roll <= sleep)
                {
                    Form1.WriteToFile("The dragon(s) are asleep.");
                }
                else
                {
                    Form1.WriteToFile("The dragon(s) are awake.");
                }

                if (specials > 0) GenerateDragonSpecials(specials);

                //Treasures and lair generation area
                if (Form1.lairGen)
                {
                    for (int i = 0; i < numAppearing; i++)
                    {
                        treasures.Add(treasureType);
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains: ");
                    for (int i = 0; i < numAppearing; i++)
                    {
                        treasure.RollTreasure(treasureType);
                    }
                }
            }
            else
            {
                //wilderness encounter
                numAppearing = GenerateNumberInt(wildNum);
                if (numAppearing > 1)
                Form1.WriteToFile("You have encountered a " + monsterName + " encounter of " + numAppearing + " " + monsterName + "s!");
                else Form1.WriteToFile("You have encountered a " + monsterName + " encounter of " + numAppearing + " " + monsterName + "!");
                Form1.WriteToFile("They are out in the wilderness.");
                if (specials > 0) GenerateDragonSpecials(specials);
            }
        }


        public void GenerateDragonSpecials(int number)
        {
            int roll2 = 0, roll3 = 27;
            if (number == 1)
            {
                roll = rand.Next(1, 13);
                PickSpecial(roll);
            }
            else if (number == 2)
            {
                while (roll != roll2)
                {
                    roll = rand.Next(1, 13);
                    roll2 = rand.Next(1, 13);
                    if ((roll == 8) && (roll2 == 8))
                        break;
                }
                PickSpecial(roll);
                PickSpecial(roll2);
            }
            else if (number == 3)
            {
                while ((roll != roll2) && (roll2 != roll3) && (roll != roll3))
                {
                    roll = rand.Next(1, 13);
                    roll2 = rand.Next(1, 13);
                    roll3 = rand.Next(1, 13);
                    if (((roll == 8) && (roll2 == 8)) || ((roll2 == 8) && (roll3 == 8)) || (roll == 8) && (roll3 == 8))
                        break;
                }
                PickSpecial(roll);
                PickSpecial(roll2);
                PickSpecial(roll3);
            }
        }

        //clutching claws
        //decapitating bite
        //elemental aura
        //fear aura
        //gem-encrusted hide
        //horrific stench
        //invulnerable
        //massive size
        //paralyzing blows
        //poisonous blood
        //polymorph self
        //tail lash
        //wing claws
        public void PickSpecial(int number)
        {
            string ability = "";
            switch (number)
            {
                case 1: ability = "clutching claws"; break;
                case 2: ability = "decapitating bite"; break;
                case 3: ability = "elemental aura"; break;
                case 4: ability = "fear aura"; break;
                case 5: ability = "gem-encrusted hide"; break;
                case 6: ability = "horrific stench"; break;
                case 7: ability = "invulnerable"; break;
                case 8: ability = "massive size"; break;
                case 9: ability = "paralyzing blows"; break;
                case 10: ability = "poisonous blood"; break;
                case 11: ability = "polymorph self"; break;
                case 12: ability = "tail lash"; break;
                case 13: ability = "wing claws"; break;
            }
            Form1.WriteToFile("The dragon has the " + ability + " special ability.");
        }

        //Normal xp: 29, hd 2* spellcasting xp: 38
        public void DragonSpawnEncounter()
        {
            DragonGenericEncounter(29, 38, 90, "B", "1d4", "1d4", "dragon spawn", 1, 80, 0);
        }

        //Normal xp: 190, hd 4**, spellcasting xp: 245
        public void DragonVeryYoungEncounter()
        {
            DragonGenericEncounter(190, 245, 70, "H", "1d4", "1d4", "very young dragon", 2, 70, 0);
        }

        //normal xp: 820, hd 6**, spellcasting xp: 1070
        public void DragonYoungEncounter()
        {
            DragonGenericEncounter(820, 1070, 50, "N", "1d4", "1d4", "young dragon", 5, 60, 0);
        }

        //normal xp: 1600, hd 8**, spellcasting xp: 2100
        public void DragonJuvenileEncounter()
        {
            DragonGenericEncounter(1600, 2100, 40, "Q", "1d4", "1d4", "juvenile dragon", 10, 50, 0);
        }

        //normal xp: 2950, hd 10***, spellcasting xp: 3650
        public void DragonAdultEncounter()
        {
            DragonGenericEncounter(2950, 3650, 40, "QN", "1d4", "1d4", "adult dragon", 20, 40, 1);
        }

        //normal xp: 3900, hd 12***, spellcasting xp: 4800
        public void DragonMatureAdultEncounter()
        {
            DragonGenericEncounter(3900, 4800, 30, "QN", "1d4", "1d4", "mature adult dragon", 35, 30, 1);
        }

        //normal xp: 4900, hd 14***, spellcasting xp: 6000
        public void DragonOldEncounter()
        {
            DragonGenericEncounter(4900, 6000, 40, "R", "1d2", "1d2", "old dragon", 50, 20, 1);
        }

        //normal xp: 7200, hd 16****, spellcasting xp: 8500
        public void DragonVeryOldEncounter()
        {
            DragonGenericEncounter(7200, 8500, 70, "R", "1d2", "1d2", "very old dragon", 75, 10, 2);
        }

        //can always cast spells
        public void DragonAncientEncounter()
        {
            DragonGenericEncounter(8400, 8400, 70, "R", "1d2", "1d2", "ancient dragon", 100, 5, 2);
        }

        //can always cast spells
        public void DragonVenerableEncounter()
        {
            DragonGenericEncounter(12800, 12800, 90, "RN", "1d1", "1d1", "venerable dragon", 100, 0, 3);
        }

        public void DragonTurtleEncounter()
        {
            GenericEncounter(9500, 5, "RN", "1d1", "1d1", "dragon turtles", "solitary", "solitary");
        }

        public void DragonBlackEncounter()
        {
            Form1.WriteToFile("You have encountered a black dragon encounter!");
            Form1.WriteToFile("A black dragon's breath weapon is a 100' long, 5' wide line of acid.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "green-grey"; break;
                case 2: hide = "midnight green"; break;
                case 3: hide = "black"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonBlueEncounter()
        {
            Form1.WriteToFile("You have encountered a blue dragon encounter!");
            Form1.WriteToFile("A blue dragon's breath weapon is a 100' long, 5' wide line of lightning.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "sky blue"; break;
                case 2: hide = "slate grey"; break;
                case 3: hide = "cloud white"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonBrownEncounter()
        {
            Form1.WriteToFile("You have encountered a brown dragon encounter!");
            Form1.WriteToFile("A brown dragon's breath weapon is a 90' long, 30' wide cone of scouring wind.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "burnt orange"; break;
                case 2: hide = "copper"; break;
                case 3: hide = "sandy brown"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonGreenEncounter()
        {
            Form1.WriteToFile("You have encountered a green dragon encounter!");
            Form1.WriteToFile("A green dragon's breath weapon is a 40' long, 40' wide cloud of poison vapor.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "moss green"; break;
                case 2: hide = "olive"; break;
                case 3: hide = "forest green"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonRedEncounter()
        {
            Form1.WriteToFile("You have encountered a red dragon encounter!");
            Form1.WriteToFile("A red dragon's breath weapon is a 90' long, 30' wide cone of fire.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "flaming red"; break;
                case 2: hide = "burnt orange"; break;
                case 3: hide = "charcoal"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonWyrmEncounter()
        {
            Form1.WriteToFile("You have encountered a wyrm encounter!");
            Form1.WriteToFile("A wyrm's breath weapon is a 40' long, 40' wide cloud of fetid gas.");
            string hide = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: hide = "purple taupe"; break;
                case 2: hide = "liver"; break;
                case 3: hide = "charcoal"; break;
                case 4: hide = "black"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonMetallicEncounter()
        {
            Form1.WriteToFile("You have encountered a metallic dragon encounter!");
            Form1.WriteToFile("A metallic dragon's breath weapon is a 90' long, 30' wide cone of fire.");
            string hide = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: hide = "bronze"; break;
                case 2: hide = "silver"; break;
                case 3: hide = "electrum"; break;
                case 4: hide = "gold"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonSeaEncounter()
        {
            Form1.WriteToFile("You have encountered a sea dragon encounter!");
            Form1.WriteToFile("A sea dragon's breath weapon is a 90' long, 30' wide cloud of blistering steam.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "sea green"; break;
                case 2: hide = "teal"; break;
                case 3: hide = "cerulean blue"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DragonWhiteEncounter()
        {
            Form1.WriteToFile("You have encountered a white dragon encounter!");
            Form1.WriteToFile("A white dragon's breath weapon is a 90' long, 30' wide cloud of freezing vapor.");
            string hide = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: hide = "ivory"; break;
                case 2: hide = "pearl"; break;
                case 3: hide = "snow white"; break;
            }
            Form1.WriteToFile("Its hide is " + hide + ".");
            DragonColorEncounter();
        }

        public void DryadEncounter()
        {
            GenericEncounter(29, 10, "D", "1d6", "1d1", "dryads", "grove", "solitary");
        }

        public void DwarfEncounter()
        {
            xp = 10;
            int companies = 0, squads = 0, temp = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 51)
            {
                //Lair encounter
                companies = rand.Next(1, 11);
                for (int i = 0; i < companies; i++)
                {
                    //Temp is the number of squads in this particular company
                    temp = rand.Next(1, 13);
                    for (int j = 0; j < temp; j++)
                    {
                        //each squad is 1d6 dwarves
                        numAppearing += rand.Next(1, 7);
                        squads++;
                    }
                }
                //Now I know the number of dwarves!
                Form1.WriteToFile("You have encountered a vault of " + numAppearing + " dwarves!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The vault has a total of " + companies + " companies and " + squads + " squads.");
                Form1.WriteToFile("Each company is led by a dwarven vaultguard.  Their levels and possessions follow.");
                for (int i = 0; i < companies; i++)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("A level " + level + " vaultguard leads a company.");
                    Form1.WriteToFile("He has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }
                Form1.WriteToFile("The vault is ruled by a vaultlord, a dwarven vaultguard of 9th level.");
                Form1.WriteToFile("He has the following treasure: ");
                magicTreasure.leaderTreasure(9);
                //temp is now repurposed as the number of elite guards
                temp = rand.Next(1, 7) + rand.Next(1, 7);
                Form1.WriteToFile("The vaultlord has an elite guard of " + temp + " vaultguards.  Their levels and equipment follow.");
                for (int i = 0; i < temp; i++)
                {
                    level = rand.Next(1, 5) + 1;
                    Form1.WriteToFile("A level " + level + " vaultguard, with the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }
                //50% chance of a craftpriest of level 6+1d2
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 3) + 6;
                    Form1.WriteToFile("The vaultlord is advised by a dwarven craftpriest of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //60% chance of trained animals:  50/50 5d4 war dogs or 2d4 brown bears
                roll = rand.Next(1, 101);
                if (roll < 61)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        temp = GenerateNumberInt("5d4");
                        Form1.WriteToFile("The vault is additionally guarded by " + temp + " war dogs.");
                    }
                    else
                    {
                        temp = GenerateNumberInt("2d4");
                        Form1.WriteToFile("The vault is additionally guarded by " + temp + " brown bears.");
                    }
                }
                //adult noncombatants 50% numappearing, young 25% numappearing
                Form1.WriteToFile("The vault contains " + (numAppearing / 2) + " adult noncombatants and " + (numAppearing / 4) + " young.");

                if (Form1.lairGen)
                {
                    for (int i = 0; i < companies; i++)
                    {
                        treasures.Add("D");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    //At least roll their treasure, since they're in lair and have it.
                    Form1.WriteToFile("Their lair contains: ");
                    string tempTreasure = "";
                    for (int i = 0; i < companies; i++)
                    {
                        //treasure.RollTreasure("D");
                        tempTreasure += "D";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //Wilderness encounter
                numAppearing = GenerateNumberInt("1d12*1d6");
                Form1.WriteToFile("You have encountered a company of " + numAppearing + " dwarves!");
                Form1.WriteToFile("They are out in the wilderness.");
                level = rand.Next(1, 5) + 1;
                Form1.WriteToFile("They are led by a dwarven vaultguard of level " + level + ".");
                Form1.WriteToFile("He has the following gear: ");
                magicTreasure.leaderTreasure(level);
            }
        }

        public void EagleEncounter()
        {
            //1-4 normal, 5 or 6 giant
            roll = rand.Next(1, 7);
            if (roll < 5) EagleOrdinaryEncounter();
            else EagleGiantEncounter();
        }

        public void EagleGiantEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //IN LAIR
                GenericEncounter(65, 100, "", "1d3", "1d3", "giant eagles", "aerie", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(65, 0, "", "1d3", "1d3", "giant eagles", "aerie", "flock");
            }
        }

        public void EagleOrdinaryEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //IN LAIR
                GenericEncounter(5, 100, "", "1d6", "1d6", "ordinary eagles", "aerie", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(5, 0, "", "1d6", "1d6", "ordinary eagles", "aerie", "flock");
            }
        }

        public void EfreetiEncounter()
        {
            GenericEncounter(2950, 0, "", "1d1", "1d1", "Efreetis", "solitary", "solitary");
        }

        public void ElementalEncounter()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: ElementalFireEncounter(); break;
                case 2: ElementalWaterEncounter(); break;
                case 3: ElementalEarthEncounter(); break;
                case 4: ElementalFireEncounter(); break;
            }
        }

        public void ElementalFireEncounter()
        {
            GenericEncounter(1100, 0, "", "1d1", "1d1", "fire elementals", "solitary", "solitary");
        }

        public void ElementalWaterEncounter()
        {
            GenericEncounter(1100, 0, "", "1d1", "1d1", "water elementals", "solitary", "solitary");
        }

        public void ElementalEarthEncounter()
        {
            GenericEncounter(1100, 0, "", "1d1", "1d1", "earth elementals", "solitary", "solitary");
        }

        public void ElementalAirEncounter()
        {
            GenericEncounter(1100, 0, "", "1d1", "1d1", "air elementals", "solitary", "solitary");
        }


        public void ElephantEncounter()
        {
            GenericEncounter(700, 0, "", "1d20", "1d20", "elephants", "herd", "herd");
            Form1.WriteToFile("The ivory from their tusks is valuable; the tusks are worth: ");
            for (int i = 0; i < numAppearing*2; i++)
            {
                Form1.WriteToFile((rand.Next(1, 7) * 100) + " gp");
            }
        }

        public void ElfEncounter()
        {
            xp = 15;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            int companies = 0, fellowships = 0, temp = 0, level = 0;
            if (roll < 11)
            {
                //Lair encounter
                companies = rand.Next(1, 11);
                for (int i = 0; i < companies; i++)
                {
                    //1d10 fellowships per company
                    temp = rand.Next(1, 11);
                    for (int j = 0; j < temp; j++)
                    {
                        fellowships++;
                        numAppearing += rand.Next(1, 5);
                    }
                }
                //I now know how many elves I have!
                Form1.WriteToFile("You have encountered a fastness of " + numAppearing + " elves!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The fastness consists of " + companies + " companies and " + fellowships + " fellowships.");
                Form1.WriteToFile("Each company is led by an elven spellsword.  Their levels and gear follow: ");
                for (int i = 0; i < companies; i++)
                {
                    level = rand.Next(1, 7) + 1;
                    Form1.WriteToFile("This company is led by a spellsword of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                Form1.WriteToFile("The fastness is ruled by a wizard-lord, a 9th level elven spellblade.");
                Form1.WriteToFile("The wizard-lord has the following gear: ");
                magicTreasure.leaderTreasure(9);
                temp = rand.Next(1, 7) + rand.Next(1, 7);
                Form1.WriteToFile("The wizard-lord is guarded by an elite guard of " + temp + " spellswords of varying levels, below: ");
                for (int i = 0; i < temp; i++)
                {
                    level = rand.Next(1, 7) + 1;
                    Form1.WriteToFile("A spellsword of level " + level + " with the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //50% chance of an elven nightblade, level 1d2+6
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 3) + 6;
                    Form1.WriteToFile("The wizard-lord is served by an elven nightblade of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //70% chance the fastness is protected by 2d6 giant hawk
                roll = rand.Next(1, 101);
                if (roll < 71)
                {
                    Form1.WriteToFile("The fastness is additionally protected by " + (rand.Next(1, 7) + rand.Next(1, 7)) + " trained giant hawks.");
                }
                //adult noncombatants equal to able-bodied adults, young equal to 5%
                Form1.WriteToFile("The fastness contains " + numAppearing + " adult noncombatants and " + (numAppearing / 20) + " young.");

                if (Form1.lairGen)
                {
                    //generate lair
                    for (int i = 0; i < companies; i++)
                    {
                        treasures.Add("E");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    //roll treasure
                    string tempTreasure = "";
                    for (int i = 0; i < companies; i++)
                    {
                        //treasure.RollTreasure("E");
                        tempTreasure += "E";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //Wilderness encounter
                fellowships = rand.Next(1, 11);
                for (int i = 0; i < fellowships; i++)
                {
                    numAppearing += rand.Next(1, 5);
                }
                Form1.WriteToFile("You have encountered a company of " + numAppearing + " elves!");
                Form1.WriteToFile("They are out in the wilderness.");
                level = rand.Next(1, 7);
                Form1.WriteToFile("They are led by an elven spellsword of level " + level + ".");
                Form1.WriteToFile("He has the following gear: ");
                magicTreasure.leaderTreasure(level);


            }
        }

        public void EttinEncounter()
        {
            GenericEncounter(850, 20, "NH", "1d4", "1d4", "ettins", "lair", "warband");
        }

        public void FerretGiantEncounter()
        {
            GenericEncounter(15, 25, "A", "1d12", "1d8", "giant ferrets", "den", "fesnying");
        }

        public void FighterEncounter()
        {
            NPCEncounter("Fighter");
        }

        public void FishCatfishEncounter()
        {
            GenericEncounter(600, 0, "", "1d2", "1d2", "giant catfishs", "school", "school");
        }

        public void FishPiranhaEncounter()
        {
            GenericEncounter(65, 0, "", "2d4", "2d4", "giant piranha", "pack", "pack");
        }

        public void FishSturgeonEncounter()
        {
            GenericEncounter(1550, 0, "I", "1d1", "1d1", "giant sturgeons", "solitary", "solitary");
            Form1.WriteToFile("The sturgeon's belly contains: ");
            treasure.RollTreasure("I");
        }

        public void FlyGiantCarnivorousEncounter()
        {
            GenericEncounter(20, 35, "C", "2d6", "2d6", "giant carnivorous flies", "nest", "swarm");
        }

        public void GargoyleEncounter()
        {
            GenericEncounter(135, 20, "H", "2d4", "2d4", "gargoyles", "lair", "wing");
        }

        public void GelatinousCubeEncounter()
        {
            GenericEncounter(135, 0, "C", "1d1", "1d1", "gelatinous cubes", "solitary", "solitary");
            Form1.WriteToFile("Its gelatinous body contains: ");
            treasure.RollTreasure("C");
        }

        public void GhoulEncounter()
        {
            GenericEncounter(29, 20, "D", "2d8", "2d8", "ghouls", "lair", "horde");
        }

        public void GiantCloudEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //IN LAIR
                GenericEncounter(1200, 100, "N", "1d3", "1d3", "cloud giants", "lair", "warband");
                Form1.WriteToFile("If their lair is in the clouds, they are guarded by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " giant hawks.");
                Form1.WriteToFile("If their lair is on the ground, they are guarded by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " dire wolves.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(1200, 0, "N", "1d3", "1d3", "cloud giants", "lair", "warband");
            }
            for (int i = 0; i < numAppearing; i++)
                {
                    roll = rand.Next(1, 101);
                    if (roll < 6) Form1.WriteToFile("One of the cloud giants has mage abilities of level " + (rand.Next(1, 5) + rand.Next(1, 5)) + ".");
                }
        }

        public void GiantFireEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 36)
            {
                //IN LAIR
                GenericEncounter(1000, 100, "N", "1d3", "1d3", "fire giants", "lair", "warband");
                roll = rand.Next(1, 11);
                if (roll < 9) Form1.WriteToFile("Their lair is also guarded by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " hellhounds.");
                else Form1.WriteToFile("Their lair is also guarded by " + rand.Next(1, 3) + " hydras.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(1000, 0, "N", "1d3", "1d3", "fire giants", "lair", "warband");
            }
        }

        public void GiantFrostEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 31)
            {
                //IN LAIR
                GenericEncounter(850, 100, "N", "1d6", "1d4", "frost giants", "lair", "warband");
                roll = rand.Next(1, 11);
                if (roll < 9) Form1.WriteToFile("Their lair is also guarded by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " dire wolves.");
                else Form1.WriteToFile("Their lair is also guarded by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " polar bears.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(850, 0, "N", "1d6", "1d4", "frost giants", "lair", "warband");
            }
        }

        public void GiantHillEncounter()
        {
            GenericEncounter(600, 25, "N", "2d4", "2d4", "hill giants", "lair", "warband");
        }

        public void GiantStoneEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 26)
            {
                //IN LAIR
                GenericEncounter(700, 100, "N", "1d6", "1d6", "stone giants", "lair", "warband");
                roll = rand.Next(1, 101);
                if (roll < 51)
                    Form1.WriteToFile("Their lair is also guarded by " + rand.Next(1, 5) + " cave bears.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(700, 0, "N", "1d6", "1d6", "stone giants", "lair", "warband");
            }
        }

        public void GiantStormEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 46)
            {
                //IN LAIR
                GenericEncounter(1800, 100, "NH", "1d3", "1d3", "storm giants", "lair", "warband");
                Form1.WriteToFile("If their lair is above water, they are guarded by " + (rand.Next(1, 5) + rand.Next(1, 5)) + " griffons.");
                Form1.WriteToFile("If their lair is under water, they are guarded by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " giant crabs.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(1800, 0, "NH", "1d3", "1d3", "storm giants", "lair", "warband");
            }
            for (int i = 0; i < numAppearing; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 11) Form1.WriteToFile("One of the storm giants has mage abilities of level " + (rand.Next(1, 5) + rand.Next(1, 5)) + ".");
            }
        }

        public void GnollEncounter()
        {
            xp = 20;
            int warbands = 0, gangs = 0, temp = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    temp = rand.Next(1, 7);
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += rand.Next(1, 7);
                    }
                }
                //I know how many gnolls we have
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " gnolls!");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                //females 50% numappearing, young 200%
                Form1.WriteToFile("The village contains " + (numAppearing / 2) + " females and " + (numAppearing * 2) + " young.");
                //1 prisoner for every 10 gnolls
                Form1.WriteToFile("The village has a total of " + (numAppearing/10) + " prisoners taken.");
                //33% chance of 3 trolls
                roll = rand.Next(1, 101);
                if (roll < 34)
                {
                    Form1.WriteToFile("The village is additionally guarded by 3 gnolls.");
                }
                //66% chance of 4d4 hyenas
                roll = rand.Next(1, 101);
                if (roll < 67)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + GenerateNumberInt("4d4") + " trained hyenas.");
                }
                //60% chance of shaman
                roll = rand.Next(1, 101);
                if (roll < 61)
                {
                    level = rand.Next(1, 5) + 1;
                    Form1.WriteToFile("The village contains a shaman with sub-chieftain stats and clerical abilities at level " + level + ".");
                }
                //50% chance of witch doctor
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village contains a witch doctor with champion stats and mage abilities at level " + level + ".");
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("G");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    //roll treasure anyway
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("G");
                        tempTreasure += "G";
                    }
                    treasure.RollTreasure(tempTreasure);
                }

            }
            else
            {
                //wilderness encounter
                gangs = rand.Next(1, 7);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += rand.Next(1, 7);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " bugbears!");
                Form1.WriteToFile("The warband is made of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
            }
        }

        public void GnomeEncounter()
        {
            xp = 10;
            int companies = 0, squads = 0, temp = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 51)
            {
                //lair encounter
                companies = rand.Next(1, 11);
                for (int i = 0; i < companies; i++)
                {
                    temp = rand.Next(1, 11);
                    for (int j = 0; j < temp; j++)
                    {
                        squads++;
                        numAppearing += rand.Next(1, 9);
                    }
                }
                //I now know how many gnomes I have!
                Form1.WriteToFile("You have encountered a vault of " + numAppearing + " gnomes!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The vault consists of " + companies + " companies and " + squads + " squads.");
                Form1.WriteToFile("Each squad has a leader with increased stats.");
                Form1.WriteToFile("Each company has a sub-chieftain with increased stats.");
                Form1.WriteToFile("The vault is led by a grand chief with increased stats.");
                Form1.WriteToFile("The grand chief has " + rand.Next(1, 7) + " bodyguards, who have stats as a sub-chieftain.");
                Form1.WriteToFile("The vault has " + (numAppearing / 2) + " adult noncombatants and " + (numAppearing / 4) + " young.");
                if (Form1.lairGen)
                {
                    for (int i = 0; i < companies; i++)
                    {
                        treasures.Add("D");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    string tempTreasure = "";
                    for (int i = 0; i < companies; i++)
                    {
                        //treasure.RollTreasure("D");
                        tempTreasure += "D";
                    }
                    treasure.RollTreasure(tempTreasure);
                }

            }
            else
            {
                //wilderness encounter
                squads = rand.Next(1, 11);
                for (int i = 0; i < squads; i++)
                {
                    numAppearing += rand.Next(1, 9);
                }
                Form1.WriteToFile("You have encountered a company of " + numAppearing + " gnomes!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The company is made up of " + squads + " squads.");
                Form1.WriteToFile("Each squad has a leader with increased stats.");
                Form1.WriteToFile("The company is led by a sub-chieftain with increased stats.");
            }
        }

        public void GoblinEncounter()
        {
            xp = 5;
            int warbands = 0, gangs = 0, temp = 0, level = 0, wolfgangs = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    //each warband has a 20% chance to have 1/4 of its gangs mounted on dire wolves
                    temp = rand.Next(1, 7) + rand.Next(1, 7);
                    roll = rand.Next(1, 101);
                    if (roll < 21)
                    {
                        wolfgangs += (temp / 4);
                    }
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        roll = rand.Next(1, 101);
                        numAppearing += rand.Next(1, 5) + rand.Next(1, 5);
                    }
                }
                //I know how many goblins are appearing now
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " goblins!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                //sanity check
                if (wolfgangs > 0 && wolfgangs < gangs)
                {
                    Form1.WriteToFile(wolfgangs + " gangs are mounted on dire wolves.");
                }
                //if any gang is mounted, its champion is mounted; if any gangs are mounted, the warband leader is mounted; if anyone is mounted, the chieftain is
                Form1.WriteToFile("Each gang is led by a champion with increased stats.  If the gang is mounted, the champion is mounted.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.  If any gangs within a warband are mounted, the sub-chieftain is mounted");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.  If any goblins in the village are mounted, the chieftain is mounted.");
                Form1.WriteToFile("The village contains " + (numAppearing * .6) + " females and " + numAppearing + " young.");
                //60% chance of 5d6 dire wolves
                roll = rand.Next(1, 101);
                if (roll < 61)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + GenerateNumberInt("5d6") + " dire wolves.");
                }
                //20% chance of 2d6 bugbear mercenaries
                roll = rand.Next(1, 101);
                if (roll < 21)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + GenerateNumberInt("2d6") + " bugbear mercenaries.");
                }
                //75% chance of shaman
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    level = GenerateNumberInt("2d4");
                    Form1.WriteToFile("The village contains a shaman, with sub-chieftain stats and clerical abilities at level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //50% chance of witch doctor
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = GenerateNumberInt("1d6");
                    Form1.WriteToFile("The village contains a witch doctor, with champion stats and mage abilities at level " + level + ".");
                    Form1.WriteToFile("He has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("E");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("E");
                        tempTreasure += "E";
                    }
                    treasure.RollTreasure(tempTreasure);
                }

            }
            else
            {
                //wilderness encounter
                //each gang has a 5% chance to be mounted on dire wolves
                gangs = GenerateNumberInt("2d6");
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += rand.Next(1, 5) + rand.Next(1, 5);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " goblins!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                for (int i = 0; i < gangs; i++)
                {
                    roll = rand.Next(1, 101);
                    if (roll < 6) wolfgangs++;
                }
                Form1.WriteToFile("Each gang is led by a champion.  If the gang is mounted, the champion is also mounted.");
                if (wolfgangs > 0) Form1.WriteToFile(wolfgangs + " gangs are mounted on dire wolves.");
                Form1.WriteToFile("The warband is led by a sub-chieftain.  If any gangs are mounted, the sub-chieftain is also mounted.");
            }
        }

        public void GolemEncounter()
        {
            //Randomly determine which kind of golem it is
            //1-4 wood, 5-7 bone, 8-9 amber, 10 bronze
            roll = rand.Next(1, 11);
            if (roll < 5) GolemWoodEncounter();
            else if (roll < 8) GolemBoneEncounter();
            else if (roll < 10) GolemAmberEncounter();
            else GolemBronzeEncounter();
        }

        public void GolemAmberEncounter()
        {
            GenericEncounter(1550, 0, "", "1d1", "1d1", "amber golems", "solitary", "solitary");
        }

        public void GolemBoneEncounter()
        {
            GenericEncounter(1100, 0, "", "1d1", "1d1", "bone golems", "solitary", "solitary");
        }

        public void GolemBronzeEncounter()
        {
            GenericEncounter(4600, 0, "", "1d1", "1d1", "bronze golems", "solitary", "solitary");
        }

        public void GolemWoodEncounter()
        {
            GenericEncounter(47, 0, "", "1d1", "1d1", "wood golems", "solitary", "solitary");
        }

        public void GorgonEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //IN LAIR
                GenericEncounter(1600, 100, "K", "1d4", "1d4", "gorgons", "den", "gang");
                Form1.WriteToFile("Any treasure in the gorgons' lair is on the bodies of petrified victims, and is only accessible if they are returned to flesh.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(1600, 0, "K", "1d4", "1d4", "gorgons", "den", "gang");
            }
        }

        public void GrayOozeEncounter()
        {
            GenericEncounter(65, 0, "", "1d1", "1d1", "gray oozes", "solitary", "solitary");
        }

        public void GreenSlimeEncounter()
        {
            GenericEncounter(38, 0, "", "1d1", "1d1", "green slimes", "solitary", "solitary");
        }

        public void GriffonEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 26)
            {
                //IN LAIR
                GenericEncounter(440, 100, "P", "2d8", "2d8", "griffons", "aerie", "pride");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    //EGGS OR YOUNG
                    roll = rand.Next(1, 3);
                    if (roll == 1) Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                }
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(440, 0, "P", "2d8", "2d8", "griffons", "aerie", "pride");
            }
        }

        public void HalflingEncounter()
        {
            xp = 5;
            int meets = 0, bands = 0, temp = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 91)
            {
                //lair encounter
                meets = rand.Next(1, 11);
                for (int i = 0; i < meets; i++)
                {
                    //1d4 bands per meet
                    temp = rand.Next(1, 5);
                    for (int j = 0; j < temp; j++)
                    {
                        bands++;
                        numAppearing += GenerateNumberInt("3d6");
                    }
                }
                //I now know the number of halflings
                Form1.WriteToFile("You have encountered a shire of " + numAppearing + " halflings!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The shire consists of " + meets + " meets and " + bands + " bands.");
                Form1.WriteToFile("Each band is led by a reeve with 2 hit dice.");
                Form1.WriteToFile("The shire is led by a sherrif with " + (rand.Next(1, 7) + 1) + " hit dice.");
                Form1.WriteToFile("The shire is defended by a militia of " + GenerateNumberInt("5d4") + " halflings with 2 hit dice.");
                Form1.WriteToFile("The shire also has " + numAppearing + " adult noncombatants and " + (numAppearing * 2) + " young.");

                if (Form1.lairGen)
                {
                    for (int i = 0; i < meets; i++)
                    {
                        treasures.Add("D");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    string tempTreasure = "";
                    for (int i = 0; i < meets; i++)
                    {
                        //treasure.RollTreasure("D");
                        tempTreasure += "D";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //wilderness encounter
                bands = rand.Next(1, 5);
                for (int i = 0; i < bands; i++)
                {
                    numAppearing += GenerateNumberInt("3d6");
                }
                Form1.WriteToFile("You have encountered a meet of " + numAppearing + " halflings!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The meet consists of " + bands + " bands.");
                Form1.WriteToFile("Each band is led by a reeve with two hit dice.");
            }
        }

        public void HarpyEncounter()
        {
            GenericEncounter(65, 25, "E", "2d4", "2d4", "harpies", "nest", "wing");
        }

        public void HawkEncounter()
        {
            //1-4 normal, 5-6 giant
            roll = rand.Next(1, 7);
            if (roll < 5) HawkOrdinaryEncounter();
            else HawkGiantEncounter();
        }

        public void HawkOrdinaryEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //IN LAIR
                GenericEncounter(5, 100, "", "1d6", "1d6", "ordinary hawks", "aerie", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(5, 0, "", "1d6", "1d6", "ordinary hawks", "aerie", "flock");
            }
        }

        public void HawkGiantEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //IN LAIR
                GenericEncounter(65, 100, "", "1d3", "1d3", "giant hawks", "aerie", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(65, 0, "", "1d3", "1d3", "giant hawks", "aerie", "flock");
            }
        }

        public void HellhoundEncounter()
        {
            //Randomly determine kind of hellhound
            //1-5 lesser, 6 greater
            roll = rand.Next(1, 7);
            if (roll == 6) HellhoundGreaterEncounter();
            else HellhoundLesserEncounter();
        }

        public void HellhoundLesserEncounter()
        {
            GenericEncounter(65, 30, "F", "2d4", "2d4", "lesser hellhounds", "den", "pack");
        }

        public void HellhoundGreaterEncounter()
        {
            GenericEncounter(790, 30, "P", "2d4", "2d4", "greater hellhounds", "den", "pack");
        }

        public void HerdAnimalAntelopeEncounter()
        {
            roll = rand.Next(1, 3);
            if (roll == 1) GenericEncounter(10, 0, "", "3d10", "3d10", "1 HD antelopes", "herd", "herd");
            else GenericEncounter(20, 0, "", "3d10", "3d10", "2 HD antelopes", "herd", "herd");
        }

        public void HerdAnimalGoatEncounter()
        {
            roll = rand.Next(1, 3);
            if (roll == 1) GenericEncounter(10, 0, "", "3d10", "3d10", "1 HD goats", "herd", "herd");
            else GenericEncounter(20, 0, "", "3d10", "3d10", "2 HD goats", "herd", "herd");
            Form1.WriteToFile("There are " + (numAppearing * 4) + " females and young in the herd.");
        }

        public void HerdAnimalSheepEncounter()
        {
            roll = rand.Next(1, 3);
            if (roll == 1) GenericEncounter(10, 0, "", "3d10", "3d10", "1 HD sheep", "herd", "herd");
            else GenericEncounter(20, 0, "", "3d10", "3d10", "2 HD sheep", "herd", "herd");
            Form1.WriteToFile("There are " + (numAppearing * 4) + " females and young in the herd.");
        }

        public void HippogriffEncounter()
        {
            GenericEncounter(65, 10, "F", "2d8", "2d8", "hippogriffs", "aerie", "herd");
        }

        public void HobgoblinEncounter()
        {
            xp = 15;
            int warbands = 0, gangs = 0, temp = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 26)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    temp = rand.Next(1, 9);
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += rand.Next(1, 7);
                    }
                }
                //I now know the number of hobgoblins appearing
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " hobgoblins!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                Form1.WriteToFile("The village also has " + (numAppearing * 1.5) + " females and " + (numAppearing * 3) + " young.");
                //60% chance of 2d6 trained albino apes
                roll = rand.Next(1, 101);
                if (roll < 61)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + GenerateNumberInt("2d6") + " trained albino apes.");
                }
                //90% chance of shaman - cleric 1d8
                roll = rand.Next(1, 101);
                if (roll < 91)
                {
                    level = rand.Next(1, 9);
                    Form1.WriteToFile("The village has a shaman with clerical abilities of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //75% chance of witch doctor - mage 1d6
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("The village has a witch doctor with mage abilities of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                if (Form1.lairGen)
                {
                    //generate random lair
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("E");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    //roll their treasure
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("E");
                        tempTreasure += "E";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //out of lair
                gangs = rand.Next(1, 9);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += rand.Next(1, 7);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " hobgoblins!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
            }
        }

        public void HorseLightEncounter()
        {
            GenericEncounter(20, 0, "", "1d10*10d1", "1d10*10d1", "light horses", "herd", "herd");
        }

        public void HorseMediumEncounter()
        {
            GenericEncounter(50, 0, "", "1d10*10d1", "1d10*10d1", "medium horses", "herd", "herd");
        }

        public void HorseHeavyEncounter()
        {
            GenericEncounter(65, 0, "", "1d10*10d1", "1d10*10d1", "heavy horses", "herd", "herd");
        }

        public void HydraEncounter()
        {
            HydraGenericEncounter("hydra");
        }

        public void HydraSeaEncounter()
        {
            HydraGenericEncounter("sea hydra");
        }

        public void HydraGenericEncounter(string type)
        {
            //Between 5 and 12 hit dice, plus one special ability
            //want to make the lower tiers more likely: use 2 or more dice, perhaps with a penalty to the roll
            //7d2 - 2 = 5 to 12
            int hd = GenerateNumberInt("7d2-2");
            int xp = 0;
            int special = 0;
            string name = "", treasureType = "";
            roll = rand.Next(1, 101);
            if (roll < 11)
            {
                name = "HD regenerating" + type;
                special = 2;
            }
            else
            {
                name = "HD " + type;
                special = 1;
            }
            name = hd + " " + name;
            /*
             * XP values by HD, special ability value
             * 5: 200, 150
             * 6: 320, 250
             * 7: 440, 350
             * 8: 600, 500
             * 9: 700, 600
             * 10: 850, 700
             * 11: 1000, 800
             * 12: 1200, 900
             * */
            switch (hd)
            {
                case 5:
                    xp = 200 + 150 * special;
                    treasureType = "I";
                    break;
                case 6:
                    xp = 320 + 250 * special;
                    treasureType = "I";
                    break;
                case 7:
                    xp = 440 + 350 * special;
                    treasureType = "I";
                    break;
                case 8:
                    xp = 600 + 500 * special;
                    treasureType = "K";
                    break;
                case 9:
                    xp = 700 + 600 * special;
                    treasureType = "K";
                    break;
                case 10:
                    xp = 850 + 700 * special;
                    treasureType = "M";
                    break;
                case 11:
                    xp = 1000 + 800 * special;
                    treasureType = "M";
                    break;
                case 12:
                    xp = 1200 + 900 * special;
                    treasureType = "M";
                    break;
            }
            Form1.WriteToFile("You have encountered a " + type + "!");
            Form1.WriteToFile("Your " + type + "'s XP value is " + xp + ".");
            GenericEncounter(xp, 20, treasureType, "1d1", "1d1", name, "nest", "solitary");
        }

        public void InsectSwarmEncounter()
        {
            roll = rand.Next(1, 4) + 1;
            if (roll == 2)
            {
                GenericEncounter(29, 25, "", "1d3", "1d3", "2 HD insect swarms", "nest", "plague");
            }
            else if (roll == 3)
            {
                GenericEncounter(65, 25, "", "1d3", "1d3", "3 HD insect swarms", "nest", "plague");
            }
            else if (roll == 4)
            {
                GenericEncounter(135, 25, "", "1d3", "1d3", "4 HD insect swarms", "nest", "plague");
            }
        }

        public void InvisibleStalkerEncounter()
        {
            GenericEncounter(1100, 0, "", "1d1", "1d1", "invisible stalkers", "solitary", "solitary");
        }

        public void KoboldEncounter()
        {
            xp = 5;
            int warbands = 0, gangs = 0, temp = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    temp = rand.Next(1, 7);
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += GenerateNumberInt("4d4");
                    }
                }
                //I now know how many kobolds are appearing
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " kobolds!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                Form1.WriteToFile("The chieftain is defended by " + GenerateNumberInt("5d4") + " guards, equivalent to sub-chieftains statistically.");
                //kennel of trained beasts:  70% 1d4+1 boars, 30% 1d4 giant weasels
                roll = rand.Next(1, 101);
                if (roll < 71)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + (rand.Next(1, 5) + 1) + " boars.");
                }
                else
                {
                    Form1.WriteToFile("The village is additionally guarded by " + (rand.Next(1, 5)) + " giant weasels.");
                }
                //75% chance of shaman - cleric 1d6
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("The village also contains a shaman with clerical abilities of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //50% chance of witch doctor - mage 1d4
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village also contains a witch doctor with mage abilities of level " + level + ".");
                    Form1.WriteToFile("He has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //lair generation code goes here
                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("E");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("E");
                        tempTreasure += "E";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //wilderness encounter
                gangs = rand.Next(1, 7);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += GenerateNumberInt("4d4");
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " kobolds!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
            }
        }

        public void LamiaEncounter()
        {
            GenericEncounter(2500, 40, "N", "1d1", "1d1", "lamias", "lair", "solitary");
        }

        public void LammasuEncounter()
        {
            GenericEncounter(1900, 30, "R", "2d4", "2d4", "lammasu", "lair", "flight");
        }

        public void LeechGiantEncounter()
        {
            GenericEncounter(570, 0, "", "1d4", "1d4", "giant leeches", "brood", "brood");
        }

        public void LizardDracoEncounter()
        {
            GenericEncounter(140, 25, "", "1d6", "1d3", "giant draco lizards", "lair", "lounge");
        }

        public void LizardGeckoEncounter()
        {
            GenericEncounter(65, 25, "", "1d10", "1d6", "giant geckos", "lair", "lounge");
        }

        public void LizardHornedEncounter()
        {
            GenericEncounter(350, 25, "", "1d6", "1d3", "giant horned chameleons", "lair", "lounge");
        }

        public void LizardTuataraEncounter()
        {
            GenericEncounter(320, 25, "", "1d4", "1d2", "giant tuatara lizards", "lair", "lounge");
        }

        public void LizardmanEncounter()
        {
            xp = 35;
            int warbands = 0, gangs = 0, level = 0, temp = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 31)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    //temp is the number of gangs in this particular warband
                    temp = rand.Next(1, 9);
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += GenerateNumberInt("2d4");
                    }
                }
                //I now know the total number of lizardmen
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " lizardmen!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a chieftain with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                //d4*10 females and d4*20 eggs per 20 lizardmen
                int females = 0, eggs = 0;
                for (int i = 0; i < numAppearing / 20; i++)
                {
                    females += (rand.Next(1, 5) * 10);
                    eggs += (rand.Next(1, 5) * 20);
                }
                Form1.WriteToFile("There are " + females + " female lizardmen and " + eggs + " eggs.");
                //75% chance of shaman, cleric 1d6 + sub-chieftain
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("The village contains a shaman, with sub-chieftain stats and clerical abilities of level " + level + ".");
                    Form1.WriteToFile("The shaman has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }
                //50% chance of witch doctor, mage 1d4 + champion
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village contains a witch doctor, with champion stats and mage abilities of level " + level + ".");
                    Form1.WriteToFile("The witch doctor has the following treasure: ");
                    magicTreasure.leaderTreasure(level);
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("L");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following treasure: ");
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                       // treasure.RollTreasure("L");
                        tempTreasure += "L";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else 
            {
                //wilderness encounter
                gangs = rand.Next(1, 9);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += GenerateNumberInt("2d4");
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " lizardmen!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
            }
        }

        public void LocustCavernEncounter()
        {
            GenericEncounter(29, 30, "", "2d10", "1d10", "cavern locusts", "nest", "plague");
        }

        public void LycanthropeEncounter()
        {
            //Pick a random lycanthrope
            /*
             * Werebear 10
             * Wereboar 9
             * Wererat 1-3
             * Weretiger 7-8
             * Werewolf 4-6
             * */
            roll = rand.Next(1, 11);
            if (roll < 4) WereratEncounter();
            else if (roll < 7) WerewolfEncounter();
            else if (roll < 9) WeretigerEncounter();
            else if (roll < 10) WereboarEncounter();
            else WerebearEncounter();
        }

        public void MageEncounter()
        {
            NPCEncounter("Mage");
        }

        public void ManticoreEncounter()
        {
            GenericEncounter(680, 20, "K", "1d4", "1d4", "manticores", "lair", "wing");
        }

        public void MediumEncounter()
        {
            //Medium is a level title for one of the player's companion classes: Warlock
            NPCEncounter("Warlock");
        }

        public void MastodonEncounter()
        {
            GenericEncounter(1800, 0, "", "2d8", "2d8", "mastodons", "herd", "herd");
            Form1.WriteToFile("The ivory from their tusks is valuable.  Each tusk is worth 2d4*100 gp.");
            for (int i = 0; i < numAppearing*2; i++)
            {
                Form1.WriteToFile(((rand.Next(1, 5)+ rand.Next(1, 5)) * 100) + " gp");
            }
        }

        public void MedusaEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 51)
            {
                //IN LAIR
                GenericEncounter(245, 100, "H", "1d4", "1d4", "medusas", "lair", "coven");
                Form1.WriteToFile("Half of the treasure found in the medusas' lair is on petrified victims and is only accessible if they are returned to flesh.");
            }
            else
            {
                //NOT IN LAIR
                GenericEncounter(245, 0, "H", "1d4", "1d4", "medusas", "lair", "coven");
            }
        }

        public void MerchantEncounter()
        {
            //Wilderness encounter    
            //One caravan: d4x10 wagons
            roll = rand.Next(1, 5);
            numAppearing = (roll * 10);
            Form1.WriteToFile("You have encountered a caravan of " + numAppearing + " wagons of merchants!");
            Form1.WriteToFile("Each wagon is drawn by four draft horses.");
            Form1.WriteToFile("There are a total of " + roll * 5 + " merchants traveling with the wagons.");
            Form1.WriteToFile("There are a total of " + 20 * roll + " 1st-level fighter guards riding medium horses.");
            for (int i = 0; i < roll; i++)
            {
                Form1.WriteToFile("There are 2 3rd level fighters acting as guard lieutenants for each troop of 20 guards.");
                Form1.WriteToFile("They have as loot: ");
                magicTreasure.leaderTreasure(3);
                magicTreasure.leaderTreasure(3);
            }
            Form1.WriteToFile("The guards are led by a guard captain of 5th level.");
            magicTreasure.leaderTreasure(5);
            Form1.WriteToFile("They are out in the wilderness.");
            Form1.WriteToFile("Their caravans contain: ");
            string tempTreasure = "";
            for (int i = 0; i < roll; i++)
            {
                //treasure.RollTreasure("J");
                tempTreasure += "J";
            }
            treasure.RollTreasure(tempTreasure);
            Form1.WriteToFile("");
        }

        public void MermanEncounter()
        {
            xp = 10;
            int bands = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 26)
            {
                //lair encounter
                bands = rand.Next(1, 21) + rand.Next(1, 21);
                for (int i = 0; i < bands; i++)
                {
                    numAppearing += rand.Next(1, 21);
                }
                //I now know the number of mermen
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " mermen!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + bands + " bands.");
                Form1.WriteToFile("Each band is led by a leader with 2 hit dice.");
                Form1.WriteToFile("The village is led by an exceptional leader with 4 hit dice.");
                //70% chance of 3d6 giant fish, let's go with rockfish to make more sense with the rest of the entry
                roll = rand.Next(1, 101);
                if (roll < 71)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + GenerateNumberInt("3d6") + " giant rockfish.");
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < bands; i++)
                    {
                        treasures.Add("B");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following treasure: ");
                    string tempTreasure = "";
                    for (int i = 0; i < bands; i++)
                    {
                        //treasure.RollTreasure("B");
                        tempTreasure += "B";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //wilderness encounter
                numAppearing = rand.Next(1, 21);
                Form1.WriteToFile("You have encountered a band of " + numAppearing + " mermen!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The band is led by a leader with 2 hit dice.");
            }
        }

        public void MinotaurEncounter()
        {
            GenericEncounter(320, 20, "LG", "1d8", "1d8", "minotaurs", "lair", "warband");
        }

        public void MonkeyEncounter()
        {
            Form1.WriteToFile("I found no stats for monkeys!  Monkey around with it!");
        }

        public void MorlockEncounter()
        {
            xp = 10;
            int gangs = 0;
            //1 warband shows up in either case, so I can roll num appearing before checking for lair
            gangs = rand.Next(1, 9);
            for (int i = 0; i < gangs; i++)
            {
                numAppearing += rand.Next(1, 13);
            }
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 36)
            {
                //lair encounter
                Form1.WriteToFile("You have encountered a lair of " + numAppearing + " morlocks!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The lair consists of a single warband and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The lair is led by a chieftain with increased stats.");
                //75% chance of 3d6 trained white apes
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    Form1.WriteToFile("The lair is additionally guarded by " + GenerateNumberInt("3d6") + " trained white apes.");
                }
                //100% females, 200% young
                Form1.WriteToFile("The lair contains " + numAppearing + " female morlocks and " + numAppearing * 2 + " young.");

                if (Form1.lairGen)
                {
                    treasures.Add("E");
                    Form1.GenerateLair(this);
                }
                else
                {
                    treasure.RollTreasure("E");
                }
            }
            else
            {
                //wilderness encounter
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " morlocks!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
            }

        }

        public void MuleEncounter()
        {
            GenericEncounter(20, 0, "", "2d6", "2d6", "mules", "herd", "herd");
        }

        public void MummyEncounter()
        {
            GenericEncounter(460, 20, "NN", "1d12", "1d12", "mummies", "tomb", "horde");
        }

        public void NaiadEncounter()
        {
            GenericEncounter(13, 95, "D", "2d20", "1d1", "naiads", "watery lair", "solitary");
        }

        public void NeanderthalEncounter()
        {
            xp = 20;
            int bands = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //lair encounter
                bands = rand.Next(1, 7);
                for (int i = 0; i < bands; i++)
                {
                    numAppearing += rand.Next(1, 11);
                }

                Form1.WriteToFile("You have encountered a lair of " + numAppearing + " neanderthals!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The lair consists of " + bands + " bands.");
                Form1.WriteToFile("Each band is led by a champion with increased stats.");
                Form1.WriteToFile("The lair is led by a chieftain with increased stats.");
                //75% chance of 3d6 trained white apes
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    Form1.WriteToFile("The lair is additionally guarded by " + GenerateNumberInt("3d6") + " trained white apes.");
                }
                Form1.WriteToFile("The lair has " + numAppearing + " women and " + numAppearing * 2 + " children.");

                if (Form1.lairGen)
                {
                    treasures.Add("E");
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following treasure: ");
                    treasure.RollTreasure("E");
                }
            }
            else
            {
                //wilderness encounter
                numAppearing += rand.Next(1, 11);
                Form1.WriteToFile("You have encountered a band of " + numAppearing + " neanderthals!");
                Form1.WriteToFile("The band is led by a champion with increased stats.");
            }
        }

        public void NobleEncounter()
        {
            Form1.WriteToFile("You have encountered nobles!");
            Form1.WriteToFile("I can't find what the noble encounter looks like in ACKS!");
            Form1.WriteToFile("");
        }
        public void NomadEncounter()
        {
            xp = 10;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //LAIR ENCOUNTER
                int caravans = rand.Next(1, 7) + rand.Next(1, 7);
                bool cleric = false;
                bool mage = false;
                roll = rand.Next(1, 101);
                if (roll < 51) cleric = true;
                roll = rand.Next(1, 101);
                if (roll < 31) mage = true;
                for (int i = 0; i < caravans; i++)
                {
                    numAppearing += (rand.Next(1, 5) * 10);
                }
                Form1.WriteToFile("You have encountered a camp of " + numAppearing + " nomads, made up of " + caravans + " caravans.");
                double leather, chain, lamellar, lances, bows;
                leather = Math.Truncate(numAppearing * .5);
                chain = Math.Truncate(numAppearing * .3);
                lamellar = numAppearing - (leather + chain);
                Form1.WriteToFile(leather + " wear leather, " + chain + " wear chain, and " + lamellar + " wear lamellar.");
                lances = Math.Truncate(numAppearing * .5);
                bows = numAppearing - lances;
                Form1.WriteToFile(lances + " are armed with lances on light warhorses.  " + bows + " are armed with composite bows on light riding horses.");
                for (int i = 0; i < caravans; i++)
                {
                    Form1.WriteToFile("This caravan is led by a 4th level fighter with this loot: ");
                    magicTreasure.leaderTreasure(4);
                    Form1.WriteToFile("And two 2nd level fighters with this loot: ");
                    magicTreasure.leaderTreasure(2);
                    magicTreasure.leaderTreasure(2);
                }
                Form1.WriteToFile("The camp is ruled by a chieftain, an 8th level fighter, with the following items: ");
                magicTreasure.leaderTreasure(8);
                if (cleric)
                {
                    Form1.WriteToFile("The camp has a cleric of 9th level with the following items: ");
                    magicTreasure.leaderTreasure(9);
                }
                if (mage)
                {
                    Form1.WriteToFile("The camp has a mage of 8th level with the following items: ");
                    magicTreasure.leaderTreasure(8);
                }
                roll = rand.Next(1, 101);
                if (roll < 71) Form1.WriteToFile("The camp is protected by " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " trained hunting dogs.");
                Form1.WriteToFile("The camp has " + numAppearing + " adult noncombatants and " + numAppearing * 2 + " young nomads.");
                //Check if a random lair should be generated
                if (Form1.lairGen)
                {
                    //Generate a random lair
                    for (int i = 0; i < caravans; i++)
                    {
                        treasures.Add("E");
                    }
                    Form1.GenerateLair(this);
                }
                else
                //Do not generate a random lair
                {
                    Form1.WriteToFile("The camp contains the following treasure: ");
                    string tempTreasure = "";
                    for (int i = 0; i < caravans; i++)
                    {
                        //treasure.RollTreasure("E");
                        tempTreasure += "E";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //WILDERNESS ENCOUNTER
                numAppearing += (rand.Next(1, 5) * 10);
                Form1.WriteToFile("You have encountered a caravan of " + numAppearing + " nomads.");
                double leather, chain, lamellar, lances, bows;
                leather = Math.Truncate(numAppearing * .5);
                chain = Math.Truncate(numAppearing * .3);
                lamellar = numAppearing - (leather + chain);
                Form1.WriteToFile(leather + " wear leather, " + chain + " wear chain, and " + lamellar + " wear lamellar.");
                lances = Math.Truncate(numAppearing * .5);
                bows = numAppearing - lances;
                Form1.WriteToFile(lances + " are armed with lances on light warhorses.  " + bows + " are armed with composite bows on light riding horses.");
                Form1.WriteToFile("This caravan is led by a 4th level fighter with this loot: ");
                magicTreasure.leaderTreasure(4);
                Form1.WriteToFile("And two 2nd level fighters with this loot: ");
                magicTreasure.leaderTreasure(2);
                magicTreasure.leaderTreasure(2);

            }
        }

        public void OctopusGiantEncounter()
        {
            GenericEncounter(1600, 0, "", "1d2", "1d2", "giant octopus'", "pod", "pod");
        }

        public void OgreEncounter()
        {
            xp = 140;
            int warbands = 0, gangs = 0, level = 0, temp = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    //number of gangs in this particular warband
                    temp = rand.Next(1, 4);
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += rand.Next(1, 7);
                    }
                }
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " ogres!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                //2d6 females and 2d4 young per 10 ogres
                int females = 0, young = 0;
                for (int i = 0; i < numAppearing / 10; i++)
                {
                    females += rand.Next(1, 7) + rand.Next(1, 7);
                    young += rand.Next(1, 5) + rand.Next(1, 5);
                }
                Form1.WriteToFile("The village contains " + females + " females and " + young + " young.");
                //30% chance 2d8 prisoners
                roll = rand.Next(1, 101);
                if (roll < 31)
                {
                    Form1.WriteToFile("The ogres are currently keeping " + GenerateNumberInt("2d8") + " prisoners in the village.");
                }
                //50% chance of shaman - sub-chieftain with 1d4 cleric
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village contains a shaman, with sub-chieftain stats and clerical abilities of level " + level + ".");
                    Form1.WriteToFile("The shaman has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //25% chance of witch doctor - champion with 1d2 mage
                roll = rand.Next(1, 101);
                if (roll < 26)
                {
                    level = rand.Next(1, 3);
                    Form1.WriteToFile("The village contains a witch doctor, with champion stats and mage abilities of level " + level + ".");
                    Form1.WriteToFile("The witch doctor has the following gear:");
                    magicTreasure.leaderTreasure(level);
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("L");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following treasure:");
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("L");
                        tempTreasure += "L";
                    }
                    treasure.RollTreasure(tempTreasure);
                }

            }
            else
            {
                //wilderness encounter
                gangs = rand.Next(1, 4);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += rand.Next(1, 7);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " ogres!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("Each ogre is carrying a sack of gold.  Their sacks have: ");
                string gold = "";
                for (int i = 0; i < numAppearing; i++)
                {
                    if (i != numAppearing - 1)
                        gold += (rand.Next(1, 7) * 100) + ",";
                    else gold += (rand.Next(1, 7) * 100);
                }
                Form1.WriteToFile(gold);
            }
        }

        public void OrcEncounter()
        {
            xp = 10;
            int warbands = 0, gangs = 0, temp = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 36)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    temp = GenerateNumberInt("2d6");
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += GenerateNumberInt("2d4");
                    }
                }
                //I now know the number of orcs appearing
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " orcs!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                //100% females, 200% young
                Form1.WriteToFile("The village also contains " + numAppearing + " females and " + numAppearing * 2 + " young.");
                //1d20 prisoners per 100 orcs - various human and demihuman races
                int prisoners = 0;
                for (int i = 0; i < numAppearing / 100; i++)
                {
                    prisoners += rand.Next(1, 21);
                }
                Form1.WriteToFile("The village contains " + prisoners + " prisoners of various human and demihuman races.");
                //50% chance of d4+1 ogres
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + (rand.Next(1, 5) + 1) + " ogres.");
                }
                //25% chance of 1d4 trolls
                roll = rand.Next(1, 101);
                if (roll < 26)
                {
                    Form1.WriteToFile("The village is additionally guarded by " + rand.Next(1, 5) + " trolls.");
                }
                //75% chance of shaman - sub-chieftain with cleric 1d6
                roll = rand.Next(1, 101);
                if (roll < 76)
                {
                    level = rand.Next(1, 7);
                    Form1.WriteToFile("The village also contains a shaman with sub-chieftain stats and clerical ability of level " + level + ".");
                    Form1.WriteToFile("The shaman has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //50% chance of witch doctor - champion with mage 1d4
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village also contains a witch doctor with champion stats and mage abilty of level " + level + ".");
                    Form1.WriteToFile("The witch doctor has the following gear:");
                    magicTreasure.leaderTreasure(level);
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("G");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following loot:");
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("G");
                        tempTreasure += "G";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //wilderness encounter
                gangs = rand.Next(1, 7) + rand.Next(1, 7);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += GenerateNumberInt("2d4");
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " orcs!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
            }
        }

        public void OwlbearEncounter()
        {
            GenericEncounter(200, 30, "I", "1d4", "1d4", "owlbears", "den", "sloth");
        }

        public void OwlEncounter()
        {
            //1-4 ordinary; 5-6 giant
            roll = rand.Next(1, 7);
            if (roll < 5) OwlOrdinaryEncounter();
            else OwlGiantEncounter();
        }

        public void OwlOrdinaryEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //IN LAIR
                GenericEncounter(5, 100, "", "1d6", "1d6", "ordinary owls", "nest", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The nest contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The nest contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(5, 0, "", "1d6", "1d6", "ordinary owls", "nest", "flock");
            }
        }

        public void OwlGiantEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 21)
            {
                //IN LAIR
                GenericEncounter(65, 100, "", "1d3", "1d3", "giant owls", "nest", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The nest contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The nest contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(65, 0, "", "1d3", "1d3", "giant owls", "nest", "flock");
            }
        }

        public void PegasusEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 15)
            {
                //IN LAIR
                GenericEncounter(35, 100, "", "1d12", "1d12", "pegasis", "aerie", "flock");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(35, 0, "", "1d12", "1d12", "pegasis", "aerie", "flock");
            }
        }

        public void PhaseTigerEncounter()
        {
            GenericEncounter(350, 25, "K", "1d4", "1d4", "phase tigers", "den", "clowder");
        }

        public void PiranhaGiantEncounter()
        {
            FishPiranhaEncounter();
        }

        public void PirateEncounter()
        {
            xp = 10;
            roll = rand.Next(1, 101);
            if (roll < 71) BuccaneerEncounter();
            else
            {
                Form1.WriteToFile("You have encountered publicers!");
                GeneratePirateFleet();
            }
        }

        public void PixieEncounter()
        {
            GenericEncounter(13, 5, "B", "1d4*10d1", "1d4*10d1", "pixies", "lair", "wing");
        }

        public void PterodactylEncounter()
        {
            GenericEncounter(10, 0, "", "2d4", "2d4", "pterodactyls", "flight", "flight");
        }

        public void PteranadonEncounter()
        {
            GenericEncounter(200, 0, "", "1d4", "1d4", "pteranadons", "flight", "flight");
        }

        public void PurpleWormEncounter()
        {
            GenericEncounter(4200, 0, "PP", "1d4", "1d4", "purple worms", "herd", "herd");
            Form1.WriteToFile("The following treasure is in the bellies of one or more worms: ");
            treasure.RollTreasure("PP");
        }

        public void RemorhazEncounter()
        {
            //10-15 hd, with 2 special abilities
            //10-15 = 5d2 + 5
            int hd = GenerateNumberInt("5d2+5");
            int xp = 0;
            int special = 0;
            string name = "", treasureType = "", type = "remorhaz";
            name = "HD remorhaz";
            special = 2;
            name = hd + " " + name;
            /*
             * XP values by HD, special ability value
             * 10: 850, 700
             * 11: 1000, 800
             * 12: 1200, 900
             * 13: 1400, 1000
             * 14: 1600, 1100
             * 15: 1800, 1200
             * */
            switch (hd)
            {
                case 10:
                    xp = 850 + 700 * special;
                    treasureType = "P";
                    break;
                case 11:
                    xp = 1000 + 800 * special;
                    treasureType = "P";
                    break;
                case 12:
                    xp = 1200 + 900 * special;
                    treasureType = "P";
                    break;
                case 13:
                    xp = 1400 + 1000 * special;
                    treasureType = "KP";
                    break;
                case 14:
                    xp = 1600 + 1100 * special;
                    treasureType = "MP";
                    break;
                case 15:
                    xp = 1800 + 1200 * special;
                    treasureType = "MP";
                    break;
            }
            Form1.WriteToFile("You have encountered a " + type + " encounter!");
            Form1.WriteToFile("Each " + type + "'s XP value is " + xp + ".");
            GenericEncounter(xp, 25, treasureType, "3d6", "1d6", name, "colony", "herd");
        }

        public void RatEncounter()
        {
            //1-4 swarm
            //5-6 giant
            roll = rand.Next(1, 7);
            if (roll < 5) RatSwarmEncounter();
            else RatGiantEncounter();
        }

        public void RatSwarmEncounter()
        {
            roll = rand.Next(1, 4) + 1;
            if (roll == 2)
            {
                GenericEncounter(29, 10, "", "2d4", "2d4", "2 HD rat swarms", "den", "horde");
            }
            else if (roll == 3)
            {
                GenericEncounter(65, 10, "", "2d4", "2d4", "3 HD rat swarms", "den", "horde");
            }
            else if (roll == 4)
            {
                GenericEncounter(135, 10, "", "2d4", "2d4", "4 HD rat swarms", "den", "horde");
            }
        }

        public void RatGiantEncounter()
        {
            GenericEncounter(5, 10, "A", "3d10", "3d10", "giant rats", "den", "horde");
        }

        public void RhagodessaGiantEncounter()
        {
            GenericEncounter(215, 35, "I", "1d6", "1d6", "giant rhagodessas", "den", "cluster");
        }

        public void RhinocerosOrdinaryEncounter()
        {
            GenericEncounter(320, 0, "", "1d12", "1d12", "rhinos", "herd", "herd");
        }

        public void RhinocerosWoolyEncounter()
        {
            GenericEncounter(600, 0, "", "1d8", "1d8", "wooly rhinos", "herd", "herd");
        }

        public void RocEncounter()
        {
            //1-3 small, 4-5 large, 6 giant
            roll = rand.Next(1, 7);
            if (roll < 4) RocSmallEncounter();
            else if (roll == 5) RocLargeEncounter();
            else RocGiantEncounter();
        }

        public void RocSmallEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //IN LAIR
                GenericEncounter(570, 100, "IM", "1d12", "1d12", "small rocs", "aerie", "flight");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The nest contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The nest contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(570, 0, "IM", "1d12", "1d12", "small rocs", "aerie", "flight");
            }
        }

        public void RocLargeEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //IN LAIR
                GenericEncounter(2100, 100, "KP", "1d8", "1d8", "large rocs", "aerie", "flight");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The nest contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The nest contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(2100, 0, "KP", "1d8", "1d8", "large rocs", "aerie", "flight");
            }
        }

        public void RocGiantEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //IN LAIR
                GenericEncounter(12500, 100, "MP", "1d2", "1d1", "giant rocs", "aerie", "flight");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The nest contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The nest contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(12500, 0, "MP", "1d2", "1d2", "giant rocs", "aerie", "flight");
            }
        }

        public void RotGrubEncounter()
        {
            GenericEncounter(5, 0, "", "5d4", "5d4", "rot grubs", "brood", "brood");
        }

        public void RustMonsterEncounter()
        {
            GenericEncounter(200, 10, "", "1d4", "1d4", "rust monsters", "den", "pack");
        }

        public void SalamanderEncounter()
        {
            roll = rand.Next(1, 5);
            if (roll < 4) SalamanderFlameEncounter();
            else SalamanderFrostEncounter();
        }

        public void SalamanderFlameEncounter()
        {
            GenericEncounter(1100, 25, "Q", "2d4", "2d4", "flame salamanders", "nest", "swarm");
        }

        public void SalamanderFrostEncounter()
        {
            GenericEncounter(2100, 25, "Q", "1d3", "1d3", "frost salamanders", "nest", "band");
        }

        public void ScorpionGiantEncounter()
        {
            GenericEncounter(135, 50, "", "1d6", "1d6", "giant scorpions", "nest", "scourge");
        }

        public void SeaSerpentEncounter()
        {
            GenericEncounter(320, 0, "MI", "2d6", "2d6", "sea serpents", "swarm", "swarm");
            Form1.WriteToFile("Their bellies contain: ");
            treasure.RollTreasure("M");
            treasure.RollTreasure("I");
        }

        public void ShadowEncounter()
        {
            GenericEncounter(59, 40, "B", "1d12", "1d12", "shadows", "haunt", "horde");
        }

        public void SharkEncounter()
        {
            //1-2 bull, 3-4 mako, 5-6 great white
            roll = rand.Next(1, 7);
            if (roll < 3) SharkBullEncounter();
            else if (roll < 5) SharkMakoEncounter();
            else SharkGreatWhiteEncounter();
        }

        public void SharkBullEncounter()
        {
            GenericEncounter(29, 0, "", "3d6", "3d6", "bull sharks", "shiver", "shiver");
        }

        public void SharkMakoEncounter()
        {
            GenericEncounter(135, 0, "", "2d6", "2d6", "mako sharks", "shiver", "shiver");
        }

        public void SharkGreatWhiteEncounter()
        {
            GenericEncounter(1100, 0, "", "1d4", "1d4", "great white sharks", "shiver", "shiver");
        }


        public void ShrewGiantEncounter()
        {
            GenericEncounter(10, 40, "A", "1d8", "1d8", "giant shrews", "den", "drove");
        }

        public void ShriekerEncounter()
        {
            GenericEncounter(50, 0, "", "1d8", "1d8", "shriekers", "troop", "troop");
        }

        public void SkeletonEncounter()
        {
            GenericEncounter(13, 35, "", "3d10", "3d10", "skeletons", "boneyard", "horde");
        }

        public void SkitteringMawEncounter()
        {
            GenericEncounter(1600, 10, "M", "1d4", "1d4", "skittering maws", "den", "shiver");
        }

        public void SnakeGiantRattlerEncounter()
        {
            GenericEncounter(135, 0, "", "1d4", "1d4", "giant rattler snakes", "den", "den");
        }

        public void SnakePitViperEncounter()
        {
            GenericEncounter(38, 0, "", "1d6", "1d6", "pit vipers", "den", "den");
        }

        public void SnakePythonEncounter()
        {
            GenericEncounter(350, 0, "", "1d3", "1d3", "giant pythons", "den", "den");
        }

        public void SnakeSeaEncounter()
        {
            GenericEncounter(65, 0, "", "1d8", "1d8", "sea snakes", "den", "den");
        }

        public void SnakeSpittingCobraEncounter()
        {
            GenericEncounter(13, 0, "", "1d6", "1d6", "spitting cobras", "den", "den");
        }

        public void SpectreEncounter()
        {
            GenericEncounter(820, 20, "N", "1d8", "1d8", "spectres", "haunt", "horde");
        }

        public void SphinxEncounter()
        {
            Form1.WriteToFile("I do not have stats for sphinxes.");
            Form1.WriteToFile("But you rolled a sphinx encounter.");
            Form1.WriteToFile("Have fun!");
        }

        public void SpiderBlackWidowEncounter()
        {
            GenericEncounter(80, 90, "C", "1d3", "1d3", "giant black widows", "den", "clutter");
        }

        public void SpiderCrabEncounter()
        {
            GenericEncounter(38, 70, "C", "1d4", "1d4", "giant crab spiders", "den", "clutter");
        }

        public void SpiderTarantulaEncounter()
        {
            GenericEncounter(190, 50, "F", "1d3", "1d3", "giant tarantulas", "den", "clutter");
        }

        public void SpriteEncounter()
        {
            GenericEncounter(6, 30, "B", "3d6", "3d6", "sprites", "lair", "wing");
        }

        public void SquidGiantEncounter()
        {
            GenericEncounter(570, 0, "", "1d4", "1d4", "giant squids", "pod", "pod");
        }

        public void StatueCrystalEncounter()
        {
            GenericEncounter(65, 0, "", "1d6", "1d6", "animated crystal statues", "parade", "parade");
        }

        public void StatueStoneEncounter()
        {
            GenericEncounter(350, 0, "", "1d3", "1d3", "animated stone statues", "parade", "parade");
        }

        public void StatueIronEncounter()
        {
            GenericEncounter(190, 0, "", "1d4", "1d4", "animated iron statues", "parade", "parade");
        }

        public void StegosaurusEncounter()
        {
            GenericEncounter(1000, 0, "", "1d4", "1d4", "stegosaurus'", "herd", "herd");
        }

        public void StirgeEncounter()
        {
            GenericEncounter(13, 40, "F", "3d12", "3d12", "stirges", "nest", "swarm");
        }

        public void SwanEncounter()
        {
            Form1.WriteToFile("There are a lot of monsters on the tables that ACKS does not have stats for!  In this case it was a swan.");
            Form1.WriteToFile("So you encountered some swans!");
        }

        public void SwarmBatEncounter()
        {
            roll = rand.Next(1, 4) + 1;
            if (roll == 2)
            {
                GenericEncounter(29, 50, "", "1d3", "1d3", "2 HD bat swarms", "den", "horde");
            }
            else if (roll == 3)
            {
                GenericEncounter(65, 50, "", "1d3", "1d3", "3 HD bat swarms", "den", "horde");
            }
            else if (roll == 4)
            {
                GenericEncounter(135, 50, "", "1d3", "1d3", "4 HD bat swarms", "den", "horde");
            }
        }

        public void ThiefEncounter()
        {
            NPCEncounter("Thief");
        }

        public void ThroghrinEncounter()
        {
            GenericEncounter(80, 35, "G", "1d10", "1d10", "throghrins", "lair", "pack");
        }

        public void TitanothereEncounter()
        {
            GenericEncounter(1200, 0, "", "1d6", "1d6", "titanotheres", "herd", "herd");
        }

        public void ToadGiantEncounter()
        {
            GenericEncounter(47, 0, "C", "1d4", "1d4", "giant toads", "knot", "knot");
            Form1.WriteToFile("The toads' bellies contain: ");
            treasure.RollTreasure("C");
        }

        public void TreantEncounter()
        {
            GenericEncounter(1100, 10, "P", "1d8", "1d4", "treants", "grove", "shepherds");
        }

        public void TriceratopsEncounter()
        {
            GenericEncounter(1200, 0, "", "1d4", "1d4", "triceratops'", "herd", "herd");
        }

        public void TroglodyteEncounter()
        {
            xp = 20;
            int warbands = 0, gangs = 0, level = 0, temp = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 16)
            {
                //lair encounter
                warbands = rand.Next(1, 11);
                for (int i = 0; i < warbands; i++)
                {
                    //number of gangs in this particular warband
                    temp = rand.Next(1, 11);
                    for (int j = 0; j < temp; j++)
                    {
                        gangs++;
                        numAppearing += rand.Next(1, 9);
                    }
                }
                //I now know the total number of trogs
                Form1.WriteToFile("You have encountered a warren of " + numAppearing + " troglodytes!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The warren consists of " + warbands + " warbands and " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("Each warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("The warren is led by a chieftain with increased stats.");
                Form1.WriteToFile("The warren also contains " + numAppearing + " each of females and eggs.");
                Form1.WriteToFile("The warren also contains " + warbands + " sub-chieftains who are not in direct command of a warband.");
                Form1.WriteToFile("The warren also contains " + GenerateNumberInt("2d4") + " champions who are not in direct command of a gang.");
                //33% chance of shaman - sub-chieftain plus cleric 1d4
                roll = rand.Next(1, 101);
                if (roll < 34)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The warren also contains a shaman with sub-chieftain stats and cleric powers of level " + level + ".");
                    Form1.WriteToFile("The shaman has the following items:");
                    magicTreasure.leaderTreasure(level);
                }
                //25% chance of witch doctor - champion plus mage 1d2
                roll = rand.Next(1, 101);
                if (roll < 26)
                {
                    level = rand.Next(1, 3);
                    Form1.WriteToFile("The warren also contains a witch doctor with champion stats and mage abiliites of level " + level + ".");
                    Form1.WriteToFile("The witch doctor has the following items:");
                    magicTreasure.leaderTreasure(level);
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < warbands; i++)
                    {
                        treasures.Add("J");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following treasure:");
                    string tempTreasure = "";
                    for (int i = 0; i < warbands; i++)
                    {
                        //treasure.RollTreasure("J");
                        tempTreasure += "J";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //wilderness encounter
                gangs = rand.Next(1, 11);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += rand.Next(1, 9);
                }
                Form1.WriteToFile("You have encountered a warband of " + numAppearing + " troglodytes!");
                Form1.WriteToFile("They are out in the wilderness.");
                Form1.WriteToFile("The warband consists of " + gangs + " gangs.");
                Form1.WriteToFile("The warband is led by a sub-chieftain with increased stats.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
            }

        }

        public void TrollEncounter()
        {
            xp = 680;
            int gangs = 0, level = 0;
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 41)
            {
                //lair encounter
                gangs = rand.Next(1, 11);
                for (int i = 0; i < gangs; i++)
                {
                    numAppearing += rand.Next(1, 9);
                }
                //I now know the number of trolls
                Form1.WriteToFile("You have encountered a village of " + numAppearing + " trolls!");
                Form1.WriteToFile("They are in their lair.");
                Form1.WriteToFile("The village consists of " + gangs + " gangs.");
                Form1.WriteToFile("Each gang is led by a champion with increased stats.");
                Form1.WriteToFile("The village is led by a chieftain with increased stats.");
                Form1.WriteToFile("The chieftain is accompanied by a sub-chieftain and " + rand.Next(1, 5) + " bodyguards.");
                //females and young, 100%
                Form1.WriteToFile("The village has " + numAppearing + " each of females and young.");
                //50% chance of shaman - sub-chieftain with cleric 1d4
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    level = rand.Next(1, 5);
                    Form1.WriteToFile("The village contains a shaman, with sub-chieftain stats and clerical abilities of level " + level + ".");
                    Form1.WriteToFile("The shaman has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }
                //25% chance of witch doctor - champion with mage 1d2
                roll = rand.Next(1, 101);
                if (roll < 26)
                {
                    level = rand.Next(1, 3);
                    Form1.WriteToFile("The village contains a witch doctor, with champion stats and mage abilities of level " + level + ".");
                    Form1.WriteToFile("The witch doctor has the following gear: ");
                    magicTreasure.leaderTreasure(level);
                }

                if (Form1.lairGen)
                {
                    for (int i = 0; i < gangs; i++)
                    {
                        treasures.Add("O");
                    }
                    Form1.GenerateLair(this);
                }
                else
                {
                    Form1.WriteToFile("Their lair contains the following loot:");
                    string tempTreasure = "";
                    for (int i = 0; i < gangs; i++)
                    {
                        //treasure.RollTreasure("O");
                        tempTreasure += "O";
                    }
                    treasure.RollTreasure(tempTreasure);
                }
            }
            else
            {
                //wilderness encounter
                numAppearing += rand.Next(1, 9);
                Form1.WriteToFile("You have encountered a gang of " + numAppearing + " trolls!");
                Form1.WriteToFile("The gang is led by a champion with increased stats.");
            }
        }

        public void TRexEncounter()
        {
            GenericEncounter(2800, 0, "", "1d1", "1d1", "tyrannosaurus rexs", "solitary", "solitary");
        }

        public void UnicornEncounter()
        {
            GenericEncounter(135, 5, "D", "1d8", "1d8", "unicorns", "sanctum", "blessing");
        }

        public void VampireEncounter()
        {
            string vampName = "";
            int vampXP = 0;
            roll = rand.Next(1, 4);
            if (roll == 1)
            {
                vampName = "7 HD vampires";
                vampXP = 1840;
            }
            else if (roll == 2)
            {
                vampName = "8 HD vampires";
                vampXP = 2600;
            }
            else if (roll == 3)
            {
                vampName = "9 HD vampires";
                vampXP = 3100;
            }
            GenericEncounter(vampXP, 25, "Q", "1d6", "1d6", vampName, "sanctum", "coven");
        }

        public void VenturerEncounter()
        {
            NPCEncounter("Venturer");
        }

        public void VultureEncounter()
        {
            Form1.WriteToFile("Vultures are the fifth unique kind of bird on the encounter table.  Unfortunately, we only have stats for one kind.");
            Form1.WriteToFile("So, some vultures circle above the PCs!  If they shoot at them for some reason, well, make something up.");
        }

        public void WeaselGiantEncounter()
        {
            GenericEncounter(215, 25, "I", "1d6", "1d6", "giant weasels", "den", "sneak");
        }

        public void WerebearEncounter()
        {
            GenericEncounter(570, 10, "L", "1d4", "1d4", "werebears", "lair", "sloth");
        }

        public void WereboarEncounter()
        {
            GenericEncounter(215, 20, "J", "2d4", "2d4", "wereboars", "lair", "herd");
        }

        public void WereratEncounter()
        {
            GenericEncounter(65, 30, "G", "2d6", "2d6", "wererats", "lair", "plague");
        }

        public void WeretigerEncounter()
        {
            GenericEncounter(350, 15, "J", "1d4", "1d4", "weretigers", "lair", "troop");
        }

        public void WerewolfEncounter()
        {
            GenericEncounter(135, 25, "J", "2d6", "2d6", "werewolves", "lair", "route");
        }

        public void WhaleEncounter()
        {
            //1 killer, 2 narwhal, 3 sperm
            roll = rand.Next(1, 4);
            if (roll == 1) WhaleKillerEncounter();
            else if (roll == 2) WhaleNarwhalEncounter();
            else if (roll == 3) WhaleSpermEncounter();
        }

        public void WhaleKillerEncounter()
        {
            GenericEncounter(570, 0, "M", "1d6", "1d6", "killer whales", "pod", "pod");
            Form1.WriteToFile("Their bellies contain: ");
            treasure.RollTreasure("M");
        }

        public void WhaleNarwhalEncounter()
        {
            GenericEncounter(1200, 0, "", "1d4", "1d4", "narwhals", "pod", "pod");
            Form1.WriteToFile("Their horns are valuable, worth: ");
            for (int i = 0; i < numAppearing; i++)
            {
                Form1.WriteToFile((rand.Next(1, 7) * 1000) + "gp");
            }
        }

        public void WhaleSpermEncounter()
        {
            GenericEncounter(12500, 0, "P", "1d3", "1d3", "sperm whales", "pod", "pod");
            Form1.WriteToFile("Their bellies contain: ");
            treasure.RollTreasure("P");
        }

        public void WightEncounter()
        {
            GenericEncounter(80, 70, "H", "1d8", "1d8", "wights", "barrow", "horde");
        }

        public void WolfEncounter()
        {
            //1-4 ordinary, 5-6 dire
            roll = rand.Next(1, 7);
            if (roll < 5) WolfOrdinaryEncounter();
            else WolfDireEncounter();
        }

        public void WolfOrdinaryEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //IN LAIR
                GenericEncounter(35, 100, "O", "3d6", "3d6", "ordinary wolfs", "den", "route");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    Form1.WriteToFile("The den contains " + rand.Next(1, 5) + " wolf cubs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(35, 0, "O", "3d6", "3d6", "ordinary wolfs", "den", "route");
            }
        }
        
        public void WolfDireEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 11)
            {
                //IN LAIR
                GenericEncounter(140, 100, "O", "2d4", "2d4", "dire wolfs", "den", "route");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    Form1.WriteToFile("The den contains " + rand.Next(1, 5) + " dire wolf cubs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(140, 0, "O", "2d4", "2d4", "dire wolfs", "den", "route");
            }
        }

        public void WraithEncounter()
        {
            GenericEncounter(190, 25, "H", "1d6", "1d6", "wraiths", "haunt", "horde");
        }

        public void WyvernEncounter()
        {
            roll = rand.Next(1, 101);
            if (Form1.forceLair) roll = 0;
            if (roll < 31)
            {
                //IN LAIR
                GenericEncounter(1140, 100, "M", "1d6", "1d6", "wyverns", "aerie", "wing");
                roll = rand.Next(1, 101);
                if (roll < 51)
                {
                    roll = rand.Next(1, 3);
                    if (roll == 1)
                    {
                        Form1.WriteToFile("The aerie contains " + rand.Next(1, 5) + " young.");
                    }
                    else Form1.WriteToFile("The aerie contains " + rand.Next(1, 7) + " eggs.");
                }
            }
            else
            {
                //OUT OF LAIR
                GenericEncounter(1140, 0, "M", "1d6", "1d6", "wyverns", "aerie", "wing");
            }
        }

        public void ZombieEncounter()
        {
            GenericEncounter(29, 35, "", "4d6", "4d6", "zombies", "abbatoir", "horde");
        }


    }
}
