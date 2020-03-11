using System;

namespace Aufgabe_5_2
{
    class Program
    {
        static int anzahl_spieler = 2;
        static void Main(string[] args)
        {
            Spielverwalter w_spielverwalter = new Spielverwalter();

            Console.WriteLine("Willkommen");

            int i = 0;

            int art;
            int pos;
            int speed;
            int dmg;
            int armor;
            int life;
            string name;
            bool is_falsche_eingabe;

            do
            {
                // Art erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.WriteLine(i + 1 + " Spieler: 0 = Melee, 1 = Ranged");
                    if (int.TryParse(Console.ReadLine(), out art))
                    {
                        if (art == 0 || art == 1)
                        {
                            is_falsche_eingabe = false;
                        }
                        else
                        {
                            Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                            Console.WriteLine("0 oder 1 nur eingeben!!!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                        is_falsche_eingabe = true;
                    }
                }
                while (is_falsche_eingabe == true);
                // Pos erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Position: ");
                    if (int.TryParse(Console.ReadLine(), out pos))
                    {
                        if (pos >= 0 && pos < 1000)
                        {
                            if (i > 0)
                            {
                                if (w_spielverwalter.is_kollision_vorhanden(pos) == true)
                                {
                                    Console.WriteLine("Achtung!! Ein Enemy befindet sich schon hier in dieser Position!!!");
                                    Console.WriteLine("Andere Position eingeben!!!");
                                }
                                else
                                {
                                    is_falsche_eingabe = false;
                                }
                            }
                            else
                            {
                                is_falsche_eingabe = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Es darf kein Null eingegeben werden oder großer als 1000!!! Nochmal");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                        is_falsche_eingabe = true;
                    }
                }
                while (is_falsche_eingabe == true);
                // Speed erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Speed: ");
                    if (int.TryParse(Console.ReadLine(), out speed))
                    {
                        if (speed < 0)
                        {
                            Console.WriteLine("Achtung !!! es darf kein Wert kleiner als 0 eingegeben werden !!!!");
                        }
                        else
                        {
                            if (i > 0)
                            {
                                if (w_spielverwalter.speed_kontrolle(speed) == true)
                                {
                                    Console.WriteLine("Achtung!! Dein Enemyspeed ist schon 0 !!! andere Wert einegebe !!! ");
                                }
                                else
                                {
                                    is_falsche_eingabe = false;
                                }
                            }
                            else
                            {
                                is_falsche_eingabe = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                        is_falsche_eingabe = true;
                    }
                }
                while (is_falsche_eingabe == true);


                // Dmg erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Dmg: ");
                    if (int.TryParse(Console.ReadLine(), out dmg))
                    {
                        if (dmg == 0)
                        {
                            Console.WriteLine("Achtung !!! es darf kein 0 eingegeben werden !!!!");
                        }
                        else if (dmg < 0)
                        {
                            Console.WriteLine("Achtung !!! es darf kein Wert kleiner als 0 eingegeben werden !!!!");
                        }
                        else
                        {
                            if (w_spielverwalter.dmg_kontrolle(dmg) == false)
                            {
                                is_falsche_eingabe = false;
                            }
                            else
                            {
                                Console.WriteLine("Achtung !!! dein Dmg muss größer als Enemyarmor !!!Nochmal");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                        is_falsche_eingabe = true;
                    }
                }
                while (is_falsche_eingabe == true);
                // Armor erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Armor: ");
                    if (int.TryParse(Console.ReadLine(), out armor))
                    {
                        if (armor == 0)
                        {
                            Console.WriteLine("Achtung !!1 es darf kein 0 eingegeben werden !!!!");
                        }
                        else if (armor < 0)
                        {
                            Console.WriteLine("Achtung !!1 es darf kein Wert kleiner als 0 eingegeben werden !!!!");
                        }
                        else
                        {
                            if (w_spielverwalter.armor_kontrolle(armor) == false)
                            {
                                is_falsche_eingabe = false;
                            }
                            else
                            {
                                Console.WriteLine("Achtung !!! dein Armor muss kleiner als Enemydmg !!!Nochmal");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                        is_falsche_eingabe = true;
                    }
                }
                while (is_falsche_eingabe == true);
                // Life erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Life: ");
                    if (int.TryParse(Console.ReadLine(), out life))
                    {
                        if (life == 0)
                        {
                            Console.WriteLine("Achtung !!1 es darf kein 0 eingegeben werden !!!!");
                        }
                        else if (life < 0)
                        {
                            Console.WriteLine("Achtung !!1 es darf kein Wert kleiner als 0 eingegeben werden !!!!");
                        }
                        else
                        {
                            is_falsche_eingabe = false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error!! falsche Eingabe !!! Nochmal");
                        is_falsche_eingabe = true;
                    }
                }
                while (is_falsche_eingabe == true);
                // Namen geben
                name = "";
                if (i == 0)
                {
                    name = "1_Player";
                }
                if (i > 0)
                {
                    name = "2_Player";
                }
                // Units creat
                w_spielverwalter.Spieler_crieren(art, pos, speed, dmg, armor, life, name);
                i++;

            }
            while (i < anzahl_spieler);
            Console.WriteLine("____________________________");
            w_spielverwalter.Set_lauf_richtung();
            w_spielverwalter.Infos_Anzeigen();
            w_spielverwalter.spielRunde();
            w_spielverwalter.Gewinner_anzeigen();
        }
    }
}
