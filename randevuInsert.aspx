<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="randevuInsert.aspx.cs" Inherits="Sekreter_Randevu_Sistemi.randevuEkle" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>
    Hastane Randevu Sistemi
  </title>
  <!-- Favicon -->
  <link href="../assets/img/brand/favicon.png" rel="icon" type="image/png">
  <!-- Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet">
  <!-- Icons -->
  <link href="../assets/js/plugins/nucleo/css/nucleo.css" rel="stylesheet" />
  <link href="../assets/js/plugins/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet" />
  <!-- CSS Files -->
  <link href="../assets/css/argon-dashboard.css?v=1.1.0" rel="stylesheet" />

</head>

<body class="bg-default">
   <nav class="navbar navbar-vertical fixed-left navbar-expand-md navbar-light bg-white" id="sidenav-main">
    <div class="container-fluid">
      <!-- Toggler -->
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#sidenav-collapse-main" aria-controls="sidenav-main" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <!-- Brand -->
      <a class="navbar-brand pt-0" href="../checkpassword.aspx">
                  <img src="../assets/img/brand/unnamed.png" class="navbar-brand-img" alt="...">
      </a>
      <!-- User -->
      <!-- Collapse -->
      <div class="collapse navbar-collapse" id="sidenav-collapse-main">
        <!-- Form -->
        <form class="mt-4 mb-3 d-md-none">
          <div class="input-group input-group-rounded input-group-merge">
            <input type="search" class="form-control form-control-rounded form-control-prepended" placeholder="Search" aria-label="Search">
            <div class="input-group-prepend">
              <div class="input-group-text">
                <span class="fa fa-search"></span>
              </div>
            </div>
          </div>
        </form>
        <!-- Navigation -->
                  <!-- Divider -->
        <hr class="my-3">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link " href="randevuInsert.aspx">
              <i class="ni ni-planet text-blue"></i> Randevu Ekle
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link " href="randevuSearch.aspx">
              <i class="ni ni ni-world-2 text-orange"></i> Randevu Bul/Düzelt/Sil
            </a>
          </li>
        </ul>
                  <!-- Divider -->
        <hr class="my-3">
      </div>
    </div>
  </nav>
  <div class="main-content">
    <!-- Navbar -->
    <nav class="navbar navbar-top navbar-horizontal navbar-expand-md navbar-dark">
      <div class="container px-4">
        <a class="navbar-brand" href="../checkpassword.aspx">
          <img src="../assets/img/brand/unnamed.png" />
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar-collapse-main" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbar-collapse-main">
          <!-- Collapse header -->
          <div class="navbar-collapse-header d-md-none">
            <div class="row">
              <div class="col-6 collapse-brand">
                <a href="../checkpassword.html">
                  <img src="../assets/img/brand/blue.png">
                </a>
              </div>
              <div class="col-6 collapse-close">
                <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbar-collapse-main" aria-controls="sidenav-main" aria-expanded="false" aria-label="Toggle sidenav">
                  <span></span>
                  <span></span>
                </button>
              </div>
            </div>
          </div>
          <!-- Navbar items -->
        </div>
      </div>
    </nav>
    <!-- Header -->
    <div class="header bg-gradient-primary py-7 py-lg-8">
      <div class="container">
        <div class="header-body text-center mb-7">
          <div class="row justify-content-center">
            <div class="col-lg-5 col-md-6">
              <h1 class="text-white">Hastane Randevu Sistemi</h1>
            </div>
          </div>
        </div>
      </div>
      <div class="separator separator-bottom separator-skew zindex-100">
        <svg x="0" y="0" viewBox="0 0 2560 100" preserveAspectRatio="none" version="1.1" xmlns="http://www.w3.org/2000/svg">
          <polygon class="fill-default" points="2560 0 2560 100 0 100"></polygon>
        </svg>
      </div>
    </div>
    <!-- Page content -->
    <div class="container mt--8 pb-5">
      <div class="row justify-content-center">
        <div class="col-lg-8 col-md-7">
          <div class="card bg-secondary shadow border-0">
            <div class="card-body px-lg-5 py-lg-5">
              <form id="form1" method="post" role="form" runat="server">
                <div class="form-group mb-3">
                  <div class="input-group input-group-alternative">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="ni ni-circle-08"></i></span>
                    </div>
                    <input id="TextBox1" class="form-control" placeholder="TC Kimlik No" type="text" runat="server">
                  </div>
                </div>
            <br />
                <div class="form-group mb-3">
                  <div class="input-group input-group-alternative">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="ni ni-circle-08"></i></span>
                    </div>
                    <input id="TextBox2" class="form-control" placeholder="Adı" type="text" runat="server">
                  </div>
                </div>
            <br />
                <div class="form-group mb-3">
                  <div class="input-group input-group-alternative">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="ni ni-circle-08"></i></span>
                    </div>
                    <input id="TextBox3" class="form-control" placeholder="Soyadı" type="text" runat="server">
                  </div>
                </div>
            <br />
                 <div class="form-group mb-3">
                    <div class="text-center">
                         <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </div>
                  </div>
            <br />
                 <div class="form-group mb-3">
                    <div class="text-center">
                         <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                     </div>
                 </div>
            <br />
                 <div class="form-group">
                    <div class="input-group input-group-alternative">
                       <div class="input-group-prepend">
                         <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                     </div>
                        <asp:TextBox id="TextBox5" Cssclass="form-control" runat="server" placeholder="Tarih seçin!" AutoPostBack="true" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                   </div>
                </div>
            <br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="spaced" align="center">
                </asp:RadioButtonList> 
            <br />
                  <div class="text-center">
                       <button id="Button" type="submit" class="btn btn-primary my-4" runat="server" onserverclick="Button_Click">Ekle</button>     
                  </div>
             </form>
            </div>
          </div>
        </div>
      </div>
    </div>
<!-- Core -->
<script src="../assets/js/plugins/jquery/dist/jquery.min.js"></script>
<script src="../assets/js/plugins/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
<!--  JS -->
<script src="../assets/js/argon-dashboard.min.js"></script>
<!-- Bootstrap DatePicker -->
<script src="assets/js/bootstrap-datepicker.js" type="text/javascript"></script>  

<script type="text/javascript">
    $(function () {
        $('[id*=TextBox5]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd.mm.yyyy",
            language: "tr",
            autoclose:true,
        });
    });
</script>


 <script>
    window.TrackJS &&
      TrackJS.install({
        token: "ee6fab19c5a04ac1a32a645abde4613a",
        application: "argon-dashboard-free"
      });
  </script>
    </div>
</body>

</html>
