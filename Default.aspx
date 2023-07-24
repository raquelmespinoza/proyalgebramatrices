<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="patitosSAV0._1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Gráfica de Sistema de Ecuaciones 2x2</title>
    <!-- Agrega la referencia a Highcharts -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <br />
    <br />
    <br />
    <br />
     <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <div style="width: 1000px; height: 600px;">
        <canvas  id="grafico" style="display: block; box-sizing: border-box; height: 600px; width: 1000px;"></canvas>
    </div>

    <script>
        // Define tus ecuaciones del sistema 2x2 (por ejemplo, 2x + y = 5 y x - y = 1)
        // Puedes ajustar estas ecuaciones según tus necesidades.
        var ecuacion1 = { m: 0, b: 5 }; // y = 2x + 5
        var ecuacion2 = { m: 1, b: -1 }; // y = x - 1   

        // Genera los puntos para graficar las ecuaciones en el rango de x que desees
        function generarPuntos(ecuacion) {
            var puntos = [];
            for (var x = -10; x <= 10; x++) {
                var y = ecuacion.m * x + ecuacion.b;
                puntos.push({ x: x, y: y });
            }
            return puntos;
        }

        // Obtiene los puntos para cada ecuación
        var puntosEcuacion1 = generarPuntos(ecuacion1);
        var puntosEcuacion2 = generarPuntos(ecuacion2);

        // Configura los datos para la gráfica
        var data = {
            datasets: [
                {
                    label: 'Ecuación 1 (y = 2x + 5)',
                    borderColor: 'red',
                    data: puntosEcuacion1,
                    showLine: true,
                    fill: false
                },
                {
                    label: 'Ecuación 2 (y = x - 1)',
                    borderColor: 'blue',
                    data: puntosEcuacion2,
                    showLine: true,
                    fill: false
                }
            ]
        };

        // Configura opciones adicionales para el gráfico
        var options = {
            responsive: false,
            scales: {
                x: {
                    type: 'linear',
                    position: 'bottom'
                },
                y: {
                    type: 'linear',
                    position: 'left'
                }
            }
        };

        // Crea la gráfica
        var ctx = document.getElementById('grafico').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'line',
            data: data,
            options: options
        });
    </script>
  
</html>
</asp:Content>
