<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Proyecto.Web.Views.Registro.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Registro</title>

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
            <div class="card-header">
                Registro
            </div>
            <div class="card-body">
                <form id="form1" runat="server">
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-12">
                                <asp:Label runat="server" ID="lblUsername" Text="Username:"> </asp:Label>
                                <asp:TextBox runat="server" ID="txtUsername" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtUsername" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-12">
                                <asp:Label runat="server" ID="lblPass" Text="Password:"> </asp:Label>
                                <asp:TextBox runat="server" ID="txtPass" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtPass" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-12">
                                <asp:Label runat="server" ID="lblConfir" Text="Confirmar Password:"> </asp:Label>
                                <asp:TextBox runat="server" ID="txtConfir" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConfit" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtConfir" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvConfit" runat="server" ErrorMessage="Password no conincide" ControlToValidate="txtConfir" ControlToCompare="txtPass" ForeColor="Red"></asp:CompareValidator>
                             </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-12">
                                <asp:Label runat="server" ID="lblImg" Text="Imagen:"> </asp:Label>
                                <asp:FileUpload runat="server" ID="fuImg" CssClass="form-control"></asp:FileUpload>
                                <asp:RequiredFieldValidator ID="rfvImg" runat="server" ErrorMessage="Campo requerido" ControlToValidate="fuImg" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                   <asp:Button runat="server" ID="btnCrear" Text="Crear Cuenta" CssClass="btn btn-primary btn-block" ValidationGroup="ValidarCuenta" OnClick="btnCrear_Click" />                          
                    <div class="text-center">
                      <a class="d-block small mt-3" href="../Login/Login.aspx">Login</a>
                  </div>
                </form>
            </div>
        </div>
    </div>

</body>
</html>
