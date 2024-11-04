<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Clientes.aspx.vb" Inherits="GenshinImpact.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Lista de Clientes</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon" />

    <!-- slider stylesheet -->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />
    <!-- bootstrap core css -->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <!-- Custom styles for this template -->
    <link href="https://fonts.googleapis.com/css2?family=Chewy&display=swap" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet" />
    <!-- responsive style -->
    <link href="css/responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="hero_area">
            <!-- header section starts -->
            <header class="header_section">
                <nav class="navbar navbar-expand-lg custom_nav-container ">
                    <a class="navbar-brand" href="index.html">
                        <span>Peluches Teyvat</span>
                    </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link" href="CRUDPersonajes1.aspx">Personajes<span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="CRUDArmas1.aspx">Armas</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="CRUDElementos1.aspx">Elementos</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="CRUDNaciones1.aspx">Naciones</a>
                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" href="Clientes.aspx">Clientes</a>
                            </li>
                        </ul>
                        <div class="user_option">
                            <% If Session("Usuario") Is Nothing Then %>
                                <a href="Login.aspx">
                                    <i class="fa fa-user" aria-hidden="true"></i>
                                    <span>
                                        Iniciar Sesión
                                    </span>
                                </a>
                            <% Else %>
                                <span class="bienvenida-mensaje">
                                    ¡Bienvenido!
                                </span>
                                <a href="Logout.aspx">
                                    <i class="fa fa-sign-out" aria-hidden="true"></i>
                                    <span>
                                        Cerrar sesión
                                    </span>
                                </a>
                            <% End If %>
                        </div>
                    </div>
                </nav>
            </header>
            <!-- header section ends -->

            <div class="container">
                <h4 style="margin-top: 30px;">Consultar Clientes</h4>
                <asp:Button ID="btnConsultarPedidos" runat="server" Text="Consultar Pedidos" OnClick="btnConsultarPedidos_Click" CssClass="btn btn-primary" />
                <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="ClienteId" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>



