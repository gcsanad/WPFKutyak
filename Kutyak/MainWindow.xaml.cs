using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kutyak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<KutyakOsztaly> kutyaNevek = File.ReadAllLines("KutyaNevek.csv").Skip(1).Select(x => new KutyakOsztaly(x, false)).ToList();
        private List<KutyakOsztaly> kutyak = File.ReadAllLines("Kutyak.csv").Skip(1).Select(x => new KutyakOsztaly(x)).ToList();
        private List<KutyakOsztaly> kutyaFajtak = File.ReadAllLines("KutyaFajtak.csv").Skip(1).Select(x => new KutyakOsztaly(x, true)).ToList();
        public MainWindow()
        {
            InitializeComponent();
            dpDatumValaszto.Text = Convert.ToString(DateTime.Now);
            //3.Feladat
            lblKutyanavekSzama.Content = kutyaNevek.Count;
            //6.Feladat
            lblAtlagEletkor.Content =  Math.Round(kutyak.Average(x => x.Eletkor), 2);
            //7.Feladat
            int id = kutyak.OrderByDescending(x => x.Eletkor).ToList()[0].NevId;
            int eletkorId = kutyak.OrderByDescending(x => x.Eletkor).ToList()[0].FajtaId;
            string nev = kutyaNevek.Where(x => x.Id == id).ToList()[0].KutyaNev;
            string fajta = kutyaFajtak.Where(x => x.Id == eletkorId).ToList()[0].Nev;
            lblLegidosebbKutya.Content = $"{nev}, {fajta}";
        }

        private void btnKiiratas_Click(object sender, RoutedEventArgs e)
        {
            lbKutyaRendeloben.ItemsSource = kutyak.Where(x => Convert.ToString(x.UtolsoOrvosiVizsgalat) == dpDatumValaszto.Text).GroupBy(x => x.KutyaNev).Select(x => $"{x.Key} : {x.Count()}");
            
            /*
            if (lbKutyaRendeloben.Items.Count == 0)
            {
                MessageBox.Show("Ebben az időpontban nincs feljegyezve kutya");
            }*/
        }
    }
}
