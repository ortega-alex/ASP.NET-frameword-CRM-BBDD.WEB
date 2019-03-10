<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Web.Views.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>SB Admin - Login</title>

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

    <div class="container">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">Login</div>
            <div class="card-body">
                <form id="form" runat="server">
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox runat="server" ID="txtEmal" CssClass="form-control"></asp:TextBox>
                            <asp:Label Text="Email" runat="server" ID="lblEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                            <asp:Label Text="Password" runat="server" ID="lblPass" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="checkbox">
                            <asp:CheckBox ID="chkRecordar" runat="server" Text="Recordar Password" />
                        </div>
                    </div>
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary btn-block" Text="Aceptar" OnClick="btnAceptar_Click" />
                </form>
                <div class="text-center">
                    <a class="d-block small mt-3" href="#">Register an Account</a>
                    <a class="d-block small" href="../RecuperarPassword/RecuperarPassword.aspx">Forgot Password?</a>
                </div>
            </div>
    </div>
    </div>
</body>
</html>
