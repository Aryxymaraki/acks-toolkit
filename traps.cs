using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    static class traps
    {
        static Random rand = new Random(Guid.NewGuid().GetHashCode());
        static int roll = 0;

        public static string generateTrap()
        {
            roll = rand.Next(1, 7);
            if (roll < 4) return generatePressureTrap();
            else if (roll < 5) return generateTriggerTrap();
            else return generateOtherTrap();
        }

         /*
         * PRESSURE PLATE TRAPS
         * Beast release - Step on a plate and a door or gate opens to let out a monster or beast
         * Ceiling release - Swings down part of the ceiling onto the trigger
         * Boulder trap
         * Ledge release - A thin ledge along a wall leads to a raised niche with loot in it.  Part of the ledge swings down when triggered.
         * Collapsing stairs - A stairway leads up to a door.  When triggered, the stairway swings down, causing anyone standing on it to fall into a pit. 
         * Dork in a bottle - A pit trap drops you into a pit filled with water, then rolls a boulder on top of you.  The boulder is delayed, giving you time to escape.
         * Impaler - Stepping on a pressure plate causes a spike to flip up and stab you..
         * Net trap - Nets fall from the ceiling.
         */
        private static string generatePressureTrap()
        {
            roll = rand.Next(1, 21);
            if (roll < 12) return generatePitTrap();
            else if (roll < 13) return "Beast release trap: This room has a monster or beast in a cage or niche in the wall.  Triggering the trap releases it.";
            else if (roll < 14) return "Ceiling release trap: Triggering this trap causes part of the ceiling to swing down, attempting to crush the triggerer.";
            else if (roll < 15) return "Rolling boulder trap: As per Indiana Jones.";
            else if (roll < 16) return "Ledge release trap: This room has a thin ledge along the wall, at least ten feet off the ground.  Part of the ledge is a pressure plate and will swing down when triggered, causing the triggerer to fall.";
            else if (roll < 17) return "Collapsing stairway trap: This room contains a stairway leading up to a false door.  Attempting to open the door causes the stairway to swing down, dumping off anyone standing on it.";
            else if (roll < 18) return "Dork in a bottle trap: This room contains a pit trap filled with water in the bottom.  One minute after the trap is triggered, a boulder will begin to roll over to cover the water, trapping anyone who is still there.";
            else if (roll < 19) return "Impaler trap: When this pressure plate is triggered, a spike or blade swings up and stabs at the triggerer.";
            else return "Net trap: When this pressure plate is triggered, one or more nets fall from the ceiling onto the triggerer.";
        }

         /*
         * TRIGGER TRAPS
         * Aversion therapy - Pool of water on the ground with coins scattered in it.  A trigger activates a jolt of electricity.
         * Bag rippers - Essentially bear traps hidden under sacks of loot.  Will, at the very least, damage the sack severely.
         * Water trap - Trigger seals doors and releases water to fill the room.
         * Acid sprayer - Sprays acid when triggered.  
         */
        private static string generateTriggerTrap()
        {
            roll = rand.Next(1, 5);
            switch (roll)
            {
                case 1:
                    return "Aversion therapy:  The floor of this room is covered in salt water and loot.  A trigger somewhere in the room will trigger a jolt of electricity, conducted through the salt water.";
                case 2:
                    return "Bag rippers:  Bear traps set under sacks of loot.  When the loot is picked up, the traps will trigger, at the very least damaging the sacks.";
                case 3:
                    return "Water trap: Triggering seals exits and causes water to begin flowing into the room.";
                case 4:
                    return "Acid sprayer:  Triggering causes a spray of acid to be released.";
            }
            return "";
        }

         /*
         * OTHER TRAPS
         * Slime in a box - A chest full of loot also contains a gelatinous cube or other slime creature.
         * Coal furnace - A room filled with coal dust (kept suspended in air by fans or magic or any other means) and shards of flint embedded in the floor.
         * Dropshaft - A hatch at the top of a shaft drops items on the opener.
         * Gehenna - Upgraded version of coal furnace.  Lamp oil coats the walls and floor; the floor is made of flint and the door has a rugged steel edge.
         * Hangman's Revenge - A tripwire at neck height.  Walking into it triggers it, causing it to wrap around your neck.
         * Shale floor - A very thin layer of shale is atop a marshy, swampy, watery, or quicksandy area.  Stepping on it without great care will shatter it.
         * Sticky floor - Floor is covered in magical adhesive, making it very difficult to walk on without getting stuck.
         */
        private static string generateOtherTrap()
        {
            roll = rand.Next(1, 7);
            switch (roll)
            {
                case 1: return "Slime in a box:  This room contains a chest full of both loot and a gelatinous cube or other slime creature.";
                case 2: return "Coal furnace: This room is full of airborne coal dust, with shards of flint embedded in the floor.  Boots with metal (such as ordinary military boots) or metal items striking the floor may cause an explosion.";
                case 3: return "Dropshaft: This room has a shaft heading upwards.  A hatch at the top, when opened, drops something on the opener (rocks, water, snakes, whatever).";
                case 4: return "Gehenna: An upgraded version of the coal furnace, the walls and floor of this room are coated with lamp oil.  The floor is made entirely of flint and the door has a rugged steel edge, making even opening the door without care likely to set it off.";
                case 5: return "Hangman's Revenge: A tripwire set at neck height on a human, walking into it causes the wire to wrap around one's neck and begin strangulation.";
                case 6: return "Shale floor:  A very thin layer of shale is set over quicksand or other marshy or watery area.  Walking on the floor without great care will cause you to break through into the underlying terrain.";
                case 7: return "Sticky floor:  The floor is covered in a magical adhesive, making it difficult to walk on without getting stuck.";
            }
            return "";
        }

        /*
        * Sand trap - Pit trap with quicksand.
        * Pit trap - Ordinary pit trap.
        * Pit trap, Spiked - Pit trap with spikes.
        * Pit trap, Spiked, Poisoned - Pit trap with poisoned spikes.
        * Pit trap, Slime - Pit trap with a gelationous cube or other ooze creature in it.
        * Snake pit - Pit trap full of snakes.
        * Sloped pit trap - Optionally, tire spikes on the walls
        */
        private static string generatePitTrap()
        {
            roll = rand.Next(1, 9);
            switch (roll)
            {
                case 1: return "Sand trap:  This room contains a pit trap with quicksand at the bottom of the pit.";
                case 2: return "Pit trap:  This room contains an ordinary pit trap.";
                case 3: return "Spiked pit trap:  This room contains a spiked pit trap.";
                case 4: return "Poisoned spiked pit trap:  This room contains a spiked pit trap with poisoned spikes.";
                case 5: return "Slime pit:  This room contains a pit trap with a gelatinous cube or other ooze at the bottom.";
                case 6: return "Snake pit:  This room contains a pit trap full of snakes.  Why'd it have to be snakes?";
                case 7: return "Sloped pit trap:  This room contains an ordinary pit trap with sloped sides, narrowing to a point at the bottom.";
                case 8: return "Spiked sloped pit trap:  This room contains a sloped pit trap with tire spikes on the wall, such that falling deals no damage beyond falling but getting out without severe lacerations is difficult.";
            }
            return "";
        }

    }
}
