using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizibicikliKolcsonzo
{
    internal class Program
    {
        static List<Kolcsonzes> kolcsonzes = new List<Kolcsonzes>();
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"..\..\res\kolcsonzesek.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader rs = new StreamReader(fs);
            rs.ReadLine();
            while (!rs.EndOfStream)
            {
                kolcsonzes.Add(new Kolcsonzes(rs.ReadLine()));
            }
            rs.Close();
            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {kolcsonzes.Count()}");
            Console.WriteLine("6. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine();
            bool volt = false;
            bool nevkiiras = false;
            foreach (var item in kolcsonzes)
            {
                if (item.Nev == nev)
                {
                    if(!nevkiiras)
                    {
                        Console.WriteLine($"{nev} Kölcsönzései");
                    }
                    volt = true;
                    nevkiiras = true;
                    Console.WriteLine($"{item.Elvitelora}:{item.Elvitelperc}-{item.Visszaora}:{item.Visszaperc}");
                }
            }
            if (!volt)
            {
                Console.WriteLine("Nem volt.");
            }
            Console.WriteLine($"7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            string ido = Console.ReadLine();
            var split = ido.Split(':');
            int E;
            int V;
            int K;
            foreach (var item in kolcsonzes)
            {
                E = (item.Elvitelora * 60) + item.Elvitelperc;
                V = (item.Visszaora * 60) + item.Visszaperc;
                K = (int.Parse(split[0]) * 60) + int.Parse(split[1]);
                if (E <= K && V >= K)
                {
                    Console.WriteLine($"{item.Elvitelora}:{item.Elvitelperc}-{item.Visszaora}:{item.Visszaperc} {item.Nev}");
                }
            }
            //8. feladat
            int penz = 0;
            foreach (var item in kolcsonzes)
            {
                penz += (2400 * kolcsonzes.Count());
            }
            Console.WriteLine($"pénz: {penz} FT" );
            //9. feladat
            StreamWriter sw = new StreamWriter(@"..\..\res\F.txt", false);
            sw.WriteLine("NĂŠv;JAzon;EĂra;EPerc;VĂra;Vperc");
            foreach (var item in kolcsonzes)
            {
                if (item.Jarmuazonosito == "F")
                {
                    sw.WriteLine($"{item.Nev};{item.Jarmuazonosito};{item.Elvitelora};{item.Elvitelperc};{item.Visszaora};{item.Visszaperc}");
                }
            }
            sw.Close();
            Console.WriteLine("9. feladat: F.txt legenerálva!");
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;
            int f = 0;
            int g = 0;
            foreach (var item in kolcsonzes)
            {
                if(item.Jarmuazonosito == "A")
                {
                    a++;
                }
                if(item.Jarmuazonosito == "B")
                {
                    b++;
                }
                if (item.Jarmuazonosito == "C")
                {
                    c++;
                }
                if (item.Jarmuazonosito == "D")
                {
                    d++;
                }
                if (item.Jarmuazonosito == "E")
                {
                    e++;
                }
                if (item.Jarmuazonosito == "F")
                {
                    f++;
                }
                if (item.Jarmuazonosito == "G")
                {
                    g++;
                }
            }
            Console.WriteLine("10. feladat: Statisztika");
            Console.WriteLine($"A - {a}\nB - {b}\nC - {c}\nD - {d}\nE - {e}\nF - {f}\nG - {g}");
            Console.ReadKey();
        }
    }
}
