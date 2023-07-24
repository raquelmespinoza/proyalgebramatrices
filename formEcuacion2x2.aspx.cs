using System;
using patitosSAV0._1.classes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using Microsoft.Ajax.Utilities;

namespace patitosSAV0._1
{
    public partial class formEcuacion2x2 : System.Web.UI.Page
    {
        double[,] dataMatriz = new double[2, 3];
        double valor1;
        double valor2;
        double valor3;
        double valor4;
        double valor5;
        double valor6;
        int vueltaFila = 0;
        int vueltaColumna = 0;

        bool banderaCiclo = true;
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
            }
            catch (Exception ex)
            {
                ShowAlert("¡Aún Faltan valores por escribir o tienes valores incorrectos!");
            }
            dataMatriz[0, 0] = valor1;
            dataMatriz[0, 1] = valor2;
            dataMatriz[0, 2] = valor3;
            dataMatriz[1, 0] = valor4;
            dataMatriz[1, 1] = valor5;
            dataMatriz[1, 2] = valor6;


            txtResultado.Text = txtResultado.Text + "\nMatriz Normal:\n";
            MostrarMatriz();
            txtResultado.Text = txtResultado.Text + "\nInversa de 1*1\n";
            EncontrarInversa(valor1, vueltaFila);
            txtResultado.Text = txtResultado.Text + "\nOpuesto de 2*1\n";
            EncontrarOpuesto(valor4, vueltaFila);
            MostrarMatriz();
            if (dataMatriz[1,1] == 0)
            {
                banderaCiclo = false;
            }

            if (banderaCiclo)
            {
                txtResultado.Text = txtResultado.Text + "\nInversa de 2*2\n";
                EncontrarInversa(dataMatriz[1, 1], vueltaFila);
            }
            if (banderaCiclo)
            {
                txtResultado.Text = txtResultado.Text + "\nOpuesto de 1*2\n";
                EncontrarOpuestoA(dataMatriz[0, 1], 0);
                MostrarMatriz();
            }
            else
            {
                
                txtResultado.Text = txtResultado.Text + "\nEl sistema es incompatible";
            }
            txtResultado.Text = txtResultado.Text + "\nValor de X es: " + dataMatriz[0, 2] + "\n";
            txtResultado.Text = txtResultado.Text + "\nValor de Y es: " + dataMatriz[1, 2] + "\n";
        }

            private void ShowAlert(string message)
            {
                string script = $@"<script type='text/javascript'>alert('{message}');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
            }
        private void EncontrarInversa(double inversa,int valor)
        {
            if (inversa == 0) {
                banderaCiclo = false;
            }

            
           double valorInversa = Math.Pow(inversa, -1);
            //Multiplicar por fila 1
            for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
            {
                dataMatriz[valor,columna] = dataMatriz[valor, columna] * valorInversa;
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
        private void EncontrarOpuesto(double opuesto, int valor)
        {
            double valorOpuesto = -(opuesto);
            for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
            {
                dataMatriz[valor, columna] = dataMatriz[valor-1, columna] * valorOpuesto + dataMatriz[valor,columna];
            }
        }
        private void EncontrarOpuestoA(double opuesto, int valor)
        {
            double valorOpuesto = -(opuesto);
            for (int columna = 0; columna < dataMatriz.GetLength(1); columna++)
            {
                dataMatriz[valor, columna] = dataMatriz[valor + 1, columna] * valorOpuesto + dataMatriz[valor, columna];
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
            txtResultado.Text = "Acá se visualizarán los pasos";
        }
    }
    }
