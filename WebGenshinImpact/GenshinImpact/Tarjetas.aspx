<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tarjetas.aspx.vb" Inherits="GenshinImpact.Tarjetas" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
    
    <title>Tienda</title>

    <!-- Slider stylesheet -->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />
    
    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    
    <!-- Custom styles for this template -->
    <link href="https://fonts.googleapis.com/css2?family=Chewy&display=swap" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="hero_area">
            <!-- header section starts -->
            <header class="header_section">
                <nav class="navbar navbar-expand-lg custom_nav-container">
                    <a class="navbar-brand" href="index.aspx">
                        <span>Peluches Teyvat</span>
                    </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class=""></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav">
                            <li class="nav-item"><a class="nav-link" href="index.aspx">Inicio</a></li>
                            <li class="nav-item active"><a class="nav-link" href="Tarjetas.aspx">Tienda</a></li>
                            <li class="nav-item"><a class="nav-link" href="Nosotros.aspx">Nosotros</a></li>
                            <li class="nav-item"><a class="nav-link" href="Comentarios.aspx">Comentarios</a></li>
                            <li class="nav-item"><a class="nav-link" href="Contactanos.aspx">Contactános</a></li>
                        </ul>
                        <div class="user_option">
                            <a href="javascript:void(0)" id="cartIcon">
                                <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                                <span>Carrito</span>
                            </a>
                            <% If Session("Usuario") Is Nothing Then %>
                                <a href="Login.aspx">
                                    <i class="fa fa-user" aria-hidden="true"></i><span>Iniciar Sesión</span>
                                </a>
                            <% Else %>
                                <span class="bienvenida-mensaje">¡Bienvenido!</span>
                                <a href="Logout.aspx">
                                    <i class="fa fa-sign-out" aria-hidden="true"></i><span>Cerrar sesión</span>
                                </a>
                            <% End If %>
                        </div>
                    </div>
                </nav>
            </header>
            <!-- end header section -->
        </div>
        <!-- end hero area -->

        <!-- shop section -->
        <section class="shop_section layout_padding">
            <div class="container">
                <div class="heading_container heading_center"></div>
                <div class="product-container">
                    <asp:Repeater ID="ProductRepeater" runat="server">
                        <ItemTemplate>
                            <div class="product-card">
                                <img src='<%# GetImage(Eval("Imagen")) %>' alt="Producto" />
                                <div class="product-details">
                                    <div class="product-name"><%# Eval("Nombre") %></div>
                                    <div class="product-price"><%# String.Format("{0:C}", Eval("Precio")) %></div>
                                    <asp:Button ID="AddToCartButton" runat="server" Text="Agregar al carrito" 
                                        CommandArgument='<%# Eval("ID_Personaje") %>' 
                                        OnClientClick="addToCartButtonClick(this); return false;" 
                                        data-ID_Personaje='<%# Eval("ID_Personaje") %>' 
                                        data-Nombre='<%# Eval("Nombre") %>' 
                                        data-Precio='<%# Eval("Precio") %>' 
                                        CssClass="btn btn-primary" />
                                
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
        <!-- end shop section -->
        <!-- Contenedor del carrito -->
        <div id="cartContainer" class="cart-container">
            <table id="cartTable">
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Precio</th>
                        <th>Cantidad</th>
                        <th>Total</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- Aquí se llenará con JavaScript -->
                </tbody>
            </table>
            <button id="checkoutButton" type="button">Confirmar Compra</button>
        </div>
        <button type="button" class="whatsapp-button" onclick="consultarWhatsApp()">
            <img src="https://upload.wikimedia.org/wikipedia/commons/6/6b/WhatsApp.svg" alt="WhatsApp" style="width: 24px; height: 24px; vertical-align: middle;" />
            Consultar por WhatsApp
        </button>
        <!-- Contact section -->
        <section class="info_section layout_padding2-top">
            <div class="social_container">
                <div class="social_box">
                    <a href="">
                        <i class="fa fa-instagram" aria-hidden="true"></i>
                    </a>
                </div>
            </div>
            <div class="info_container">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-lg-3">
                            <h6>GENSHIN IMPACT</h6>
                            <p>
                                ¿Aún no descubriste el mundo mágico de Teyvat? ¡No te preocupés! Dale un vistazo a este maravilloso juego que ha cautivado a millones. Hacé clic <a href="https://genshin.hoyoverse.com/es/" style="color: #eca8c6; font-style: italic;">acá</a> y sumergite en una aventura inolvidable.
                            </p>
                        </div>
                        <div class="col-md-6 col-lg-3">
                            <div class="info_form">
                                <h5>Recibí nuestras novedades</h5>
                                <form action="Tarjetas.aspx" method="post">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Escribí tu email"></asp:TextBox>
                                    <asp:Button ID="btnSuscribirse" runat="server" Text="Suscribirse" OnClick="btnSuscribirse_Click" class="btn-suscribirse"/>
                                </form>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-3">
                            <h6>¿NECESITAS AYUDA?</h6>
                            <p>
                                Queremos que tu experiencia de compra sea lo más sencilla y agradable posible. Si tenés alguna duda o necesitas asistencia, te proporcionamos información útil para resolver tus inquietudes. No dudes en contactarte con nosotros.
                            </p>
                        </div>
                        <div class="col-md-6 col-lg-3">
                            <h6>CONTACTO</h6>
                            <div class="info_link-box">
                                <a href="">
                                    <i class="fa fa-map-marker" aria-hidden="true"></i>
                                    <span>Pilar, Córdoba, Argentina</span>
                                </a>
                                <a href="">
                                    <i class="fa fa-phone" aria-hidden="true"></i>
                                    <span>+54 9 3572000000</span>
                                </a>
                                <a href="">
                                    <i class="fa fa-envelope" aria-hidden="true"></i>
                                    <span>peluchesteyvat@gmail.com</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- footer section -->
            <footer class="footer_section">
                <div class="container">
                    <p>
                        &copy; <span id="displayYear"></span> Peluches Teyvat. Todos los derechos reservados.
                    </p>
                </div>
            </footer>
            <!-- footer section -->
        </section>
        <!-- JavaScript files -->
        <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.js"></script>
        <script src="js/carrito.js"></script> <!-- Asegurate de que este archivo maneje el carrito -->
        <script src="js/custom.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script>
            // Función para consultar por WhatsApp
            function consultarWhatsApp() {
                var cartItems = cart.map(item => `${item.Nombre} x${item.Cantidad}`).join(", ");
                var totalPrice = document.querySelector('#cartTable tbody tr:last-child td:last-child').innerText;
                var message = `Hola, me gustaría consultar sobre los siguientes productos: ${cartItems}. El total es ${totalPrice}.`;
                // Enlace para abrir WhatsApp en la app o versión online
                var whatsappUrl = `https://wa.me/+5493572594184?text=${encodeURIComponent(message)}`;
                window.open(whatsappUrl, '_blank');
            }
        </script>
    </form>
</body>
</html>


