using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class spells
    {

        private static Random rand = new Random(Guid.NewGuid().GetHashCode());
        private static int roll;


        //Generates a random spell of the selected level.  50/50 arcane or divine.
        public static string GenerateSpell(int level)
        {
            if (level < 1) level = 1;
            roll = rand.Next(1, 3);
            if (roll == 1) return GenerateArcaneSpell(level);
            else return GenerateDivineSpell(level);
        }

        //Generates a random arcane spell of the selected level
        public static string GenerateArcaneSpell(int level)
        {
            switch (level)
            {
                case 1: return arcane1();
                case 2: return arcane2();
                case 3: return arcane3();
                case 4: return arcane4();
                case 5: return arcane5();
                case 6: return arcane6();
                case 7: return arcane7();
                case 8: return arcane8();
                case 9: return arcane9();
            }
            return "";
        }

        //Generates a random divine spell of the selected level
        public static string GenerateDivineSpell(int level)
        {
            switch (level)
            {
                case 1: return divine1();
                case 2: return divine2();
                case 3: return divine3();
                case 4: return divine4();
                case 5: return divine5();
                case 6: return divine6();
                case 7: return divine7();
            }
            return "";
        }

        private static string arcane1()
        {
            roll = rand.Next(1, 24);
            switch (roll)
            {
                case 1: return "Burning Hands";
                case 2: return "Charm Person";
                case 3: return "Chameleon";
                case 4: return "Choking Grip";
                case 5: return "Detect Magic";
                case 6: return "Floating Disc";
                case 7: return "Hold Portal";
                case 8: return "Jump";
                case 9: return "Light";
                case 10: return "Magic Missile";
                case 11: return "Magic Mouth";
                case 12: return "Magic Rope";
                case 13: return "Protection from Evil";
                case 14: return "Read Languages";
                case 15: return "Sharpness";
                case 16: return "Shield";
                case 17: return "Silent Step";
                case 18: return "Sleep";
                case 19: return "Slipperiness";
                case 20: return "Spider Climb";
                case 21: return "Summon Berserkers";
                case 22: return "Unseen Servant";
                case 23: return "Ventriloquism";
                case 24: return "Wall of Smoke";
            }
            return "";
        }

        private static string arcane2()
        {
            roll = rand.Next(1, 24);
            switch (roll)
            {
                case 1: return "Alter Self";
                case 2: return "Continual Light";
                case 3: return "Deathless Minion";
                case 4: return "Detect Evil";
                case 5: return "Detect Invisibile";
                case 6: return "Detect Secret Doors";
                case 7: return "ESP";
                case 8: return "Glitterdust";
                case 9: return "Gust of Wind";
                case 10: return "Hypnotic Pattern";
                case 11: return "Inaudibility";
                case 12: return "Invisibility";
                case 13: return "Knock";
                case 14: return "Levitate";
                case 15: return "Locate Object";
                case 16: return "Mirror Image";
                case 17: return "Necromantic Potence";
                case 18: return "Ogre Power";
                case 19: return "Phantasmal Force";
                case 20: return "Stinking Cloud";
                case 21: return "Summon Hero";
                case 22: return "Uncanny Gyration";
                case 23: return "Web";
                case 24: return "Wizard Lock";
            }
            return "";
        }

        private static string arcane3()
        {
            roll = rand.Next(1, 24);
            switch (roll)
            {
                case 1: return "Clairvoyance";
                case 2: return "Clairaudience";
                case 3: return "Chimerical Force";
                case 4: return "Command Person";
                case 5: return "Dismember";
                case 6: return "Dispel Magic";
                case 7: return "Earth's Teeth";
                case 8: return "Enervate";
                case 9: return "Fireball";
                case 10: return "Fly";
                case 11: return "Gaseous Form";
                case 12: return "Growth";
                case 13: return "Haste";
                case 14: return "Hold Person";
                case 15: return "Infravision";
                case 16: return "Invisibility, 10' Radius";
                case 17: return "Lightning Bolt";
                case 18: return "Nondetection";
                case 19: return "Protection from Evil, Sustained";
                case 20: return "Protection from Normal Missiles";
                case 21: return "Skinchange";
                case 22: return "Summon Winged Steed";
                case 23: return "Telepathy";
                case 24: return "Water Breathing";
            }
            return "";
        }

        private static string arcane4()
        {
            roll = rand.Next(1, 24);
            switch (roll)
            {
                case 1: return "Charm Monster";
                case 2: return "Command Plant";
                case 3: return "Confusion";
                case 4: return "Conjure Ooze";
                case 5: return "Dimension Door";
                case 6: return "Fear";
                case 7: return "Find Treasure";
                case 8: return "Giant Strength";
                case 9: return "Growth of Plants";
                case 10: return "Hallucinatory Terrain";
                case 11: return "Magic Carpet";
                case 12: return "Massmorph";
                case 13: return "Minor Globe of Invulnerability";
                case 14: return "Polymorph Other";
                case 15: return "Polymorph Self";
                case 16: return "Remove Curse";
                case 17: return "Scry";
                case 18: return "Spectral Force";
                case 19: return "Spell Storing";
                case 20: return "Summon Fantastic Creature";
                case 21: return "Wall of Fire";
                case 22: return "Wall of Ice";
                case 23: return "Wall of Wood";
                case 24: return "Wizard Eye";
            }

            return "";
        }

        private static string arcane5()
        {
            roll = rand.Next(1, 24);
            switch (roll)
            {
                case 1: return "Animate Dead";
                case 2: return "Adaptation";
                case 3: return "Cloudkill";
                case 4: return "Cone of Cold";
                case 5: return "Cone of Paralysis";
                case 6: return "Conjure Elemental";
                case 7: return "Contact Other Plane";
                case 8: return "Control Undead";
                case 9: return "Curse of Swine";
                case 10: return "Enchanted Container";
                case 11: return "Feeblemind";
                case 12: return "Hold Monster";
                case 13: return "Magic Jar";
                case 14: return "Mass Infravision";
                case 15: return "Panic";
                case 16: return "Passwall";
                case 17: return "Phantasmal Killer";
                case 18: return "Protection from Normal Weapons";
                case 19: return "Scouring Wind";
                case 20: return "Telekinesis";
                case 21: return "Teleport";
                case 22: return "Transform Rock to Mud";
                case 23: return "Wall of Stone";
                case 24: return "X-Ray Vision";
            }
            return "";
        }

        private static string arcane6()
        {
            roll = rand.Next(1, 24);
            switch (roll)
            {
                case 1: return "Anti-Magic Shell";
                case 2: return "Control Plants";
                case 3: return "Control Weather";
                case 4: return "Death Spell";
                case 5: return "Detect Ritual Magic";
                case 6: return "Disintegrate";
                case 7: return "Enslave";
                case 8: return "Flesh to Stone";
                case 9: return "Geas";
                case 10: return "Globe of Invulnerability";
                case 11: return "Invisible Stalker";
                case 12: return "Lower Water";
                case 13: return "Move Earth";
                case 14: return "Oblivion";
                case 15: return "Permanent Illusion";
                case 16: return "Programmed Illusion";
                case 17: return "Projected Image";
                case 18: return "Reincarnate";
                case 19: return "Summon Djinni";
                case 20: return "Torpor";
                case 21: return "Trollblood";
                case 22: return "Wall of Corpses";
                case 23: return "Wall of Force";
                case 24: return "Wall of Iron";
            }
            return "";
        }

        private static string arcane7()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: return "Cancellation";
                case 2: return "Energy Drain";
                case 3: return "Phase Door";
                case 4: return "Spell Turning";
            }
            return "";
        }

        private static string arcane8()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: return "Opposition";
                case 2: return "Permanency";
                case 3: return "Summon Efreeti";
                case 4: return "Temporal Stasis";
            }
            return "";
        }

        private static string arcane9()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: return "Life Trapping";
                case 2: return "Plague";
                case 3: return "Undead Legion";
                case 4: return "Wish";
            }
            return "";
        }


        //*****************************DIVINE SPELLS****************************************
        private static string divine1()
        {
            roll = rand.Next(1, 11);
            switch (roll)
            {
                case 1: return "Command Word";
                case 2: return "Cure Light Wounds";
                case 3: return "Detect Evil";
                case 4: return "Detect Magic";
                case 5: return "Light";
                case 6: return "Protection from Evil";
                case 7: return "Purify Food and Water";
                case 8: return "Remove Fear";
                case 9: return "Resist Cold";
                case 10: return "Sanctuary";
            }
            return "";
        }

        private static string divine2()
        {
            roll = rand.Next(1, 11);
            switch (roll)
            {
                case 1: return "Augury";
                case 2: return "Bless";
                case 3: return "Delay Poison";
                case 4: return "Find Traps";
                case 5: return "Hold Person";
                case 6: return "Resist Fire";
                case 7: return "Righteous Wrath";
                case 8: return "Silence, 15' radius";
                case 9: return "Speak with Animals";
                case 10: return "Spiritual Weapon";
            }
            return "";
        }

        private static string divine3()
        {
            roll = rand.Next(1, 11);
            switch (roll)
            {
                case 1: return "Continual Light";
                case 2: return "Cure Blindness";
                case 3: return "Cure Disease";
                case 4: return "Feign Death";
                case 5: return "Glyph of Warding";
                case 6: return "Growth of Animals";
                case 7: return "Locate Object";
                case 8: return "Remove Curse";
                case 9: return "Speak with Dead";
                case 10: return "Striking";
            }
            return "";
        }

        private static string divine4()
        {
            roll = rand.Next(1, 11);
            switch (roll)
            {
                case 1: return "Create Water";
                case 2: return "Cure Serious Wounds";
                case 3: return "Dispel Magic";
                case 4: return "Divination";
                case 5: return "Neutralize Poison";
                case 6: return "Protection from Evil, Sustained";
                case 7: return "Smite Undead";
                case 8: return "Speak with Plants";
                case 9: return "Sticks to Snakes";
                case 10: return "Tongues";
            }
            return "";
        }

        private static string divine5()
        {
            roll = rand.Next(1, 11);
            switch (roll)
            {
                case 1: return "Atonement";
                case 2: return "Commune";
                case 3: return "Create Food";
                case 4: return "Dispel Evil";
                case 5: return "Flame Strike";
                case 6: return "Insect Plague";
                case 7: return "Quest";
                case 8: return "Restore Life and Limb";
                case 9: return "Strength of Mind";
                case 10: return "True Seeing";
            }
            return "";
        }

        private static string divine6()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: return "Forbiddance";
                case 2: return "Harvest";
                case 3: return "Longevity";
                case 4: return "Regeneration";
            }
            return "";
        }

        private static string divine7()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: return "Cataclysm";
                case 2: return "Energy Drain";
                case 3: return "Miracle";
                case 4: return "Resurrection";
            }
            return "";
        }       


    }
}
