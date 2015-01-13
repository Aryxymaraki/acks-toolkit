using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class gems
    {
        static Random rand = new Random(Guid.NewGuid().GetHashCode());
        static int roll;


        public static void GenerateOrnamentals(int number)
        {
            int value = 0;
            string gemType = "";

            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 21) + rand.Next(1, 21);
                if (roll < 11)
                {
                    value = 10;
                    treasure.value += 10;
                    gemType = tenGPType();
                }
                else if (roll < 26)
                {
                    value = 25;
                    treasure.value += 25;
                    gemType = twentyfiveGPType();
                }
                else
                {
                    gemType = fiftyGPType();
                    value = 50;
                    treasure.value += 50;

                }
                Form1.writeToBoth(value + " GP " + gemType + ".");
            }

        }

        public static void GenerateGems(int number)
        {
            int value = 0;
            string gemType = "";

            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 11)
                {
                    value = 10;
                    treasure.value += 10;
                    gemType = tenGPType();
                }
                else if (roll < 26)
                {
                    value = 25;
                    treasure.value += 25;
                    gemType = twentyfiveGPType();
                }
                else if (roll < 41)
                {
                    treasure.value += 50;
                    gemType = fiftyGPType();
                    value = 50;

                }
                else if (roll < 56)
                {
                    value = 75;
                    treasure.value += 75;
                    gemType = seventyfiveGPType();
                }
                else if (roll < 71)
                {
                    value = 100;
                    treasure.value += 100;
                    gemType = hundredGPType();
                }
                else if (roll < 81)
                {
                    value = 250;
                    treasure.value += 250;
                    gemType = twofiftyGPType();
                }
                else if (roll < 91)
                {
                    value = 500;
                    treasure.value += 500;
                    gemType = fivehundredGPType();
                }
                else if (roll < 96)
                {
                    value = 750;
                    treasure.value += 750;
                    gemType = sevenfiftyGPType();
                }
                else
                {
                    value = 1000;
                    treasure.value += 1000;
                    gemType = thousandGPType();
                }
                Form1.writeToBoth(value + " GP " + gemType + ".");
            }
        }

        public static void GenerateBrilliants(int number)
        {
            int value = 0;
            string gemType = "";


            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 101) + 80;
                if (roll < 91)
                {
                    value = 500;
                    treasure.value += 500;
                    gemType = fivehundredGPType();
                }
                else if (roll < 96)
                {
                    value = 750;
                    treasure.value += 750;
                    gemType = sevenfiftyGPType();
                }
                else if (roll < 101)
                {
                    value = 1000;
                    treasure.value += 1000;
                    gemType = thousandGPType();
                }
                else if (roll < 111)
                {
                    value = 1500;
                    treasure.value += 1500;
                    gemType = fifteenhundredGPType();
                }
                else if (roll < 126)
                {
                    value = 2000;
                    treasure.value += 2000;
                    gemType = twothousandGPType();
                }
                else if (roll < 146)
                {
                    value = 4000;
                    treasure.value += 4000;
                    gemType = fourthousandGPType();
                }
                else if (roll < 166)
                {
                    value = 6000;
                    treasure.value += 6000;
                    gemType = sixthousandGPType();
                }
                else if (roll < 176)
                {
                    value = 8000;
                    treasure.value += 8000;
                    gemType = eightthousandGPType();
                }
                else
                {
                    value = 10000;
                    treasure.value += 10000;
                    gemType = tenthousandGPType();
                }

                Form1.writeToBoth(value + " GP " + gemType + ".");
            }

        }

        private static string tenGPType()
        {
            roll = rand.Next(1, 5);
            string gemType = "";
            switch (roll)
            {
                case 1:
                    gemType = "azurite";
                    break;
                case 2:
                    gemType = "hematite";
                    break;
                case 3:
                    gemType = "malachite";
                    break;
                case 4:
                    gemType = "obsidian";
                    break;
                case 5:
                    gemType = "quartz";
                    break;
            }
            return gemType;
        }

        private static string twentyfiveGPType()
        {
            roll = rand.Next(1, 5);
            string gemType = "";
            switch (roll)
            {
                case 1:
                    gemType = "agate";
                    break;
                case 2:
                    gemType = "lapis lazuli";
                    break;
                case 3:
                    gemType = "tiger eye";
                    break;
                case 4:
                    gemType = "turquoise";
                    break;
            }
            return gemType;
        }

        private static string fiftyGPType()
        {
            roll = rand.Next(1, 7);
            string gemType = "";
            switch (roll)
            {
                case 1:
                    gemType = "bloodstone";
                    break;
                case 2:
                    gemType = "crystal";
                    break;
                case 3:
                    gemType = "citrine";
                    break;
                case 4:
                    gemType = "jasper";
                    break;
                case 5:
                    gemType = "moonstone";
                    break;
                case 6:
                    gemType = "onyx";
                    break;
            }
            return gemType;
        }

        private static string seventyfiveGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    gemType = "carnelian";
                    break;
                case 2:
                    gemType = "chalcedony";
                    break;
                case 3:
                    gemType = "sardonyx";
                    break;
                case 4:
                    gemType = "zircon";
                    break;
            }
            return gemType;
        }

        private static string hundredGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 7);
            switch (roll)
            {
                case 1:
                    gemType = "amber";
                    break;
                case 2:
                    gemType = "amethyst";
                    break;
                case 3:
                    gemType = "coral";
                    break;
                case 4:
                    gemType = "jade";
                    break;
                case 5:
                    gemType = "jet";
                    break;
                case 6:
                    gemType = "tourmaline";
                    break;
            }
            return gemType;
        }

        private static string twofiftyGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    gemType = "garnet";
                    break;
                case 2:
                    gemType = "pearl";
                    break;
                case 3:
                    gemType = "spinel";
                    break;
            }
            return gemType;
        }

        private static string fivehundredGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1:
                    gemType = "aquamarine";
                    break;
                case 2:
                    gemType = "alexandrite";
                    break;
                case 3:
                    gemType = "topaz";
                    break;
            }
            return gemType;
        }

        private static string sevenfiftyGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    gemType = "opal";
                    break;
                case 2:
                    gemType = "star ruby";
                    break;
                case 3:
                    gemType = "star sapphire";
                    break;
                case 4:
                    gemType = "sunset amethyst";
                    break;
                case 5:
                    gemType = "imperial topaz";
                    break;
            }
            return gemType;
        }

        private static string thousandGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    gemType = "black sapphire";
                    break;
                case 2:
                    gemType = "diamond";
                    break;
                case 3:
                    gemType = "emerald";
                    break;
                case 4:
                    gemType = "jacinth";
                    break;
                case 5:
                    gemType = "ruby";
                    break;
            }
            return gemType;
        }

        private static string fifteenhundredGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 3);
            if (roll == 1) gemType = "amber with preserved extinct creatures";
            else gemType = "whorled nephrite jade";
            return gemType;
        }

        private static string twothousandGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 4);
            switch (roll)
            {
                case 1: gemType = "black pearl"; break;
                case 2: gemType = "baroque pearl"; break;
                case 3: gemType = "crystal geode"; break;
            }
            return gemType;
        }

        private static string fourthousandGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 3);
            if (roll == 1) gemType = "facet cut imperial topaz";
            else gemType = "flawless diamond";
            return gemType;
        }

        private static string sixthousandGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 3);
            if (roll == 1) gemType = "facet cut star sapphire";
            else gemType = "facet cut star ruby";
            return gemType;
        }

        private static string eightthousandGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1: gemType = "flawless facet cut diamond"; break;
                case 2: gemType = "flawless facet cut emerald"; break;
                case 3: gemType = "flawless facet cut jacinth"; break;
                case 4: gemType = "flawless facet cut ruby"; break;
            }
            return gemType;
        }

        private static string tenthousandGPType()
        {
            string gemType = "";
            roll = rand.Next(1, 3);
            if (roll == 1) gemType = "flawless facet cut black sapphire";
            else gemType = "flawless facet cut blue diamond";
            return gemType;
        }

    }
}
