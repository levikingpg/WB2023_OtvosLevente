using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alapokValtozokMegminden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Hello");
            Console.WriteLine("Hello");


            // string, int, double, boole, char
            string szoveg = "Béla"; 
            Console.WriteLine($"heló {szoveg}");
            Console.Write("Kérek egy nevet:   ");
            szoveg = Console.ReadLine();
            Console.WriteLine($"heló {szoveg}");
            int kor=0;
            Console.Write($"Kérem {szoveg} korát:  ");

            do
            {

                try
                {
                    kor = int.Parse(Console.ReadLine());
                    //int kor2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Hibás adat");
                }
            }
            while (kor < 1 || kor > 21);









            Console.WriteLine($"{szoveg} {kor} éves.");





            Console.ReadKey();
        }
    }
}
