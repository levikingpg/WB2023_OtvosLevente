using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;

namespace szalloda2
{
    class data
    {
        public ushort sorszam; 
        public byte szobaszam;
        public ushort erkNap;
        public ushort tavNAp;
        public byte VendegSzam;
        public byte reggeli;
        public string azonosito;

        public data(string line)
        {
            this.azonosito = "banan";

            try
            {
                string[] sz = line.Split(' ');
                ushort tmp = ushort.Parse(sz[0]);
                if (tmp > 0 && tmp <= Program.maxSSz) this.sorszam = tmp;
                else return;

                    byte tmp1 = byte.Parse(sz[1]);
                if (tmp1 > 0 && tmp1 <= Program.maxSsz) this.szobaszam = tmp1;
                else return;


                ushort tmp = ushort.Parse(sz[2]);
                if (tmp > 0 && tmp <= Program.maxSsz) this.erkNap = tmp;
                else return;


               ushort tmp = ushort.Parse(sz[3]);
                if (tmp > 0 && tmp <= Program.maxSsz) this.tavNAp = tmp;
                else return;
            
                byte tmp1 = byte.Parse(sz[4]);
                if (tmp1 > 0 && tmp1 <= Program.maxSsz) this.VendegSzam = tmp1;
                else return;

                byte tmp = byte.Parse(sz[5]);
                if (tmp1 > 0 && tmp1 <= Program.maxSsz) this.VendegSzam = tmp1;
                else return;

            }
            catch (Exception)
            {
                return;
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] honapok = File.ReadAllLines("honapok.txt", Encoding.UTF8);
            string[] fileAdat = File.ReadAllLines("pitypang.txt", Encoding.UTF8);
            
            ushort maxSsz = 0;
            try
            {
               maxSsz = ushort.Parse(fileAdat[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba!");
                Console.ReadKey();
                return;

                ushort[, ] napok = new ushort[12,3];
                for (int i = 0; i < napok.Length; i+=3)
                {
                    napok[i / 3 , 0] = ushort.Parse(honapok[i + 1]);
                    napok[i / 3 , 0] = ushort.Parse(honapok[i + 2]);

                }

            }
           
        }
    }
}
