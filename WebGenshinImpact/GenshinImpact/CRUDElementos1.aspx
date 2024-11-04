<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CRUDElementos1.aspx.vb" Inherits="GenshinImpact.CRUDElementos1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Peluches Teyvat</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon"/>

    <!-- slider stylesheet -->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />
    <!-- bootstrap core css -->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <!-- Custom styles for this template -->
    <link href="https://fonts.googleapis.com/css2?family=Chewy&display=swap" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet" />
    <!-- responsive style -->
    <link href="css/responsive.css" rel="stylesheet" />
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css"/>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.all.min.js"></script>
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
                            <li class="nav-item active">
                                <a class="nav-link" href="CRUDElementos1.aspx">Elementos</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="CRUDNaciones1.aspx">Naciones</a>
                            </li>
                            <li class="nav-item">
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

            <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style3">ID: </td>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="auto-style8">
                                        <asp:Button ID="btncargar" runat="server" Text="Cargar" Width="118px" CssClass="botonRedondeado" />
                                    </td>
                                    <td style="height: 18px">
                                        <asp:Button ID="btnmodificar" runat="server" Text="Modificar" Width="119px" CssClass="botonRedondeado" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">Elemento:</td>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="txtelemento" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="auto-style8">
                                        <asp:Button ID="btneliminar" runat="server" Text="Eliminar" Width="119px" CssClass="botonRedondeado" />
                                    </td>
                                    <td style="height: 24px">
                                        <asp:Button ID="btnmostartodo" runat="server" Text="Mostrar Todo" Width="129px" CssClass="botonRedondeado" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">Descripción:</td>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="txtdescripcion" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="auto-style8">
                                        <asp:Button ID="btnconsultarid" runat="server" Text="Consultar ID" Width="119px" CssClass="botonRedondeado" />
                                    </td>
                                    <td style="height: 28px">
                                        <asp:Button ID="btnconsultarelemento" runat="server" Text="Consultar Elemento" CssClass="botonRedondeado" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">
                                        <asp:GridView ID="grilla" runat="server">
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
            </div>
        </div>
    </form>
</body>
</html>


