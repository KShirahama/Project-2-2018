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
using System.Windows.Shapes;
using Silnik.ViewModels;

namespace Kasa
{
    /// <summary>
    /// Interaction logic for Lotniska.xaml
    /// </summary>
    public partial class Lotniska : Window
    {
        private readonly SesjaKasy _sesjaKasy = new SesjaKasy();
        public Lotniska()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sesjaKasy.DodajSamolot();
        }
    }
}
