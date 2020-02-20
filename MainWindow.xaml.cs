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
using aideInventaire.location;
using aideInventaire.materiel;

namespace aideInventaire
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            Materiel mt = new Materiel();
            mt.ShowDialog();
        }
       

        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            Location l = new Location();
            l.ShowDialog();
        }
    }
}
