using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class magicTreasure
    {
        private static Random rand = new Random(Guid.NewGuid().GetHashCode());
        private static int roll;

        public static void magicTreasureWrite(string text)
        {
            if (Form1.playerBox)
            {
                //write to two files
                string sanitized = treasureSanitize(text);
                Form1.WriteToFile(text);
                Form1.playerWrite(sanitized);
            }
            else
            {
                //write to one file
                Form1.WriteToFile(text);
            }
        }

        private static bool isVowel(char check)
        {
            if ((check == 'A') || (check == 'E') || (check == 'I') || (check == 'O') || (check == 'U')) return true;
            return false;
        }

        static string checkContainer(string text, string check)
        {
            text = text.ToUpper();
            check = check.ToUpper();
            if (text.Contains(check))
            {
                if (isVowel(check[0])) return ("An " + check.ToLower());
                else return ("A " + check.ToLower());
            }
            return "";
        }

        static string treasureSanitize(string text)
        {
            string returner = "", temp = "";
            int counter = 0;
            System.IO.StreamReader itemReader;
            System.Collections.ArrayList items = new System.Collections.ArrayList();
            itemReader = new System.IO.StreamReader(System.Windows.Forms.Application.StartupPath + "/Resources/Treasure/Items.txt");
            while (!itemReader.EndOfStream)
            {
                items.Add(itemReader.ReadLine());
            }

            while (returner == "")
            {
                if (counter > (items.Count - 1))
                {
                    //error:  could not find the item
                    returner = "Error: Could not find item " + text;
                    return returner;
                }
                //special cases:
                //eyes
                //armor + shield
                temp = (string)items[counter];
                if ((text.Contains("armor")) && (text.Contains("shield")))
                {
                    //armor and shield special case
                    //string returned needs to have the type of armor and the shield, without the +X's
                    //the string will look like "suit of plate armor +3 and shield +1", or with -'s
                    string type = text.Substring(0, text.IndexOf("armor"));
                    returner = "A " + type.ToLower() + "armor and shield";
                }
                else if (text.Contains("armor"))
                {
                    //armor alone special case
                    string type = text.Substring(0, text.IndexOf("armor"));
                    returner = "A " + type.ToLower() + "armor";
                }
                else if (text.Contains("Eyes"))
                {
                    //eyes special case
                    returner = "A pair of crystal lenses";
                }
                else if (text.Contains("Boots"))
                {
                    //boots special case
                    returner = "A pair of boots";
                }
                else if (text.Contains("Gauntlets"))
                {
                    returner = "A pair of gauntlets";
                }
                else returner = checkContainer(text, temp);
                counter++;
            }

            return returner;
        }

        public static void leaderTreasure(int level)
        {
            bool generated = false;
            //5% chance per level for each category that an NPC leader has loot in that category
            int percent = (level * 5) + 1;
            //POTION
            roll = rand.Next(1, 101);
            if (roll < percent)
            {
                GeneratePotion(1);
                generated = true;
            }

            //RING
            roll = rand.Next(1, 101);
            if (roll < percent) GenerateRing(1);

            //SCROLL
            roll = rand.Next(1, 101);
            if (roll < percent) 
            { 
                GenerateScroll(1);
                generated = true;
            }

            //ROD, STAFF, WAND
            roll = rand.Next(1, 101);
            if (roll < percent)
            {
                GenerateRodStaffWand(1);
                generated = true;
            }

            //MISC
            roll = rand.Next(1, 101);
            if (roll < percent)
            {
                GenerateMisc(1);
                generated = true;
            }

            //SWORD
            roll = rand.Next(1, 101);
            if (roll < percent)
            {
                GenerateSword(1);
                generated = true;
            }

            //OTHER WEAPON
            roll = rand.Next(1, 101);
            if (roll < percent)
            {
                GenerateMiscWeapon(1);
                generated = true;
            }

            //ARMOR
            roll = rand.Next(1, 101);
            if (roll < percent)
            {
                GenerateArmor(1);
                generated = true;
            }

            if (generated) Form1.WriteToFile("");
            else Form1.WriteToFile("Null treasure.");
        }


        //Generate a random magic item of any type
        public static void GenerateMagicItems(int number)
        {
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 21)
                    GeneratePotion(1);
                else if (roll < 26)
                    GenerateRing(1);
                else if (roll < 57)
                    GenerateScroll(1);
                else if (roll < 62)
                    GenerateRodStaffWand(1);
                else if (roll < 67)
                    GenerateMisc(1);
                else if (roll < 88)
                    GenerateSword(1);
                else if (roll < 93)
                    GenerateMiscWeapon(1);
                else GenerateArmor(1);
            }
        }

        //Generate a magic sword, shield, or armor, randomly selected
        public static void GenerateMagicEquipment(int number)
        {
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 4);
                if (roll == 1) GenerateSword(1);
                else if (roll == 2) GenerateMiscWeapon(1);
                else GenerateArmor(1);
            }
        }

        //Generate a magical potion
        public static void GeneratePotion(int number)
        {
            string potion;
            bool oil = false;
            bool philter = false;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 4) potion = "Animal Control";
                else if (roll < 7) potion = "Clairaudience";
                else if (roll < 10) potion = "Clairvoyance";
                else if (roll < 13) potion = "Climbing";
                else if (roll < 18) potion = "Delusion";
                else if (roll < 21) potion = "Dimunition";
                else if (roll < 24) potion = "Dragon Control";
                else if (roll < 27) potion = "ESP";
                else if (roll < 29) potion = "Extra-Healing";
                else if (roll < 32) potion = "Fire Resistance";
                else if (roll < 37) potion = "Flying";
                else if (roll < 41) potion = "Gaseous Form";
                else if (roll < 44) potion = "Giant Control";
                else if (roll < 48) potion = "Giant Strength";
                else if (roll < 51) potion = "Growth";
                else if (roll < 55) potion = "Healing";
                else if (roll < 59) potion = "Heroism";
                else if (roll < 62) potion = "Human Control";
                else if (roll < 65) potion = "Invisibility";
                else if (roll < 67) potion = "Invulnerability";
                else if (roll < 70) potion = "Levitation";
                else if (roll < 72) potion = "Longevity";
                else if (roll < 74)
                {
                    oil = true;
                    potion = "Sharpness";
                }
                else if (roll < 76)
                {
                    oil = true;
                    potion = "Slipperiness";
                }
                else if (roll < 79)
                {
                    philter = true;
                    potion = "Love";
                }
                else if (roll < 82) potion = "Plant Control";
                else if (roll < 84) potion = "Poison";
                else if (roll < 86) potion = "Polymorph";
                else if (roll < 88) potion = "Speed";
                else if (roll < 91) potion = "Super-Heroism";
                else if (roll < 94) potion = "Sweet Water";
                else if (roll < 96) potion = "Treasure Finding";
                else if (roll < 98) potion = "Undead Control";
                else potion = "Water Breathing";

                if (oil) magicTreasureWrite("Oil of " + potion + ".");
                else if (philter) magicTreasureWrite("Philter of " + potion + ".");
                else magicTreasureWrite("Potion of " + potion + ".");
            }
        }

        //Generates a magic ring
        public static void GenerateRing(int number)
        {
            string ring;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 5) ring = "Animal Command";
                else if (roll < 10) ring = "Human Command";
                else if (roll < 16) ring = "Plant Command";
                else if (roll < 26) ring = "Delusion";
                else if (roll < 28) ring = "Djinni Calling";
                else if (roll < 39) ring = "Fire Resistance";
                else if (roll < 50) ring = "Invisibility";
                else if (roll < 71)
                {
                    roll = rand.Next(1, 101);
                    ring = "Protection";
                    if (roll < 81) ring += " +1";
                    else if (roll < 92) ring += " +2";
                    else if (roll < 93) ring += " +2, 5' radius";
                    else if (roll < 100) ring += " +3";
                    else ring += " +3, 5' radius";
                }
                else if (roll < 73) ring = "Regeneration";
                else if (roll < 75)
                {
                    ring = "Spell Storing with the following spells: ";
                    roll = rand.Next(1, 7);
                    for (int j = 0; j < roll; j++)
                    {
                        ring += spells.GenerateSpell(rand.Next(1, 7));
                        if (j != roll - 1)
                        {
                            ring += ", ";
                        }
                    }
                }
                else if (roll < 80) ring = "Spell Turning, " + (rand.Next(1, 7) + rand.Next(1, 7)) + " spells";
                else if (roll < 82) ring = "Telekinesis";
                else if (roll < 88) ring = "Water Walking";
                else if (roll < 95) ring = "Weakness";
                else if (roll < 98) ring = "Wishes with" + rand.Next(1, 5) + " Wishes";
                else ring = "X-Ray Vision";

                magicTreasureWrite("Ring of " + ring + ".");

            }
        }

        //Generates a scroll
        public static void GenerateScroll(int number)
        {
            string scroll = "";
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 6) scroll = "Cursed";
                else if (roll < 16) scroll = "Ward against Elementals";
                else if (roll < 31) scroll = "Ward against Magic";
                else if (roll < 41) scroll = "Ward against Undead";
                else if (roll < 77)
                {
                    scroll = "spell scroll with the following spells: " + System.Environment.NewLine;
                    if (roll < 56)
                    {
                        //One spell
                        scroll += GenerateScrollSpells(1);
                    }
                    else if (roll < 67)
                    {
                        //Two spells
                        scroll += GenerateScrollSpells(2);
                    }
                    else if (roll < 70)
                    {
                        //Three spells
                        scroll += GenerateScrollSpells(3);
                    }
                    else if (roll < 73)
                    {
                        //Four spells
                        scroll += GenerateScrollSpells(4);
                    }
                    else if (roll < 75)
                    {
                        //Five spells
                        scroll += GenerateScrollSpells(5);
                    }
                    else if (roll < 76)
                    {
                        //Six spells
                        scroll += GenerateScrollSpells(6);
                    }
                    else if (roll < 77)
                    {
                        //Seven spells
                        scroll += GenerateScrollSpells(7);
                    }
                }
                else if (roll < 81) scroll = "a map to a treasure containing " + rand.Next(1, 5) + " thousand GP.";
                else if (roll < 86) scroll = "a map to a treasure containing " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " thousand GP.";
                else if (roll < 88) scroll = "a map to a treasure containing " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " thousand GP.";
                else if (roll < 92) scroll = "a map to a treasure containing " + rand.Next(1, 7) + " gems and " + (rand.Next(1, 11) + rand.Next(1, 11)) + " jewelry";
                else if (roll < 94) scroll = "a map to a treasure containing 1 magic item";
                else if (roll < 96) scroll = "a map to a treasure containing 2 magic items";
                else if (roll < 97) scroll = "a map to a treasure containing 3 magic items, none of which are weapons";
                else if (roll < 98) scroll = "a map to a treasure containing 3 magic items and 1 potion";
                else if (roll < 99) scroll = "a map to a treasure containing 3 magic items, 1 potion, and 1 scroll";
                else if (roll < 100) scroll = "a map to a treasure containing " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " thousand GP";
                else scroll = "a map to a treasure containing " + (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) + " gems and 2 magic items";

                magicTreasureWrite("A scroll of the following type: " + scroll);

            }
        }

        //Generates a rod, staff, or wand
        public static void GenerateRodStaffWand(int number)
        {
            string item = "";
            int charges = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 7) item = "Rod of Cancellation";
                else if (roll < 9) item = "Rod of Resurrection";
                else if (roll < 11) item = "Staff of Commanding";
                else if (roll < 21) item = "Staff of Healing";
                else if (roll < 23) item = "Staff of Power";
                else if (roll < 27) item = "Staff of Striking";
                else if (roll < 29) item = "Staff of Withering";
                else if (roll < 30) item = "Staff of Wizardry";
                else if (roll < 37) item = "Staff of the Serpent";
                else if (roll < 41) item = "Wand of Cold";
                else if (roll < 46) item = "Wand of Detecting Enemies";
                else if (roll < 51) item = "Wand of Detecting Magic";
                else if (roll < 56) item = "Wand of Detecting Metals";
                else if (roll < 61) item = "Wand of Detecting Secret Doors";
                else if (roll < 65) item = "Wand of Detecting Traps";
                else if (roll < 70) item = "Wand of Device Negation";
                else if (roll < 75) item = "Wand of Fear";
                else if (roll < 80) item = "Wand of Fireballs";
                else if (roll < 85) item = "Wand of Illusion";
                else if (roll < 89) item = "Wand of Lightning Bolts";
                else if (roll < 94) item = "Wand of Magic Missiles";
                else if (roll < 97) item = "Wand of Paralyzation";
                else item = "Wand of Polymorphing";

                if (roll < 9) charges = rand.Next(1, 7) + rand.Next(1, 7);
                else if (roll < 37) charges = rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11);
                else charges = rand.Next(1, 11) + rand.Next(1, 11);

                magicTreasureWrite(item + " with " + charges + " charges.");

            }
        }

        //Generates a miscelleneous magic item
        public static void GenerateMisc(int number)
        {
            string item = "";
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 3) item = "Amulet versus Crystal Balls and ESP";
                else if (roll < 4) item = "Apparatus of the Crab";
                else if (roll < 6) item = "Bag of Devouring";
                else if (roll < 11) item = "Bag of Holding";
                else if (roll < 12) item = "Folding Boat";
                else if (roll < 15) item = "Boots of Levitation";
                else if (roll < 18) item = "Boots of Speed";
                else if (roll < 21) item = "Boots of Striding and Springing";
                else if (roll < 22) item = "Bowl of Commanding Water Elementals";
                else if (roll < 24)
                {
                    item = "Bracers of Armor";
                    roll = rand.Next(1, 101);
                    if (roll < 7) item += " AC 1";
                    else if (roll < 17) item += " AC 2";
                    else if (roll < 37) item += " AC 3";
                    else if (roll < 52) item += " AC 4";
                    else if (roll < 72) item += " AC 5";
                    else if (roll < 87) item += " AC 6";
                    else item += " AC 7";
                    roll = rand.Next(1, 101);
                    if (roll < 6) item = "Bracers of Armor, Cursed";
                }
                else if (roll < 25) item = "Brazier of Commanding Fire Elementals";
                else if (roll < 27) item = "Brooch of Shielding";
                else if (roll < 30) item = "Broom of Flying";
                else if (roll < 31) item = "Censer of Controlling Air Elementals";
                else if (roll < 32)
                {
                    item = "Chime of Opening";
                    roll = 10 * (rand.Next(1, 5) + rand.Next(1, 5));
                    item += " with" + roll + " charges";
                }
                else if (roll < 34)
                {
                    item = "Cloak of Protection";
                    roll = rand.Next(1, 101);
                    if (roll < 81) item += " +1";
                    else if (roll < 92) item += " +2";
                    else item += " +3";
                }
                else if (roll < 37) item = "Crystal Ball";
                else if (roll < 39) item = "Crystal Ball with Clairaudience";
                else if (roll < 40) item = "Crystal Ball with ESP";
                else if (roll < 41) item = "Cube of Force";
                else if (roll < 42) item = "Cube of Frost Resistance";
                else if (roll < 44) item = "Decanter of Endless Water....I mean Sand";
                else if (roll < 46) item = "Displacer Cloak";
                else if (roll < 47) item = "Drums of Panic";
                else if (roll < 50)
                {
                    item = "Dust of Appearance";
                    roll = rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11);
                    item += ", " + roll + " packets";
                }
                else if (roll < 53)
                {
                    item = "Dust of Disappearance";
                    roll = rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11);
                    item += ", " + roll + " packets";
                }
                else if (roll < 54) item = "Efreeti Bottle";
                else if (roll < 58) item = "Elven Cloak";
                else if (roll < 62) item = "Elven Boots";
                else if (roll < 63) item = "Pair of Eyes of Charming";
                else if (roll < 65) item = "Pair of Eyes of the Eagle";
                else if (roll < 68)
                {
                    roll = rand.Next(1, 101);
                    if (roll < 26) item = "Pair of Eyes of Petrification, Gaze Attack";
                    else item = "Pair of Eyes of Petrification, Cursed";
                }
                else if (roll < 72) item = "Flying Carpet";
                else if (roll < 75) item = "pair of Gauntlets of Ogre Power";
                else if (roll < 78) item = "Girdle of Giant Strength";
                else if (roll < 81) item = "Helm of Alignment Changing";
                else if (roll < 85) item = "Helm of Comprehending Languages";
                else if (roll < 86) item = "Helm of Telepathy";
                else if (roll < 87) item = "Helm of Teleportation";
                else if (roll < 88) item = "Horn of Blasting";
                else if (roll < 91) item = "Medallion of ESP";
                else if (roll < 93) item = "Medallion of ESP, 90'";
                else if (roll < 94) item = "Mirror of Life Trapping";
                else if (roll < 95) item = "Mirror of Opposition";
                else if (roll < 96) item = "Necklace of Adaptation";
                else if (roll < 98) item = "Rope of Climbing";
                else if (roll < 100) item = "Scarab of Protection";
                else item = "Stone of Controlling Earth Elementals";

                magicTreasureWrite(item + ".");
            }

        }

        //Generates a magic sword
        public static void GenerateSword(int number)
        {
            string item = "";
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 40) item = "Sword +1";
                else if (roll < 45) item = "Sword +1, +2 versus Lycanthropes";
                else if (roll < 50) item = "Sword +1, +2 vs Spellcasters";
                else if (roll < 54) item = "Sword +1, +3 vs Undead";
                else if (roll < 58) item = "Sword +1, +3 vs Dragons";
                else if (roll < 63) item = "Sword +1, +3 vs Regenerating Monsters";
                else if (roll < 68) item = "Sword +1, +3 vs Summoned Creatures";
                else if (roll < 76) item = "Sword +1, Light 30' radius";
                else if (roll < 81) item = "Sword +1, Flame Tongue";
                else if (roll < 82)
                {
                    item = "Sword +1, Life Drinker";
                    roll = rand.Next(1, 5) + 4;
                    item += " with " + roll + " charges";
                }
                else if (roll < 85) item = "Sword +1, Locate Objects";
                else if (roll < 86)
                {
                    item = "Sword +1, Luck Blade";
                    roll = rand.Next(1, 5) + 1;
                    item += " with " + roll + " Wishes";
                }
                else if (roll < 90) item = "Sword +2";
                else if (roll < 92) item = "Sword +2, Charm Person";
                else if (roll < 95) item = "Sword +3";
                else if (roll < 96) item = "Sword +3, Frost Brand";
                else if (roll < 97) item = "Sword +3, Vorpal";
                else if (roll < 99) item = "Sword -1, Cursed";
                else item = "Sword -2, Cursed";

                magicTreasureWrite(item + ".");
            }
        }

        //Generates a non-sword magic weapon
        public static void GenerateMiscWeapon(int number)
        {
            string item = "";
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 11)
                {
                    item = "Quiver containing " + (rand.Next(1, 7) + rand.Next(1, 7)) + " arrows +1";
                }
                else if (roll < 13)
                {
                    item = "Quiver containing " + (rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11)) + " arrows +1";
                }
                else if (roll < 19)
                {
                    item = "Quiver containing " + rand.Next(1, 7) + " arrows +2";
                }
                else if (roll < 22)
                {
                    item = "Quiver containing " + rand.Next(1, 5) +  " arrows +3";
                }
                else if (roll < 23) item = "Arrow +3, Slaying Arrow";
                else if (roll < 32) item = "Axe +1";
                else if (roll < 35) item = "Axe +2";
                else if (roll < 42) item = "Bow +1";
                else if (roll < 52)
                {
                    item = "Bolt case containing " + (rand.Next(1, 7) + rand.Next(1, 7)) + " crossbow bolts +1";
                }
                else if (roll < 54)
                {
                    item = "Bolt case containing " + (rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11)) + " crossbow bolts +1";
                }
                else if (roll < 61)
                {
                    item = "Bolt case containing " + (rand.Next(1, 7)) + " crossbow bolts +2";
                }
                else if (roll < 64)
                {
                    item = "Bolt case containing " + (rand.Next(1, 5)) + " crossbow bolts +3";
                }
                else if (roll < 69) item = "Dagger +1";
                else if (roll < 70) item = "Dagger +2, +3 vs Beastmen";
                else if (roll < 76) item = "Sling +1";
                else if (roll < 83) item = "Spear +1";
                else if (roll < 87) item = "Spear +2";
                else if (roll < 88) item = "Spear +3";
                else if (roll < 95) item = "War Hammer +1";
                else if (roll < 100) item = "War Hammer +2";
                else item = "War Hammer +2, Dwarven Thrower";

                magicTreasureWrite(item + ".");

            }
        }

        //Generates a suit of magical armor
        public static void GenerateArmor(int number)
        {
            string item = "";

            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 16) item = GetArmorType() + " +1";
                else if (roll < 26) item = GetArmorType() + " +1 and shield +1";
                else if (roll < 28) item = GetArmorType() + " +1 and shield +1";
                else if (roll < 29) item = GetArmorType() + " +1 and shield +3";
                else if (roll < 33) item = GetArmorType() + " +2";
                else if (roll < 36) item = GetArmorType() + " +2 and shield +1";
                else if (roll < 39) item = GetArmorType() + " +2 and shield +2";
                else if (roll < 40) item = GetArmorType() + " +2 and shield +3";
                else if (roll < 41) item = GetArmorType() + " +3";
                else if (roll < 42) item = GetArmorType() + " +3 and shield +1";
                else if (roll < 43) item = GetArmorType() + " +3 and shield +2";
                else if (roll < 44) item = GetArmorType() + " +3 and shield +3";
                else if (roll < 64) item = "Shield +1";
                else if (roll < 74) item = "Shield +2";
                else if (roll < 80) item = "Shield +3";
                else if (roll < 83) item = GetArmorType() + " -1, cursed";
                else if (roll < 86) item = GetArmorType() + " -2, cursed";
                else if (roll < 87) item = GetArmorType() + " -1, cursed, and shield +1";
                else if (roll < 88) item = GetArmorType() + " -2, cursed, and shield +1";
                else if (roll < 91) item = GetArmorType() + " AC 0, cursed";
                else if (roll < 95) item = "Shield -1, cursed";
                else if (roll < 98) item = "Shield -2, cursed";
                else item = "Shield AC 0, cursed";

                magicTreasureWrite(item);
            }
        }

        private static string GetArmorType()
        {
            roll = rand.Next(1, 101);
            if (Form1.armorBox)
                //Dark Sun armor tables
            {
                int random = rand.Next(1, 1000);
                if (random == 1)
                {
                    //Suit of metal armor
                    //Types that are available in metal: Ring, Scale, Chain, Banded, Lamellar, Plate
                    if (roll < 51) return "Suit of metal Ring mail";
                    else if (roll < 71) return "Suit of metal Scale armor";
                    else if (roll < 81) return "Suit of metal Chain mail";
                    else if (roll < 91) return "Suit of metal Banded plate";
                    else if (roll < 95) return "Suit of metal Lamellar armor";
                    else return "Suit of metal Plate armor";
                }
                else
                {
                    //Suit of non-metal armor
                    //Types that are available in non-metal: Hide, Leather, Scale, Banded, Lamellar
                    if (roll < 31) return "Suit of Hide armor";
                    else if (roll < 61) return "Suit of Leather armor";
                    else if (roll < 71) return "Suit of Scale armor";
                    else if (roll < 91) return "Suit of Banded armor";
                    else return "Suit of Lamellar armor";
                }

            }
            else
            {
                if (roll < 6) return "Suit of Hide armor";
                else if (roll < 31) return "Suit of Leather armor";
                else if (roll < 36) return "Suit of Ring mail";
                else if (roll < 41) return "Suit of Scale armor";
                else if (roll < 66) return "Suit of Chain mail";
                else if (roll < 71) return "Suit of Banded plate";
                else if (roll < 76) return "Suit of Lamellar armor";
                else return "Suit of Plate armor";
            }
        }

        private static string GenerateScrollSpells(int number)
        {
            string returner = "";
            if (number < 1) number = 1;
            for (int i = 0; i < number; i++)
            {
                returner += GenerateScrollSpell();
                if (i != number - 1)
                {
                    returner += ", ";
                }
            }
            return returner;
        }

        private static string GenerateScrollSpell()
        {
            roll = rand.Next(1, 5);
            if (roll == 4) return spells.GenerateDivineSpell(GenerateDivineSpellLevel());
            else return spells.GenerateArcaneSpell(GenerateArcaneSpellLevel());
        }

        private static int GenerateDivineSpellLevel()
        {
            roll = rand.Next(1, 101);
            if (roll < 26) return 1;
            else if (roll < 51) return 2;
            else if (roll < 71) return 3;
            else if (roll < 86) return 4;
            else if (roll < 96) return 5;
            else if (roll < 99) return 6;
            else return 7;
        }

        private static int GenerateArcaneSpellLevel()
        {
            roll = rand.Next(1, 101);
            if (roll < 26) return 1;
            else if (roll < 51) return 2;
            else if (roll < 71) return 3;
            else if (roll < 86) return 4;
            else if (roll < 96) return 5;
            else if (roll < 98) return 6;
            else if (roll < 99) return 7;
            else if (roll < 100) return 8;
            else return 9;
        }


    }//End class
}//End namespace
