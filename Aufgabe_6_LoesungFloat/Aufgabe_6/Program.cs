using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Aufgabe_6
{

    class Program
    {
        static int iSpieler = 2;

        static void Main(string[] args)
        {
            Spielverwalter wSpielverwalter = new Spielverwalter();

            
            Console.WriteLine("Willkommen");

            int i = 0;

            int art;
            float pos;
            float speed;
            float dmg;
            float armor;
            float life;
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
                    if (float.TryParse(Console.ReadLine(), out pos))
                    {
                        if (pos >= 0 && pos < 1000 )
                        {
                            if (i > 0)
                            {
                                if (wSpielverwalter.is_kollision_vorhanden(pos) == true)
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
                            Console.WriteLine("Falsche Eingabe!!!Kein Null und negative Werte!!Nochmal");
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
                    if (float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out speed))
                    {
                        if (speed < 0 || float.IsInfinity(speed) || float.IsNaN(speed))
                        {
                            Console.WriteLine("Falsche Eingabe!!!Kein Null kein negative Werte!!Nochmal");
                        }
                        else
                        {
                            if (i > 0)
                            {
                                if (wSpielverwalter.speed_kontrolle(speed) == true)
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
                    if (float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out dmg))
                    {
                        if (dmg == 0 || dmg < 0|| float.IsInfinity(dmg) || float.IsNaN(dmg))
                        {
                            Console.WriteLine("Falsche Eingabe!!!Kein Null kein negative Werte!!Nochmal");
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
                // Armor erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Armor: ");
                    if (float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out armor))
                    {
                        if (armor == 0 || armor < 0 || float.IsInfinity(armor) || float.IsNaN(armor))
                        {
                            Console.WriteLine("Falsche Eingabe!!!Kein Null kein negative Werte!!Nochmal");
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
                // Life erfassen
                do
                {
                    is_falsche_eingabe = true;
                    Console.Write("Life: ");
                    if (float.TryParse(Console.ReadLine(), out life))
                    {
                        if (life == 0 || life < 0 || float.IsInfinity(armor) || float.IsNaN(armor))
                        {
                            Console.WriteLine("Falsche Eingabe!!!Kein Null kein negative Werte!!Nochmal");
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
                wSpielverwalter.Spieler_crieren(art, pos, speed, dmg, armor, life, name);
                i++;

            }
            while (i < iSpieler);
            Console.WriteLine("____________________________");
            wSpielverwalter.Set_lauf_richtung();
            wSpielverwalter.Infos_Anzeigen();
            wSpielverwalter.spielRunde();
            wSpielverwalter.Gewinner_anzeigen();
            Console.WriteLine("Press something");
            Console.ReadKey();
        }
    }
}
