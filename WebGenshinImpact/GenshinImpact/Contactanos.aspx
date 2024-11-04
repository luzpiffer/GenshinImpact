<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Contactanos.aspx.vb" Inherits="GenshinImpact.Contactanos" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
    <title>Contactános</title>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link href="https://fonts.googleapis.com/css2?family=Chewy&display=swap" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.all.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="hero_area">
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
                            <li class="nav-item"><a class="nav-link" href="index.aspx">Inicio <span class="sr-only">(current)</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="Tarjetas.aspx">Tienda</a></li>
                            <li class="nav-item"><a class="nav-link" href="Nosotros.aspx">Nosotros</a></li>
                            <li class="nav-item"><a class="nav-link" href="Comentarios.aspx">Comentarios</a></li>
                            <li class="nav-item active"><a class="nav-link" href="Contactanos.aspx">Contactános</a></li>
                        </ul>
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
                    </div>
                </nav>
            </header>
        </div>
        <section class="contact_section layout_padding">
            <div class="container px-0">
                <div class="heading_container">
                    <h2 class="">Contactá con nosotros</h2>
                </div>
            </div>
            <div class="container container-bg">
                <div class="row">
                    <div class="col-lg-7 col-md-6 px-0">
                        <div class="map_container">
                            <div class="map-responsive">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d54324.54291830616!2d-63.95224892647879!3d-31.680805048345146!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x9432cb4e4c88d987%3A0xa9c6e711124e5e5b!2zUGlsYXIsIEPDs3Jkb2Jh!5e0!3m2!1ses-419!2sar!4v1728088420228!5m2!1ses-419!2sar" width="600" height="450" frameborder="0" style="border:0; width: 90%; height:90%" allowfullscreen></iframe>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-5 px-0" style="margin-top: 20px;">
                        <div>
                            <input type="text" id="nombre" name="nombre" placeholder="Nombre" />
                        </div>
                        <div>
                            <input type="text" id="email" name="email" placeholder="Email" />
                        </div>
                        <div>
                            <input type="text" class="message-box" placeholder="Mensaje" id="mensaje" name="mensaje" />
                        </div>
                        <div>
                            <button type="submit" runat="server" onserverclick="EnviarCorreoContacto">ENVIAR</button>
                        </div>
                        <div class="d-flex ">
                        </div>
                    </div>
                </div>
            </div>
        </section>

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
                                <form action="Contactanos.aspx" method="post">
                                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Escribí tu email" CssClass="input-email" />
                                    <asp:Button ID="btnSuscribirse" runat="server" Text="Suscribirse" OnClick="btnSuscribirse_Click" class="btn-suscribirse" />
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
                <script src="js/jquery-3.4.1.min.js"></script>
                <script src="js/bootstrap.js"></script>
                <script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js"></script>
                <script src="js/custom.js"></script>
                <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
            </form>
        </body>
    </html>


