<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcercaDe.aspx.cs" Inherits="Aplicacion_Web.AcercaDe" %>

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
                        Acerca De&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    
                    <div class="panel-body" style="text-align:justify">
                        
                    
                        <form id="form1" runat="server">
                            <asp:ScriptManager ID="scriptManejador" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="panelUpdate" runat="server"><ContentTemplate>
                              <fieldset>
                                  <asp:Label ID="lblObjetivo" runat="server" Font-Size="Large" ForeColor="#339966" Text="Objetivo"></asp:Label>
                                  <br />
                                  <br />
                                  <asp:Label ID="lblExplicacionObjetivo" runat="server" ForeColor="#339966" Text="Incentivar y concientizar a la población costarricense acerca de la protección y cuidado del medio ambiente, mediante un control y búsqueda de soluciones a los problemas ambientales."></asp:Label>
                                  <br />
                                  <br />
                                  <br />
                                  <asp:Label ID="lblAplicacion" runat="server" Font-Size="Large" ForeColor="#339966" Text="Aplicación"></asp:Label>
                                  <br />
                                  <br />
                                  <asp:Label ID="lblExplicacionAplicacion" runat="server" ForeColor="#339966" Text="Creada para que usted como usuario, pueda ayudar e impulsar a otras personas con el fin de llegar de cumplir con la meta de la carbono neutralidad. "></asp:Label>
                                  <br />
                                  <br />
                                  <br />
                                  <asp:Label ID="lblRol" runat="server" Font-Size="Large" ForeColor="#339966" Text="Roles"></asp:Label>
                                  <br />
                                  <br />
                                  <asp:Label ID="Label8" runat="server" ForeColor="#339966" Text="•	Si eres una persona dedicada a identificar, denunciar y documentar problemas ambientales, entonces el rol de guardián es ideal para usted."></asp:Label>
                                  <br />
                                  <asp:Label ID="Label9" runat="server" ForeColor="#339966" Text="•	Si más bien eres una persona entusiasta y con disposición de realizar trabajo voluntario, entonces su rol puede ser el de oficial."></asp:Label>
                                  <br />
                                  <asp:Label ID="Label10" runat="server" ForeColor="#339966" Text="•	Si lo suyo es asistir a los lugares donde se presenten los problemas y soluciones de los mismos, además de juzgarlos con base a un criterio justo y correcto, entonces su papel ideal es el de juez."></asp:Label>
                                  <br />
                                  <br />
                                  <asp:Button ID="btnSalir" runat="server" BackColor="#339966" ForeColor="White" Height="28px" OnClick="btnSalir_Click" Text="Salir" Width="77px" />
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
