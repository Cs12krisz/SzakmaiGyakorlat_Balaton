using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Epitmeny
    {
        public Epitmeny(int szamok, string utca, string hazSzam, string adoKategoria, int terulet)
        {
            Szamok = szamok;
            Utca = utca;
            HazSzam = hazSzam;
            AdoKategoria = adoKategoria;
            Terulet = terulet;
        }

        public int Szamok { get; set; }
        public string Utca { get; set; }
        public string HazSzam { get; set; }
        public string AdoKategoria { get; set; }
        public int Terulet { get; set; }



    }
}
