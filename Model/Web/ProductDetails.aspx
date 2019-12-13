<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Web.ProductDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="ProductDetailsGridView" AutoGenerateColumns="False" CellPadding="5">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="productID" HeaderText="ID" />
            <asp:BoundField DataField="productName" HeaderText="Product Name" />
            <asp:BoundField DataField="quantityPerUnit" HeaderText="Quantity Per Unit" />
            <asp:BoundField DataField="unitPrice" HeaderText="Price" />
            <asp:BoundField DataField="unitsInStock" HeaderText="In Stock" />
        </Columns>
        <HeaderStyle BackColor="Black" ForeColor="White" Height="38px" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Add to Cart" OnClick="Button1_Click" />
</asp:Content>

