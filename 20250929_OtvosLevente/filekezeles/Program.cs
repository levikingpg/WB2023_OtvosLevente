using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace filekezeles
{
    class data
    {
        public int taxi_id;
        public string indulas;
        public int idotartam;
        public double tavolsag;
        public double literdij;
        public double borravalo;
        public string fizetes_modja;

        //konstrukor
        public data(string a)
        {
            string[] sz = a.Split(';');

            this.taxi_id = int.Parse(sz[0]);
            this.indulas = sz[1];
            this.idotartam = int.Parse(sz[2]);
            this.tavolsag = double.Parse(sz[3]);
            this.literdij = double.Parse(sz[4]);
            this.borravalo = double.Parse(sz[5]);
            this.fizetes_modja = sz[6];

        }
        public override string ToString()
        {
            return $"taxi ID: {taxi_id} \t Dátum: {indulas}\t Fizetés módja: {fizetes_modja}"; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<data> list = new List<data>();
            StreamReader sr =  new StreamReader("fuvar.csv", Encoding.UTF8);
           sr.ReadLine();
            while (!sr.EndOfStream)
            {
                list.Add(new data(sr.ReadLine()));
                
            }
            sr.Close();
            //lista megjelen
            foreach (data item in list)
            {
                Console.WriteLine(item.ToString());
                
            }

            Console.ReadKey();
        }
    }
}
