using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_5_2
{
    abstract class Unit
    {
        public int pos;
        public int speed;
        public int dmg;
        public int armor;
        public int life;
        public int lauf_richtung;
        public string name;


        public Unit(int ss_pos, int ss_speed, int ss_dmg, int ss_armor, int ss_life, string ss_name)
        {
            this.pos = ss_pos;
            this.speed = ss_speed;
            this.dmg = ss_dmg;
            this.armor = ss_armor;
            this.life = ss_life;
            this.name = ss_name;
            this.lauf_richtung = 0;
        }
        public int _Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public int _Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int _Dmg
        {
            get { return dmg; }
            set { dmg = value; }
        }
        public int _Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public int _Life
        {
            get { return life; }
            set { life = value; }
        }
        public string _name
        {
            get { return name; }
            set { name = value; }
        }
        public int _lauf_richtung
        {
            get { return lauf_richtung; }
            set { lauf_richtung = value; }
        }
        public void walk(int ss_enemy_pos, int ss_typ)
        {
            // Melee
            if (ss_typ == 0)
            {
                if (lauf_richtung == 0)
                {
                    if (pos + speed + 10 <= ss_enemy_pos)
                    {
                        pos = pos + speed;
                    }
                    if (pos + speed + 10 > ss_enemy_pos)
                    {
                        pos = ss_enemy_pos - 10;
                    }
                }
                if (lauf_richtung == 1)
                {
                    if (pos - speed - 10 >= ss_enemy_pos)
                    {
                        pos = pos - speed;
                    }
                    if (pos - speed - 10 < ss_enemy_pos)
                    {
                        pos = ss_enemy_pos + 10;
                    }
                }
            }
            // Ranged
            if (ss_typ == 1)
            {
                if (lauf_richtung == 0)
                {
                    if (pos + speed + 100 <= ss_enemy_pos)
                    {
                        pos = pos + speed;
                    }
                    if (pos + speed + 100 > ss_enemy_pos)
                    {
                        pos = ss_enemy_pos - 100;
                    }
                }
                if (lauf_richtung == 1)
                {
                    if (pos - speed - 100 >= ss_enemy_pos)
                    {
                        pos = pos - speed;
                    }
                    if (pos - speed - 100 < ss_enemy_pos)
                    {
                        pos = ss_enemy_pos + 100;
                    }
                }
            }

        }
        public bool Radar(int ss_enemy_pos,int ss_typ)
        {
            bool is_enemy_nearby = false;
            // Melee
            if (ss_typ == 0)
            {
                if (lauf_richtung == 0)
                {
                    if (pos + 10 >= ss_enemy_pos)
                    {
                        is_enemy_nearby = true;
                    }
                }
                if (lauf_richtung == 1)
                {
                    if (pos - 10 <= ss_enemy_pos)
                    {
                        is_enemy_nearby = true;
                    }
                }
                
            }
            if (ss_typ == 1)
            {
                if (lauf_richtung == 0)
                {
                    if (pos + 100 >= ss_enemy_pos)
                    {
                        is_enemy_nearby = true;
                    }
                }
                if (lauf_richtung == 1)
                {
                    if (pos - 100 <= ss_enemy_pos)
                    {
                        is_enemy_nearby = true;
                    }
                }
            }
            return is_enemy_nearby;
        }

        public void attack(Unit ss_attacker, Unit ss_enemy)
        {
            ss_enemy.life -= (ss_attacker.dmg - ss_enemy.armor);
        }
        public bool is_same_Position(int ss_pos)
        {
            bool w_is_same_pos = false;
            if (ss_pos == pos)
            {
                w_is_same_pos = true;
            }
            return w_is_same_pos;
        }
    }
}
