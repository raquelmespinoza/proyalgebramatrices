using Microsoft.Ajax.Utilities;
using patitosSAV0._1.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace patitosSAV0._1
{
    public partial class formInversa3x3 : System.Web.UI.Page
    {
        //matriz de 3x6
        double[,] dataMatriz = new double[3, 6];

        //vueltafila y vueltacolumna nos van ayudar a identificar cual fila y cual columna estamos operando por bucles
        int vueltaFila = 0;
        int vueltaColumna = 0;

        //esta bandera nos ayudará a indentificar si la matriz posee inversa o no, es decir en el momento que sea falso se detendran los procesos
        bool banderaProceso = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //primeramente generamos matriz de identidad en la matriz
            generarIndentidad();
        }
        protected void generarIndentidad()
        {
            // con este bucle llenamos de "0" la matriz
            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                {
                    dataMatriz[fila, columna] = 0;
                }
            }

            // Establecer la diagonal principal a 1
            for (int i = 0; i < dataMatriz.GetLength(0); i++)
            {
                // más mitad de columnas por la mitad de la matriz
                dataMatriz[i, i + dataMatriz.GetLength(1) / 2] = 1;
            }
        }
        protected void validarIntercambioFila()
        {
            //variable bandera local para identificar si se realizó un cambio de fila o no
            bool bandera = false;
            //fila temporal, nos ayudará hacer el intercambio de las filas que necesitemos, solo si es requerido
            double[] filaTemp = new double[8];

            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                if (dataMatriz[fila, 0] == 1 && (fila != 0 && dataMatriz[0, 0] != 1))
                {
                    bandera = true;
                    for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                    {
                        //intercambio de la fila actual con la fila que tiene el 1, utilizando un vector temporal con los valores de una fila
                        filaTemp[columna] = dataMatriz[0, columna];
                        dataMatriz[0, columna] = dataMatriz[fila, columna];
                        dataMatriz[fila, columna] = filaTemp[columna];
                    }
                    //identificar cuales fueron las filas que se intercambiaron
                    txtResultado.Text = txtResultado.Text + "\nIntercambio de fila: " + (fila + 1) + " por fila: " + 1 + "\n";
                    break;
                }
            }
            //si la bandera es verdadera sabemos que se realizó un cambio en la matriz original
            if (bandera)
            {
                MostrarMatriz();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataMatriz[0, 0] = double.Parse(TextBox1.Text.Trim());
                dataMatriz[0, 1] = double.Parse(TextBox2.Text.Trim());
                dataMatriz[0, 2] = double.Parse(TextBox3.Text.Trim());
                dataMatriz[1, 0] = double.Parse(TextBox4.Text.Trim());
                dataMatriz[1, 1] = double.Parse(TextBox5.Text.Trim());
                dataMatriz[1, 2] = double.Parse(TextBox6.Text.Trim());
                dataMatriz[2, 0] = double.Parse(TextBox7.Text.Trim());
                dataMatriz[2, 1] = double.Parse(TextBox8.Text.Trim());
                dataMatriz[2, 2] = double.Parse(TextBox9.Text.Trim());
                banderaProceso = true;
                txtResultado.Text = txtResultado.Text + "\nMatriz Aumentada:\n";
                MostrarMatriz();
                validarIntercambioFila();
            }
            catch (Exception ex)
            {
                ShowAlert("¡Aún Faltan valores por escribir o tienes valores incorrectos!");
                banderaProceso = false;
            }
            //Hacer mientras la vuelta de columna sea menor a la cantidad de filas y tambien mientras la bandera de bucle sea verdadero
            do
            {
                if (banderaProceso)
                {
                    txtResultado.Text = txtResultado.Text + "\nInversa de posición: " + (vueltaFila + 1) + " x " + (vueltaFila + 1) + "\n";
                    EncontrarInversa();
                }
                if (banderaProceso)
                {
                    txtResultado.Text = txtResultado.Text + "\nOpuestos de columna: " + (vueltaColumna + 1) + "\n";
                    EncontrarOpuestoBucle2();
                    if (vueltaFila > 0)
                    {
                        vueltaColumna++;
                    }
                }
            } while (vueltaColumna < dataMatriz.GetLength(0) && banderaProceso);

            if (banderaProceso)
            {
                txtResultado.Text = txtResultado.Text + "\nMatriz inversa\n";
                MostrarMatrizInversa();
                txtResultado.Text = txtResultado.Text + "\nMatriz inversa en fraccion\n";
                mostrarMatrizFraccion();
            }
        }

        private void mostrarMatrizFraccion()
        {
            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                for (int columna = dataMatriz.GetLength(1) / 2; columna < dataMatriz.GetLength(1); columna++)
                {
                    if (validarDecimales(dataMatriz[fila, columna]))
                    {
                        txtResultado.Text = txtResultado.Text + DecimalAFraccion(dataMatriz[fila, columna]) + " ";
                    }
                    else
                    {
                        txtResultado.Text = txtResultado.Text + (dataMatriz[fila, columna]) + " ";
                    }
                }
                txtResultado.Text = txtResultado.Text + "\n";
            }
        }
        private void EncontrarInversa()
        {
            double inversa = dataMatriz[vueltaFila, vueltaFila];
            if (inversa != 0)
            {
                double valorInversa = Math.Pow(inversa, -1);
                if (inversa != 1)
                {
                    for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                    {
                        dataMatriz[vueltaFila, columna] = dataMatriz[vueltaFila, columna] * valorInversa;

                    }
                }
                vueltaFila++;


                MostrarMatriz();
            }
            else
            {
                banderaProceso = false;
                txtResultado.Text = txtResultado.Text + ("¡La matriz no posee inversa, no es posible convertir: " + inversa + " en ¨1¨");
            }
        }
        private void EncontrarOpuestoBucle2()
        {
            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                if (fila == vueltaColumna)
                {
                    Console.WriteLine("Es el valor de la inversa");
                }
                else
                {
                    if (dataMatriz[fila, vueltaColumna] != 0)
                    {
                        double factor = dataMatriz[fila, vueltaColumna] / dataMatriz[vueltaColumna, vueltaColumna];
                        for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                        {
                            dataMatriz[fila, columna] -= factor * dataMatriz[vueltaColumna, columna];
                        }
                    }
                }
            }
            MostrarMatriz();
        }
        private void ShowAlert(string message)
        {
            string script = $@"<script type='text/javascript'>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }
        private void MostrarMatriz()
        {
            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                {
                    if (columna == dataMatriz.GetLength(1) / 2)
                    {
                        txtResultado.Text = txtResultado.Text + "|  " + (dataMatriz[fila, columna]) + " ";
                    }
                    else
                    {
                        txtResultado.Text = txtResultado.Text + (dataMatriz[fila, columna]) + " ";
                    }
                }
                txtResultado.Text = txtResultado.Text + "\n";
            }
        }
        private void MostrarMatrizInversa()
        {
            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                for (int columna = dataMatriz.GetLength(1) / 2; columna < dataMatriz.GetLength(1); columna++)
                {
                    txtResultado.Text = txtResultado.Text + dataMatriz[fila, columna] + " ";
                }
                txtResultado.Text = txtResultado.Text + "\n";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            dataMatriz = null;
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            TextBox9.Text = string.Empty;

            txtResultado.Text = "Acá se visualizarán los pasos";
        }
        private static int CalcularMCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static string DecimalAFraccion(double valorDecimal)
        {
            // Convierte el valor decimal a una fracción
            int precision = 100000000;
            int numerador = (int)(valorDecimal * precision);
            int denominador = precision;

            // Simplifica la fracción
            int mcd = CalcularMCD(numerador, denominador);
            numerador /= mcd;
            denominador /= mcd;

            // Devuelve la fracción en formato string
            return numerador + "/" + denominador;
        }
        private static bool validarDecimales(double numero)
        {
            double numeroRedondeado = Math.Floor(numero);
            return numero != numeroRedondeado;
        }
        public static double FraccionADecimal(string fraccion)
        {
            string[] partes = fraccion.Split('/');
            if (partes.Length != 2)
            {
                throw new ArgumentException("La fracción debe tener el formato 'numerador/denominador'.");
            }

            double numerador = double.Parse(partes[0]);
            double denominador = double.Parse(partes[1]);

            if (denominador == 0)
            {
                throw new ArgumentException("El denominador no puede ser cero.");
            }

            return numerador / denominador;
        }
        public static bool validarFraccion(string fraccion)
        {
            // Patrón de expresión regular para validar el formato de la fracción
            string patron = @"^\s*(\d+)\s*/\s*(\d+)\s*$";

            // Verificar el formato de la fracción usando expresiones regulares
            Match coincidencia = Regex.Match(fraccion, patron);

            if (!coincidencia.Success)
            {
                return false; // La fracción no tiene el formato "numerador/denominador"
            }

            // Obtener el numerador y el denominador como valores enteros
            int numerador = int.Parse(coincidencia.Groups[1].Value);
            int denominador = int.Parse(coincidencia.Groups[2].Value);

            // Verificar que el denominador no sea cero
            if (denominador == 0)
            {
                return false; // El denominador no puede ser cero
            }

            return true; // La fracción es válida
        }


    }
}