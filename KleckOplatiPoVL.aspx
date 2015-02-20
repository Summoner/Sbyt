<%@ Page Title="Оплаты по ВЛ Клецкий РЭС" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="KleckOplatiPoVL.aspx.cs" Inherits="Sbyt.KleckOplatiPoVL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2 style="color:Navy; text-align:center">Оплаты по ВЛ Клецкий РЭС:</h2>  



<div id = "balancePoTpTable">
<h2 style="color:Navy;"><asp:Label ID="PromMonthYearLbl" runat="server" ></asp:Label></h2>

<asp:GridView ID="PromGridView" 
              runat="server" 
              BackColor="White" 
              BorderColor="White"  
              BorderStyle="Ridge" 
              BorderWidth="2px" 
              CellPadding="3" 
              CellSpacing="1" 
              EnableModelValidation="True"  
              GridLines="None" 
              AutoGenerateColumns="false" 
              AllowSorting="false" 
              OnSorting="PromGridView_OnSorting" 
              ShowFooter="true" 
              OnRowDataBound="PromGridView_RowDataBound">
             <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
             <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
             <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
             <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                              
</asp:GridView>
     <br />
      <asp:LinkButton ID="ConvertToExcelLinkButtonProm" 
        Text="Результат в Excel"  OnClick="PromHyper" runat="server" 
        BorderColor="#009900" Font-Bold="True" Font-Italic="False" 
        Font-Strikeout="False" Font-Underline="False"></asp:LinkButton>
      <br />
      <br />
       
        <h2 style="color:Navy;"><asp:Label ID="BytMonthYearLbl" runat="server" ></asp:Label></h2>

        <asp:GridView 
        ID="BytGridView" 
        runat="server" 
        BackColor="White" 
        BorderColor="White"  
        BorderStyle="Ridge" 
        BorderWidth="2px" 
        CellPadding="3" 
        CellSpacing="1" 
        EnableModelValidation="True"  
        GridLines="None" 
        AutoGenerateColumns="false"  
        AllowSorting="false" 
        OnSorting="BytGridView_OnSorting" 
        ShowFooter="true" 
        OnRowDataBound="BytGridView_RowDataBound">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                              
    </asp:GridView>
     <br />
     <asp:LinkButton ID="ConvertToExcelLinkButtonByt" Text="Результат в Excel"  
        OnClick="BytHyper" runat="server" BorderColor="#009900" Font-Bold="True" 
        Font-Italic="False" Font-Overline="False"></asp:LinkButton>
     <br />


     </div>

<div id="MyLabBALANCEPOTPADMIN">
    <asp:Label runat="server" ID="MyLabel" BackColor="AliceBlue" BorderColor="Desktop"
     BorderStyle="Solid" Font-Bold="true" ForeColor="Red"></asp:Label>
</div>
</asp:Content>
