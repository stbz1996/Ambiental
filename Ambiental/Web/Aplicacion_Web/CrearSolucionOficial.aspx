<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearSolucionOficial.aspx.cs" Inherits="Aplicacion_Web.CrearSolucionOficial" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Carbono Neutro</title>
    <!-- Core CSS - Include with every page -->
    <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/main-style.css" rel="stylesheet" />
    <!-- Page-Level CSS -->
    <link href="assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
   </head>
<body>
    <form id="form1" runat="server">
    <!--  wrapper -->
    <div id="wrapper">
        <!-- navbar top -->
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation" id="navbar">
            <!-- navbar-header -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="HomeOficial.aspx">&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="CARBONO NEUTRO"></asp:Label>
                </a>&nbsp;<asp:Label ID="lblPuntos" runat="server" Text="Puntos:"></asp:Label>
                &nbsp;<asp:Label ID="lblObtenerPuntos" runat="server"></asp:Label>
            </div>
            <!-- end navbar-header -->
            <!-- navbar-top-links -->
            <ul class="nav navbar-top-links navbar-right">
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-3x"></i>
                    </a>
                    <!-- dropdown user-->
                    <ul class="dropdown-menu dropdown-user">
                        <li><a href="ModificarDatosUsuario.aspx"><i class="fa fa-user fa-fw"></i>Perfil</a>
                        </li>
                        <li class="divider"></li>
                        <li><a href="Login.aspx"><i class="fa fa-sign-out fa-fw"></i>Salir</a>
                        </li>
                    </ul>
                    <!-- end dropdown-user -->
                </li>
                <!-- end main dropdown -->
            </ul>
            <!-- end navbar-top-links -->

        </nav>
        <!-- end navbar top -->

        <!-- navbar side -->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <!-- sidebar-collapse -->
            <div class="sidebar-collapse">
                <!-- side-menu -->
                <ul class="nav" id="side-menu">
                    
                    <li class="selected">
                        <i class="fa fa-dashboard fa-fw"></i>
                    </li>
                    <li>
                        <!--ASP form de crear Denuncia-->
                        <!--<a href="timeline.html"><i class="fa fa-flask fa-fw"></i>Timeline</a>-->
                        <!--Se debe consultar la denuncia primero, luego se dirige a otra ventana para crear solucion-->
                        <a href ="CrearSolucionOficial.aspx"><i class ="fa fa-flask fa-fw"></i>Crear Solucion</a>
                    </li>
                    <li>
                        <!--ASP form de crear Aporte-->
                        <!--<a href="timeline.html"><i class="fa fa-flask fa-fw"></i>Timeline</a>-->
                        <!--<a href="forms.html"><i class="fa fa-edit fa-fw"></i>Forms</a>-->
                        <a href="CrearAporteOficial.aspx"><i class="fa fa-edit fa-fw"></i>Crear aporte</a>
                    </li>
                    
                </ul>
                <!-- end side-menu -->
            </div>
            <!-- end sidebar-collapse -->
        </nav>
        <!-- end navbar side -->
        <!--  page-wrapper -->
        <div id="page-wrapper">

            <div class="row">
                <!-- Page Header -->
                <div class="col-lg-12">
                    <h1 class="page-header">Menú Oficial</h1>
                </div>
                <!--End Page Header -->
            </div>

            <div class="row">
                <!-- Welcome -->
                <div class="col-lg-12">
                    <asp:Label ID="lblTitulo" runat="server" Text="Titulo" Visible="False"></asp:Label>
                    <asp:Label ID="lblAsterisco1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                    <asp:Label ID="lblElegirDenuncia" runat="server" Text="Elija Denuncia (por ID)"></asp:Label>
                    <asp:HiddenField ID="HiddenFieldIdDenuncia" runat="server" />
                    <br />
                    <asp:TextBox ID="txtTitulo" runat="server" Height="18px" Width="146px" Visible="False" MaxLength="30"></asp:TextBox>
                    <asp:Label ID="lblRestriccionTitulo" runat="server" ForeColor="Red" Text="No ingresó título" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtIdDenuncia" runat="server"></asp:TextBox>
                    <asp:Label ID="lblRestriccionExisteID" runat="server" ForeColor="Red" Text="ID no existe" Visible="False"></asp:Label>
                    <asp:Label ID="lblRestriccionEstado" runat="server" ForeColor="Red" Text="Estado de la denuncia diferente a En Proceso" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="btnIniciarSolucion" runat="server" BackColor="#339966" ForeColor="White" OnClick="btnIniciarSolucion_Click" Text="Iniciar Solución" />
                    <br />
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" Visible="False"></asp:Label>
                    <asp:Label ID="lblAsterisco2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                    <asp:Label ID="lblRestriccionDescripcion" runat="server" ForeColor="Red" Text="No agregó ninguna descripción" Visible="False"></asp:Label>
                    <asp:Table ID="tblDenuncias" runat="server" 
                        Font-Size="Medium" 
                        Width="938px" 
                        Font-Names="Palatino"
                        BackColor="#669999"
                        BorderColor="DarkRed"
                        BorderWidth="2"
                        ForeColor="Snow"
                        CellPadding="5"
                        CellSpacing="5">
                        <asp:TableHeaderRow runat="server" 
                            ForeColor="Snow" 
                            BackColor="OliveDrab"
                            Font-Bold="true">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Titulo</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Provincia</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Canton</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Distrito</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Detalle</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <br />
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="82px" TextMode="MultiLine" Width="207px" Visible="False" MaxLength="500"></asp:TextBox>
                    <br />
                    <asp:HiddenField ID="hdfIdDenuncia" runat="server" />
                    <br />
                    <asp:Label ID="lblFoto" runat="server" Text="Foto" Visible="False"></asp:Label>
                    <asp:Label ID="lblAsterisco3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                    <br />
                    <asp:FileUpload ID="fileUploadImage" runat="server" Visible="False" />
                    <asp:Label ID="lblRestriccionAgregarImagen" runat="server" ForeColor="Red" Text="No agregó una imagen" Visible="False"></asp:Label>
                    <asp:Label ID="lblRestriccionFormatoImagen" runat="server" ForeColor="Red" Text="La imagen no posee el formato apropiado" Visible="False"></asp:Label>
                    
                    <br />
                    <asp:Button ID="btnCrearSolucion" runat="server" BackColor="#339966" ForeColor="White" Text="Crear Solucion" Visible="False" OnClick="btnCrearSolucion_Click" />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
                <!--end  Welcome-->
            </div>


            <div class="row">
                <div class="col-lg-8">
                </div>
            </div>

            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-4">
                </div>
                <div class="col-lg-4">
                </div>
            </div>
        </div>
        <!-- end page-wrapper -->

    </div>
    <!-- end wrapper -->

    <!-- Core Scripts - Include with every page -->
    <script src="assets/plugins/jquery-1.10.2.js"></script>
    <script src="assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="assets/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="assets/plugins/pace/pace.js"></script>
    <script src="assets/scripts/siminta.js"></script>
    <!-- Page-Level Plugin Scripts-->
    <script src="assets/plugins/morris/raphael-2.1.0.min.js"></script>
    <script src="assets/plugins/morris/morris.js"></script>
    <script src="assets/scripts/dashboard-demo.js"></script>

    </form>

</body>

</html>

