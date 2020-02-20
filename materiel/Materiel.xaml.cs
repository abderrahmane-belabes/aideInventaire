using aideInventaire.Dal;
using System;
using System.Collections;
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
    /// Logique d'interaction pour Materiel.xaml
    /// </summary>
    public partial class Materiel : Window
    {
        public Materiel()
        {
            InitializeComponent();
            try
            {
                listerMateriel();
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
        public void listerMateriel()
        {
            string query = "select * from Materiel";
            //string query = "select idMat, libMat from Materiel";
            //string query = "select m.libMat, m.numSerie, c.libCat, l.libLoc from Materiel m inner join Catégorie c on m.idCat = c.idCat inner join Location l on l.idLoc = m.idLoc ";
            SqlCommand cmd = new SqlCommand(query,Connexion.sqlcon);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Materiel");
           
            sda.Fill(dt);
            dgMateriel.ItemsSource = dt.DefaultView;

            Connexion.sqlcon.Close();
        }
        private void btnAjoutMateriel_Click(object sender, RoutedEventArgs e)
        {
            AjouterMateriel ajm = new AjouterMateriel();
            ajm.ShowDialog();
            listerMateriel();
        }
        private void btnSupp_Click(object sender, RoutedEventArgs e)
        {
           
            DataRowView row = (DataRowView)dgMateriel.SelectedItem;
            if(row != null)
            {
                int idmt = (int)row["idMat"];
                try
                {
                    string query = "delete from Materiel where idMat =" + idmt;
                    Connexion.sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query, Connexion.sqlcon);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        listerMateriel();
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
                MessageBox.Show("selectionnez une ligne à supprimer");
            }
        }
    }
}
