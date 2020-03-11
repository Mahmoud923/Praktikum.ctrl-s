using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aufgabe_6
{
    class Melee : Unit
    {
        public Melee(float ss_position, float ss_speed, float ss_dmg, float ss_armor, float ss_life, string ss_name) : base(ss_position, ss_speed, ss_dmg, ss_armor, ss_life, ss_name)
        {
            this.reichweite = 10;
        }
    }
}
