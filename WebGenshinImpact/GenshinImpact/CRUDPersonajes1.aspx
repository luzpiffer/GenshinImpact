<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CRUDPersonajes1.aspx.vb" Inherits="GenshinImpact.CRUDPersonajes1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Peluches Teyvat</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    
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
    

    <script type="text/javascript">
        function previewImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = document.getElementById('<%= Image1.ClientID %>');
                    img.src = e.target.result;

                    // Crear una imagen temporal para obtener sus dimensiones
                    var tempImg = new Image();
                    tempImg.onload = function () {
                        // Calcular las proporciones
                        var imgWidth = tempImg.width;
                        var imgHeight = tempImg.height;
                        var maxWidth = 200; // Ajusta el máximo ancho deseado
                        var maxHeight = 200; // Ajusta el máximo alto deseado
                        var ratio = Math.min(maxWidth / imgWidth, maxHeight / imgHeight);

                        // Establecer el tamaño del control de imagen para mantener la proporción
                        img.style.width = imgWidth * ratio + 'px';
                        img.style.height = imgHeight * ratio + 'px';
                    };
                    tempImg.src = e.target.result;

                    img.style.display = 'block'; // Mostrar la imagen
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

        function resizeImageOnLoad() {
            var img = document.getElementById('<%= Image1.ClientID %>');
            img.onload = function () {
                var maxWidth = 300;  // Ajusta el máximo ancho
                var maxHeight = 300; // Ajusta el máximo alto
                var ratio = Math.min(maxWidth / img.naturalWidth, maxHeight / img.naturalHeight);

                img.width = img.naturalWidth * ratio;
                img.height = img.naturalHeight * ratio;
            };
        }

        window.onload = resizeImageOnLoad;
    </script>

    <style type="text/css">
        .auto-style3 {
            height: 81px;
        }
        .auto-style4 {
            width: 143px;
        }
        .auto-style5 {
            height: 81px;
            width: 143px;
        }
        .auto-style6 {
            height: 81px;
            width: 187px;
        }
        .auto-style7 {
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-size: 16px;
            line-height: 1.5;
            overflow: visible;
            transition: background-color 0.3s;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            margin: 10px 0;
            padding: 10px 15px;
            background-color: #e7879b;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
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
                            <li class="nav-item active">
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

            <table class="w-100">
                <tr>
                    <td class="auto-style6">ID:</td>
                    <td class="auto-style6"><asp:TextBox ID="txtid" runat="server"></asp:TextBox></td>
                    <td class="auto-style4"><asp:Button ID="btncargar" runat="server" Text="Cargar" Width="118px" CssClass="botonRedondeado" /></td>
                    <td><asp:Button ID="btnmodificar" runat="server" Text="Modificar" Width="119px" CssClass="botonRedondeado" /></td>
                </tr>
                <tr>
                    <td class="auto-style6">Nombre:</td>
                    <td class="auto-style6"><asp:TextBox ID="txtnombre" runat="server"></asp:TextBox></td>
                    <td class="auto-style4"><asp:Button ID="btneliminar" runat="server" Text="Eliminar" Width="119px" CssClass="botonRedondeado" /></td>
                    <td><asp:Button ID="btnmostartodo" runat="server" Text="Mostrar Todo" Width="130px" CssClass="botonRedondeado" /></td>
                </tr>
                <tr>
                    <td class="auto-style6">Altura: </td>
                    <td class="auto-style6"><asp:TextBox ID="txtaltura" runat="server"></asp:TextBox></td>
                    <td class="auto-style4"><asp:Button ID="btnconsultarnombre" runat="server" Text="Consultar Nombre" CssClass="botonRedondeado" /></td>
                    <td><asp:Button ID="btnbuscar" runat="server" Text="ID" CssClass="botonRedondeado" /></td>
                </tr>
                <tr>
                    <td class="auto-style3">Sexo:</td>
                    <td class="auto-style6"><asp:TextBox ID="txtsexo" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnconsultarnaciones" runat="server" Text="Consultar por Naciones" CssClass="botonRedondeado" /></td>
                    <td class="auto-style5">&nbsp;</td>
                  
                </tr>
                <tr>
                    <td class="auto-style6">Nación:</td>
                    <td class="auto-style6"><asp:DropDownList ID="cbonaciones" runat="server" Width="147px" Style="margin: 10px;"></asp:DropDownList></td>
                    
                    
                    <td><asp:Button ID="btnconsultarelementos" runat="server" Text="Consultar por Elementos" CssClass="auto-style7" Width="272px" /></td>
                    
                    
                </tr>
                <tr>
                    <td class="auto-style6">Elemento:</td>
                    <td class="auto-style6"><asp:DropDownList ID="cboelementos" runat="server" Width="146px" Style="margin: 10px;"></asp:DropDownList></td>
                    
                    
                    <td><asp:Button ID="btnconsultararmas" runat="server" Text="Consultar por Armas" CssClass="auto-style7" Width="272px" /></td>
                    
                    
                </tr>
                <tr>
                    <td class="auto-style3">Arma:</td>
                    <td class="auto-style6"><asp:DropDownList ID="cboarmas" runat="server" Width="147px" Style="margin: 10px;"></asp:DropDownList></td>
                    
                </tr>
                <tr>
                    <td class="auto-style6">Precio:</td>
                    <td class="auto-style6"><asp:TextBox ID="txtprecio" runat="server"></asp:TextBox></td>
                    
                    
                </tr>
                <tr>
                    <td class="auto-style6">Cantidad:</td>
                    <td class="auto-style6"><asp:TextBox ID="txtcantidad" runat="server"></asp:TextBox></td>
                    
                    
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
                <div>
            <asp:Image ID="Image1" runat="server" CssClass="Image1" style="display:none;" />
        </div>

        
        
        <asp:GridView ID="grilla" runat="server" AutoGenerateColumns="False" Style="margin: 40px;">
            <Columns>
                <asp:BoundField DataField="ID_Personaje" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Altura" HeaderText="Altura" />
                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                <asp:BoundField DataField="Nacion" HeaderText="Nacion" />
                <asp:BoundField DataField="Elemento" HeaderText="Elemento" />
                <asp:BoundField DataField="Arma" HeaderText="Arma" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:TemplateField HeaderText="Imagen">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# GetImage(Eval("Imagen")) %>' Width="100px" Height="100px" />
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </form>
</body>
</html>
