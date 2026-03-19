using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;


namespace szalloda
{
    class foglalas
    {
        public int fogsorszam;
        public int szobszam;
        public int erkezes;
        public int tavozas;
        public int vendegekszama;
        public bool reggeli;
        public string azonosito;

        public foglalas(string line)
        {   
            this.fogsorszam = Convert.ToInt32(line.Split(' ')[0]);
            this.szobszam = Convert.ToInt32(line.Split(' ')[1]);
            this.erkezes = Convert.ToInt32(line.Split(' ')[2]);
            this.tavozas = Convert.ToInt32(line.Split(' ')[3]);
            this.vendegekszama = Convert.ToInt32(line.Split(' ')[4]);
            this.reggeli = line.Split(' ')[5] == "1";
            this.azonosito = line.Split(' ')[6];
        }

        class honap
        {

        }
        internal class Program
        { }
        static void Main(string[] args)
        {
            List<foglalas> foglalasok = new List<foglalas>();
            StreamReader sr = new StreamReader("pitypang.txt",  Encoding.UTF8);
            sr.ReadLine();
            



            while (!sr.EndOfStream)
            {
                foglalasok.Add(new foglalas(sr.ReadLine()));
             
            }
            //--------------------------------2.feladaat-------------------------------
            int max = 0;
            int maxi = 0;
            for (int i = 0; i < foglalasok.Count; i++)
            {
                if ((foglalasok[i].tavozas  - foglalasok[i].erkezes) > max)
                {
                    max = (foglalasok[i].tavozas - foglalasok[i].erkezes);
                    maxi = i; 
                }

            }

            Console.WriteLine($"{foglalasok[maxi].azonosito} ({foglalasok[maxi].erkezes}) {max} ");

            //--------------------------------3.feladaat-------------------------------
            

            Console.ReadKey();

        }
    }
}