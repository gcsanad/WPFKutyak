﻿using System;
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
        private List<KutyakOsztaly> kutyaNevek = File.ReadAllLines("Adatok\\KutyaNevek.csv").Skip(1).Select(x => new KutyakOsztaly(x, false)).ToList();
        private List<KutyakOsztaly> kutyak = File.ReadAllLines("Adatok\\Kutyak.csv").Skip(1).Select(x => new KutyakOsztaly(x)).ToList();
        private List<KutyakOsztaly> kutyaFajtak = File.ReadAllLines("Adatok\\KutyaFajtak.csv").Skip(1).Select(x => new KutyakOsztaly(x, true)).ToList();
        KutyakOsztaly kezelo = new KutyakOsztaly();
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
            
            KutyakOsztaly legidosebb = kutyak.Where(x => x.Eletkor == kutyak.Max(x => x.Eletkor)).First();

            //9.Feladat
            IGrouping<DateTime, KutyakOsztaly> orvosnalKutyak = kutyak.GroupBy(x => x.UtolsoOrvosiVizsgalat).OrderByDescending(x => x.Count()).First();
            lblLegleterheltebbNap.Content = orvosnalKutyak.Key.ToShortDateString();
            lblLegtobbKutya.Content = $"{orvosnalKutyak.Count()} kutya";
        }


        private void btnKiiratas_Click(object sender, RoutedEventArgs e)
        {

            DateTime idopont = (DateTime)dpDatumValaszto.SelectedDate;
            
            try
            {
                lbKutyaRendeloben.ItemsSource =kezelo.KutyaBeolvasas.Where(x => x.UtolsoOrvosiVizsgalat == dpDatumValaszto.Text).GroupBy(x => x.FajtaId).Select(x => x);
            }
            catch
            {

                MessageBox.Show("Ebben az időpontban nincs feljegyezve kutya");
            }
            
            /*
            if (lbKutyaRendeloben.Items.Count == 0)
            {
                MessageBox.Show("Ebben az időpontban nincs feljegyezve kutya");
            }*/
        }
    }
}
