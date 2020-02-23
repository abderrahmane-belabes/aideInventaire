using aideInventaire.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace aideInventaire.location
{
    /// <summary>
    /// Logique d'interaction pour Location.xaml
    /// </summary>
    public partial class Location : Window
    {
        public Location()
        {
            InitializeComponent();
            listerLocation();
        }
        public void listerLocation()
        {
            //string query = "select * from Materiel";
            //string query = "select idMat, libMat from Materiel";
            string query = "select libLoc from Location";
            SqlCommand cmd = new SqlCommand(query, Connexion.sqlcon);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Materiel");

            sda.Fill(dt);
            dgLocation.ItemsSource = dt.DefaultView;

            Connexion.sqlcon.Close();
        }

        private void btnAjoutLocation_Click(object sender, RoutedEventArgs e)
        {
            AjouterLocation ajl = new AjouterLocation();
            ajl.ShowDialog();
            listerLocation();
        }
    }
}
