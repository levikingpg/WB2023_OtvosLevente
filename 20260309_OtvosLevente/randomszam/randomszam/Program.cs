using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace randomszam
{
    namespace randomszam
    {
        class Program
        {
            static void Main()
            {
                int[,] m = new int[10, 10];
                int[,] f = new int[10, 10];
                Random r = new Random();

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        m[i, j] = r.Next(100);
                        Console.Write(m[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                for (int k = 1; k <= 3; k++)  
                {
                    Console.WriteLine("\nForgatas " + k + ":\n");

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            f[j, 9 - i] = m[i, j];
                        }
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Console.Write(f[i, j] + " ");
                            m[i, j] = f[i, j];
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}