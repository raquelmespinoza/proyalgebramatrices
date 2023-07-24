using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class claseConexionServer
    {
        public String coneccion = "Data Source = sql5103.site4now.net; Initial Catalog=db_a7823f_registros; User id=db_a7823f_registros_admin;Password=deyvin321;";
        public SqlConnection cnn;
        public Boolean Conectando()
        {
            try
            {
                cnn = new SqlConnection(this.coneccion);
                //Probamos que hay coneccion
                cnn.Close();
                //Cerramos la coneccion
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
