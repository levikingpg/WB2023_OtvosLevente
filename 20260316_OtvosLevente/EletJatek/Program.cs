using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    class EletjatekSzimulator
    {
        private int[,] matrix;
        private int oszlopokSzama;
        private int sorokSzama;

        public EletjatekSzimulator(int oszlopokSzama, int sorokSzama)
        {
            this.oszlopokSzama = oszlopokSzama + 2;
            this.sorokSzama = sorokSzama + 2;


            matrix = new int[this.sorokSzama, this.oszlopokSzama];

            Random rnd = new Random();

            for (int i = 1; i < this.sorokSzama - 1; i++)
            {
                for (int j = 1; j < this.oszlopokSzama - 1; j++)
                {
                    matrix[i, j] = rnd.Next(0, 2);
                }
            }
        }

        public void Megjelenit()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == matrix.GetLength(0) - 1 || j == matrix.GetLength(1) - 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        if (matrix[i, j] == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("S");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
   // private void 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EletjatekSzimulator szimulator = new EletjatekSzimulator(9, 5);

            szimulator.Megjelenit();
            

            Console.ReadLine();
        }
    }
}