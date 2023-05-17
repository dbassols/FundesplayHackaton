<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="David_Bassols_Hackaton_Backend._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div role="row">
    <asp:Label ID="Label1" runat="server" Text="Label" style="color:darkblue;font-size:30px;"><Strong>Has logrado hacer Login</Strong></asp:Label>
    </div>
    <br />
    <div role="row">
    <asp:Label ID="Label2" runat="server" Text="Usuario " style="color:darkblue;font-size:20px;"> </asp:Label><asp:Label ID="UserText" runat="server" Text=" " style="color:darkblue;font-size:20px;"></asp:Label><asp:Label ID="Label4" runat="server" Text=" Bienvenido" style="color:darkblue;font-size:20px;"></asp:Label>
    </div>
    <div style="height: 21px">
    </div>

</asp:Content>
