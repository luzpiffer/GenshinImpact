﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="GenshinImpact.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- Basic -->
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<!-- Mobile Metas -->
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
<!-- Site Metas -->
<meta name="keywords" content="" />
<meta name="description" content="" />
<meta name="author" content="" />
<link rel="shortcut icon" href="images/favicon.png" type="image/x-icon" />

<title>
  Inicio
</title>

<!-- slider stylesheet -->
<link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />

<!-- bootstrap core css -->
<link rel="stylesheet" type="text/css" href="css/bootstrap.css" />

<!-- Custom styles for this template -->
<link href="https://fonts.googleapis.com/css2?family=Chewy&display=swap" rel="stylesheet"/>
<link href="css/style.css" rel="stylesheet" />
<!-- responsive style -->
<link href="css/responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="hero_area">
  <!-- header section strats -->
  <header class="header_section">
    <nav class="navbar navbar-expand-lg custom_nav-container ">
      <a class="navbar-brand" href="index.aspx">
        <span class="tituloprincipal">
          Peluches Teyvat
        </span>
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class=""></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav  ">
          <li class="nav-item active">
            <a class="nav-link" href="index.aspx">Inicio <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Tarjetas.aspx">Tienda</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Nosotros.aspx">Nosotros</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Comentarios.aspx">Comentarios</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Contactanos.aspx">Contactános</a>
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
  <!-- end header section -->
  <!-- slider section -->

  <section class="slider_section">
    <div class="slider_container">
        <video autoplay muted loop class="video-background">
            <source src="images/sangonomiya-kokomi-genshin-impact-desktop-wallpaperwaifu-com.mp4" type="video/mp4"/>
            Tu navegador no soporta el video.
        </video>
      <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <div class="carousel-inner">
          <div class="carousel-item active">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-7">
                  <div class="detail-box">
                    <h1>
                      ¡Bienvenidos a nuestra <br/>
                      tienda de peluches!
                    </h1>
                    <p class="info-index">
                      Acá vas a encontrar los peluches más adorables y suaves,
                      cada peluche está hecho con amor y cuidado
                    </p>
                    <a href="Contactanos.aspx">Contactános</a>
                  </div>
                </div>
                <div class="col-md-5 ">               
                </div>
              </div>
            </div>
          </div>
          <div class="carousel-item ">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-7">
                  <div class="detail-box">
                    <h1>
                      ¡Bienvenidos a nuestra <br/>
                      tienda de peluches!
                    </h1>
                    <p class="info-index">
                      Estos peluches son más que suaves amigos; cada uno está hecho con cariño y atención a los detalles. ¡Llévate a casa uno!
                    </p>
                    <a href="Contactanos.aspx">Contactános</a>
                  </div>
                </div>
                <div class="col-md-5 ">
                </div>
              </div>
            </div>
          </div>
          <div class="carousel-item ">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-7">
                  <div class="detail-box">
                    <h1>
                      ¡Bienvenidos a nuestra <br/>
                      tienda de peluches!
                    </h1>
                    <p class="info-index">
                      Nuestros peluches son el compañero perfecto para cualquier aventura,
                      hechos con materiales suaves y un cariño que se siente
                    </p>
                    <a href="Contactanos.aspx">
                      Contactános
                    </a>
                  </div>
                </div>
                <div class="col-md-5 ">
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end slider section -->
</div>
<!-- end hero area -->



<!-- saving section -->

<section class="saving_section ">
  <div class="box">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-6">
          <div class="img-box">
            <img src="images/Kokomi Genshin GIF - Kokomi Genshin Genshin Impact - Discover & Share GIFs.gif" alt=""/>
          </div>
        </div>
        <div class="col-lg-6">
          <div class="detail-box">
            <div class="heading_container">
              <h2 class="peluchesperandote">
                ¡Peluches exclusivos esperándote! <br/>
              </h2>
            </div>
            <p>
              Lleva a casa la ternura de Teyvat. Diseños únicos, edición limitada, y materiales extra suaves. ¡No te quedes sin el tuyo! ପ(๑•ᴗ•๑)ଓ ♡
            </p>
            <div class="btn-box">
              <a href="Tarjetas.aspx" class="btn1">
                COMPRAR
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

<!-- end saving section -->

<!-- client section -->
<section class="client_section layout_padding">
  <div class="container">
    <div class="heading_container heading_center">

    </div>
  </div>
  <div class="container px-0">
    <div id="customCarousel2" class="carousel  carousel-fade" data-ride="carousel">
      <div class="carousel-inner">
        <div class="carousel-item active">
          <div class="box">
            <div class="client_info">
              <div class="client_name">
                <h5>
                  Mariana J.
                </h5>
                <h6>
                  Córdoba, Argentina
                </h6>
              </div>
              <i class="fa fa-quote-left" aria-hidden="true"></i>
            </div>
            <p>
              ¡Estoy encantada con mi compra! El peluche de Paimon es aún más adorable en persona. La atención al cliente fue excepcional y la entrega súper rápida. Definitivamente volveré a comprar. ¡Gracias, Peluches Teyvat!
            </p>
          </div>
        </div>
        <div class="carousel-item">
          <div class="box">
            <div class="client_info">
              <div class="client_name">
                <h5>
                  Ignacio N.
                </h5>
                <h6>
                  Montevideo, Uruguay
                </h6>
              </div>
              <i class="fa fa-quote-left" aria-hidden="true"></i>
            </div>
            <p>
              Estaba dudando si comprar el peluche por el precio barato que está, no le tenia fe pero al final me decidí por comprarlo y me impresionó lo bien hecho que está. Muy recomendado, me enamoré del peluche de Diluc
            </p>
          </div>
        </div>
        <div class="carousel-item">
          <div class="box">
            <div class="client_info">
              <div class="client_name">
                <h5>
                  Sofía T.
                </h5>
                <h6>
                  Buenos Aires, Argentina
                </h6>
              </div>
              <i class="fa fa-quote-left" aria-hidden="true"></i>
            </div>
            <p>
              Me encantó mi experiencia de compra en Peluches Teyvat. El peluche de Zhongli es simplemente perfecto, y llegó en perfectas condiciones. La atención fue increíble. ¡No puedo esperar a volver a comprar más!
            </p>
          </div>
        </div>
      </div>
      <div class="carousel_btn-box">
        <a class="carousel-control-prev" href="#customCarousel2" role="button" data-slide="prev">
          <i class="fa fa-angle-left" aria-hidden="true"></i>
          <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#customCarousel2" role="button" data-slide="next">
          <i class="fa fa-angle-right" aria-hidden="true"></i>
          <span class="sr-only">Next</span>
        </a>
      </div>
    </div>
  </div>
</section>
<!-- end client section -->

<!-- info section -->

<section class="info_section layout_padding2-top">
  <div class="social_container">
    <div class="social_box">
      <a href="https://www.instagram.com/genshinimpact?igsh=ZXVxbXlreWQ2Y2F3">
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
            <form action="your-server-endpoint" method="post">
              <asp:TextBox ID="txtEmail" runat="server" Placeholder="Escribí tu email" CssClass="input-email" />
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


<!-- end info section -->


<script src="js/jquery-3.4.1.min.js"></script>
<script src="js/bootstrap.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js"></script>
<script src="js/custom.js"></script>
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    </form>
</body>
</html>
