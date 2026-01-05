using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [DataRow("A", 1)]
        [DataRow("B", 1)]
        [DataRow("C", 1)]
        public void adoTest(string kategoria, int terulet)
        {
            int akategoria = 1, bkategoria = 1, ckategoria = 1;
            int ertek = 0;
            switch (kategoria)
            {

                case "A":
                    ertek = akategoria * terulet;
                    break;
                case "B":
                    ertek = bkategoria * terulet;
                    break;
                case "C":
                    ertek = ckategoria * terulet;
                    break;
            }
            Assert.AreEqual(1, ertek);
        }

        [TestMethod()]
        [DataRow("A", 1)]
        [DataRow("B", 1)]
        [DataRow("C", 1)]
        public void adoTestNulla(string kategoria, int terulet)
        {
            int akategoria = 0, bkategoria = 0, ckategoria = 0;
            int ertek = 0;
            switch (kategoria)
            {

                case "A":
                    ertek = akategoria * terulet;
                    break;
                case "B":
                    ertek = bkategoria * terulet;
                    break;
                case "C":
                    ertek = ckategoria * terulet;
                    break;
            }
            Assert.AreEqual(0, ertek);
        }
    }
}