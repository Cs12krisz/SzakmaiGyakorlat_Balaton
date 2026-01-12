using BalatonCLI;
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
        public MainWindow()
        {
            InitializeComponent();
            cBoxAdoKategoria.SelectedIndex = 0;
            cBoxAdoKategoria.ItemsSource = new string[] { "A", "B", "C" };
            Feladat1("utca.txt");
            dtgTabla.ItemsSource = epitmenyek;
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
    }
}