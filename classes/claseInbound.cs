using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class claseInbound : claseConexionLocal
    {

        public int valor1;
        public string valor2;
        public int valor3;
        public int valor4;
        public string valor5;
        public string valor6;
        public DateTime valor7;
        public string valor8;
        public string valor9;

        public DataSet datosTabla = new DataSet();
        public DataTable datos = new DataTable();

        public claseInbound()
        {

        }

        public claseInbound(int p1, string p2, int p3, int p4, string p5, string p6, DateTime p7, string p8, string p9)
        {
        valor1 = p1;
        valor2 = p2;
        valor3 = p3;
        valor4 = p4;
        valor5 = p5;
        valor6 = p6;
        valor7 = p7;
        valor8 = p8;
        valor9 = p9;
    }

    public string generarIngreso()
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
                coneccion.CommandText = "PaIngresos";
                coneccion.Parameters.AddWithValue("@idIngreso", valor1);
                coneccion.Parameters.AddWithValue("@Usuario", valor2);
                coneccion.Parameters.AddWithValue("@Producto", valor3);
                coneccion.Parameters.AddWithValue("@Proovedor", valor4);
                coneccion.Parameters.AddWithValue("@Almacen", valor5);
                coneccion.Parameters.AddWithValue("@cantidad", valor6);
                coneccion.Parameters.AddWithValue("@fechaVencimiento", valor7);
                coneccion.Parameters.AddWithValue("@accion", valor8);
                coneccion.Parameters.AddWithValue("@precio", valor9);
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();
                return "Se generó el nuevo ingreso con exito";

            }
            catch (Exception ex)
            {
                return ex.Message;   
            }

        }
        public DataSet listar(string accion)
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
                coneccion.CommandText = "listarRegistros";

                coneccion.Parameters.AddWithValue("@accion", accion);
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(ds);
                conectado.Close();
                return ds;

            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}