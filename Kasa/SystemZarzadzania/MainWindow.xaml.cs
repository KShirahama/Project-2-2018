using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SystemZarzadzania
{
    
    public partial class MainWindow : Window
    {
        SerwerGlowny serwer;

        BinaryFormatter Formation = new BinaryFormatter();
        public void mainSerialize()
        {
            FileStream mStream = new FileStream("C:\\ProgramTestowy\\data.dat", FileMode.Create);
            Formation.Serialize(mStream, serwer);
            mStream.Close();
        }
        public void mainDeserialize()
        {
            FileStream openStream = new FileStream("C:\\ProgramTestowy\\data.dat", FileMode.Open);
            serwer = (SerwerGlowny)Formation.Deserialize(openStream);
            openStream.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainSerialize();
        }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                mainDeserialize();
            }
            catch (Exception)
            {

                serwer = new SerwerGlowny();
            }
            

            wylotTrasy.ItemsSource = serwer.lotniska;
            destynacjaTrasy.ItemsSource = serwer.lotniska;
            typSamolotu.ItemsSource = serwer.typySamolotow;
            lotniskoSamolotu.ItemsSource = serwer.lotniska;

            listaLotowRezerwacje.ItemsSource = serwer.loty;
            listaBiletowRezerwacje.ItemsSource = (ObservableCollection<Bilet>)listaLotowRezerwacje.SelectedItem;
            listaKlientow.ItemsSource = serwer.klienci;
            listaTras.ItemsSource = serwer.trasy;
            listaTypowSamolotow.ItemsSource = serwer.typySamolotow;
            listaSamolotow.ItemsSource = serwer.samoloty;
            listaLotnisk.ItemsSource = serwer.lotniska;

            NowyKlient();
            NowaTrasa();
            NoweLotnisko();
            NowySamolot();
            NowyTypSamolotu();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((e) =>
            {
                serwer.GenerujLoty();
            }, null, startTimeSpan, periodTimeSpan);
        }

        private void UsunRezerwacje_Click(object sender, RoutedEventArgs e)
        {
        }

        #region Klient

        private void NowyKlient()
        {
            idKlienta.Text = "" + serwer.klienciID;
            nazwaKlienta.Text = "";
            imieKlienta.Text = "";
            nazwiskoKlienta.Text = "";
        }

        private void DodajKlienta_Click(object sender, RoutedEventArgs e)
        {
            switch (typKlienta.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "Klient indywidualny":
                    if (imieKlienta.Text.Count() != 0 && nazwiskoKlienta.Text.Count() != 0)
                    {
                        serwer.DodajKlienta(new KlientIndywidualny(imieKlienta.Text.ToString(), nazwiskoKlienta.Text.ToString()));
                        NowyKlient();
                    }
                    else MessageBox.Show("Imie i nazwisko klienta nie mogą być puste!");
                    break;
                case "Pośrednik":
                    if (nazwaKlienta.Text.Count() != 0)
                    {
                        serwer.DodajKlienta(new Posrednik(nazwaKlienta.Text.ToString()));
                        NowyKlient();
                    }
                    else MessageBox.Show("Nazwa klienta nie może być pusta!");
                    break;
            }
        }

        private void UsunKlienta_Click(object sender, RoutedEventArgs e)
        {
            Klient klient = listaKlientow.SelectedItem as Klient;
            if (klient != null)
            {
                serwer.klienci.Remove(klient);
            }
        }

        private void TypKlienta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (typKlienta.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "Klient indywidualny":
                    nazwaKlientaLabel.Visibility = Visibility.Hidden;
                    nazwaKlienta.Visibility = Visibility.Hidden;
                    imieKlientaLabel.Visibility = Visibility.Visible;
                    imieKlienta.Visibility = Visibility.Visible;
                    nazwiskoKlientaLabel.Visibility = Visibility.Visible;
                    nazwiskoKlienta.Visibility = Visibility.Visible;
                    break;
                case "Pośrednik":
                    nazwaKlientaLabel.Visibility = Visibility.Visible;
                    nazwaKlienta.Visibility = Visibility.Visible;
                    imieKlientaLabel.Visibility = Visibility.Hidden;
                    imieKlienta.Visibility = Visibility.Hidden;
                    nazwiskoKlientaLabel.Visibility = Visibility.Hidden;
                    nazwiskoKlienta.Visibility = Visibility.Hidden;
                    break;
            }
            dodajKlienta.IsEnabled = IsEnabled;
        }

        #endregion

        #region Trasa

        private void NowaTrasa()
        {
            idTrasy.Text = serwer.trasyID.ToString();
            wylotTrasy.SelectedItem = null;
            destynacjaTrasy.SelectedItem = null;
            godzimaTrasy.Text = "";
            minutaTrasy.Text = "";
            odlegloscTrasy.Text = "";
            czestotliwoscTrasy.Text = "";
        }

        private void DodajTrase_Click(object sender, RoutedEventArgs e)
        {
            int idAktualnejTrasy, godzTrasy, minTrasy, odleglosc, czestotliwosc;
            if (odlegloscTrasy.Text.Count() != 0 && czestotliwoscTrasy.Text.Count() != 0 && godzimaTrasy.Text.Count() != 0 && minutaTrasy.Text.Count() != 0)
            {

                if (wylotTrasy.SelectedItem == null || destynacjaTrasy.SelectedItem == null)
                {
                    MessageBox.Show("Wylot i destynacja muszą być wybrane!");
                    return;
                }
                if (wylotTrasy.SelectedItem == destynacjaTrasy.SelectedItem)
                {
                    MessageBox.Show("Wylot i destynacja muszą być różne!");
                    return;
                }
                if (!Int32.TryParse(idTrasy.Text, out idAktualnejTrasy))
                {
                    MessageBox.Show("Wystąpił problem z ID!");
                    return;
                }
                if (!Int32.TryParse(godzimaTrasy.Text, out godzTrasy))
                {
                    MessageBox.Show("Godzina musi być liczbą!");
                    return;
                }
                if (!Int32.TryParse(minutaTrasy.Text, out minTrasy))
                {
                    MessageBox.Show("Minuta musi być liczbą!");
                    return;
                }
                if (!Int32.TryParse(odlegloscTrasy.Text, out odleglosc))
                {
                    MessageBox.Show("Odległość musi być liczbą!");
                    return;
                }
                if (!Int32.TryParse(czestotliwoscTrasy.Text, out czestotliwosc))
                {
                    MessageBox.Show("Częstotliwość musi być liczbą!");
                    return;
                }
                if(godzTrasy > 23)
                {
                    MessageBox.Show("Dzień ma tylko 24 godziny./n(Zakres 0 - 23)");
                    return;
                }
                if (godzTrasy > 59)
                {
                    MessageBox.Show("Godzina ma tylko 60 minut./n(Zakres 0 - 59)");
                    return;
                }

                serwer.DodajTrase(new Trasa(idAktualnejTrasy, odleglosc, czestotliwosc, new DateTime(1,1,1, godzTrasy, minTrasy, 0), (Lotnisko)wylotTrasy.SelectedItem, (Lotnisko)destynacjaTrasy.SelectedItem));
                NowaTrasa();
            }
            else MessageBox.Show("Pola nie mogą być puste!");
        }

        private void UsunTrase_Click(object sender, RoutedEventArgs e)
        {
            Trasa trasa = listaTras.SelectedItem as Trasa;
            if (trasa != null)
            {
                serwer.trasy.Remove(trasa);
            }
        }

        #endregion

        #region TypSamolotu

        private void NowyTypSamolotu()
        {
            idTypuSamolotu.Text = serwer.typySamolotowID.ToString();
            nazwaTypuSamolotu.Text = "";
            zasiegTypuSamolotu.Text = "";
            iloscMiejscTypuSamolotu.Text = "";
        }

        private void DodajTypSamolotu_Click(object sender, RoutedEventArgs e)
        {
            int idTypu, zasieg, iloscMiejsc;
            if ((nazwaTypuSamolotu.Text.Count() != 0) && (zasiegTypuSamolotu.Text.Count() != 0) && (iloscMiejscTypuSamolotu.Text.Count() != 0))
            {
                String nazwaTypu = nazwaTypuSamolotu.Text.ToString();
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
            idSamolotu.Text = serwer.samolotyID.ToString();
            nazwaSamolotu.Text = "";
            typSamolotu.SelectedItem = null;
            lotniskoSamolotu.SelectedItem = null;
        }

        private void DodajSamolot_Click(object sender, RoutedEventArgs e)
        {
            int idSamolotu;
            if (nazwaSamolotu.Text.Count() != 0)
            {
                String nazwaAktualnegoSamolotu = nazwaSamolotu.Text.ToString();
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
            idLotniska.Text = serwer.lotniskaID.ToString();
            nazwaLotniska.Text = "";
        }

        private void DodajLotnisko_Click(object sender, RoutedEventArgs e)
        {
            if (nazwaLotniska.Text.Count() != 0)
            {
                serwer.DodajLotnisko(new Lotnisko(Int32.Parse(idLotniska.Text), nazwaLotniska.Text.ToString()));
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

        private void typKlienta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
