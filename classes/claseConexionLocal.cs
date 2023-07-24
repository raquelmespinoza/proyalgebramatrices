using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class claseConexionLocal
    {
        public String coneccion = "Data Source = localhost; Initial Catalog=mercadoPatitos; Integrated Security=True";
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
