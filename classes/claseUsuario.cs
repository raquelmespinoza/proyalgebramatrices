using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class claseUsuario : claseConexionLocal
    {
        public string usuario;
        public string contrasena;
        private DataSet datosTabla = new DataSet();

        public claseUsuario(string pUsuario, string pcontrasena)
        {
            usuario = pUsuario;
            contrasena = pcontrasena;
        }


        public DataSet ValidarUsuario()
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
                coneccion.CommandText = "PaUsuarios";
                coneccion.Parameters.AddWithValue("@usuario", usuario);
                coneccion.Parameters.AddWithValue("@contrasena", contrasena);
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
                    if (datosTabla.Tables[0].Rows[0].ItemArray[0].ToString() == usuario)
                    {
                        if (datosTabla.Tables[0].Rows[0].ItemArray[1].ToString() == contrasena)
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