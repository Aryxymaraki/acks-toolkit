using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//LEVEL TEMPLATE
//GenerateRoom
//GenerateTrap
//GenerateMonster
//GenerateUnique
//GenerateTreasure
//levelNMonster

namespace ACKS_Toolkit
{
    class thirdLevel
    {
        static Random rand = new Random(Guid.NewGuid().GetHashCode());
        static int roll;

        public static void GenerateRoom(int roomType)
        {
            switch (roomType)
            {
                //Empty room
                case 1:
                    Form1.WriteToFile("This is an empty room.");
                    roll = rand.Next(1, 101);
                    if (roll < 16) GenerateTreasure();
                    Form1.WriteToFile("\n");
                    break;
                //Monster room
                case 2:
                    GenerateMonster();
                    Form1.WriteToFile("\n");
                    break;
                //Trap room
                case 3:
                    Form1.WriteToFile("This room contains a trap.");
                    roll = rand.Next(1, 101);
                    GenerateTrap();
                    if (roll < 31) GenerateTreasure();
                    Form1.WriteToFile("\n");
                    break;
                //Unique room
                case 4:
                    Form1.WriteToFile("This is a unique room, such as a chess puzzle or a fountain of molten gold.");
                    GenerateUnique();
                    Form1.WriteToFile("\n");
                    break;
            }
        }

        private static void GenerateTrap()
        {
            Form1.WriteToFile(traps.generateTrap());
        }

        private static void GenerateMonster()
        {
            roll = rand.Next(1, 13);
            if (roll == 1) firstLevel.level1Monster(3);
            else if (roll < 4) secondLevel.level2Monster(3);
            else if (roll < 10) level3Monster(3);
            else if (roll < 12) fourthLevel.level4Monster(3);
            else fifthLevel.level5Monster(3);
        }

        private static void GenerateUnique()
        {

        }

        private static void GenerateTreasure()
        {
            roll = rand.Next(1, 7);
            switch (roll)
            {
                case 1: treasure.RollTreasure("E"); break;
                case 2: treasure.RollTreasure("F"); break;
                case 3: treasure.RollTreasure("G"); break;
                case 4: treasure.RollTreasure("H"); break;
                case 5: treasure.RollTreasure("I"); break;
                case 6: treasure.RollTreasure("J"); break;
            }
        }

        public static void level3Monster(int level)
        {
            double multiplier = Form1.getMultiplier(level, 3);
            string path = System.Windows.Forms.Application.StartupPath + "/Resources/Dungeon/thirdLevel.txt";
            Form1.GenericMonsterGenerator(path, multiplier);
        }


    }
}
