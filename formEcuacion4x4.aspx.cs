using patitosSAV0._1.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace patitosSAV0._1
{
    public partial class formProductos : System.Web.UI.Page
    {
        double[,] dataMatriz = new double[4, 5];
        double[] filaContieneUno = new double[5];
        double valor1;
        double valor2;
        double valor3;
        double valor4;
        double valor5;
        double valor6;
        double valor7;
        double valor8;
        double valor9;
        double valor10;
        double valor11;
        double valor12;
        double valor13;
        double valor14;
        double valor15;
        double valor16;
        double valor17;
        double valor18;
        double valor19;
        double valor20;

        int vueltaFila = 0;
        int vueltaColumna = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                valor1 = double.Parse(TextBox1.Text.Trim());
                valor2 = double.Parse(TextBox2.Text.Trim());
                valor3 = double.Parse(TextBox3.Text.Trim());
                valor4 = double.Parse(TextBox4.Text.Trim());
                valor5 = double.Parse(TextBox5.Text.Trim());
                valor6 = double.Parse(TextBox6.Text.Trim());
                valor7 = double.Parse(TextBox7.Text.Trim());
                valor8 = double.Parse(TextBox8.Text.Trim());
                valor9 = double.Parse(TextBox9.Text.Trim());
                valor10 = double.Parse(TextBox10.Text.Trim());
                valor11 = double.Parse(TextBox11.Text.Trim());
                valor12 = double.Parse(TextBox12.Text.Trim());
                valor13 = double.Parse(TextBox13.Text.Trim());
                valor14 = double.Parse(TextBox14.Text.Trim());
                valor15 = double.Parse(TextBox15.Text.Trim());
                valor16 = double.Parse(TextBox16.Text.Trim());
                valor17 = double.Parse(TextBox17.Text.Trim());
                valor18 = double.Parse(TextBox18.Text.Trim());
                valor19 = double.Parse(TextBox19.Text.Trim());
                valor20 = double.Parse(TextBox20.Text.Trim());
            }
            catch (Exception ex)
            {
                ShowAlert("¡Aún Faltan valores por escribir o tienes valores incorrectos!");
            }
            dataMatriz[0, 0] = valor1;
            dataMatriz[0, 1] = valor2;
            dataMatriz[0, 2] = valor3;
            dataMatriz[0, 3] = valor4;
            dataMatriz[0, 4] = valor5;
            dataMatriz[1, 0] = valor6;
            dataMatriz[1, 1] = valor7;
            dataMatriz[1, 2] = valor8;
            dataMatriz[1, 3] = valor9;
            dataMatriz[1, 4] = valor10;
            dataMatriz[2, 0] = valor11;
            dataMatriz[2, 1] = valor12;
            dataMatriz[2, 2] = valor13;
            dataMatriz[2, 3] = valor14;
            dataMatriz[2, 4] = valor15;
            dataMatriz[3, 0] = valor16;
            dataMatriz[3, 1] = valor17;
            dataMatriz[3, 2] = valor18;
            dataMatriz[3, 3] = valor19;
            dataMatriz[3, 4] = valor20;


            txtResultado.Text = txtResultado.Text + "\nMatriz Normal:\n";
            MostrarMatriz();

            txtResultado.Text = txtResultado.Text + "\nInversa de 1*1\n";
            EncontrarInversa(valor1, vueltaFila);

            txtResultado.Text = txtResultado.Text + "\nOpuestos\n";
            EncontrarOpuestoBucle2(valor5, valor9);
            MostrarMatriz();

            txtResultado.Text = txtResultado.Text + "\nInversa de 2*2\n";
            EncontrarInversa(dataMatriz[1, 1], vueltaFila);

            vueltaColumna++;
            txtResultado.Text = txtResultado.Text + "\nOpuestos\n";
            EncontrarOpuestoBucle2(valor5, valor9);
            MostrarMatriz();

            txtResultado.Text = txtResultado.Text + "\nInversa de 3*3\n";
            EncontrarInversa(dataMatriz[2, 2], vueltaFila);

            vueltaColumna++;
            txtResultado.Text = txtResultado.Text + "\nOpuestos\n";
            EncontrarOpuestoBucle2(valor5, valor9);
            MostrarMatriz();

            txtResultado.Text = txtResultado.Text + "\nInversa de 4*4\n";
            EncontrarInversa(dataMatriz[2, 2], vueltaFila);

            vueltaColumna++;
            txtResultado.Text = txtResultado.Text + "\nOpuestos\n";
            EncontrarOpuestoBucle2(valor5, valor9);
            MostrarMatriz();

            txtResultado.Text = txtResultado.Text + "\nValor de X es: " + dataMatriz[0, 4] + "\n";
            txtResultado.Text = txtResultado.Text + "\nValor de Y es: " + dataMatriz[1, 4] + "\n";
            txtResultado.Text = txtResultado.Text + "\nValor de Z es: " + dataMatriz[2, 4] + "\n";
            txtResultado.Text = txtResultado.Text + "\nValor de T es: " + dataMatriz[3, 4] + "\n";
        }

        private void EncontrarOpuestoBucle2(double opuesto, double opuesto2)
        {
            double valorOpuesto = -(opuesto);

            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                if (fila == vueltaColumna)
                {
                    Console.WriteLine("Es el valor de la inversa");
                }
                else
                {
                    double factor = dataMatriz[fila, vueltaColumna] / dataMatriz[vueltaColumna, vueltaColumna];
                    for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                    {
                        dataMatriz[fila, columna] -= factor * dataMatriz[vueltaColumna, columna];
                    }
                }
            }
        }

        private void ShowAlert(string message)
        {
            string script = $@"<script type='text/javascript'>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }
        private void EncontrarInversa(double inversa, int valor)
        {
            double valorInversa = Math.Pow(inversa, -1);
            //Multiplicar por fila 1

            for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
            {
                filaContieneUno[columna] = dataMatriz[valor, columna] = dataMatriz[valor, columna] * valorInversa;

            }
            vueltaFila++;

            MostrarMatriz();
        }
        private void MostrarMatriz()
        {
            for (int fila = 0; fila < dataMatriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
                {
                    txtResultado.Text = txtResultado.Text + (dataMatriz[fila, columna] + "  ");
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
            TextBox10.Text = string.Empty;
            TextBox1.Text = string.Empty;
            TextBox12.Text = string.Empty;
            txtResultado.Text = "Acá se visualizarán los pasos";
        }
    }
}