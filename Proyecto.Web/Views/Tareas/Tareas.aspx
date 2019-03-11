<%@ Page Title="" Language="C#" MasterPageFile="~/Resoutces/Template/Template.Master.Master" AutoEventWireup="true" CodeBehind="Tareas.aspx.cs" Inherits="Proyecto.Web.Views.Tareas.Tareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedor" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="mx-auto mt-1">
        <h1>Crear Tarea</h1>

        <asp:TextBox runat="server" ID="txtId" Style="display: none"></asp:TextBox>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblTituloTarea" Text="Titulo tarea:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTitulTarea" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="twmTitularTarea" runat="server"
                        TargetControlID="txtTitulTarea"
                        WatermarkText="Titular tarea" />
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblAsunto" Text="Asunto:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="twmAsunto" runat="server"
                        TargetControlID="txtAsunto"
                        WatermarkText="Asunto" />
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblFechaDeVencimiento" Text="Fecha de vencimiento:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaDeVencimiento" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="twmFechaVencimiento" runat="server"
                        TargetControlID="txtFechaDeVencimiento"
                        WatermarkText="Fecha de Vencimiento" />
                    <ajaxToolkit:CalendarExtender ID="ceFechaVencimiento" runat="server"
                        TargetControlID="txtFechaDeVencimiento" Format="yyyy-MM-dd" />
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblContacto" Text="Contacto:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtContacto" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="twmContacto" runat="server"
                        TargetControlID="txtContacto"
                        WatermarkText="Contacto" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblCuenta" Text="Cuenta:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCuenta" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxwatermarkExtender1" runat="server"
                        TargetControlID="txtCuenta"
                        WatermarkText="Cuenta" />
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
                    <ajaxToolkit:TextBoxWatermarkExtender ID="twmDescripcion" runat="server"
                        TargetControlID="txtDescripcion"
                        WatermarkText="Descripcion" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" OnClick="BtnGuardar_Click" />
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" OnClick="BtnCancelar_Click" />
                </div>
            </div>
        </div>

        <br />
        <h3>Resultados</h3>

        <div class="form-group">
            <div class="from-row">
                <div class="col-md-12">
                    <asp:GridView
                        runat="server"
                        ID="gvDatos"
                        AutoGenerateColumns="False"
                        EmptyDataText="No se encontraron registros"
                        CellPadding="4"
                        ForeColor="#333333"
                        GridLines="None"
                        OnRowCommand="GvDatos_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblId" Text='<%# Bind("id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Titular" DataField="titular" />
                            <asp:BoundField HeaderText="Asunto" DataField="asunto" />
                            <asp:BoundField HeaderText="Fecha de Vencimiento" DataField="fechaVencimiento" />
                            <asp:BoundField HeaderText="Contacto" DataField="contacto" />
                            <asp:BoundField HeaderText="Cuenta" DataField="cuenta" />
                            <asp:BoundField HeaderText="Estado" DataField="estado.description" />
                            <asp:BoundField HeaderText="Prioridad" DataField="prioridad.description" />
                            <asp:BoundField HeaderText="Envia Mensaje" DataField="enviaMensaje" />
                            <asp:BoundField HeaderText="Repetir" DataField="repetir" />
                            <asp:BoundField HeaderText="Tarea Descripcion" DataField="tareaDescripcion" />
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("estado.id") %>'></asp:Label>
                                    <asp:Label runat="server" ID="lblPrioridad" Text='<%# Bind("prioridad.id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Opciones">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnEditar" CssClass="btn btn-info"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        CommandName="Editar">
                                                <i class="fa fa-pen"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        CommandName="Eliminar">
                                                <i class="fa fa-trash"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
