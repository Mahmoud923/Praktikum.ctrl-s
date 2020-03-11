using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_5_2
{
    class Melee : Unit
    {
        public Melee(int ss_position, int ss_speed, int ss_dmg, int ss_armor, int ss_life, string ss_name) : base(ss_position, ss_speed, ss_dmg, ss_armor, ss_life, ss_name)
        {
        }
    }
}
