<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarHashtagDenuncia.aspx.cs" Inherits="Aplicacion_Web.AgregarHashtagDenuncia" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Carbono Neutro</title>
    <!-- Core CSS - Se incluye en cada página-->
    <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/main-style.css" rel="stylesheet" />
    <!-- Nivel de página CSS -->
    <link href="assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
   </head>
<body>
    <form id="form1" runat="server">
    <!-- Cubierta de la página -->
    <div id="wrapper">
        <!-- Parte superior de la página -->
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation" id="navbar">
            <!-- Titulo de la página -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="HomeGuardian.aspx">&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="CARBONO NEUTRO"></asp:Label>
                    
                </a>&nbsp;<asp:Label ID="lblPuntos" runat="server" Text="Puntos:"></asp:Label>
                &nbsp;<asp:Label ID="lblObtenerPuntos" runat="server"></asp:Label>
            </div>
            <!-- Termina título de la página -->
            <!-- Links de la barra superior -->
            <ul class="nav navbar-top-links navbar-right">
                <!-- Botones de esa sección -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-3x"></i>
                    </a>
                    <!-- Botón de usuario -->
                    <ul class="dropdown-menu dropdown-user">
                        <li><a href="ModificarDatosUsuario.aspx"><i class="fa fa-user fa-fw"></i>Perfil</a>
                        </li>
                        <li class="divider"></li>
                        <li><a href="Login.aspx"><i class="fa fa-sign-out fa-fw"></i>Salir</a>
                        </li>
                    </ul>
                    <!-- Termina Botón de usuario -->
                </li>
                <!-- Termina botónes de la sección superior -->
            </ul>
            <!-- Links de la barra superior  -->

        </nav>
        <!-- Termina parte superior de la pagina -->

        <!-- Parte lateral de la página -->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <!-- Botones ubicados en la parte lateral -->
            <div class="sidebar-collapse">
                <!-- Menu lateral -->
                <ul class="nav" id="side-menu">
                    
                    <li class="selected">
                    </li>
                    <li>
                        <!--ASP form de crear Denuncia-->
                        <a href ="CrearDenunciaGuardian.aspx"><i class ="fa fa-flask fa-fw"></i>Crear Denuncia</a>
                    </li>
                    <li>
                        <!--ASP form de consultar Denuncias (todas las denuncias existentes del mismo distrito)-->
                        <a href="ConsultaDenunciasGuardian.aspx"><i class="fa fa-table fa-fw"></i>Consultar Denuncias</a>
                    </li>
                    <li>
                        <!--ASP form de crear Aporte-->
                        <a href="CrearAporteGuardian.aspx"><i class="fa fa-edit fa-fw"></i>Crear aporte</a>
                    </li>
                    
                </ul>
                <!-- Termina Menu lateral -->
            </div>
            <!-- termina botones ubicados en la parte lateral -->
        </nav>
        <!-- termina parte lateral de la página -->
        <!--  Capa del resto de la página -->
        <div id="page-wrapper">

            <div class="row">
                <!-- Cabeza de la página -->
                <div class="col-lg-12">
                    <h1 class="page-header">Guardián</h1>
                </div>
                <!--Termina cabeza de la pagina -->
            </div>
            <div class="row">
                <!-- Parte Bienvenida -->
                <div class="col-lg-12">
                    <asp:Label ID="lblHashtag" runat="server" Text="Hashtag"></asp:Label>
                    <asp:Label ID="lblExitoCrearDenuncia" runat="server" ForeColor="#339966" Text="Denuncia Creada de forma exitosa" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtHashtag" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblRestriccionHashtag" runat="server" ForeColor="Red" Text="Hashtag no válido" Visible="False"></asp:Label>
                    <asp:Label ID="lblExitoHashtag" runat="server" ForeColor="#339966" Text="Hashtag creado de forma exitosa" Visible="False"></asp:Label>
                    <asp:Button ID="btnSalir2" runat="server" OnClick="btnSalir2_Click" Text="Salir" Visible="False" BackColor="#339966" ForeColor="White" />
                    <br />
                    <br />
                    <asp:Button ID="btnAgregarHashtag" runat="server" OnClick="btnAgregarHashtag_Click" Text="AgregarHashtag" BackColor="#339966" ForeColor="White" />
                    <asp:Button ID="btnSalir" runat="server" OnClick="btnSalir_Click" Text="Salir" BackColor="#339966" ForeColor="White" />
                </div>
                <!-- termina parte Bienvenida -->
            </div>


            <div class="row">
                <div class="col-lg-8">
                </div>

            </div>
        </div>
        <!-- Termina capa del resto de la página -->

    </div>
    <!-- Termina cubierta de la página -->

    <!-- Core Scripts - se incluyen a cada página -->
    <script src="assets/plugins/jquery-1.10.2.js"></script>
    <script src="assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="assets/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="assets/plugins/pace/pace.js"></script>
    <script src="assets/scripts/siminta.js"></script>
    <!-- Nivel de página - Conexion de scripts necesarios -->
    <script src="assets/plugins/morris/raphael-2.1.0.min.js"></script>
    <script src="assets/plugins/morris/morris.js"></script>
    <script src="assets/scripts/dashboard-demo.js"></script>

    </form>

</body>

</html>

