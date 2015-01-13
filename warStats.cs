using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class warStats
    {
        //Needs to be separated into melee and ranged attacks
        static double unrAttacks = 0;
        static double unrHP = 0;
        static double unrAC = 0;
        //FORMATION TYPES
        //Loose Foot = 1
        //Formed Foot = 2
        //Irregular Foot = 3
        //Either Loose or Formed = 4
        static int formationType = -1;
        static double chargeDamage = 0;
        static double missileRange = 0;
        static double morale = 0;
        static double walkSpeed = 0;
        static double chargeSpeed = 0;

        public static void setAC(string AC)
        {
            unrAC = System.Convert.ToInt32(AC);
        }

        public static void setMorale(string baseMorale)
        {
            if (baseMorale.Contains('+'))
            {
                morale += System.Convert.ToInt32(baseMorale.Substring(baseMorale.IndexOf('+')+1));
            }
            else if (baseMorale.Contains('-'))
            {
                morale -= System.Convert.ToInt32(baseMorale.Substring(baseMorale.IndexOf('-')+1));
            }
            else if (baseMorale == "0"){
                morale = 0;
            }
            else{
                morale = -999;
            }
        }

        //Checks what is essentially a table to get the movement type and rate of the unit characteristics being passed here
        /*
         * WEAPONS ALLOWED
         * Spear and shield
         * Polearm
         * Weapon and shield
         * Spear without shield
         * Two-handed weapon
         * Dual-wielding
         * Bow
         * Crossbow
         * Dart
         * Javelin
         * Sling
         * One handed weapon without shield
         * Natural weapons
         * */

        //FORMATION TYPES
        //Loose Foot = 1
        //Formed Foot = 2
        //Irregular Foot = 3
        //Either Loose or Formed = 4
        public static string getMovement(string movement, string weapons)
        {
            if (movement == "60'")
            {
                if ((weapons == "Spear and shield") || (weapons == "Polearm"))
                {
                    formationType = 2;
                    chargeSpeed = 3;
                    chargeDamage++;
                    return ("1/2/3, Formed Foot");
                }
                else if ((weapons == "Weapon and shield") || (weapons == "Spear without shield") || (weapons == "Two-handed weapon"))
                {
                    formationType = 2;
                    chargeSpeed = 3;
                    if (weapons.Contains("Spear")) chargeDamage++;
                    return ("1/2/3, Formed Foot");
                }
                else if ((weapons == "Dual-wielding"))
                {
                    formationType = 2;
                    chargeSpeed = 3;
                    return ("1/2/3, Formed Foot");
                }
                else if ((weapons == "Bow") || (weapons == "Crossbow") || (weapons == "Dart") || (weapons == "Javelin") || (weapons == "Sling") || (weapons == "One handed weapon without shield"))
                {
                    formationType = 1;
                    chargeSpeed = 3;
                    return ("1/2/3, Loose Foot");
                }
                else if ((weapons == "Natural weapons"))
                {
                    formationType = 3;
                    chargeSpeed = 3;
                    return ("1/2/3, Irregular Foot");
                }
                else return ("Error!  Weapon type not found for weapon: " + weapons);

            }
            else if (movement == "90'")
            {
                if ((weapons == "Spear and shield") || (weapons == "Polearm"))
                {
                    formationType = 2;
                    chargeSpeed = 4;
                    chargeDamage++;
                    return ("2/3/4, Formed Foot");
                }
                else if ((weapons == "Weapon and shield") || (weapons == "Spear without shield") || (weapons == "Two-handed weapon"))
                {
                    formationType = 4;
                    chargeSpeed = 4;
                    if (weapons.Contains("Spear")) chargeDamage++;
                    return ("2/3/4, Formed Foot or Loose Foot");
                }
                else if ((weapons == "Dual-wielding"))
                {
                    formationType = 4;
                    chargeSpeed = 4;
                    return ("2/3/4, Formed Foot or Loose Foot");
                }
                else if ((weapons == "Bow") || (weapons == "Crossbow") || (weapons == "Dart") || (weapons == "Javelin") || (weapons == "Sling") || (weapons == "One handed weapon without shield"))
                {
                    formationType = 1;
                    chargeSpeed = 4;
                    return ("2/3/4, Loose Foot");
                }
                else if ((weapons == "Natural weapons"))
                {
                    formationType = 3;
                    chargeSpeed = 4;
                    return ("2/3/4, Irregular Foot");
                }
                else return ("Error!  Weapon type not found for weapon: " + weapons);
            }
            else if (movement == "120'")
            {
                if ((weapons == "Spear and shield") || (weapons == "Polearm"))
                {
                    formationType = 2;
                    chargeSpeed = 6;
                    chargeDamage++;
                    return ("2/4/6, Formed Foot");
                }
                else if ((weapons == "Weapon and shield") || (weapons == "Spear without shield") || (weapons == "Two-handed weapon"))
                {
                    formationType = 4;
                    chargeSpeed = 6;
                    if (weapons.Contains("Spear")) chargeDamage++;
                    return ("2/4/6, Formed Foot or Loose Foot");
                }
                else if ((weapons == "Dual-wielding"))
                {
                    formationType = 1;
                    chargeSpeed = 6;
                    return ("2/4/6, Loose Foot");
                }
                else if ((weapons == "Bow") || (weapons == "Crossbow") || (weapons == "Dart") || (weapons == "Javelin") || (weapons == "Sling") || (weapons == "One handed weapon without shield"))
                {
                    formationType = 1;
                    chargeSpeed = 6;
                    return ("2/4/6, Loose Foot");
                }
                else if ((weapons == "Natural weapons"))
                {
                    formationType = 3;
                    chargeSpeed = 6;
                    return ("2/4/6, Irregular Foot");
                }
                else return ("Error!  Weapon type not found for weapon: " + weapons);
            }
            else
            {
                return ("Error in movement!  Movement rate not found for movement:" + movement);
            }
        }

        //Checks if the string passed is a legitimate number to be used for AC or HD
        //All it does is check if it's beteen -10 and 40, to make sure that a number was actually entered
        public static string validateAC(string AC)
        {
            int checker = System.Convert.ToInt32(AC);
            if ((checker < -10) || (checker > 40))
            {
                return ("Error!  Number passed was below -10 or above 40.  Probably not a number at all.");
            }
            else return AC;
        }

        public static string validateHD(string HD)
        {
            if (HD.Contains('-'))
            {
                //Substring everything before the minus sign
                //Convert everything before and everything after (noninclusive) to doubles
                //Subtract .25 * after from before
                //Convert back to string and return it

                string baseHD = HD.Substring(0, HD.IndexOf('-'));
                string modifier = HD.Substring(HD.IndexOf('-') + 1);
                double hdBase = System.Convert.ToDouble(baseHD);
                double mod = System.Convert.ToDouble(modifier);
                double final = hdBase - (0.25 * mod);
                return System.Convert.ToString(final);
            }
            else if (HD.Contains('+'))
            {
                string baseHD = HD.Substring(0, HD.IndexOf('+'));
                string modifier = HD.Substring(HD.IndexOf('+') + 1);
                double hdBase = System.Convert.ToDouble(baseHD);
                double mod = System.Convert.ToDouble(modifier);
                double final = hdBase + (0.25 * mod);
                return System.Convert.ToString(final);
            }
            else return validateAC(HD);
        }

        public static string getUnitHP(string HD, string size)
        {
            int numCreatures = getNumCreatures(size);
            double creatureHD = System.Convert.ToDouble(HD);
            double value = (numCreatures * creatureHD) / 15;
            unrHP = value;
            return System.Convert.ToString(Math.Round(value));
        }

        //Unit's Number of Attacks = (Number of Creatures * (Number of Attacks + Cleave Factor) * Average Damage)/Size Factor * 4.5
        public static string getNumAttacks(string HD, string size, string attacks, string avgDamage)
        {
            int numCreatures = getNumCreatures(size);
            int numAttacks = System.Convert.ToInt32(attacks);
            double hd = System.Convert.ToDouble(HD);
            double cleave = getCleaveFactor(hd);
            double avgDam = System.Convert.ToDouble(avgDamage);
            int sizeFactor = getSizeFactor(size);

            double finalNumber = ((numCreatures * (numAttacks + cleave) * avgDam) / (sizeFactor * 4.5));

            unrAttacks = finalNumber;
            return System.Convert.ToString(Math.Round(finalNumber));
        }
       
        /*
         * SIZES
         * Man-sized
         * Large
         * Huge
         * Gigantic
         * Colossal*/
        private static int getNumCreatures(string size)
        {
            if (size == "Man-sized")
                return 120;
            else if (size == "Large")
                return 60;
            else if (size == "Huge")
                return 20;
            else if (size == "Gigantic")
                return 5;
            else if (size == "Colossal")
                return 1;
            else return -1;
        }

        private static double getCleaveFactor(double HD)
        {
            if (HD < 1.25)
            {
                return 0.35;
            }
            else if (HD < 2.25)
            {
                return 0.5;
            }
            else if (HD < 3.25)
            {
                return 0.65;
            }
            else if (HD < 4.25)
            {
                return 0.85;
            }
            else if (HD < 5.25)
            {
                return 1.10;
            }
            else if (HD < 6.25)
            {
                return 1.40;
            }
            else if (HD < 7.25)
            {
                return 1.75;
            }
            else if (HD < 8.25)
            {
                return 2.15;
            }
            else if (HD < 9.25)
            {
                return 2.70;
            }
            else if (HD < 10.25)
            {
                return 3.33;
            }
            else if (HD >= 10.25) return 4.15;
            else return -1;
        }

        private static int getSizeFactor(string size)
        {
            if (size == "Man-sized")
                return 60;
            else if (size == "Large")
                return 40;
            else if (size == "Huge")
                return 30;
            else if (size == "Gigantic")
                return 20;
            else if (size == "Colossal")
                return 10;
            else return -1;
        }

        //FORMULA FOR BR
        //(AC * UHP/8 * Morale Multiplier * Speed Multiplier * Formation Multiplier * Combat Multiplier) / 6
        public static string getBattleRating()
        {
            double br = 0;
            if (formationType != 4)
            {
                br = ((unrAC * (unrHP / 8) * moraleMultiplier() * speedMultiplier() * formationMultiplier() * combatMultiplier()) / 6);
                br = Math.Round(br, 2);
                return System.Convert.ToString(br);
            }
            else
            {
                return "";
            }
        }

        //Square root of (morale + 7)/7
        private static double moraleMultiplier()
        {
            return Math.Sqrt((morale + 7) / 7);
        }

        //Charge move/7.5 raised to the .33
        private static double speedMultiplier()
        {
            return Math.Pow((chargeSpeed / 7.5), .33);
        }

        //Based off chart
        //FF 1.15, IF 0.675, LF 1
        //1 loose, 2 formed, 3 irregular
        private static double formationMultiplier()
        {
            if (formationType == 1)
            {
                return 1;
            }
            else if (formationType == 2)
            {
                return 1.15;
            }
            else if (formationType == 3)
            {
                return 0.675;
            }
            else return -1;
        }

        //Unrounded number of melee attacks/rounded number of melee attacks * max damage during a charge
        //Max damage during a charge is rounded number of attacks, plus charge bonus damage
        private static double combatMultiplier()
        {
            return ((unrAttacks / Math.Round(unrAttacks)) * (chargeDamage + Math.Round(unrAttacks)));
        }




    }
}
