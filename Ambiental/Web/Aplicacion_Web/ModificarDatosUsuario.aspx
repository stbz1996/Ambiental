<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarDatosUsuario.aspx.cs" Inherits="Aplicacion_Web.ModificarDatosUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Carbono Neutral</title>
    <!-- Core CSS - Include with every page -->
    <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/main-style.css" rel="stylesheet" />

</head>
<body class="body-Login-back">

    <div class="container">
       
        <div class="row">
            <div class="col-md-4 col-md-offset-4 text-center logo-margin">
              &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Tw Cen MT" Font-Size="XX-Large" ForeColor="White" Text="CARBONO NEUTRAL"></asp:Label>
                </div>
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default" style ="height: 100%; width: 100%">              
                    <div class="panel-heading">
                        Ingrese Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPreviaInformacion" runat="server" ForeColor="Blue" Text="* Datos modificables" Visible="False"></asp:Label>
                        </div>
                    
                    <div class="panel-body">
                        
                    
                        <form id="form1" runat="server">
                            <asp:ScriptManager ID="scriptManejador" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="panelUpdate" runat="server"><ContentTemplate>
                              <fieldset>
                                <asp:Label ID="lblCedula" runat="server" Text="Cédula"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCedula" runat="server" MaxLength="9" Enabled="False"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblPrimerNombre" runat="server" Text="Primer Nombre"></asp:Label>
                                  <asp:Label ID="lblAsterisco1" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtPrimerNombre" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                  <asp:Label ID="lblRestriccionNombre" runat="server" ForeColor="Blue" Text="No existe nombre" Visible="False"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblSegundoNombre" runat="server" Text="Segundo Nombre"></asp:Label>
                                  <asp:Label ID="lblAsterisco2" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtSegundoNombre" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido"></asp:Label>
                                  <asp:Label ID="lblAsterisco3" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtPrimerApellido" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                  <asp:Label ID="lblRestriccionApellido" runat="server" ForeColor="Blue" Text="No existe apellido" Visible="False"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido"></asp:Label>
                                  <asp:Label ID="lblAsterisco4" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtSegundoApellido" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico"></asp:Label>
                                  <asp:Label ID="lblAsterisco5" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Enabled="False"></asp:TextBox>
                                  <asp:Label ID="lblRestriccionEmail" runat="server" ForeColor="Blue" Text="Email no está correcto" Visible="False"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                                  <asp:Label ID="lblAsterisco6" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="8" Enabled="False"></asp:TextBox>
                                  <asp:Label ID="lblRestriccionTelefono" runat="server" ForeColor="Blue" Text="Teléfono no está correcto" Visible="False"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                                  <asp:Label ID="lblAsterisco7" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label>
                                <br />
                                  <asp:TextBox ID="txtProvincia" runat="server" Enabled="False"></asp:TextBox>
                                <asp:DropDownList ID="ddlProvincia" runat="server" Height="17px" Width="122px" Visible="False">
                                </asp:DropDownList>
                                  &nbsp;
                                  <asp:Button ID="btnActualizarCanton" runat="server" Height="24px" Width="90px" Text="Actualizar" Visible="False" OnClick="btnActualizarCanton_Click"/>
                                <br />
                                <br />
                                <asp:Label ID="lblCanton" runat="server" Text="Cantón"></asp:Label>
                                <br />
                                  <asp:TextBox ID="txtCanton" runat="server" Enabled="False"></asp:TextBox>
                                <asp:DropDownList ID="ddlCanton" runat="server" Height="17px" Width="122px" Visible="False">
                                </asp:DropDownList>
                                  &nbsp;
                                  <asp:Button ID="btnActualizarDistrito" runat="server" Height="24px" Width="90px" Text="Actualizar" Visible="False" OnClick="btnActualizarDistrito_Click"/>
                                <br />
                                <br />
                                <asp:Label ID="lblDistrito" runat="server" Text="Distrito"></asp:Label>
                                <br />
                                  <asp:TextBox ID="txtDistrito" runat="server" Enabled="False"></asp:TextBox>
                                <asp:DropDownList ID="ddlDistrito" runat="server" Height="17px" Width="122px" Visible="False">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:Label ID="lblDetalle" runat="server" Text="Detalle"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtDetalle" runat="server" Height="61px" Width="277px" TextMode="MultiLine" MaxLength="500" Enabled="False"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                                  <asp:Label ID="lblAsterisco8" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                  <br />
                                  <asp:DropDownList ID="ddlAnio" runat="server" Height="16px" Width="96px" Visible="False">
                                  </asp:DropDownList>
                                  <asp:Button ID="btnActualizarFecha" runat="server" Height="21px" Text="Actualizar" Width="68px" Visible="False" OnClick="btnActualizarFecha_Click" />
                                  <asp:TextBox ID="txtFechaNacimiento" runat="server" Enabled="False"></asp:TextBox>
                                <br />
                                <asp:Calendar ID="calendarFecha" runat="server" SelectionMode="DayWeekMonth" Visible="False"></asp:Calendar>
                                    
                                <br />
                                <asp:Label ID="lblUsername" runat="server" Text="Nombre de Usuario"></asp:Label>
                                  <asp:Label ID="lblAsterisco9" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtUsername" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                  <asp:Label ID="lblRestriccionUsername" runat="server" ForeColor="Blue" Text="No existe nombre de usuario" Visible="False"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblRol" runat="server" Text="Rol"></asp:Label>
                                  <br />
                                  <asp:TextBox ID="txtRol" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <br />
                                  <asp:Label ID="lblDecision" runat="server" ForeColor="Blue" Text="Una vez realizado los cambios no se puede devolver" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnModificarUsuario1" runat="server" BackColor="#00CC99" Text="Modificar Usuario" ForeColor="White" OnClick="btnModificarUsuario1_Click"/>
                                  <asp:Button ID="btnModificarUsuario2" runat="server" BackColor="#00CC99" ForeColor="White" Text="Modificar Usuario" Visible="False" OnClick="btnModificarUsuario2_Click" />
                                  <asp:Button ID="btnSalir" runat="server" BackColor="#00CC99" ForeColor="White" OnClick="btnSalir_Click" Text="Salir" Width="107px" />
                                  <asp:Label ID="lblError" runat="server" ForeColor="Blue" Text="Datos incorrectos" Visible="False"></asp:Label>
                                  <br />
                            </fieldset>
                            </ContentTemplate></asp:UpdatePanel>
                        </form>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>

     <!-- Core Scripts - Include with every page -->
    <script src="assets/plugins/jquery-1.10.2.js"></script>
    <script src="assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="assets/plugins/metisMenu/jquery.metisMenu.js"></script>

</body>
</html>

