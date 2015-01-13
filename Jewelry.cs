using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class jewelry
    {
        static Random rand = new Random(Guid.NewGuid().GetHashCode());
        static int roll;

        public static void GenerateTrinkets(int number)
        {
            string trinketType = "";
            int value = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 21) + rand.Next(1, 21);
                if (roll < 11)
                {
                    value = rand.Next(1, 21) + rand.Next(1, 21);
                    treasure.value += value;
                    trinketType = type1Jewel();
                }
                else if (roll < 26)
                {
                    value = 10 * (rand.Next(1, 11) + rand.Next(1, 11));
                    treasure.value += value;
                    trinketType = type2Jewel();
                }
                else
                {
                    value = 100 * (rand.Next(1, 5) + rand.Next(1, 5));
                    treasure.value += value;
                    trinketType = type3Jewel();
                }
                Form1.writeToBoth("A piece of jewelry constructed from " + trinketType + " worth " + value + " GP.");
            }
        }
        public static void GenerateJewelry(int number)
        {
            string trinketType = "";
            int value = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 11)
                {
                    value = rand.Next(1, 21) + rand.Next(1, 21);
                    treasure.value += value;
                    trinketType = type1Jewel();
                }
                else if (roll < 26)
                {
                    value = 10 * (rand.Next(1, 11) + rand.Next(1, 11));
                    treasure.value += value;
                    trinketType = type2Jewel();
                }
                else if (roll < 41)
                {
                    value = 100 * (rand.Next(1, 5) + rand.Next(1, 5));
                    treasure.value += value;
                    trinketType = type3Jewel();
                }
                else if (roll < 71)
                {
                    value = 100 * (rand.Next(1, 7) + rand.Next(1, 7));
                    treasure.value += value;
                    trinketType = type4Jewel();
                }
                else if (roll < 81)
                {
                    value = 100 * (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
                    treasure.value += value;
                    trinketType = type5Jewel();
                }
                else if (roll < 96)
                {
                    value = 1000 * (rand.Next(1, 5));
                    treasure.value += value;
                    trinketType = type6Jewel();
                }
                else
                {
                    value = 1000 * (rand.Next(1, 5) + rand.Next(1, 5));
                    treasure.value += value;
                    trinketType = type7Jewel();
                }
                Form1.writeToBoth("A piece of jewelry constructed from " + trinketType + " worth " + value + " GP.");
            }
        }

        public static void GenerateRegalia(int number)
        {
            string type = "";
            int value = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101) + 80;
                if (roll < 96)
                {
                    value = (rand.Next(1, 5)) * 1000;
                    treasure.value += value;
                    type = type6Jewel();
                }
                else if (roll < 101)
                {
                    value = (rand.Next(1, 5) + rand.Next(1, 5)) * 1000;
                    treasure.value += value;
                    type = type7Jewel();
                }
                else if (roll < 126)
                {
                    type = type8Jewel();
                    value = (rand.Next(1, 5) + rand.Next(1, 5) + rand.Next(1, 5)) * 1000;
                    treasure.value += value;
                }
                else if (roll < 146)
                {
                    type = type9Jewel();
                    value = (rand.Next(1, 9) + rand.Next(1, 9)) * 1000;
                    treasure.value += value;
                }
                else if (roll < 156)
                {
                    type = type10Jewel();
                    value = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)) * 1000;
                    treasure.value += value;
                }
                else if (roll < 166)
                {
                    type = type11Jewel();
                    value = (rand.Next(1, 21) + rand.Next(1, 21)) * 1000;
                    treasure.value += value;
                }
                else if (roll < 176)
                {
                    type = type12Jewel();
                    value = (rand.Next(1, 5)) * 10000;
                    treasure.value += value;
                }
                else
                {
                    type = type13Jewel();
                    value = (rand.Next(1, 9)) * 10000;
                    treasure.value += value;
                }
                Form1.writeToBoth("A piece of jewelry constructed from " + type + " worth " + value + " GP.");
            }

        }

        private static string type1Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    jewelType = "bone";
                    break;
                case 2:
                    jewelType = "scrimshaw";
                    break;
                case 3:
                    jewelType = "beast parts";
                    break;
            }
            return jewelType;
        }

        private static string type2Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    jewelType = "glass";
                    break;
                case 2:
                    jewelType = "shells";
                    break;
                case 3:
                    jewelType = "wrought copper";
                    break;
                case 4:
                    jewelType = "wrought brass";
                    break;
                case 5:
                    jewelType = "wrought bronze";
                    break;
            }
            return jewelType;
        }

        private static string type3Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    jewelType = "fine wood";
                    break;
                case 2:
                    jewelType = "porcelain";
                    break;
                case 3:
                    jewelType = "wrought silver";
                    break;
            }
            return jewelType;
        }

        private static string type4Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    jewelType = "alabaster";
                    break;
                case 2:
                    jewelType = "chryselephantine";
                    break;
                case 3:
                    jewelType = "ivory";
                    break;
                case 4:
                    jewelType = "wrought gold";
                    break;
            }
            return jewelType;
        }

        private static string type5Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 3);
            switch (roll)
            {
                case 1:
                    jewelType = "carved jade";
                    break;
                case 2:
                    jewelType = "wrought platinum";
                    break;
            }
            return jewelType;
        }

        private static string type6Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    jewelType = "wrought orichalcum";
                    break;
                case 2:
                    jewelType = "silver studded with turquoise";
                    break;
                case 3:
                    jewelType = "silver studded with moonstone";
                    break;
                case 4:
                    jewelType = "silver studded with opal";
                    break;
            }
            return jewelType;
        }

        private static string type7Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    jewelType = "silver studded with jet";
                    break;
                case 2:
                    jewelType = "silver studded with amber";
                    break;
                case 3:
                    jewelType = "silver studded with pearl";
                    break;
            }
            return jewelType;
        }

        private static string type8Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    jewelType = "gold studded with topaz";
                    break;
                case 2:
                    jewelType = "gold studded with jacinth";
                    break;
                case 3:
                    jewelType = "gold studded with ruby";
                    break;
            }
            return jewelType;
        }

        private static string type9Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    jewelType = "platinum studded with diamond";
                    break;
                case 2:
                    jewelType = "platinum studded with sapphire";
                    break;
                case 3:
                    jewelType = "platinum studded with emerald";
                    break;
            }
            return jewelType;
        }

        private static string type10Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 3);
            switch (roll)
            {
                case 1:
                    jewelType = "electrum studded with pearls and star rubies";
                    break;
                case 2:
                    jewelType = "silver studded with pearl and star rubies";
                    break;
            }
            return jewelType;
        }

        private static string type11Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    jewelType = "gold studded with diamonds";
                    break;
                case 2:
                    jewelType = "gold studded with sapphires";
                    break;
                case 3:
                    jewelType = "platinum studded with diamonds";
                    break;
                case 4:
                    jewelType = "platinum studded with sapphries";
                    break;
            }
            return jewelType;
        }

        private static string type12Jewel()
        {
            string jewelType = "";
            jewelType = "gold encrusted with flawless facet cut diamonds";
            return jewelType;
        }

        private static string type13Jewel()
        {
            string jewelType = "";
            roll = rand.Next(1, 3);
            switch (roll)
            {
                case 1:
                    jewelType = "platinum encrusted with flawless black sapphires";
                    break;
                case 2:
                    jewelType = "platinum encrusted with flawless blue diamonds";
                    break;
            }
            return jewelType;
        }


    }
}
