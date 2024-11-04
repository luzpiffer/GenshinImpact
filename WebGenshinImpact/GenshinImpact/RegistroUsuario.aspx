<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroUsuario.aspx.vb" Inherits="GenshinImpact.RegistroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrarse</title>
    <link href="css/RegistroUsuario.css" rel="stylesheet" />
    <!-- Enlace a la fuente Poppins -->
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">Nombre:</td>
                    <td>
                        <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Apellido:</td>
                    <td>
                        <asp:TextBox ID="txtapellido" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Email:</td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Teléfono:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txttelefono" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style3">Dirección:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtdireccion" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Contraseña:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtcontrasena" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="btnregistrarse" runat="server" Text="Registrarse" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center; padding-top: 10px;">
                        <span style="font-size: 14px; color: #555;">¿Ya tenés una cuenta? <a href="Login.aspx" style="color: #a088d1; text-decoration: none;">Inicia Sesión</a></span>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
