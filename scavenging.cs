using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class scavenging
    {
        private static Random rand = new Random(Guid.NewGuid().GetHashCode());
        private static int roll;

        public static void scavengeBladedWeapon()
        {
            roll = rand.Next(1, 21);
            //roll effect value
            //1–2 Serviceable -- 100%
            //3–6 Blade dented -1 damage -20%
            //7–10 Blade rusty -1 damage -20%
            //11–14 Off balance -1 to attacks -20%
            //15–16 Loose hilt/haft -1 to initiative -20%
            //17–18 Shoddy construction breaks -20%
            //19–20 Roll again twice -- --
            if (roll < 3)
            {
                //serviceable
                Form1.WriteToFile("Serviceable - No penalty, full value.");
            }
            else if (roll < 7)
            {
                //blade dented
                Form1.WriteToFile("Blade dented - -1 damage, -20% value.");
            }
            else if (roll < 11)
            {
                Form1.WriteToFile("Blade rusty - -1 damage, -20% value.");
            }
            else if (roll < 15)
            {
                Form1.WriteToFile("Off balance - -1 to attacks, -20% value.");
            }
            else if (roll < 17)
            {
                Form1.WriteToFile("Loose hilt/haft - -1 to initiative, -20% value.");
            }
            else if (roll < 19)
            {
                Form1.WriteToFile("Shoddy construction - breaks, no value.");
            }
            else
            {
                scavengeBladedWeapon();
                scavengeBladedWeapon();
            }
        }

        public static void scavengeBluntWeapon()
        {
            roll = rand.Next(1, 21);
            //1–2 Serviceable -- 100%
            if (roll < 3)
            {
                Form1.WriteToFile("Serviceable - No penalty, full value.");
            }
            //3–6 Soft head -1 damage -20%
            else if (roll < 7)
            {
                Form1.WriteToFile("Soft head - -1 damage, -20% value.");
            }
            //7–10 Wobbly head -1 damage -20%
            else if (roll < 11)
            {
                Form1.WriteToFile("Wobbly head - -1 damage, -20% value.");
            }
            //11–14 Off balance -1 to attacks -20%
            else if (roll < 15)
            {
                Form1.WriteToFile("Off balance - -1 to attacks, -20% value.");
            }
            //15–16 Wobbly head -1 to initiative -20%
            else if (roll < 17)
            {
                Form1.WriteToFile("Wobbly head - -1 to initiative, -20% value.");
            }
            //17–18 Shoddy construction breaks -20%
            else if (roll < 19)
            {
                Form1.WriteToFile("Shoddy construction - breaks.  No value.");
            }
            //19–20 Roll again twice -- -
            else
            {
                scavengeBluntWeapon();
                scavengeBluntWeapon();
            }

        }

        public static void scavengeArmor()
        {
            roll = rand.Next(1, 21);
            //1–2 Serviceable -- 100%
            if (roll < 3)
            {
                Form1.WriteToFile("Serviceable - No penalty, full value.");
            }
            //3–6 Broken straps +1 stone encumbrance -20%
            else if (roll < 7)
            {
                Form1.WriteToFile("Broken straps - +1 stone encumbrance, -20% value.");
            }
            //7–10 Rattles if moved Cannot move silently -20%
            else if (roll < 11)
            {
                Form1.WriteToFile("Rattles if moved - Cannot move silently.  -20% value.");
            }
            //11–14 Rotting -1 Armor Class / breaks -20%
            else if (roll < 15)
            {
                Form1.WriteToFile("Rotting - -1 AC, or breaks if equipment.  -20% value if not broken.");
            }
            //15–16 Makeshift work -1 Armor Class / breaks -20%
            else if (roll < 17)
            {
                Form1.WriteToFile("Makeshift work - -1 AC, or breaks if equipment.  -20% value if not broken.");
            }
            //17–18 Torn / ripped Breaks -20%
            else if (roll < 19)
            {
                Form1.WriteToFile("Torn/Ripped - Breaks.  No value.");
            }
            //19–20 Roll again twice -- -
            else
            {
                scavengeArmor();
                scavengeArmor();
            }

        }
    }
}
