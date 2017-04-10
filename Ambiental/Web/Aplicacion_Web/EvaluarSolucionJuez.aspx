<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluarSolucionJuez.aspx.cs" Inherits="Aplicacion_Web.EvaluarSolucionJuez" %>

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
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 66.66666667%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
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
                <a class="navbar-brand" href="HomeJuez.aspx">&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="CARBONO NEUTRO"></asp:Label>
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
                        <!--ASP form de Evaluar Denuncia (Consulta de las denuncias que pertenezcan a la misma provincia)-->
                        <!--<a href="timeline.html"><i class="fa fa-flask fa-fw"></i>Timeline</a>-->
                        <a href ="EvaluarDenunciaJuez.aspx"><i class ="fa fa-flask fa-fw"></i>Evaluar Denuncia</a>
                    </li>
                    <li>
                        <!--ASP form de Evaluar solución-->
                        <!--<a href="tables.html"><i class="fa fa-table fa-fw"></i>Tables</a>-->
                        <a href="EvaluarSolucionJuez.aspx"><i class="fa fa-table fa-fw"></i>Evaluar Solución</a>
                    </li>
                    <li>
                        <!--ASP form de crear Aporte-->
                        <!--<a href="timeline.html"><i class="fa fa-flask fa-fw"></i>Timeline</a>-->
                        <!--<a href="forms.html"><i class="fa fa-edit fa-fw"></i>Forms</a>-->
                        <a href="CrearAporteJuez.aspx"><i class="fa fa-edit fa-fw"></i>Crear aporte</a>
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
                    <h1 class="page-header">Menú Juez</h1>
                </div>
                <!--End Page Header -->
            </div>

            <div class="row">
                <!-- Welcome -->
                <div class="col-lg-12">
                    <asp:Label ID="lblTitulo" runat="server" Text="Título" Visible="False"></asp:Label>
                    <asp:Label ID="lblElegirSolucion" runat="server" Text="Ingrese la solucion a evaluar (ID)"></asp:Label>
                    <asp:Label ID="lblEvaluoTerminado" runat="server" ForeColor="#339966" Text="Evaluación finalizada" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTitulo" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtIdSolucion" runat="server"></asp:TextBox>
                    <asp:Label ID="lblRestriccionIdSolucion" runat="server" ForeColor="Red" Text="ID no corresponde al de la tabla" Visible="False"></asp:Label>
                    <asp:Button ID="btnSalir" runat="server" BackColor="#339966" ForeColor="White" OnClick="btnSalir_Click1" Text="Salir" Visible="False" />
                    <br />
                    <asp:HiddenField ID="hdfIdSolucion" runat="server" />
                    <br />
                    <asp:Button ID="btnEvaluarSolucion" runat="server" BackColor="#339966" ForeColor="White" OnClick="btnEvaluarSolucion_Click" Text="Evaluar Solución" />
                    <br />
                    <asp:Table ID="tblSoluciones" runat="server" BackColor="#669999" BorderColor="DarkRed" BorderWidth="2" CellPadding="5" CellSpacing="5" Font-Names="Palatino" Font-Size="Medium" ForeColor="Snow" Width="700px">
                        <asp:TableHeaderRow runat="server" BackColor="OliveDrab" Font-Bold="true" ForeColor="Snow">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Titulo</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDescripcion" runat="server" Enabled="False" Height="76px" TextMode="MultiLine" Visible="False" Width="221px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFecha" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblFoto" runat="server" Text="Foto" Visible="False"></asp:Label>
                    <br />
                    <asp:Image ID="imgSolucion" runat="server" Height="199px" Visible="False" Width="256px" />
                    <br />
                    <br />
                    <asp:Label ID="lblEvaluacion" runat="server" Text="Decisión de la evaluación" Visible="False"></asp:Label>
                    <br />
                    <asp:RadioButtonList ID="rdbDecision" runat="server" Visible="False">
                        <asp:ListItem>Confirmar</asp:ListItem>
                        <asp:ListItem>Rechazar</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lblRestriccionOpcion" runat="server" ForeColor="Red" Text="Debe elegir una opción" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="btnTomarDecision" runat="server" Height="25px" Text="Tomar Decisión" Visible="False" Width="152px" OnClick="btnTomarDecision_Click" BackColor="#339966" ForeColor="White" />
                </div>
                <!--end  Welcome -->
            </div>


            <div class="row">
                <div class="auto-style1">
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