<%@ Page Title="Лог файл всей программы" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="LogViewProgramm.aspx.cs" Inherits="Sbyt.LogViewProgramm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:GridView runat="server" ID="logRead"  BackColor="White" BorderColor="White" 
         BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
         EnableModelValidation="True" GridLines="None" >
                  <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
         <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
         <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
         <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
         <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"  />

</asp:GridView>


</asp:Content>
