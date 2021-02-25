<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="randevuSearch.aspx.cs" Inherits="Sekreter_Randevu_Sistemi.randevuSearch" %>

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
        <div class="col-xl-13 col-md-7">
          <div class="card bg-secondary shadow border-0">
            <div class="card-body px-lg-4 py-lg-5">
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
                            <div class="text-center">
            <button id="Button" type="submit" class="btn btn-primary my-4" runat="server" onserverclick="Button_Click">Randevu Bul</button>     

                            </div>
                  <br />
                                                                                <div style="OVERFLOW: auto; HEIGHT:600px">
                  <div class="table-responsive">

    <asp:GridView ID="GridView1" class="table align-items-center table-flush" HeaderStyle-CssClass="thead-dark" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
                        <asp:TemplateField HeaderText="Randevu No">  
                            <ItemTemplate>  
                                                            <div class="text-center">
                              <h2>  <asp:Label CssClass="mb-0 text-sm" ID="randevuno" runat="server" Text='<%#Eval("RandevuNo")%>' CausesValidation="false" CommandName="Update"> </asp:Label>  </h2>
                                                        </div>
                                                                </ItemTemplate>  
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="TC Kimlik No">  
                            <ItemTemplate>  
                                 <div class="text-center">
                                <asp:Label CssClass="mb-0 text-sm" ID="tc" runat="server" Text='<%#Eval("TC")%>'  CausesValidation="false" CommandName="Update"> </asp:Label>  
                           </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="Adi">  
                            <ItemTemplate>  
                                 <div class="text-center">
                             <asp:Label CssClass="mb-0 text-sm" ID="adi" runat="server" Text='<%#Eval("Adi")%>'  CausesValidation="false" CommandName="Update"> </asp:Label> 
                            </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="Soyadi">  
                            <ItemTemplate>  
                                 <div class="text-center">
                              <asp:Label CssClass="mb-0 text-sm" ID="soyadi" runat="server" Text='<%#Eval("Soyadi")%>'  CausesValidation="false" CommandName="Update"> </asp:Label>  
                        </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="Klinik Adi">  
                            <ItemTemplate>  
                                 <div class="text-center">
                                <asp:Label CssClass="mb-0 text-sm" ID="klinikadi" runat="server" Text='<%#Eval("KlinikAdi")%>'  CausesValidation="false" CommandName="Update"> </asp:Label> 
                         </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="Doktor Adi">  
                            <ItemTemplate>  
                                 <div class="text-center">
                               <asp:Label CssClass="mb-0 text-sm" ID="doktoradi" runat="server" Text='<%#Eval("Doktor")%>'  CausesValidation="false" CommandName="Update"> </asp:Label> 
                           </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 

                        
                        <asp:TemplateField HeaderText="Tarih">  
                            <ItemTemplate>  
                                 <div class="text-center">
                           <asp:Label CssClass="mb-0 text-sm" ID="tarih" runat="server" Text='<%#Convert.ToDateTime(Eval("Tarih")).ToShortDateString()%>'  CausesValidation="false" CommandName="Update"> </asp:Label>
                           </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 
                        

                        <asp:TemplateField HeaderText="Saat">
                            <ItemTemplate>  
                                 <div class="text-center">
                                <asp:Label CssClass="mb-0 text-sm" ID="saat" runat="server" Text='<%#Eval("Saat")%>'  CausesValidation="false" CommandName="Update"> </asp:Label>  </h4>
                           </div>
                                     </ItemTemplate>  
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="Güncelle">  
                            <ItemTemplate>  
                                                                                            <div class="text-center">
                                <asp:LinkButton CssClass="btn btn-warning my-4" ID="asd" runat="server" Text='Güncelle'  CausesValidation="false" CommandName="Update"> </asp:LinkButton>  
                           </div>
                                                                                                </ItemTemplate>  
                        </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Sil">  
                            <ItemTemplate>  
                                                                                            <div class="text-center">
                                <asp:LinkButton CssClass="btn btn-danger my-4" ID="dsa" runat="server" Text='Sil' AutoPostBack="true" CausesValidation="false" CommandName="Delete"> </asp:LinkButton>  
                           </div>
                                                                                                </ItemTemplate>  
                        </asp:TemplateField> 
                    </Columns>  
                </asp:GridView>
                      </div>
                      </div>
               </form>
              </div>
            </div>
          </div>
          </div>
        </div>
      </div>
  <script>
    window.TrackJS &&
      TrackJS.install({
        token: "ee6fab19c5a04ac1a32a645abde4613a",
        application: "argon-dashboard-free"
      });
  </script>
</body>

</html>