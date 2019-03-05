<%@ Page Title="" Language="C#" MasterPageFile="~/Resoutces/Template/Template.Master.Master" AutoEventWireup="true" CodeBehind="PosiblesClientes.aspx.cs" Inherits="Proyecto.Web.Views.PosiblesClientes.PosiblesClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedor" runat="server">
    <div class="mx-auto mt-5">
        <h1>Posibles Clientes</h1>

        <asp:TextBox runat="server" ID="txtId" style="display:none"></asp:TextBox>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblNombre" Text="Nombre:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblApellido" Text="Apellido:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblCorreo" Text="Correo:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblTelefono" Text="Telefono:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblDireccion" Text="Direccion:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click"/>
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>

        <br />
        <h3>Resultados</h3>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12" style="overflow: auto">
                    <asp:GridView
                        runat="server"
                        ID="gvwDatos"
                        Width="100%"
                        AutoGenerateColumns="False"
                        EmptyDataText="No se encontraron registros" 
                        CellPadding="4" 
                        ForeColor="#333333" 
                        GridLines="None"
                        OnRowCommand="gvwDatos_RowCommand"
                        DataKeyNames ="id">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="id" Visible="false" />
                            <%-- representacion de datos en controlles web --%>
                            <asp:TemplateField HeaderText="Nombres">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNombres" Text='<%# Bind("nombres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- representacion de datos en celdas --%>
                            <asp:BoundField HeaderText="Apellidos" DataField="apellidos" />
                            <asp:BoundField HeaderText="Correo" DataField="correo" />
                            <asp:BoundField HeaderText="Telefono" DataField="telefono" />
                            <asp:BoundField HeaderText="Direccion" DataField="direccion" />

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
