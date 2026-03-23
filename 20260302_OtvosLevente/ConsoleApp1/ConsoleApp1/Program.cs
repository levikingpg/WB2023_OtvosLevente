using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Forgoracs
{
    internal class Program
    {
        class Fracs
        {
            public char[,] Kodlemez;
            public char[,] Titkositott;
            public string Titkositando;

            public Fracs()
            {
                Kodlemez = new char[8, 8];
                Titkositott = new char[8, 8];
                Titkositando = "";


            }

            //static void Forgatkodlemez():
            {

            }

        public void Atalakit()
            {
                Titkositando = Titkositando.Replace(" ", "");
                if (Titkositando.Length > 64)
                {
                    Console.WriteLine("Túl hosszú a titkosítandó szöveg");
                }
                while (Titkositando.Length < 64)
                {
                    Titkositando += "X";
                }
            }

       



        static void Main(string[] args)
            {
                List<Fracs> fracsk = new List<Fracs>();
                StreamReader sr = new StreamReader("kodlemez.txt");
                while (!sr.EndOfStream)
                {
                    Fracs f = new Fracs();
                    for (int i = 0; i < 8; i++)
                    {
                        string sor = sr.ReadLine();
                        for (int j = 0; j < 8; j++)
                        {
                            f.Kodlemez[i, j] = sor[j];
                        }
                    }
                    f.Titkositando = sr.ReadLine();
                    fracsk.Add(f);
                }
                foreach (var item in fracsk)
                {
                    Console.WriteLine(item);
                    //5. feladat

                    List<string> szovegek = new List<string>();
                    StreamReader sr2 = new StreamReader("szoveg.txt");
                    while (!sr2.EndOfStream)
                    {
                        szovegek.Add(sr2.ReadLine());
                    }
                    foreach (var item2 in szovegek)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine(
                        "A titkosítandó szöveg: " + item.Titkositando
                        );

                    // 6. feladat 
                    Console.WriteLine();

                    // 7. feladat


                    Console.ReadKey();

                }







            }
        }

    }
}

