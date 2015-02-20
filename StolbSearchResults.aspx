<%@ Page Title="Результаты поиска" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="StolbSearchResults.aspx.cs" Inherits="Sbyt.StolbSearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2 style="color:Navy; text-align:center">Результаты поиска по Столбцовскому РЭС:</h2>  




<div id = "balancePoTpTable">
<h2 style="color:Navy;"><asp:Label ID="PromMonthYearLbl" runat="server" ></asp:Label></h2>
<asp:GridView ID="PromGridView" runat="server" BackColor="White" BorderColor="White"  
        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
        EnableModelValidation="True"  GridLines="None" AutoGenerateColumns="true" AllowSorting="true" OnSorting="PromGridView_OnSorting" 
        ShowFooter="true" OnRowDataBound="PromGridView_RowDataBound">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
        
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                              
    </asp:GridView>
     <br />
      <br />
       
        <h2 style="color:Navy;"><asp:Label ID="BytMonthYearLbl" runat="server" ></asp:Label></h2>
        <asp:GridView ID="BytGridView" runat="server" BackColor="White" BorderColor="White"  
        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
        EnableModelValidation="True"  GridLines="None" AutoGenerateColumns="true" AllowSorting="true" OnSorting="BytGridView_OnSorting" 
        ShowFooter="true" OnRowDataBound="BytGridView_RowDataBound">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
        
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                              
    </asp:GridView>
     <br />
      <br />


     </div>
</asp:Content>
