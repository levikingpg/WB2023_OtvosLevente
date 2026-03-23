using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Eletjatek2
{
    internal class Program
    {
        class EletjatekSzimulator
        {
            private int[,] Matrix;
            private int OszlopokSzama;
            private int SorokSzama;

            public EletjatekSzimulator(int oszlopokSz, int sorokSz)
            {
                this.OszlopokSzama = oszlopokSz;
                this.SorokSzama = sorokSz;
                this.Matrix = new int[sorokSz + 2, oszlopokSz + 2];
                Random random = new Random();
                for (int sor = 1; sor <= sorokSz; sor++)
                {
                    for (global::System.Int32 oszlop = 1; oszlop <= oszlopokSz; oszlop++)
                    {
                        Matrix[sor, oszlop] = random.Next(0, 2);
                    }
                }
                this.Matrix = new int[,] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 1, 1, 0, 0, 0, 0 }, { 0, 0, 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
                //this.Matrix = new int[,] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };

            }

            private void KovetkezoAllapot()
            {
                int[,] tmp = new int[SorokSzama + 2, OszlopokSzama + 2];
                int szomszedok = 0;
                for (int sor = 1; sor <= SorokSzama; sor++)
                {


                    for (global::System.Int32 oszlop = 1; oszlop <= OszlopokSzama; oszlop++)
                    {
                        szomszedok = Matrix[sor - 1, oszlop - 1] +
                            Matrix[sor - 1, oszlop] +
                            Matrix[sor - 1, oszlop + 1] +
                            Matrix[sor, oszlop - 1] +
                            Matrix[sor, oszlop + 1] +
                            Matrix[sor + 1, oszlop - 1] +
                            Matrix[sor + 1, oszlop] +
                            Matrix[sor + 1, oszlop + 1];
                        

                        if (Matrix[sor, oszlop] == 1 && (szomszedok == 2 || szomszedok == 3))
                        {
                            tmp[sor, oszlop] = 1;
                            continue;
                        }
                        if (Matrix[sor, oszlop] == 1 && (szomszedok < 2 || szomszedok > 3))
                        {
                            tmp[sor, oszlop] = 0;
                            continue;
                        }
                        if (Matrix[sor, oszlop] == 0 && szomszedok == 3)
                        {
                            tmp[sor, oszlop] = 1;
                            continue;
                        }
                    }
                    Matrix = tmp;
                }
            }

            private void Megjelenit()
            {
                for (int sor = 0; sor <= SorokSzama + 1; sor++)
                {
                    for (global::System.Int32 oszlop = 0; oszlop <= OszlopokSzama + 1; oszlop++)
                    {
                        if (sor == 0 || oszlop == 0 || sor == SorokSzama + 1 || oszlop == OszlopokSzama + 1)
                        {
                            Console.Write("X");
                            continue;
                        }
                        if (Matrix[sor, oszlop] == 0)
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("S");
                        }
                    }
                    Console.WriteLine();
                }
            }

            public void Run()
            {
                Megjelenit();
                KovetkezoAllapot();
                

            }
        }

        static void Main(string[] args)
        {
            EletjatekSzimulator a = new EletjatekSzimulator(5, 9);
            a.Run();
            a.Run();
            a.Run();
            a.Run();
            Console.ReadKey();
        }
    }
}