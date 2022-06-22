<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAPIApplication1._Default" async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Button ID="Button1" runat="server" Text="Get Request" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Post request" OnClick="Button2_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    

    <br />
    <br />
    <div>
    <asp:ListBox ID="ListBox1" runat="server"  Width="1500px" Height="300px" Rows="10" ></asp:ListBox>
        </div>
</asp:Content>
