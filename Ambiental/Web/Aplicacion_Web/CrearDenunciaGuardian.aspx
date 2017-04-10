<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearDenunciaGuardian.aspx.cs" Inherits="Aplicacion_Web.CrearDenunciaGuardian" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        .auto-style2 {
            width: 196px;
            height: 18px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManejador" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panelUpdate" runat="server"><ContentTemplate>
                            
        
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
                    
                    <li>
                        <br />
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
                    <h1 class="page-header">Menú Crear Denuncia</h1>
                </div>
                <!--End Page Header -->
            </div>

            <div class="row">
                <!-- Welcome -->
                <div class="col-lg-12">
                    <asp:Label ID="lblEspaciosObligatorios" runat="server" ForeColor="Red" Text="* Espacios obligatorios"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblTitulo" runat="server" Text="Título "></asp:Label>
                    <asp:Label ID="lblAsterisco1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTitulo" runat="server" Height="18px" Width="202px" MaxLength="30"></asp:TextBox>
                    <asp:Label ID="lblRestriccionTitulo" runat="server" ForeColor="Red" Text="No ingresó título" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="66px" Width="202px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
                    <asp:Label ID="lblAsterisco2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="lblRestriccionDireccion" runat="server" ForeColor="Red" Text="No completó dirección" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlProvincia" runat="server" Height="18px" Width="148px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnActualizarCanton" runat="server" Text="Actualizar" BackColor="#339966" ForeColor="White" OnClick="btnActualizarCanton_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblCanton" runat="server" Text="Cantón"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCanton" runat="server" Height="18px" Width="148px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnActualizarDistrito" runat="server" Text="Actualizar" BackColor="#339966" ForeColor="White" OnClick="btnActualizarDistrito_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblDistrito" runat="server" Text="Distrito"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlDistrito" runat="server" Height="18px" Width="148px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                    <asp:Label ID="lblDetalle" runat="server" Text="Detalle"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDetalle" runat="server" Height="66px" Width="202px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblLatitud" runat="server" Text="Latitud "></asp:Label>
                    <br />
                    
                    <input type="text" id="txtLatitud" class="auto-style2" runat="server" disabled="disabled"/>
                    <asp:HiddenField ID="hdfLatitud" runat="server" />
                    <br />
                    <br />
                    <asp:Label ID="lblLongitud" runat="server" Text="Longitud"></asp:Label>
                    <br />
                    
                    <input type="text" id="txtLongitud" class="auto-style2" runat="server" disabled="disabled"/>
                    <asp:HiddenField ID="hdfLongitud" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="btnPruebaLocalizacion" runat="server" OnClientClick="return getLocation();" Text="Obtener Localización" BackColor="#339966" ForeColor="White" />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblImagen" runat="server" Text="Imagen"></asp:Label>
                    <asp:Label ID="lblAsterisco3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="lblRestriccionImagen" runat="server" ForeColor="Red" Text="No agregó imagen" Visible="False"></asp:Label>
                    <br />
                    <asp:FileUpload ID="fileUploadImage" runat="server" />
                    <asp:Label ID="lblRestriccionAgregarImagen" runat="server" ForeColor="Red" Text="No agregó una imagen" Visible="False"></asp:Label>
                    <asp:Label ID="lblRestriccionFormatoImagen" runat="server" ForeColor="Red" Text="La imagen no posee el formato apropiado" Visible="False"></asp:Label>
                    
                    <br />
                    <asp:Button ID="btnCrearDenuncia" runat="server" Height="31px" Text="Crear Denuncia" Width="194px" BackColor="#339966" ForeColor="White" OnClick="btnCrearDenuncia_Click" />
                    <script type="text/javascript">
                        var latlon;

                        function getLocation() {
                            navigator.geolocation.getCurrentPosition(showPosition);
                        }

                        function showPosition(position) {
                            //var latlondata = position.coords.latitude + "," + position.coords.longitude;
                            document.getElementById("txtLatitud").value = position.coords.latitude;
                            document.getElementById("txtLongitud").value = position.coords.longitude;
                            document.getElementById("hdfLatitud").value = position.coords.latitude;
                            document.getElementById("hdfLongitud").value = position.coords.longitude;
                            //alert(latlon)
                        }
                        
                    </script>
                    <br />
                </div>
                <!--end  Welcome -->
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
        
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCrearDenuncia" />
        </Triggers>
    </asp:UpdatePanel>
    </form>

</body>

</html>
