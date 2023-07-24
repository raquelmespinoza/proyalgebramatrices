using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class clasePersonas : claseConexionLocal
    {
        public string cedula;
        public string nombre;
        public string accion;
        private DataSet datosTabla = new DataSet();

        public clasePersonas(string p1, string p2, string p3)
        {
            cedula = p1;
            nombre = p2;
            accion = p3;
        }


        public DataSet buscarPersona()
        {
            try
            {
                SqlDataAdapter adapter;
                DataSet ds = new DataSet();
                //creamos nuestra propia coneccion
                SqlConnection conectado = new SqlConnection(this.coneccion);
                conectado.Open();
                SqlCommand coneccion = new SqlCommand();
                coneccion.Connection = conectado;
                //coneccion.CommandType = System.Data.CommandType.StoredProcedure;
                coneccion.CommandType = CommandType.StoredProcedure;
                coneccion.CommandText = "PaPersonas";
                coneccion.Parameters.AddWithValue("@cedula", cedula);
                coneccion.Parameters.AddWithValue("@nombre", nombre);
                coneccion.Parameters.AddWithValue("@accion", accion);
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

        private Boolean validarIngreso()
        {
            String mensaje = "";
            Boolean bandera = false;
            try
            {
                if (datosTabla.Tables[0].Rows.Count > 0)
                {
                    if (datosTabla.Tables[0].Rows[0].ItemArray[0].ToString() == cedula)
                    {
                        if (datosTabla.Tables[0].Rows[0].ItemArray[1].ToString() == nombre)
                        {

                            string usuario = datosTabla.Tables[0].Rows[0].ItemArray[0].ToString();
                            string role = datosTabla.Tables[0].Rows[0].ItemArray[2].ToString();

                            mensaje = "Bienvenido: " + usuario + " Su role es: " + role;
                            bandera = true;

                        }
                        else
                        {
                            mensaje = "Contraseña Invalida";
                        }
                    }
                    else
                    {
                        mensaje = "Usuario No existe";
                    }
                }
                return bandera;
            }
            catch
            {
                mensaje = "Hubo un error al validar";
                return false;
            }
        }
    }
}