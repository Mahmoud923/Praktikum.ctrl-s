using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aufgabe_6
{
    class Spielverwalter
    {
        List<Unit> Unit_Liste = new List<Unit>();

        public void Spieler_crieren(float ss_art, float ss_pos, float ss_speed, float ss_dmg, float ss_armor, float ss_life, string ss_name)
        {
            if (ss_art == 0)
            {
                Melee melee = new Melee(ss_pos, ss_speed, ss_dmg, ss_armor, ss_life, ss_name);
                Unit_Liste.Add(melee);
            }
            if (ss_art == 1)
            {
                Ranged ranged = new Ranged(ss_pos, ss_speed, ss_dmg, ss_armor, ss_life, ss_name);
                Unit_Liste.Add(ranged);
            }
        }
        public bool is_kollision_vorhanden(float ss_pos)
        {
            bool w_is_kollision_vorhanden = false;

            if (Unit_Liste.Count > 0)
            {
                if (Unit_Liste[0].pos == ss_pos)
                {
                    w_is_kollision_vorhanden = true;
                }
            }
            return w_is_kollision_vorhanden;
        }
        public bool speed_kontrolle(float ss_speed)
        {
            bool is_fehler = false;
            if (Unit_Liste[0].speed == 0 && ss_speed == 0)
            {
                is_fehler = true;
            }
            return is_fehler;
        }
        public void Set_lauf_richtung()
        {
            int i = 0;
            // Vorwirts
            if (Unit_Liste[i].pos < Unit_Liste[i + 1].pos)
            {
                Unit_Liste[i].lauf_richtung = 0;
                Unit_Liste[i + 1].lauf_richtung = 1;
            }
            // Rückwirts
            if (Unit_Liste[i].pos > Unit_Liste[i + 1].pos)
            {
                Unit_Liste[i].lauf_richtung = 1;
                Unit_Liste[i + 1].lauf_richtung = 0;
            }
        }
        public void Infos_Anzeigen()
        {
            int spieler_Nr = 1;
            foreach (Unit w_unit in Unit_Liste)
            {
                if (typeof(Melee).IsInstanceOfType(w_unit) == true)
                {
                    Console.WriteLine(spieler_Nr + " Spieler: Melee " + w_unit._name);
                }
                if (typeof(Ranged).IsInstanceOfType(w_unit) == true)
                {
                    Console.WriteLine(spieler_Nr + " Spiler: Ranged " + w_unit._name);
                }
                Console.Write("Pos: " + w_unit.pos);
                Console.Write(",Speed: " + w_unit.speed);
                Console.Write(",Dmg: " + w_unit.dmg);
                Console.Write(",Armor: " + w_unit.armor);
                Console.Write(",Life: " + w_unit.life);
                Console.Write(",Laufrichtung: " + w_unit.lauf_richtung);
                Console.WriteLine("");
                spieler_Nr++;
            }
        }
        public void spielRunde()
        {
            bool spiel_ende = false;


            do
            {
                int i = 0;
                int typ = 0;
                do
                {
                    Unit attacker = Unit_Liste[i];
                    if (typeof(Melee).IsInstanceOfType(Unit_Liste[i]) == true)
                    {
                        Console.WriteLine("Spieler Melee ist daran:");
                        typ = 0;
                    }
                    if (typeof(Ranged).IsInstanceOfType(Unit_Liste[i]) == true)
                    {
                        Console.WriteLine("Spieler Ranged ist daran:");
                        typ = 1;
                    }
                    // Walk
                    if (Unit_Liste[i].Radar(get_Enemypos(attacker), typ) == false)
                    {
                        Console.WriteLine("Status: Walk");
                        Unit_Liste[i].walk(get_Enemypos(attacker), typ);
                    }
                    // Attack
                    if (Unit_Liste[i].Radar(get_Enemypos(attacker), typ) == true)
                    {
                        Console.WriteLine("Status: Attack");
                        foreach (Unit w_unit in Unit_Liste)
                        {
                            if (Unit_Liste[i].pos != w_unit.pos)
                            {
                                Unit enemy = w_unit;
                                Unit_Liste[i].attack(Unit_Liste[i], enemy);
                                if (enemy.life <= 0)
                                {
                                    spiel_ende = true;
                                }
                            }
                        }
                    }
                    i++;
                } while (i < Unit_Liste.Count);
                Console.WriteLine("");
                Infos_Anzeigen();
                Console.WriteLine("");
            } while (spiel_ende == false);
            Console.WriteLine("Spiel Ende");
        }
        public void Gewinner_anzeigen()
        {
            Console.WriteLine("Gewinner ist: " + Unit_Liste[0].name);
        }
        public float get_Enemypos(Unit ss_attacker)
        {
            float w_ss_enemypos = 0;
            foreach (Unit w_unit in Unit_Liste)
            {
                if (w_unit.pos != ss_attacker.pos)
                {
                    w_ss_enemypos = w_unit.pos;
                }
            }
            return w_ss_enemypos;
        }
    }
}
