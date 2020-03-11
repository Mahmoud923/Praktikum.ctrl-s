using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aufgabe_6
{
    abstract class Unit
    {
        public float pos;
        public float speed;
        public float dmg;
        public float armor;
        public float life;
        public float reichweite;
        public int lauf_richtung;
        public string name;


        public Unit(float ss_pos, float ss_speed, float ss_dmg, float ss_armor, float ss_life, string ss_name)
        {
            this.pos = ss_pos;
            this.speed = ss_speed;
            this.dmg = ss_dmg;
            this.armor = ss_armor;
            this.life = ss_life;
            this.reichweite = 0;
            this.name = ss_name;
            this.lauf_richtung = 0;
        }
        public float _Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public float _Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public float _Dmg
        {
            get { return dmg; }
            set { dmg = value; }
        }
        public float _Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public float _Life
        {
            get { return life; }
            set { life = value; }
        }
        public float _reichweite
        {
            get { return reichweite; }
            set { reichweite = value; }
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
        public void walk(float ss_enemy_pos, int ss_typ)
        {

            if (lauf_richtung == 0)
            {
                if (pos + speed + reichweite <= ss_enemy_pos)
                {
                    pos = pos + speed;
                }
                if (pos + speed + reichweite > ss_enemy_pos)
                {
                    pos = ss_enemy_pos - reichweite;
                }
            }
            if (lauf_richtung == 1)
            {
                if (pos - speed - reichweite >= ss_enemy_pos)
                {
                    pos = pos - speed;
                }
                if (pos - speed - reichweite < ss_enemy_pos)
                {
                    pos = ss_enemy_pos + reichweite;
                }
            }

        }
        public bool Radar(float ss_enemy_pos, int ss_typ)
        {
            bool is_enemy_nearby = false;
           
                if (lauf_richtung == 0)
                {
                    if (pos + reichweite >= ss_enemy_pos)
                    {
                        is_enemy_nearby = true;
                    }
                }
                if (lauf_richtung == 1)
                {
                    if (pos - reichweite <= ss_enemy_pos)
                    {
                        is_enemy_nearby = true;
                    }
                }
            return is_enemy_nearby;
        }

        public void attack(Unit ss_attacker, Unit ss_enemy)
        {
            if(ss_attacker.dmg < ss_enemy.armor)
            {
                ss_enemy.life -= 1;
            }
            else
            {
                ss_enemy.life -= (ss_attacker.dmg - ss_enemy.armor);
            }
            
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
