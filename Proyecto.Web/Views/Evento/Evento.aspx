<%@ Page Title="" Language="C#" MasterPageFile="~/Resoutces/Template/Template.Master.Master" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="Proyecto.Web.Views.Evento.Evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenedor" runat="server">
    <div class="container">
        <div class="card mx-auto">
            <div class="card-header">
                <h1> Eventos </h1>
            </div>
            <div class="card-body">

                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-12">
                            <asp:GridView 
                                runat="server"
                                ID="gvwDatos"
                                EmptyDataText="No se encotro informacion"
                                AutoGenerateColumns="False" 
                                CellPadding="4" 
                                ForeColor="#333333" 
                                GridLines="None" Width="960px"
                                >
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblId" Text='<%# Bind("Id") %>'></asp:Label>
                                            <asp:Label runat="server" ID="Label1" Text='<%# Bind("Relacionado.Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />                                    
                                    <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion" />
                                    <asp:BoundField HeaderText="Todo Dia" DataField="TodoDia" />
                                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" />                                    
                                    <asp:BoundField HeaderText="Relacionado" DataField="Relacionado.Descripcion" />
                                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
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
        </div>
    </div>    
</asp:Content>
