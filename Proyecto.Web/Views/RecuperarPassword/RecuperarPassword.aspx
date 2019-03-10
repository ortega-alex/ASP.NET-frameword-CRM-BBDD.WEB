<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="Proyecto.Web.Views.RecuperarPassword.RecuperarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>recuperar password</title>

    <!-- Custom fonts for this template-->
    <link href="../../Public/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template-->
    <link href="../../Public/css/sb-admin.css" rel="stylesheet" />

    <!--Sweet Alert-->
    <link href="../../Public/bootstrap-sweetalert/dist/sweetalert.css" rel="stylesheet" />

    <!-- Bootstrap core JavaScript-->
    <script src="../../Public/vendor/jquery/jquery.min.js"></script>
    <script src="../../Public/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../../Public/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!--Sweet Alert javascript-->
    <script src="../../Public/bootstrap-sweetalert/dist/sweetalert.min.js"></script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
      <div class="container">
          <div class="card card-login mx-auto mt-5">
              <div class="card-header">
                  Recuperar password
              </div>
              <div class="card-body">
                  <div class="text-center mt-4 mb-5">
                      <h4>Olbido password?</h4>
                      <p>Ingese su direccion de correo y nosostros enviaremos las instrucciones para la recuperacion de su password</p>
                  </div>
                  <div class="form-group">
                      <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control "></asp:TextBox>
                  </div>
                  <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-primary btn-block" Text="Recuperar password" OnClick="btnAceptar_Click" />
                  <div class="text-center">
                      <a class="d-block small mt-3" href="../Login/Login.aspx">Login</a>
                  </div>
              </div>
          </div>
      </div>
    </form>
</body>
</html>
