using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizibicikliKolcsonzo
{
    internal class Kolcsonzes
    {
        public string Nev { get; set; }
        public string Jarmuazonosito { get; set; }
        public int Elvitelora { get; set; }
        public int Elvitelperc { get; set; }
        public int Visszaora { get; set; }
        public int Visszaperc { get; set; }

        public Kolcsonzes(string sor)
        {
            var v = sor.Split(';');
            this.Nev = v[0];
            this.Jarmuazonosito = v[1];
            this.Elvitelora = int.Parse(v[2]);
            this.Elvitelperc = int.Parse(v[3]);
            this.Visszaora = int.Parse(v[4]);
            this.Visszaperc = int.Parse(v[5]);
        }
    }
}
