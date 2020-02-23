using aideInventaire.Dal;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour AjouterLocation.xaml
    /// </summary>
    public partial class AjouterLocation : Window
    {
        public AjouterLocation()
        {
            InitializeComponent();
        }

        private void btnAjouterLocation_Click(object sender, RoutedEventArgs e)
        {
            if ( txtNomLocation != null)
            {
                try
                {
                    //récupérer les informations saisies
                    string liblOC = txtNomLocation.Text;
                    
                    //construire la requete
                    string query = "Insert Into Location(libLoc) values('"+liblOC+"')";

                    Connexion.sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query, Connexion.sqlcon);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //Materiel mt = new Materiel();
                        //this.Hide();
                        //mt.Show();
                        this.Close();
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                finally
                {
                    Connexion.sqlcon.Close();
                }
            }
            else
            {
                MessageBox.Show("veuillez selectionner une valeur");
            }
        }
    }
}
