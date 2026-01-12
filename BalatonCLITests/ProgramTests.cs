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
        [DataRow("A", 100)]
        [DataRow("B", 10000)]
        [DataRow("C", 10000000)]
        public void adoTest(string kategoria, int terulet)
        {
            int akategoria = Program.akategoria, bkategoria = Program.bkategoria, ckategoria = Program.ckategoria;
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
            Assert.AreEqual(1, Program.ado(kategoria, terulet));
        }

        [TestMethod()]
        [DataRow("A", 0)]
        [DataRow("B", 0)]
        [DataRow("C", 0)]
        public void adoTestHaTeruletNulla(string kategoria, int terulet)
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
            Assert.AreEqual(0, Program.ado(kategoria, terulet));
        }

        [TestMethod()]
        [DataRow("A", 1)]
        [DataRow("B", 1)]
        [DataRow("C", 1)]
        [DataRow("A", 0)]
        [DataRow("B", 0)]
        [DataRow("C", 0)]
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
            Assert.AreEqual(0, Program.ado(kategoria, terulet));
        }
    }
}