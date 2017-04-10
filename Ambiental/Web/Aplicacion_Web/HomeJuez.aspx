<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeJuez.aspx.cs" Inherits="Aplicacion_Web.HomeJuez" %>

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
            width: 100%;
            left: 1px;
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
                <div class="auto-style1">
                    <div class="alert alert-info">
                        <b>&nbsp;Hola! </b>Bienvenido de vuelta
                        <!--Falta obtener el nombre del usuario-->
                        <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>

                    </div>
                </div>
                <asp:Label ID="Label2" runat="server" BorderStyle="None" Font-Size="X-Large" ForeColor="#339966" Text="Objetivo"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Size="Large" ForeColor="#339966" Text="Llevar un control de las denuncias y soluciones creadas por los guardianes y oficiales"></asp:Label>
                <br />
                <br />
                <br />
                <!--end  Welcome -->
                <asp:Label ID="Label4" runat="server" Font-Size="X-Large" ForeColor="#339966" Text="Opciones"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Font-Size="Large" ForeColor="#339966" Text="Evaluar Denuncia: Consulta las denuncias existentes y con base a su criterio decidir si es serio o no el problema."></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="#339966" Text="Evaluar Solución: Consulta las soluciones existentes de las denuncias evaluadas previamente y decidir si la solución es la apropiada."></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Font-Size="Large" ForeColor="#339966" Text="Crear Aporte: Pequeñas acciones que se pueden realizar para contribuir al cuidado del medio ambiente, entre más realice, más puntos gana. Es importante que tome una foto previamente para agregarla en el aporte."></asp:Label>
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