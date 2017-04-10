<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaDenunciasGuardian.aspx.cs" Inherits="Aplicacion_Web.ConsultaDenunciasGuardian" %>

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
                <a class="navbar-brand" href="HomeGuardian.aspx">&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="CARBONO NEUTRO"></asp:Label>
                </a>&nbsp;<asp:Label ID="lblPuntos" runat="server" Text="Puntos:"></asp:Label>
                &nbsp;<asp:Label ID="lblObtenerPuntos" runat="server"></asp:Label>
            </div>
            <!-- end navbar-header -->
            <!-- navbar-top-links -->
            <ul class="nav navbar-top-links navbar-right">
                <!-- main dropdown -->
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
                        <a href ="CrearDenunciaGuardian.aspx"><i class ="fa fa-flask fa-fw"></i>Crear Denuncia</a>
                    </li>
                    <li>
                        <!--ASP form de consultar Denuncias (todas las denuncias existentes del mismo distrito)-->
                        <!--<a href="tables.html"><i class="fa fa-table fa-fw"></i>Tables</a>-->
                        <a href="ConsultaDenunciasGuardian.aspx"><i class="fa fa-table fa-fw"></i>Consultar Denuncias</a>
                    </li>
                    <li>
                        <!--ASP form de crear Aporte-->
                        <!--<a href="timeline.html"><i class="fa fa-flask fa-fw"></i>Timeline</a>-->
                        <!--<a href="forms.html"><i class="fa fa-edit fa-fw"></i>Forms</a>-->
                        <a href="CrearAporteGuardian.aspx"><i class="fa fa-edit fa-fw"></i>Crear aporte</a>
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
                    <h1 class="page-header">
                        <asp:Label ID="lblConsultaDenuncia" runat="server" Text="Consulta Denuncias"></asp:Label>
                        <asp:Label ID="lblModificaDenuncia" runat="server" Text="Modificar Denuncia" Visible="False"></asp:Label>
                    </h1>
                </div>
                <!--End Page Header -->
            </div>

            <div class="row">
                <!-- Welcome -->
                <div class="col-lg-12">
                    <asp:Label ID="lblTitulo" runat="server" Text="Título" Visible="False"></asp:Label>
                    <asp:Label ID="lblAsterisco1" runat="server" ForeColor="Blue" Text="*" Visible="False"></asp:Label>
                    <asp:Label ID="lblExitoModificarDenuncia" runat="server" ForeColor="#339966" Text="Cambios Realizados de forma exitosa" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtIdDenuncia" runat="server"></asp:TextBox>
                    <asp:Button ID="btnModificarDenuncia" runat="server" BackColor="#339966" ForeColor="White" Text="Modificar Denuncia" OnClick="btnModificarDenuncia_Click" />
                    <asp:Label ID="lblRestriccionExisteID" runat="server" ForeColor="Red" Text="ID no existe" Visible="False"></asp:Label>
                    <asp:Label ID="lblRestriccionDenunciaDiferente" runat="server" ForeColor="Red" Text="ID de denuncia de otro guardián" Visible="False"></asp:Label>
                    <asp:Label ID="lblRestriccionEstado" runat="server" ForeColor="Red" Text="Estado de la denuncia diferente a Registrado" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTitulo" runat="server" Visible="False" MaxLength="30"></asp:TextBox>
                    <asp:Label ID="lblRestriccionTitulo" runat="server" ForeColor="Blue" Text="Debe tener título" Visible="False"></asp:Label>
                    <asp:Button ID="btnSalir" runat="server" BackColor="#339966" ForeColor="White" OnClick="btnSalir_Click" Text="Salir" Visible="False" />
                    <br />
                    <asp:Table ID="tblDenuncias" runat="server" 
                        Font-Size="Medium" 
                        Width="789px" 
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
                            <asp:TableHeaderCell>Provincia</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Canton</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Distrito</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Detalle</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Estado</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <br />
                    <asp:HiddenField ID="hdfIdDenuncia" runat="server" />
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="73px" TextMode="MultiLine" Visible="False" Width="251px" MaxLength="500"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblFoto" runat="server" Text="Foto" Visible="False"></asp:Label>
                    <br />
                    <asp:FileUpload ID="fileUploadImage" runat="server" Visible="False" />
                    <asp:Label ID="lblRestriccionFormatoFoto" runat="server" ForeColor="Blue" Text="Debe contener el formato correcto" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="lblAvisoModificacion" runat="server" ForeColor="Blue" Text="Una vez realizado los cambios no se puede devolver" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="btnModificarDenuncia2" runat="server" BackColor="#339966" ForeColor="White" Text="Modificar Denuncia" Visible="False" OnClick="btnModificarDenuncia2_Click" />
                </div>
                <!--end  Welcome -->
            </div>


            <div class="row">
                <div class="col-lg-8">
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
