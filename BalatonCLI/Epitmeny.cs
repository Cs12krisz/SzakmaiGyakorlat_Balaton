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

        public int Szamok { get; private set; }
        public string Utca { get; private set; }
        public string HazSzam { get; private set; }
        public string AdoKategoria { get; private set; }
        public int Terulet { get; private set; }

        public bool SetAdoKategoria(string adoKategoria) 
        {
            AdoKategoria = adoKategoria;
            return true;
        }

        public override string ToString()
        {
            return $"{Szamok} {Utca} {HazSzam} {AdoKategoria} {Terulet}";
        }
    }
}
