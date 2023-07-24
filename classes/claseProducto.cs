using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace patitosSAV0._1.classes
{
    public class claseProducto : claseConexionLocal
    {
        int idProducto;
        int lote;
        int cantidad;
        string accion;
        public DataSet datosTabla = new DataSet();
        public DataTable datos = new DataTable();

        public claseProducto()
        {
        }

        public claseProducto(int p1, int p2, int p3)
        {
            idProducto = p1;
            lote = p2;
            cantidad = p3;

        }
        public DataSet validarProducto()
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
                coneccion.CommandText = "PaTablaTemporal";
                coneccion.Parameters.AddWithValue("@idProducto", idProducto);
                coneccion.Parameters.AddWithValue("@Lote", lote);
                coneccion.Parameters.AddWithValue("@Cantidad", 1);
                coneccion.Parameters.AddWithValue("@accion", "validarProducto");
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();
                return datosTabla;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet listar()
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
                coneccion.CommandText = "PaTablaTemporal";
                coneccion.Parameters.AddWithValue("@idProducto", 1);
                coneccion.Parameters.AddWithValue("@Lote", 1);
                coneccion.Parameters.AddWithValue("@Cantidad", 1);
                coneccion.Parameters.AddWithValue("@accion", "listar");
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
        public DataSet agregarLista()
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
                coneccion.CommandText = "PaTablaTemporal";
                coneccion.Parameters.AddWithValue("@idProducto", idProducto);
                coneccion.Parameters.AddWithValue("@Lote", lote);
                coneccion.Parameters.AddWithValue("@Cantidad", cantidad);
                coneccion.Parameters.AddWithValue("@accion", "agregarFila");
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();

                return datosTabla;
            }
            catch
            {
                return null;
            }
        }

        public DataSet eliminarLista()
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
                coneccion.CommandText = "PaTablaTemporal";
                coneccion.Parameters.AddWithValue("@idProducto", idProducto);
                coneccion.Parameters.AddWithValue("@Lote", lote);
                coneccion.Parameters.AddWithValue("@Cantidad", cantidad);
                coneccion.Parameters.AddWithValue("@accion", "eliminarFila");
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();

                return datosTabla;
            }
            catch
            {
                return null;
            }
        }
        public DataSet eliminarTodo()
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
                coneccion.CommandText = "PaTablaTemporal";
                coneccion.Parameters.AddWithValue("@idProducto", 1);
                coneccion.Parameters.AddWithValue("@Lote", 1);
                coneccion.Parameters.AddWithValue("@Cantidad", 1);
                coneccion.Parameters.AddWithValue("@accion", "eliminarTodo");
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();

                return datosTabla;
            }
            catch
            {
                return null;
            }
        }
        public void generarFactura(string usuario, string cliente, float total, string accion)
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
                coneccion.CommandText = "PaGenerarFactura";
                coneccion.Parameters.AddWithValue("@idFactura", 1);
                coneccion.Parameters.AddWithValue("@Usuario", usuario);
                coneccion.Parameters.AddWithValue("@Cliente", cliente);
                coneccion.Parameters.AddWithValue("@estado", "1");
                coneccion.Parameters.AddWithValue("@total", total);
                coneccion.Parameters.AddWithValue("@accion", "insertarFactura");
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();

            }
            catch (Exception)
            {

            }
        }

        public void generarDetalle(int producto, string desc, int cantidad, int precio, float total)
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
                coneccion.CommandText = "PaDetalleFactura";
                coneccion.Parameters.AddWithValue("@Producto", producto);
                coneccion.Parameters.AddWithValue("@Desc", desc);
                coneccion.Parameters.AddWithValue("@Cantidad", cantidad);
                coneccion.Parameters.AddWithValue("@Precio", precio);
                coneccion.Parameters.AddWithValue("@Total", total);
                //coneccion.Parameters.AddWithValue("@accion", "insertarFactura");
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(datosTabla);
                conectado.Close();

            }
            catch (Exception)
            {

            }
        }

        public DataSet mantenimientoProducto(int p1, string p2, string p3, int p4, int p5, string accion)
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
                coneccion.CommandText = "PaMantenimientoProducto";
                coneccion.Parameters.AddWithValue("@idProducto", p1);
                coneccion.Parameters.AddWithValue("@desc", p2);
                coneccion.Parameters.AddWithValue("@tipo", p3);
                coneccion.Parameters.AddWithValue("@min", p4);
                coneccion.Parameters.AddWithValue("@max", p5);
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
        public DataSet listarFacturas(int Factura, string accion)
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
                coneccion.CommandText = "PaTablaTemporal";
                coneccion.Parameters.AddWithValue("@idProducto", Factura);
                coneccion.Parameters.AddWithValue("@Lote", 1);
                coneccion.Parameters.AddWithValue("@Cantidad", 1);
                coneccion.Parameters.AddWithValue("@accion", accion);
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(ds);
                conectado.Close();

                return ds;
            }
            catch
            {
                return null;
            }
        }
    }
}