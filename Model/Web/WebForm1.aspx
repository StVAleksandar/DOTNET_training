<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>


    <%--    <asp:DropDownList ID="DropDownList1" runat="server" Width="136px"></asp:DropDownList>

    <%--    <asp:ListBox ID="ListBox1" runat="server" Height="178px" Width="183px"></asp:ListBox>
    <asp:ListBox ID="ListBox2" runat="server" Height="177px" Width="203px"></asp:ListBox>--%>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Width="58px" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


</asp:Content>

