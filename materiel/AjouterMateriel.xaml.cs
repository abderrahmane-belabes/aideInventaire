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

namespace aideInventaire.materiel
{
    /// <summary>
    /// Logique d'interaction pour AjouterMateriel.xaml
    /// </summary>
    public partial class AjouterMateriel : Window
    {
        public AjouterMateriel()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ListerLocation() 
        {
            string query = "select * from Location";
            Connexion.sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Connexion.sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cbxLocation.ItemsSource = dt.DefaultView;
            cbxLocation.DisplayMemberPath = "libLoc";
            cbxLocation.SelectedValuePath = "idLoc";
            
            //cmd.Dispose();
            Connexion.sqlcon.Close();
        }
        public void ListerCat()
        {
            string query = "select * from Catégorie";
            Connexion.sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Connexion.sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cbxCategorie.ItemsSource = dt.DefaultView;
            cbxCategorie.DisplayMemberPath = "libCat";
            cbxCategorie.SelectedValuePath = "idCat";
            //cmd.Dispose();
            Connexion.sqlcon.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListerCat();
            ListerLocation();
        }

        private void btnAjouterMateriel_Click(object sender, RoutedEventArgs e)
        {   if(cbxCategorie.SelectedItem != null && cbxLocation!= null)
            {
                try
                {
                    //récupérer les informations saisies
                    string idCat = cbxCategorie.SelectedValue.ToString();
                    string idLoc = cbxLocation.SelectedValue.ToString();
                    string nomMat = txtNomMat.Text;
                    string numSerMat = txtNumSerie.Text;
                    //construire la requete
                    string query = "Insert Into Materiel(libMat, idCat, numSerie, idLoc) values('" + nomMat + "'," + idCat + ",'" + numSerMat + "'," + idLoc + ")";

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
