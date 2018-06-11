using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Silnik;
using Silnik.Models;

namespace SystemZarzadzania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerwerGlowny serwer = new SerwerGlowny();

        public MainWindow()
        {
            InitializeComponent();
            typSamolotu.ItemsSource = serwer.typySamolotow;
            lotniskoSamolotu.ItemsSource = serwer.lotniska;
            listaTypowSamolotow.ItemsSource = serwer.typySamolotow;
            listaSamolotow.ItemsSource = serwer.samoloty;
            listaLotnisk.ItemsSource = serwer.lotniska;
            serwer.DodajLotnisko(new Lotnisko(1, "Yami"));
            serwer.DodajLotnisko(new Lotnisko(0, "Ryozanpaku"));
            serwer.DodajTypSamolotu(new TypSamolotu(0, "Air Force One", 99999, 5));
            NoweLotnisko();
            NowySamolot();
            NowyTypSamolotu();
        }

        #region TypSamolotu

        private void NowyTypSamolotu()
        {
            idTypuSamolotu.Text = "" + serwer.typySamolotowID;
            nazwaTypuSamolotu.Text = "";
            zasiegTypuSamolotu.Text = "";
            iloscMiejscTypuSamolotu.Text = "";
        }

        private void DodajTypSamolotu_Click(object sender, RoutedEventArgs e)
        {
            int idTypu, zasieg, iloscMiejsc;
            if ((nazwaTypuSamolotu.Text.Count() != 0) && (zasiegTypuSamolotu.Text.Count() != 0) && (iloscMiejscTypuSamolotu.Text.Count() != 0))
            {
                String nazwaTypu = "" + nazwaTypuSamolotu.Text;
                if(!Int32.TryParse(idTypuSamolotu.Text, out idTypu))
                {
                    MessageBox.Show("Wystąpił problem z ID!");
                    return;
                }
                if (!Int32.TryParse(zasiegTypuSamolotu.Text, out zasieg))
                {
                    MessageBox.Show("Zasięg musi być liczbą!");
                    return;
                }
                if (!Int32.TryParse(iloscMiejscTypuSamolotu.Text, out iloscMiejsc))
                {
                    MessageBox.Show("Ilość Miejsc musi być liczbą!");
                    return;
                }

                serwer.DodajTypSamolotu(new TypSamolotu(idTypu, nazwaTypu, zasieg, iloscMiejsc));
                NowyTypSamolotu();
            } 
            else MessageBox.Show("Pola nie mogą być puste!");
        }

        private void UsunTypSamolotu_Click(object sender, RoutedEventArgs e)
        {
            TypSamolotu typ = listaTypowSamolotow.SelectedItem as TypSamolotu;
            if (typ != null)
            {
                serwer.typySamolotow.Remove(typ);
            }
        }

        #endregion

        #region Samolot

        private void NowySamolot()
        {
            idSamolotu.Text = "" + serwer.samolotyID;
            nazwaSamolotu.Text = "";
            typSamolotu.SelectedItem = null;
            lotniskoSamolotu.SelectedItem = null;
        }

        private void DodajSamolot_Click(object sender, RoutedEventArgs e)
        {
            int idSamolotu;
            if (nazwaSamolotu.Text.Count() != 0)
            {
                String nazwaAktualnegoSamolotu = "" + nazwaSamolotu.Text;
                if (!Int32.TryParse(idTypuSamolotu.Text, out idSamolotu))
                {
                    MessageBox.Show("Wystąpił problem z ID!");
                    return;
                }
                if (lotniskoSamolotu.SelectedItem == null || typSamolotu.SelectedItem == null)
                {
                    MessageBox.Show("Typ i Lotnisko muszą być wybrane!");
                    return;
                }

                serwer.DodajSamolot(new Samolot(nazwaAktualnegoSamolotu, idSamolotu, (TypSamolotu)typSamolotu.SelectedItem, (Lotnisko)lotniskoSamolotu.SelectedItem));
                NowySamolot();
            }
            else MessageBox.Show("Pola nie mogą być puste!");
        }

        private void UsunSamolot_Click(object sender, RoutedEventArgs e)
        {
            Samolot samolot = listaSamolotow.SelectedItem as Samolot;
            if (samolot != null)
            {
                serwer.samoloty.Remove(samolot);
            }
        }

        #endregion

        #region Lotnisko

        private void NoweLotnisko()
        {
            idLotniska.Text = "" + serwer.lotniskaID;
            nazwaLotniska.Text = "";
        }

        private void DodajLotnisko_Click(object sender, RoutedEventArgs e)
        {
            if (nazwaLotniska.Text.Count() != 0)
            {
                serwer.DodajLotnisko(new Lotnisko(Int32.Parse(idLotniska.Text), ""+nazwaLotniska.Text));
                NoweLotnisko();
            }
            else MessageBox.Show("Nazwa Lotniska nie może być pusta!");
        }

        private void UsunLotnisko_Click(object sender, RoutedEventArgs e)
        {
            Lotnisko lotnisko = listaLotnisk.SelectedItem as Lotnisko;
            if (lotnisko != null)
            {
                serwer.lotniska.Remove(lotnisko);
            }
        }

        #endregion
    }
}
