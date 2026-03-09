using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Markup;
namespace Ciklusok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //hatultesztelo ciklus
            double valos;
            do
            {
                Console.Write("Kérem a Pi értékét:  ");
                valos = Convert.ToDouble(Console.ReadLine());
                
            }
            while (valos < 3.14 || valos > 3.15);


            while (valos == 3.14)
            {
                Console.WriteLine("Nem tul pontos az ertek");
                valos = Math.PI;
            }
            // szamlalo ciklus
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Az eltérés: {Math.PI - valos}");
            }

            Console.Write("Kérek egy szöveget:  ");
            string szoveg = Console.ReadLine();
            foreach (var item in szoveg)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
