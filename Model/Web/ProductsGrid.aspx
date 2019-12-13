<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsGrid.aspx.cs" Inherits="Web.ProductsGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="ProductsGridView" AutoGenerateColumns="False" BackColor="White" CellPadding="5">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="productID" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="productName" HeaderText="Product Name" />
            <asp:BoundField DataField="unitPrice" HeaderText="Price" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='ProductDetails.aspx?id=<%# Eval("productID") %>'>Details...</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#333333" ForeColor="White" Height="38px" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>

