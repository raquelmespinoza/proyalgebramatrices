using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class claseEstante : claseConexionLocal
    {

        private DataTable datosTabla = new DataTable();

        public claseEstante()
        {
        }


        public DataTable mostrarEstantes()
        {
            try
            {
                SqlDataAdapter adapter;
                SqlConnection conectado = new SqlConnection(this.coneccion);
                conectado.Open();
                SqlCommand coneccion = new SqlCommand();
                coneccion.Connection = conectado;
                coneccion.CommandType = CommandType.StoredProcedure;
                coneccion.CommandText = "PaEstantes";
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();
                return datosTabla;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}