using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for ModositasiAblak.xaml
    /// </summary>
    public partial class ModositasiAblak : Window
    {
        int _index = -1;
        public ModositasiAblak()
        {
            InitializeComponent();
        }

        public ModositasiAblak(Epitmeny telek, int index)
        {
            InitializeComponent();
            tbxAdoSzam.Text = telek.Szamok.ToString();
            tbxUtca.Text = telek.Utca;
            tbxHazszam.Text = telek.HazSzam;
            tbxAdoKategoria.Text = telek.AdoKategoria;
            tbxTerulet.Text = telek.Terulet.ToString();
            _index = index;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Epitmeny newEpitmeny = new Epitmeny(
            int.Parse(tbxAdoSzam.Text),
            tbxUtca.Text,
            tbxHazszam.Text,
            tbxAdoKategoria.Text,
            int.Parse(tbxTerulet.Text)
            );
            MainWindow.Modositas(newEpitmeny, _index);
            this.Close();
            
        }
    }
}
