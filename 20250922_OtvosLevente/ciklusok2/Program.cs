

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ciklusok2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //1. Írj programot, mely beolvas egy pozitív egész számot, és kiírja az egész számokat a képernyőre eddig a számig, egymástól szóközzel elválasztva!
            Console.Write("Írj be egy számot:  ");
            int szam = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < szam; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(); 
            Console.WriteLine();

            //2. Írj programot, mely beolvas egy pozitív egész számot, és kiírja az egész számokat egymás alá a képernyőre eddig a számig!

            Console.Write("Írj be egy számot:  ");
            int szam1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= szam1; i++)
            { Console.WriteLine(i); }
            Console.WriteLine();
            Console.WriteLine();

            //3.  Írj programot, mely beolvas egy pozitív egész számot, és kiírja az osztóit!

            Console.Write("Kérek egy számot:  ");
           int szam2 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= szam2; i++)
            {
                if (szam2 % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
            
            //4. Írj programot, mely beolvas egy pozitív egész számot, és kiírja az osztóinak az összegét!
            Console.Write("kérek egy számot:  ");
            int osszeg = 0;
            int szam3 = Convert.ToInt32(Console.ReadLine());


            for (int i = 1; i <= szam3; i++)
            {
                if (szam3 % i == 0)
                {
                    osszeg += i;
                    
                }
            }
            Console.WriteLine(osszeg);
           
            // 5.Írj programot, mely beolvas egy pozitív egész számot, és megmondja, hogy tökéletes szám - e!
            // (A tökéletes számok azok, melyek osztóinak összege egyenlő a szám kétszeresével.Ilyen szám pl.a 6, mert 2 * 6 = 1 + 2 + 3 + 6.)

            Console.WriteLine("Írj be egy számot");
            int szam = Convert.ToInt32(Console.ReadLine());
            int osszeg = 0;

            for (int i = 1; i <= szam; i++)
            {
                if (szam % i == 0)
                {
                    osszeg += i;
                }
    
            }
            if (szam * 2 == osszeg)
            {
                Console.WriteLine("Ez egy tökéletes szám");
            }

            else
            {
                Console.WriteLine("Ez nem tökéletes szám");
            }
             

            int szam = 0
                do
            {
                Console.Write("kerek egy szamot");
                szam = int parse(Console.ReadLine());
            }
                while (szam < 1);
            */
            int szam = 0;
            do
            {
                Console.Write("kérek egy számot");
                szam = double.Parse(Console.ReadLine());
                s += szam;

            }
            while (szam < 10);
            Console.ReadKey();  
            

        }
    }
}
