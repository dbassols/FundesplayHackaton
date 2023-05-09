<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="David_Bassols_Hackaton_Backend._Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <div role="row">
    <asp:Label ID="Label1" runat="server" Text="Label" style="color:darkblue;font-size:40px;"><Strong>Hackaton Backend Register</Strong></asp:Label>
    </div>
    <div role="row">
    <asp:Label ID="Label2" runat="server" Text="Label" style="color:darkblue;font-size:20px;">Crear nuevo usuario</asp:Label>
    </div>
    <div style="height: 21px">
    </div>
    <div role="row">
        <table style="width: 100%;">
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Login"></asp:Label></td>
                <td><asp:TextBox ID="RegisterUser" runat="server"></asp:TextBox></td>
             
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="PasswordUser" TextMode="Password" runat="server"></asp:TextBox></td>
           
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="Login" runat="server" Text="Crear Usuario" OnClick="CreateUser_Click" />
                    <asp:Label ID="Mensage" runat="server" Text=" "></asp:Label>
                </td>
              
            </tr>
        </table>
   </div>
    
</asp:Content>
