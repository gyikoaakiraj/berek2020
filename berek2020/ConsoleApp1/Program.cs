using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace berek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Berek> berek = new List<Berek>();
            FileStream fs = new FileStream("berek2020.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            bool elso = true;
            while (!sr.EndOfStream)
            {
                if (elso)
                {   
                    elso = false;
                    sr.ReadLine();
                }
                else
                {
                    berek.Add(new Berek(sr.ReadLine()));

                }
            }
            Console.WriteLine($"3. Feladat: {berek.Count}");
            double osszeg = berek.Sum(k => k.Ber);
            double atlag = (osszeg / berek.Count) / 1000;
            Console.WriteLine($"4. Feladat: {atlag:0.0} eFt");
            Console.Write($"5. Feladat: Kérem a részleg nevét: ");
            string freszleg = Console.ReadLine();
            List<Berek> freszlegesek = berek.FindAll(k => k.Hely == freszleg);
            if (freszlegesek.Count == 0)
            {
                Console.WriteLine("6. Feladat: A megadott részleg nem létezik a cégnél!");
            }
            else
            {
                Berek legnagyobb = freszlegesek.MaxBy(k => k.Ber);
                Console.WriteLine($"6. Feladat: A legtöbbet kereső dolgozó a megadott részlegen");
                Console.WriteLine($"\tNév: {legnagyobb.Nev}");
                Console.WriteLine($"\tNeme: {legnagyobb.Neme}");
                Console.WriteLine($"\tBelépés: {legnagyobb.Csatlakozas}");
                Console.WriteLine($"\tBér: {legnagyobb.Ber} Forint");
            }
            Console.WriteLine("7. Feladat: Statisztika");
            var osztalyok = berek.Select(k => k.Hely);
            foreach (var item in osztalyok.Distinct())
            {
                int csoportdb = berek.Count(k => k.Hely == item);
                Console.WriteLine($"\t{item} - {csoportdb}");
            }
            Console.ReadKey();
        }
    }
}
