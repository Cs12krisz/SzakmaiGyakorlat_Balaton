using BalatonCLI;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        static ObservableCollection<Epitmeny> epitmenyek = new ObservableCollection<Epitmeny>();
        public static int akategoria, bkategoria, ckategoria;

        public static void Modositas(Epitmeny telek, int index)
        {
            epitmenyek[index] = telek;
        }

        private void btnModositas_Click(object sender, RoutedEventArgs e)
        {
            ModositasiAblak modositasiAblak = new ModositasiAblak(epitmenyek[dtgTabla.SelectedIndex], dtgTabla.SelectedIndex);
            modositasiAblak.ShowDialog();
        }

        private void dtgTabla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (!ofd.ShowDialog().Value)
            {
                MessageBox.Show("Error");
            }

            using (StreamWriter sw = new StreamWriter(ofd.FileName))
            {
                sw.WriteLine("800 600 100");
                foreach (var epitmeny in epitmenyek)
                {
                    sw.WriteLine(epitmeny);
                }
            }
            MessageBox.Show("Sikeres mentés", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MainWindow()
        {
            InitializeComponent();
            cBoxAdoKategoria.SelectedIndex = 0;
            cBoxAdoKategoria.ItemsSource = new string[] { "A", "B", "C" };
            Feladat1();
            dtgTabla.ItemsSource = epitmenyek;
        }

        public void Feladat1()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (!openFileDialog.ShowDialog().Value)
            {
                MessageBox.Show("Error");
            }

            StreamReader sr = new StreamReader(openFileDialog.FileName);
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
           sr.Close();

        }
    }
}