using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aideInventaire.Dal
{
    class Connexion
    {
        public static SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["aideInventaire.Properties.Settings.parcMaterielConnectionString"].ConnectionString);
    }
}
