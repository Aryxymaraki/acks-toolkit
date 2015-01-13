using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACKS_Toolkit
{
    public class importer
    {
        static int xp;
        static int lair;
        static string numWilderness;
        static string numLair;
        static string treasure;

        public importer()
        {
            xp = 0;
            lair = 0;
            numWilderness = "";
            numLair = "";
            treasure = "";
        }

        /*private string SelectTextFile(string initialDirectory)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a text file";
            return (dialog.FileName);
        }*/

        public void importMonster(string monster)
        {
            string name = Wilderness.sanitizeMonster(monster);
            if (System.IO.File.Exists(Application.StartupPath + "/Resources/Wilderness/monsters/" + name + ".txt"))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(Application.StartupPath + "/Resources/Wilderness/monsters/" + name + ".txt");
                xp = System.Convert.ToInt32(reader.ReadLine());
                lair = System.Convert.ToInt32(reader.ReadLine());
                numWilderness = reader.ReadLine();
                numLair = reader.ReadLine();
                treasure = reader.ReadLine();
            }
            else
            {
                //Error
                Form1.WriteToFile("Cannot find a file for " + monster + "!");
                Form1.WriteToFile("Expected file path was: " + Application.StartupPath + "/Resources/Wilderness/monsters/" + name + ".txt");
            }
        }

        public int getXP()
        {
            return xp;
        }

        public int getLair()
        {
            return lair;
        }

        public string getNumWilderness()
        {
            return numWilderness;
        }

        public string getNumLair()
        {
            return numLair;
        }

        public string getTreasure()
        {
            return treasure;
        }

    }
}
