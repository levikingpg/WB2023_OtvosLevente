using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace szamonkeres
{
    internal class Program
    {
        static void Main(string[] args)
        {//program amely bekeri egy haromszog oldalanak hosszat.
            //a bekert ertekek csak 0-nal nagyobbak lehetnek
            //a 3 oldal megadasa utan, ira ki: a harom oldal valoban egy haromszog oldalalai-e?
            Console.WriteLine("Adja meg a háromszög A oldalát: ");
            double A = double.Parse(Console.ReadLine());
            Console.WriteLine();
            


                Console.WriteLine("Adja meg a háromszög B oldalát:  ");
                double B = double.Parse(Console.ReadLine());
            Console.WriteLine();

          


            Console.WriteLine("Adja meg a háromszög C oldalát:  ");
                double C = double.Parse(Console.ReadLine());
                Console.WriteLine();

            if (A > 0 & B > 0 & C > 0)
            {
                Console.WriteLine("Az összes oldal nagyobb mint 0");

            }
            else
            {
                Console.WriteLine("AZ egyik oldal kisebb mint 0, adj meg uj szamokat");
            }

            

                Console.ReadKey();
            }
        }
    }
