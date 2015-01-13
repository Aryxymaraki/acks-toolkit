using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class treasure
    {
        private static Random rand = new Random(Guid.NewGuid().GetHashCode());
        private static int roll;
        public static double value, weight;
        static bool success;

        public static void RollTreasure(string type)
        {
            value = 0;
            weight = 0;
            double totalValue = 0, totalWeight = 0;
            for (int i = 0; i < type.Length; i++)
            {
                Form1.writeToBoth("This room contains a type " + type.Substring(i, 1) + " treasure.");
                switch (type.Substring(i, 1))
                {
                    case "A":
                        typeA();
                        break;
                    case "B":
                        typeB();
                        break;
                    case "C":
                        typeC();
                        break;
                    case "D":
                        typeD();
                        break;
                    case "E":
                        typeE();
                        break;
                    case "F":
                        typeF();
                        break;
                    case "G":
                        typeG();
                        break;
                    case "H":
                        typeH();
                        break;
                    case "I":
                        typeI();
                        break;
                    case "J":
                        typeJ();
                        break;
                    case "K":
                        typeK();
                        break;
                    case "L":
                        typeL();
                        break;
                    case "M":
                        typeM();
                        break;
                    case "N":
                        typeN();
                        break;
                    case "O":
                        typeO();
                        break;
                    case "P":
                        typeP();
                        break;
                    case "Q":
                        typeQ();
                        break;
                    case "R":
                        typeR();
                        break;

                }
                if (success)
                {
                    if (type.Length > 1)
                    {
                        Form1.writeToBoth("");
                        Form1.writeToBoth("The total value of this sub-hoard (excluding any magic) is " + value + " gp and its total weight is " + weight + " stone.");
                        Form1.writeToBoth("");
                    }
                    else
                    {
                        Form1.writeToBoth("");
                    }
                }
                else
                {
                    Form1.writeToBoth("");
                }
                totalValue += value;
                totalWeight += weight;
                value = 0;
                weight = 0;

            }
            //output total value and weight
            Form1.writeToBoth("The total value of this hoard (excluding any magic) is " + totalValue + " gp and its total weight is " + totalWeight + " stone.");
            Form1.writeToBoth("");
            Form1.writeToBoth("");
        }//End of RollTreasure

        private static void typeA()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll == 1)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeB()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            //Check for magic items
            roll = rand.Next(1, 101);
            success = true;
            if (roll < 6)
            {
                magicTreasure.GenerateMagicItems(2);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeC()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 16)
            {
                roll = rand.Next(1, 5);
                thousandEP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand electrum pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
               // gems.GenerateGems(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 7);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll < 6)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeD()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            roll = rand.Next(1, 101);
            if (roll < 21)
            {
                roll = rand.Next(1, 5);
                thousandEP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand electrum pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll < 16)
            {
                magicTreasure.GenerateMagicItems(2);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeE()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 11) + rand.Next(1, 11);
                thousandCP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand copper pieces.");
            }
            roll = rand.Next(1, 101);
            if (roll < 8)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 5);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            //Check for magic items
            roll = rand.Next(1, 101);
            //15% 1 sword, weapon, or armor
            if (roll < 16)
            {
                magicTreasure.GenerateMagicEquipment(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            //15% 1 potion
            if (roll < 16)
            {
                magicTreasure.GeneratePotion(1);
                success = true;
            }
            //5% any 1
            roll = rand.Next(1, 101);
            if (roll < 6)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeF()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            roll = rand.Next(1, 101);
            if (roll < 16)
            {
                roll = rand.Next(1, 5);
                thousandGP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand gold pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
                //gems.GenerateGems(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
                //jewelry.GenerateJewelry(roll);
            }
            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll < 8)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeG()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 21) + rand.Next(1, 21);
                thousandCP(roll);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandSP(roll);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 5);
                thousandEP(roll);
                success = true;
            }


            //Check for gems

            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                perOrnamental(roll);
                success = true;
            }

            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                perTrinket(roll);
                success = true;
            }

            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                magicTreasure.GenerateMagicEquipment(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                magicTreasure.GeneratePotion(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 11)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeH()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 7);
                thousandSP(roll);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 7);
                thousandEP(roll);
                success = true;
            }

            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                perTrinket(roll);
                success = true;
            }

            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                magicTreasure.GenerateMagicItems(3);
                magicTreasure.GeneratePotion(1);
                magicTreasure.GenerateScroll(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeI()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 5);
                thousandSP(roll);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }

            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 5) + rand.Next(1, 5);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 9);
                perJewelry(roll);
                success = true;
            }

            //Check for magic items
            roll = rand.Next(1, 101);
            if (roll < 21)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeJ()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandCP(roll);
                success = true;
            }

            //70% 2d20 sp
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 21) + rand.Next(1, 21);
                thousandSP(roll);
                success = true;
            }
            //70% 1d8 ep
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 9);
                thousandEP(roll);
                success = true;
            }

            //Check for gems
            //50% 1d6 gems
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            //50% 1d8 trinkets
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 9);
                perTrinket(roll);
                success = true;
            }

            //Check for magic items
            //50% 1 equipment; 45% 1 potion; 20% any 1
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                magicTreasure.GenerateMagicEquipment(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 45)
            {
                magicTreasure.GeneratePotion(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 21)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeK()
        {
            success = false;
            //Check for coins
            //30% 1d4 electrum
            //25% 1d6 gold
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                thousandEP(roll);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }

            //Check for gems
            //25% 1d4 brilliants
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 5);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //50% 1d4 jewelry
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
            }

            //Check for magic items
            //40% any 1
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeL()
        {
            success = false;
            //Check for coins
            //40% 3d6 copper
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandCP(roll);
                success = true;
            }
            //60% 2d10 silver
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 11) + rand.Next(1, 11);
                thousandSP(roll);
                success = true;
            }
            //75% 3d6 electrum
            roll = rand.Next(1, 101);
            if (roll < 76)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandEP(roll);
                success = true;
            }

            //Check for gems
            //60% 1d6 gems
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            //40% 1d4 jewelry
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
            }

            //Check for magic items
            //75% 1 equipment; 75% 1 potion; 30% any 1
            roll = rand.Next(1, 101);
            if (roll < 76)
            {
                magicTreasure.GenerateMagicEquipment(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 76)
            {
                magicTreasure.GeneratePotion(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                magicTreasure.GenerateMagicItems(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeM()
        {
            success = false;
            //Check for coins
            //25% 1d4 electrum
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 5);
                thousandEP(roll);
                success = true;
            }
            //15% 1d4 platinum
            roll = rand.Next(1, 101);
            if (roll < 16)
            {
                roll = rand.Next(1, 5);
                thousandPP(roll);
                success = true;
            }

            //Check for gems
            //30% 1d6 brilliants
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 7);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //50% 1d6 jewelry
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                perJewelry(roll);
                success = true;
            }

            //Check for magic items
            //30% any 2
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                magicTreasure.GenerateMagicItems(2);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeN()
        {
            success = false;
            //Check for coins
            //60% 1d8 silver
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 9);
                thousandSP(roll);
                success = true;
            }
            //60% 2d4 electrum
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5) + rand.Next(1, 5);
                thousandEP(roll);
                success = true;
            }
            //80% 1d6 gold
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }

            //Check for gems
            //80% 1d8 gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 9);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            //80% 1d8 jewelry
            roll = rand.Next(1, 9);
            if (roll < 81)
            {
                roll = rand.Next(1, 9);
                perJewelry(roll);
                success = true;
            }

            //Check for magic items
            //50% any 4 + 1 potion + 1 scroll
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                magicTreasure.GenerateMagicItems(4);
                magicTreasure.GeneratePotion(1);
                magicTreasure.GenerateScroll(1);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void typeO()
        {
            success = false;
            //Check for coins
            //30% 3d6 copper
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandCP(roll);
                success = true;
            }
            //50% 3d6 silver
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandSP(roll);
                success = true;
            }
            //60% 3d6 electrum
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandEP(roll);
                success = true;
            }
            //60% 2d6 gold
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }

            //Check for gems
            //30% 1d4 brilliants
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //60% 1d4 jewelry
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
            }

            //Check for magic items
            //75% 1 equipment; 75% 2 potions; 50% any 2
            roll = rand.Next(1, 101);
            if (roll < 76)
            {
                magicTreasure.GenerateMagicEquipment(1);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 76)
            {
                magicTreasure.GeneratePotion(2);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                magicTreasure.GenerateMagicItems(2);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeP()
        {
            success = false;
            //Check for coins
            //30% 1d4 gold
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                thousandGP(roll);
                success = true;
            }
            //30% 1d4 platinum
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                thousandPP(roll);
                success = true;
            }

            //Check for gems
            //40% 1d4 brilliants
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 5);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //30% 1d4 regalia
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perRegalia(roll);
                success = true;
            }

            //Check for magic items
            //40% any 3
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                magicTreasure.GenerateMagicItems(3);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeQ()
        {
            success = false;
            //Check for coins
            //50% 1d8 electrum
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 9);
                thousandEP(roll);
                success = true;
            }
            //80% 2d6 gold
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }
            //40% 1d4 platinum
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 5);
                thousandPP(roll);
                success = true;
            }

            //Check for gems
            //60% 1d6 brilliants
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //80% 1d4 jewelry
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
            }
            
            //Check for magic items
            //1d4 potions; 1d4 scrolls; 50% any 6
            roll = rand.Next(1, 101);
            magicTreasure.GeneratePotion(rand.Next(1, 5));
            magicTreasure.GenerateScroll(rand.Next(1, 5));
            if (roll < 51) magicTreasure.GenerateMagicItems(6);
            success = true;
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        private static void typeR()
        {
            //Check for coins
            //50% 1d6 electrum
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                thousandEP(roll);
            }
            //60% 1d6 gold
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7);
                thousandGP(roll);
            }
            //80% 1d8 platinum
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 9);
                thousandPP(roll);
            }

            //Check for gems
            //70% 1d4 brilliants
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                perBrilliant(roll);
            }

            //Check for jewelry
            //60% 1d4 regalia
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5);
                perRegalia(roll);
            }

            //Check for magic items
            //2d4 potions; 2d4 scrolls; 75% 1d3 of each category (swords, armor, misc weapon, wand/staff/rod, misc magic, ring)
            magicTreasure.GeneratePotion((rand.Next(1, 5) + rand.Next(1, 5)));
            magicTreasure.GenerateScroll((rand.Next(1, 5) + rand.Next(1, 5)));
            roll = rand.Next(1, 101);
            if (roll < 75) magicTreasure.GenerateSword(rand.Next(1, 4));
            roll = rand.Next(1, 101);
            if (roll < 75) magicTreasure.GenerateArmor(rand.Next(1, 4));
            roll = rand.Next(1, 101);
            if (roll < 75) magicTreasure.GenerateMiscWeapon(rand.Next(1, 4));
            roll = rand.Next(1, 101);
            if (roll < 75) magicTreasure.GenerateRodStaffWand(rand.Next(1, 4));
            roll = rand.Next(1, 101);
            if (roll < 75) magicTreasure.GenerateMisc(rand.Next(1, 4));
            roll = rand.Next(1, 101);
            if (roll < 75) magicTreasure.GenerateRing(rand.Next(1, 4));



        }


        public static void NPCTreasureBQuarter()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                roll = (int)Math.Truncate((double)roll / 4);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                roll = (int)Math.Truncate((double)roll / 4);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                roll = (int)Math.Truncate((double)roll / 4);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureBHalf()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                roll = (int)Math.Truncate((double)roll / 2);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                roll = (int)Math.Truncate((double)roll / 2);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                roll = (int)Math.Truncate((double)roll / 2);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureB()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                thousandSP(roll);
                success = true;
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                perOrnamental(roll);
                success = true;
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perTrinket(roll);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureDHalf()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                roll = (int)Math.Truncate((double)roll / 2);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            roll = rand.Next(1, 101);
            if (roll < 21)
            {
                roll = rand.Next(1, 5);
                roll = (int)Math.Truncate((double)roll / 2);
                thousandEP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand electrum pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                roll = (int)Math.Truncate((double)roll / 2);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                roll = (int)Math.Truncate((double)roll / 2);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureD()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                thousandSP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand silver pieces.");
            }
            roll = rand.Next(1, 101);
            if (roll < 21)
            {
                roll = rand.Next(1, 5);
                thousandEP(roll);
                success = true;
                //Form1.writeToBoth(roll + " thousand electrum pieces.");
            }
            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                perOrnamental(roll);
                success = true;
                //gems.GenerateOrnamentals(roll);
            }
            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                perTrinket(roll);
                success = true;
                //jewelry.GenerateTrinkets(roll);
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureH()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 26)
            {
                roll = rand.Next(1, 7);
                thousandSP(roll);
                success = true;
            }
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 7);
                thousandEP(roll);
                success = true;
            }

            //Check for gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                perTrinket(roll);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureJ()
        {
            success = false;
            //Check for coins
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandCP(roll);
                success = true;
            }

            //70% 2d20 sp
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 21) + rand.Next(1, 21);
                thousandSP(roll);
                success = true;
            }
            //70% 1d8 ep
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 9);
                thousandEP(roll);
                success = true;
            }

            //Check for gems
            //50% 1d6 gems
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            //50% 1d8 trinkets
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 9);
                perTrinket(roll);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureN()
        {
            success = false;
            //Check for coins
            //60% 1d8 silver
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 9);
                thousandSP(roll);
                success = true;
            }
            //60% 2d4 electrum
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5) + rand.Next(1, 5);
                thousandEP(roll);
                success = true;
            }
            //80% 1d6 gold
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }

            //Check for gems
            //80% 1d8 gems
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 9);
                perGem(roll);
                success = true;
            }

            //Check for jewelry
            //80% 1d8 jewelry
            roll = rand.Next(1, 9);
            if (roll < 81)
            {
                roll = rand.Next(1, 9);
                perJewelry(roll);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureO()
        {
            success = false;
            //Check for coins
            //30% 3d6 copper
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandCP(roll);
                success = true;
            }
            //50% 3d6 silver
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandSP(roll);
                success = true;
            }
            //60% 3d6 electrum
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                thousandEP(roll);
                success = true;
            }
            //60% 2d6 gold
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }

            //Check for gems
            //30% 1d4 brilliants
            roll = rand.Next(1, 101);
            if (roll < 31)
            {
                roll = rand.Next(1, 5);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //60% 1d4 jewelry
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureQ()
        {
            success = false;
            //Check for coins
            //50% 1d8 electrum
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 9);
                thousandEP(roll);
                success = true;
            }
            //80% 2d6 gold
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 7) + rand.Next(1, 7);
                thousandGP(roll);
                success = true;
            }
            //40% 1d4 platinum
            roll = rand.Next(1, 101);
            if (roll < 41)
            {
                roll = rand.Next(1, 5);
                thousandPP(roll);
                success = true;
            }

            //Check for gems
            //60% 1d6 brilliants
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7);
                perBrilliant(roll);
                success = true;
            }

            //Check for jewelry
            //80% 1d4 jewelry
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 5);
                perJewelry(roll);
                success = true;
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }

        public static void NPCTreasureR()
        {
            success = false;
            //Check for coins
            //50% 1d6 electrum
            roll = rand.Next(1, 101);
            if (roll < 51)
            {
                roll = rand.Next(1, 7);
                thousandEP(roll);
                success = true;
            }
            //60% 1d6 gold
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 7);
                success = true;
                thousandGP(roll);
            }
            //80% 1d8 platinum
            roll = rand.Next(1, 101);
            if (roll < 81)
            {
                roll = rand.Next(1, 9);
                success = true;
                thousandPP(roll);
            }

            //Check for gems
            //70% 1d4 brilliants
            roll = rand.Next(1, 101);
            if (roll < 71)
            {
                roll = rand.Next(1, 5);
                success = true;
                perBrilliant(roll);
            }

            //Check for jewelry
            //60% 1d4 regalia
            roll = rand.Next(1, 101);
            if (roll < 61)
            {
                roll = rand.Next(1, 5);
                success = true;
                perRegalia(roll);
            }
            if (!success) Form1.writeToBoth("Null treasure.");
        }



        private static void thousandCP(int number)
        {
            int thousands = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 21);
                if (roll == 1)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " rugs or tapestries, each worth 5 gp and weighing 2d6 stone.");
                    for (int j = 0; j < roll; j++)
                    {
                        value += 5;
                        weight += (rand.Next(1, 7) + rand.Next(1, 7));
                    }
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " barrels of preserved fish, each worth 5 gp and weighing 8 stone.");
                    value += (5 * roll);
                    weight += (8 * roll);
                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " tenths of a cord of hardwood, each worth 5 gp and weighing 8 stone.");
                    value += (5 * roll);
                    weight += (8 * roll);
                }
                else if (roll == 4)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " barrels of beer, each worth 10 gp and weighing 10 stone.");
                    value += (10 * roll);
                    weight += (10 * roll);
                }
                else if (roll == 5)
                {
                    roll = (rand.Next(1, 7) + rand.Next(1, 7));
                    Form1.writeToBoth(roll + " bricks of salt, each worth 7 sp and weighing 1/2 stone.");
                    value += (.7 * roll);
                    weight += (.5 * roll);
                }
                else if (roll == 6)
                {
                    roll = (rand.Next(1, 5) + rand.Next(1, 5));
                    Form1.writeToBoth(roll + " gallons of lamp oil, each worth 2 gp and weighing 1/2 stone.");
                    value += (2 * roll);
                    weight += (.5 * roll);
                }
                else if (roll == 7)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " rolls of cloth, each worth 10 gp and weighing 4 stone.");
                    value += (10 * roll);
                    weight += (4 * roll);
                }
                else if (roll == 8)
                {
                    roll = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
                    Form1.writeToBoth(roll + " ingots of common metal, each worth 1 gp and weighing 1/2 stone.");
                    value += (roll);
                    weight += (.5 * roll);
                }
                else thousands++;

            }
            if (thousands != 0)
            {
                value += (thousands * 10);
                weight += thousands;
                Form1.writeToBoth(thousands + " thousand copper pieces.");
            }
        }

        private static void thousandSP(int number)
        {
            int thousands = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 21);
                if (roll == 1)
                {
                    roll = rand.Next(1, 101);
                    Form1.writeToBoth(roll + " animal horns worth 2 gp each, weighing 2 stone per 5 horns.");
                    value += (roll * 2);
                    weight += ((roll / 5) * 2);
                }
                else if (roll == 2)
                {
                    roll = (rand.Next(1, 5) + rand.Next(1, 5));
                    Form1.writeToBoth(roll + " jars of lamp oil, worth 20 gp each and weighing 6 stone per jar.");
                    value += (20 * roll);
                    weight += (6 * roll);

                }
                else if (roll == 3)
                {
                    roll = (rand.Next(1, 21) + rand.Next(1, 21));
                    Form1.writeToBoth(roll + " bottles of fine wine, worth 5 gp each and weighing 1 stone per 5 bottles.");
                    value += (5 * roll);
                    weight += (roll / 5);
                }
                else if (roll == 4)
                {
                    roll = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
                    Form1.writeToBoth(roll + " rolls of garishly dyed cloth, worth 10 gp each and weighing 4 stone each.");
                    value += (10 * roll);
                    weight = (4 * roll);
                }
                else if (roll == 5)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " jars of dyes and pigments, worth 50 gp each and weighing 5 stone each.");
                    value += (50 * roll);
                    weight += (5 * roll);
                }
                else if (roll == 6)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " crates of terra cotta pottery, worth 100 gp each and weighing 5 stone each.");
                    value += (100 * roll);
                    weight += (5 * roll);
                }
                else if (roll == 7)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " bags of loose tea, worth 75 gp each and weighing 5 stone each.");
                    value += (75 * roll);
                    weight += (5 * roll);
                }
                else if (roll == 8)
                {
                    roll = (rand.Next(1, 7) + rand.Next(1, 7));
                    Form1.writeToBoth(roll + " bundles of fur pelts, worth 15 gp each and weighing 3 stone each.");
                    value += (15 * roll);
                    weight += (3 * roll);
                }
                else thousands++;

            }
            if (thousands != 0)
            {
                value += (thousands * 100);
                weight += thousands;
                Form1.writeToBoth(thousands + " thousand silver pieces.");
            }
        }

        private static void thousandEP(int number)
        {
            int thousands = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 11);
                if (roll == 1)
                {
                    roll = rand.Next(1, 5);
                    Form1.writeToBoth(roll + " barrels of fine spirits or liquor, worth 200 gp each and weighing 16 stone each.");
                    value += (200 * roll);
                    weight += (16 * roll);
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " crates of armor and weapons, worth 225 gp each and weighing 10 stone each.");
                    value += (225 * roll);
                    weight += (10 * roll);

                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 5);
                    Form1.writeToBoth(roll + " crates of glassware, worth 200 gp each and weighing 5 stone each.");
                    value += (200 * roll);
                    weight += (5 * roll);
                }
                else if (roll == 4)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " crates of " + Form1.getMonsterType() + " parts, worth 300 gp each and weighing 5 stone each.");
                    value += (300 * roll);
                    weight += (5 * roll);
                }
                else thousands++;

            }
            if (thousands != 0)
            {
                value += (thousands * 500);
                weight += (thousands);
                Form1.writeToBoth(thousands + " thousand electrum pieces.");
            }
        }

        private static void thousandGP(int number)
        {
            int thousands = 0;
            int partValue = 0, totalValues = 0, valueMultiplier = 0;
            string temp = "";
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 21);
                if (roll == 1)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " bundles of rare fur pelts, worth 500 gp each and weighing 5 stone each.");
                    value += (roll * 500);
                    weight += (roll * 5);
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " jars of spices, worth 800 gp each and weighing 1 stone each.");
                    value += (roll * 800);
                    weight += roll;

                }
                else if (roll == 3)
                {
                    roll = (rand.Next(1, 11) * 50);
                    partValue = rand.Next(1, 7);
                    Form1.writeToBoth(roll + " " + Form1.getMonsterFeathers() + " feathers, each worth " + partValue + " gp and weighing 1 stone per 25 feathers.");
                    value += (partValue * roll);
                    weight += (roll / 25);
                }
                else if (roll == 4)
                {
                    roll = rand.Next(1, 101);
                    int HD = 0, counter = 0;
                    temp = "";
                    totalValues = 0;
                    for (int j = 0; j < roll; j++)
                    {
                        counter = rand.Next(1, 11);
                        HD += counter;
                        valueMultiplier = rand.Next(1, 5) + 1;
                        partValue = counter * valueMultiplier;
                        totalValues += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    //Form1.writeToBoth(roll + " monster horns, 1d10 HD * 1d4+1 GP/HD, weighing 1 stone per 20 HD.");
                    Form1.writeToBoth(roll + " " + Form1.getMonsterHorns() + " horns, totaling " + HD + " hit dice and weighing 1 stone per 20 HD.");
                    Form1.writeToBoth("Their values are: " + temp);
                    Form1.writeToBoth("The total value is: " + totalValues + " and the average value is " + (totalValues/roll) + ".");
                    value += totalValues;
                    weight += (HD / 20);
                }
                else if (roll == 5)
                {
                    roll = rand.Next(1, 7);
                    int HD = 0, counter = 0;
                    temp = "";
                    totalValues = 0;
                    for (int j = 0; j < roll; j++)
                    {
                        counter = rand.Next(1, 11);
                        HD += counter;
                        valueMultiplier = rand.Next(1, 11) * 10;
                        partValue = counter * valueMultiplier;
                        totalValues += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    //Form1.writeToBoth(roll + " monster carcasses, worth 1d10 HD * 1d10*10 GP/HD, weighing 1 stone per HD.");
                    Form1.writeToBoth(roll + " " + Form1.getMonsterType() + " carcasses, totaling " + HD + " hit dice and weighing 1 stone per HD.");
                    Form1.writeToBoth("Their values are: " + temp);
                    Form1.writeToBoth("The total value is: " + totalValues + " and the average value is " + (totalValues / roll) + ".");
                    value += totalValues;
                    weight += HD;
                }
                else if (roll == 6)
                {
                    roll = rand.Next(1, 5);
                    Form1.writeToBoth(roll + " crates of fine porcelain, worth 500 gp each and weighing 2 stone each.");
                    value += (roll * 500);
                    weight += (roll * 2);
                }
                else if (roll == 7)
                {
                    roll = (rand.Next(1, 21) + rand.Next(1, 21));
                    temp = "";
                    totalValues = 0;
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = rand.Next(1, 101);
                        totalValues += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    Form1.writeToBoth(roll + " pieces of fine ivory, weighing 1 stone per 100 GP value.");
                    Form1.writeToBoth("Their values are: " + temp);
                    Form1.writeToBoth("The total value is: " + totalValues + " and the average value is " + (totalValues / roll) + ".");
                    value += totalValues;
                    weight += (totalValues / 100);
                }
                else if (roll == 8)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " rolls of silk, worth 400 gp each and weighing 4 stone each.");
                    value += (roll * 400);
                    weight += (roll * 4);
                }
                else thousands++;

            }
            if (thousands != 0)
            {
                value += (thousands * 1000);
                weight += thousands;
                Form1.writeToBoth(thousands + " thousand gold pieces.");
            }
        }

        private static void thousandPP(int number)
        {
            int thousands = 0;
            for (int i = 0; i < number; i++)
            {
                roll = rand.Next(1, 11);
                if (roll == 1)
                {
                    roll = rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11) + rand.Next(1, 11);
                    Form1.writeToBoth(roll + " rare books, worth 150 gp each and weighing 1 stone per 2 books.");
                    value += (roll * 150);
                    weight += (roll * .5);
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 4);
                    Form1.writeToBoth(roll + " ornamental jars of rare spices, worth 2500 gp each and weighing 4 stone each.");
                    value += (roll * 2500);
                    weight += (roll * 4);

                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 21) + rand.Next(1, 21) + rand.Next(1, 21) + rand.Next(1, 21) + rand.Next(1, 21);
                    Form1.writeToBoth(roll + " typical fur capes, worth 100 gp each and weighing 1 stone each.");
                    value += (roll * 100);
                    weight += roll;
                }
                else if (roll == 4)
                {
                    roll = rand.Next(1, 9) + rand.Next(1, 9) + rand.Next(1, 9) + rand.Next(1, 9);
                    Form1.writeToBoth(roll + " ingots of precious metals, worth 300 gp each and weighing 2 stone each.");
                    value += (roll * 300);
                    weight += (roll * 2);
                }
                else thousands++;

            }
            if (thousands != 0)
            {
                value += (thousands * 5000);
                weight += thousands;
                Form1.writeToBoth(thousands + " thousand platinum pieces.");
            }

        }

        private static void perOrnamental(int number)
        {
            roll = rand.Next(1, 9);
            int num = 0;

            for (int i = 0; i < number; i++)
            {
                if (roll == 1)
                {
                    roll = rand.Next(1, 13);
                    Form1.writeToBoth(roll + " silver arrows, each worth 5 gp.");
                    value += (roll * 5);
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 7);
                    Form1.writeToBoth(roll + " pouches of belladonna or wolfsbane, each worth 10 gp.");
                    value += (roll * 10);
                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 5);
                    Form1.writeToBoth(roll + " pouches of saffron, each worth 15 gp.");
                    value += (roll * 15);
                }
                else num++;
            }
            gems.GenerateOrnamentals(num);

        }

        private static void perGem(int number)
        {
            roll = rand.Next(1, 9);
            int num = 0;
            string temp = "";
            int partValue = 0, totalValue = 0;

            for (int i = 0; i < number; i++)
            {
                if (roll == 1)
                {
                    roll = rand.Next(1, 4);
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = 10*(rand.Next(1, 7) + rand.Next(1, 7));
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    Form1.writeToBoth(roll + " sets of engraved teeth, weighing 1 stone per 100 sets.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                    weight += (roll / 100);
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 11);
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    Form1.writeToBoth(roll + " sticks of rare incense, weighing 1 stone per 100 sticks.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                    weight += (roll / 100);
                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 4);
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = 25*(rand.Next(1, 7));
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    Form1.writeToBoth(roll + " vials of rare perfume, weighing 1 stone per 100 vials.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                    weight += (roll/100);
                }
                else num++;
            }
            //1 gem or 2d6 ornamentals
            for (int i = 0; i < num; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 76) gems.GenerateGems(1);
                else gems.GenerateOrnamentals((rand.Next(1, 7) + rand.Next(1, 7)));
            }
        }

        private static void perBrilliant(int number)
        {
            roll = rand.Next(1, 9);
            int num = 0;

            for (int i = 0; i < number; i++)
            {
                if (roll == 1)
                {
                    roll = rand.Next(1, 21) + rand.Next(1, 21);
                    Form1.writeToBoth(roll + " jade carvings of heroes, monsters, and gods, each worth 200 gp.");
                    value += (roll * 200);
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 9);
                    Form1.writeToBoth(roll + " opal cameo portraits and intaglio erotic tableux, each worth 800 gp.");
                    value += (roll * 800);
                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 7);
                    Form1.writeToBoth(roll + " amethyst cylinder seals depicting religious scenes, each worth 1200 gp.");
                    value += (roll * 1200);
                }
                else num++;
            }
            //1 brilliant or 4d8 gems
            for (int i = 0; i < num; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 76) gems.GenerateBrilliants(1);
                else gems.GenerateGems((rand.Next(1, 9) + rand.Next(1, 9) + rand.Next(1, 9) + rand.Next(1, 9)));
            }
        }

        private static void perTrinket(int number)
        {
            roll = rand.Next(1, 9);
            int num = 0;
            int partValue = 0, totalValue = 0;
            string temp = "";

            for (int i = 0; i < number; i++)
            {
                if (roll == 1)
                {
                    roll = (rand.Next(1, 7) + rand.Next(1, 7));
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = rand.Next(1, 101);
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                   // Form1.writeToBoth(roll + " glass eyes, lenses or prisms, each worth 1d6*10 gp.");
                    Form1.writeToBoth(roll + " glass eyes, lenses, or prisms.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                }
                else if (roll == 2)
                {
                    roll = rand.Next(1, 5);
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = 10*(rand.Next(1, 9) + rand.Next(1, 9));
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    //Form1.writeToBoth(roll + " silver holy or unholy symbols, each worth 2d8 * 10 gp.");
                    Form1.writeToBoth(roll + " silver holy or unholy symbols.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                }
                else if (roll == 3)
                {
                    roll = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = rand.Next(1, 101);
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    //Form1.writeToBoth(roll + " bone fetishes and figurines, each worth 2d20 gp.");
                    Form1.writeToBoth(roll + " bone fetishes and figurines.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                }
                else num++;
            }
            jewelry.GenerateTrinkets(num);
        }

        private static void perJewelry(int number)
        {
            roll = rand.Next(1, 9);
            int num = 0;
            string temp = "";
            int partValue = 0, totalValue = 0;

            for (int i = 0; i < number; i++)
            {
                if (roll == 1)
                {
                    roll = (100 * (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)));
                    Form1.writeToBoth("This room contains a rich fur cape, worth " + roll + " gp.");
                    value += roll;
                }
                else if (roll == 2)
                {
                    roll = (1000 * (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7)));
                    Form1.writeToBoth("This room contains a rich fur coat, worth " + roll + " gp.");
                    value += roll;
                }
                else if (roll == 3)
                {
                    roll = rand.Next(1, 4);
                    temp = "";
                    for (int j = 0; j < roll; j++)
                    {
                        partValue = (rand.Next(1, 11)) * 100;
                        totalValue += partValue;
                        if (j != roll - 1)
                            temp += partValue + ", ";
                        else temp += partValue;
                    }
                    //Form1.writeToBoth(roll + " statuettes, each worth 1d10*100 gp and weighing 1/3 stone each.");
                    Form1.writeToBoth(roll + " statuettes, weighing 1/3 stone each.");
                    Form1.writeToBoth("Their values are: " + temp);
                    value += totalValue;
                    weight += (roll / 3);
                }
                else num++;
            }
            jewelry.GenerateJewelry(num);
        }

        private static void perRegalia(int number)
        {
            roll = rand.Next(1, 9);
            int num = 0;
            string temp = "";
            int partValue = 0, totalValue = 0;

            if (roll == 1)
            {
                roll = rand.Next(1, 11) + rand.Next(1, 11);
                for (int j = 0; j < roll; j++)
                {
                    partValue = 100 * (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
                    totalValue += partValue;
                    temp += partValue;
                    if (j != roll - 1)
                        temp += ", ";
                }
                Form1.writeToBoth(roll + " alabaster and jet game pieces with jeweled eyes.");
                Form1.writeToBoth("Their values are: " + temp);
                value += totalValue;
            }
            else if (roll == 2)
            {
                roll = rand.Next(1, 5);
                for (int j = 0; j < roll; j++)
                {
                    partValue = 1000 * rand.Next(1, 9);
                    totalValue += partValue;
                    temp += partValue;
                    if (j != roll - 1)
                        temp += ", ";
                }
                Form1.writeToBoth(roll + " platinum reliquaries with crystal panes.");
                Form1.writeToBoth("Their values are: " + temp);
                value += totalValue;
            }
            else if (roll == 3)
            {
                roll = rand.Next(1, 9);
                for (int j = 0; j < roll; j++)
                {
                    partValue = 1000 * rand.Next(1, 5);
                    totalValue += partValue;
                    temp += partValue;
                    if (j != roll - 1)
                        temp += ", ";
                }
                Form1.writeToBoth(roll + " carved ivory netsuke and figurines.");
                Form1.writeToBoth("Their values are: " + temp);
                value += totalValue;
            }
            else num++;

            //1 regalia or 4d8 jewelry
            for (int i = 0; i < num; i++)
            {
                roll = rand.Next(1, 101);
                if (roll < 76) jewelry.GenerateRegalia(1);
                else jewelry.GenerateJewelry((rand.Next(1, 9) + rand.Next(1, 9) + rand.Next(1, 9) + rand.Next(1, 9)));
            }
        }



    }//End of class
}//End of namespace
