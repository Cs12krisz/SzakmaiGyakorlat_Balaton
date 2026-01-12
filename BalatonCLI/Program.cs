



namespace BalatonCLI
{
    public class Program
    {
        static List<Epitmeny> epitmenyek = new List<Epitmeny>();
        public static int akategoria, bkategoria, ckategoria;

        static void Main(string[] args)
        {
            Feladat1("utca.txt");
            Feladat2();
            Feladat3();
            Feladat5();
            Feladat6("teljes.txt");
        }

        public static void Feladat6(string fajlnev)
        {
            var epitmenyAdoval = epitmenyek.Select(e => new { e, Ado = ado(e.AdoKategoria, e.Terulet) });
            using (StreamWriter sw = new StreamWriter(fajlnev))
            {
                foreach (var item in epitmenyAdoval)
                {
                    sw.WriteLine($"{item.e.Szamok} {item.e.Utca} {item.e.HazSzam} {item.e.Terulet} {item.Ado}");
                }
            }

        }

        public static void Feladat5()
        {
            var epitmenyekCsoport = epitmenyek
                .GroupBy(e => e.AdoKategoria)
                .Select(e => new 
                { e.Key,
                    Db = e.Count(),
                    Osszesen = e.Sum(elem => ado(elem.AdoKategoria, elem.Terulet))
                })
                .OrderBy(e => e.Key);
                
            foreach (var csoport in epitmenyekCsoport)
            {
                Console.WriteLine($"{csoport.Key} sávba {csoport.Db} telek esik, az adó {csoport.Osszesen} Ft.");
            }
        }

        public static void Feladat3()
        {
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            string adoSzam = Console.ReadLine();
            var utcai = epitmenyek
                .Where(e => e.Szamok == int.Parse(adoSzam))
                .Select(e => new { e.Utca, e.HazSzam });
            foreach (var item in utcai)
            {
                Console.WriteLine($"{item.Utca} utca {item.HazSzam}");
            }
        }

        public static void Feladat2()
        {
            Console.WriteLine($"2. feladat. A mintában {epitmenyek.Count()} telek szerepel.");
        }

        public static void Feladat1(string fajlNev)
        {
            using (StreamReader sr = new StreamReader(fajlNev))
            {
                string[] elsoSor = sr.ReadLine().Split(" ");
                akategoria = int.Parse(elsoSor[0]);
                bkategoria = int.Parse(elsoSor[1]);
                ckategoria = int.Parse(elsoSor[2]);

                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(" ");
                    Epitmeny ujEpitmeny = new Epitmeny(
                        int.Parse(sor[0]),
                        sor[1],
                        sor[2],
                        sor[3],
                        int.Parse(sor[4])
                    );
                    epitmenyek.Add(ujEpitmeny);
                }
            }
        }

        public static int ado(string kategoria, int alapterulet)
        {
            int ado = 0;
            if (kategoria == "A")
            {
                ado = akategoria * alapterulet;
            }
            else if (kategoria == "B")
            {
                ado = bkategoria * alapterulet;
            }
            else if (kategoria == "C")
            {
                ado = ckategoria * alapterulet;
            }

            if(ado < 10000)
            {
                return 0;
            }

            return ado;

        }
    }
}
