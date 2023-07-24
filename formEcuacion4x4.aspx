﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="formEcuacion4x4.aspx.cs" Inherits="patitosSAV0._1.formProductos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=submit] {
  width: 100%;
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type=submit]:hover {
  background-color: #45a049;
}

div {
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 20px;
}
        </style>


<div>
    <br />
    <br />
    <br />
    <h1 style="text-align:center">Sistema de ecucaciones resolución Gauss-Jordan, 4 * 4</h1>
    <br />
    <table style="text-align:left;  margin: 0 auto; width:100%">
        <tr>
           <th><label for="fname"></label></th> 
             <th><label style="text-align:center" for="fname">X</label></th> 
             <th><label style="text-align:center" for="fname">Y</label></th>  
             <th><label style="text-align:center" for="fname">Z</label></th> 
            <th><label style="text-align:center" for="fname">T</label></th> 
            <th><label style="text-align:center" for="fname">=</label></th>  
        </tr>
        <tr>
            <th><label for="fname">Valores</label></th> 
            <th><asp:TextBox ID="TextBox1" runat="server" Enabled="true"></asp:TextBox></th> 
            <th><asp:TextBox ID="TextBox2" runat="server" Enabled="true"></asp:TextBox></th>
            <th><asp:TextBox ID="TextBox3" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox4" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox5" runat="server" Enabled="true"></asp:TextBox></th>
        </tr>
        <tr>
            <th><label for="fname">Valores</label></th> 
            <th><asp:TextBox ID="TextBox6" runat="server" Enabled="true"></asp:TextBox></th> 
            <th><asp:TextBox ID="TextBox7" runat="server" Enabled="true"></asp:TextBox></th>
            <th><asp:TextBox ID="TextBox8" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox9" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox10" runat="server" Enabled="true"></asp:TextBox></th>
        </tr>
        <tr>
            <th><label for="fname">Valores</label></th> 
            <th><asp:TextBox ID="TextBox11" runat="server" Enabled="true"></asp:TextBox></th> 
            <th><asp:TextBox ID="TextBox12" runat="server" Enabled="true"></asp:TextBox></th>
            <th><asp:TextBox ID="TextBox13" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox14" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox15" runat="server" Enabled="true"></asp:TextBox></th>
            <tr>
            <th><label for="fname">Valores</label></th> 
            <th><asp:TextBox ID="TextBox16" runat="server" Enabled="true"></asp:TextBox></th> 
            <th><asp:TextBox ID="TextBox17" runat="server" Enabled="true"></asp:TextBox></th>
            <th><asp:TextBox ID="TextBox18" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox19" runat="server" Enabled="true"></asp:TextBox></th>
             <th><asp:TextBox ID="TextBox20" runat="server" Enabled="true"></asp:TextBox></th>
        </tr>
        </tr>
     </table>
    <br />
    <div style="widows:inherit; width:100%">
          <asp:Button ID="Button1" runat="server" Text="Resolver" Width=100% OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Limpiar" Width="100%" OnClick="Button2_Click" />
    </div>
        <h3 style="text-align:center">Pasos de resolución</h3>
        <br />
    <br />
    <div>
         <style>
        body {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        form {
            text-align: center;
        }
    </style>
        <body>
  <asp:TextBox style="text-align:center" ID="txtResultado" TextMode="MultiLine" Rows="25" Columns="25" runat="server" Enabled="false">Acá se visualizarán los pasos</asp:TextBox>
            </body>
</div>
    </div>
</asp:Content>
