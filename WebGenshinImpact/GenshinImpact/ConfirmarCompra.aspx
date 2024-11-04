<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConfirmarCompra.aspx.vb" Inherits="GenshinImpact.ConfirmarCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon" />
    <title>Confirmar Compra</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet" />
    <link href="css/confirmarcompra.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
        <div class="user_option">
            <% If Session("Usuario") Is Nothing Then %>
                <a href="Login.aspx">
                    <i class="fa fa-user" aria-hidden="true"></i>
                    <span>Iniciar Sesión</span>
                </a>
            <% Else %>
                <span class="bienvenida-mensaje">¡Bienvenido!</span>
                <a href="Logout.aspx">
                    <i class="fa fa-sign-out" aria-hidden="true"></i>
                    <span>Cerrar sesión</span>
                </a>
            <% End If %>
        </div>
        <div class="container">
            <h2>Confirmar Compra</h2>
            <div class="form-group">
                <label for="txtFecha">Fecha del Pedido:</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div id="orderDetails">
                <h4>Detalles del Pedido</h4>
                <asp:GridView ID="OrderGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="ID_Personaje">
                    <Columns>
                        <asp:BoundField DataField="ID_Personaje" HeaderText="Producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" HtmlEncode="False" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" HtmlEncode="False" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="text-right">
                <h4>Total: <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control d-inline-block w-25" ReadOnly="True"></asp:TextBox></h4>
            </div>
            <div class="text-right">
                <asp:Button ID="btnCancelarCompra" runat="server" Text="Cancelar Compra" CssClass="btn btn-cancelar" OnClick="CancelarCompraButton_Click" />
                <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-finalizar" OnClick="FinalizarCompraButton_Click" />
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="js/carrito.js"></script>
</body>
</html>




