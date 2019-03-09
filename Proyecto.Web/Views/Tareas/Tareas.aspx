<%@ Page Title="" Language="C#" MasterPageFile="~/Resoutces/Template/Template.Master.Master" AutoEventWireup="true" CodeBehind="Tareas.aspx.cs" Inherits="Proyecto.Web.Views.Tareas.Tareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedor" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="card mx-auto">
            <div class="card-header text-center">
                <h1>Crear Tarea</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblTituloTarea" Text="Titulo tarea:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTitulTarea" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="twmTitularTarea" runat="server"
                                targetcontrolid="txtTitulTarea"
                                watermarktext="Titular tarea" />
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblAsunto" Text="Asunto:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="twmAsunto" runat="server"
                                targetcontrolid="txtAsunto"
                                watermarktext="Asunto" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblFechaDeVencimiento" Text="Fecha de vencimiento:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFechaDeVencimiento" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="twmFechaVencimiento" runat="server"
                                targetcontrolid="txtFechaDeVencimiento"
                                watermarktext="Fecha de Vencimiento" />
                            <ajaxtoolkit:calendarextender id="ceFechaVencimiento" runat="server"
                                targetcontrolid="txtFechaDeVencimiento" format="yyyy-MM-dd" />
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblContacto" Text="Contacto:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtContacto" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="twmContacto" runat="server"
                                targetcontrolid="txtContacto"
                                watermarktext="Contacto" />
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblCuenta" Text="Cuenta:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCuenta" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="TextBoxwatermarkExtender1" runat="server"
                                targetcontrolid="txtCuenta"
                                watermarktext="Cuenta" />
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblEstado" Text="Estado:"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblPrioridad" Text="Prioridad:"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddlPrioridad" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblEnviarMensaje" Text="Enviar Mensaje:">
                                <asp:CheckBox runat="server" ID="chkEnviarMensaje" CssClass="form-control"></asp:CheckBox>
                            </asp:Label>
                        </div>
                    </div>
                </div>

                 <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblRepetir" Text="Repetir:">
                                <asp:CheckBox runat="server" ID="chkRepetir" CssClass="form-control"></asp:CheckBox>
                            </asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblDescricion" Text="Descripcion:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="twmDescripcion" runat="server"
                                targetcontrolid="txtDescripcion"
                                watermarktext="Descripcion" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
